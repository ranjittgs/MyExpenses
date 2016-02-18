using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Security.Cryptography.Certificates;
using Windows.Web.Http.Filters;

namespace MyExpenses.WebAccessLayer
{
    public delegate void WebDataAccessEventHandler(object sender, WebDataAccessEventArgs e);

    public class WebProvider
    {
        public event WebDataAccessEventHandler OnWebDataAccessEvent;

        public WebProvider()
        {

        }

        public bool DoGetRequest(String Url)
        {
            return DoGetRequest(Url, new Object());
        }

        public bool DoGetRequest(String Url, Object Payload)
        {
            return DoGetRequest(Url, null, Payload);
        }

        public bool DoGetRequest(String Url, Dictionary<String, string> parameters)
        {
            return SendRequestAndGetResponse(Url, parameters, null, "GET");
        }

        public bool DoGetRequest(String Url, Dictionary<String, string> parameters, Object Payload)
        {
            return SendRequestAndGetResponse(Url, parameters, null, "GET", Payload);
        }

        public bool DoPostRequest(String Url)
        {
            return DoPostRequest(Url, new Object());
        }

        public bool DoPostRequest(String Url, Object Payload)
        {
            return DoPostRequest(Url, null, Payload);
        }

        public bool DoPostRequest(String Url, Dictionary<String, string> parameters)
        {
            return DoPostRequest(Url, parameters, new Object());
        }

        public bool DoPostRequest(String Url, Dictionary<String, string> parameters, Object Payload)
        {
            return DoPostRequest(Url, parameters, null, Payload);
        }

        public bool DoPostRequest(String Url, Dictionary<String, string> parameters, string body)
        {
            return SendRequestAndGetResponse(Url, parameters, body, "POST");
        }

        public bool DoPostRequestForPhotoUpload(String Url, byte[] bytes, Object Payload)
        {
            return SendRequestAndGetResponse(Url, "POST", bytes, Payload);
        }

        private bool SendRequestAndGetResponse(string reqUrl, string Method, byte[] bytes, Object Payload)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(reqUrl);
            request.Method = Method;
            request.ContentType = "image/jpeg";
            request.BeginGetRequestStream(new AsyncCallback(GetHttpWebRequestStreamCallbackForPhotoUpload), new Object[] { request, bytes, Payload });
            return true;
        }
        public bool DoPostRequest(String Url, Dictionary<String, string> parameters, string body, Object Payload)
        {
            return SendRequestAndGetResponse(Url, parameters, body, "POST", Payload);
        }
        public bool SendRequestAndGetResponse(String Url, Dictionary<String, string> parameters, string body, string Method)
        {
            return SendRequestAndGetResponse(Url, parameters, body, Method, null);
        }
        Timer timer = null;
        private TimeSpan _timeout = TimeSpan.FromSeconds(100);
        public TimeSpan Timeout
        {
            set
            {
                _timeout = value;
            }
            get
            {
                return _timeout;
            }
        }
        public bool SendRequestAndGetResponse(String Url, Dictionary<String, string> parameters, string body, string Method, Object payload)
        {
            string reqUrl = Url;

            HttpWebRequest request = HttpWebRequest.CreateHttp(reqUrl);
            request.Method = Method;
            if (parameters != null && parameters.Count > 0)
            {
                request.Headers[parameters.Keys.FirstOrDefault()] = parameters.Values.FirstOrDefault();
            }
            if (parameters != null && parameters.Count > 0)
            {
                foreach (var header in parameters)
                {
                    request.Headers[header.Key] = header.Value;
                }
            }
            if (Method == "POST")
            {
                request.ContentType = "text/xml";
                request.BeginGetRequestStream(new AsyncCallback(GetHttpWebRequestStreamCallback), new Object[] { request, body, payload });
            }
            else
            {
                request.BeginGetResponse(new AsyncCallback(GetResponseCallback), new Object[] { request, payload });
            }
            timer = new Timer(OnTimeoutCompleted, request, Timeout, Timeout);

            return true;
        }

        private void OnTimeoutCompleted(object state)
        {
            DisposeTimer();
            HttpWebRequest request = (HttpWebRequest)state;
            if (request != null)
            {
                request.Abort();
            }
        }

        private void DisposeTimer()
        {
            if (timer != null)
            {
                timer.Dispose();
                timer = null;
            }
        }

        private void GetHttpWebRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            Object[] state = (Object[])asynchronousResult.AsyncState;
            HttpWebRequest request = (HttpWebRequest)state[0];
            String strPostData = (String)state[1];
            Object payload = (Object)state[2];
            try
            {
                if (!String.IsNullOrEmpty(strPostData))
                {
                    System.IO.Stream postStream = request.EndGetRequestStream(asynchronousResult);
                    byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(strPostData);
                    postStream.Write(byteArray, 0, byteArray.Length);
                    postStream.Dispose();
                    byteArray = null;
                    strPostData = null;
                }
                request.BeginGetResponse(new AsyncCallback(GetResponseCallback), new Object[] { request, payload });
            }
            catch (Exception ex)
            {
                RaiseWebDataAccessEvent(901, ex.Message, null, payload);
            }
        }
        private void GetHttpWebRequestStreamCallbackForPhotoUpload(IAsyncResult asynchronousResult)
        {
            Object[] state = (Object[])asynchronousResult.AsyncState;
            HttpWebRequest request = (HttpWebRequest)state[0];
            byte[] strPostData = (byte[])state[1];
            Object payload = (Object)state[2];
            try
            {
                if (strPostData != null)
                {
                    System.IO.Stream postStream = request.EndGetRequestStream(asynchronousResult);
                    postStream.Write(strPostData, 0, strPostData.Length);
                    postStream.Dispose();
                    strPostData = null;
                }
                request.BeginGetResponse(new AsyncCallback(GetResponseCallback), new Object[] { request, payload });
            }
            catch (Exception ex)
            {
                RaiseWebDataAccessEvent(901, ex.Message, null, payload);
            }
        }

        private void GetResponseCallback(IAsyncResult asynchronousResult)
        {
            Object[] state = (Object[])asynchronousResult.AsyncState;
            HttpWebRequest request = (HttpWebRequest)state[0];
            Object payload = (Object)state[1];
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
                Stream streamResponse = response.GetResponseStream();
                StreamReader streamRead = new StreamReader(streamResponse);
                string responseString = streamRead.ReadToEnd();
                streamResponse.Dispose();
                response.Dispose();
                RaiseWebDataAccessEvent(200, "Success", responseString, payload);
                DisposeTimer();
            }
            catch (WebException ex1)
            {
                Stream streamResponse = null;
                string responseString = null;
                StreamReader streamRead = null;
                if (ex1.Response != null)
                {
                    streamResponse = ex1.Response.GetResponseStream();
                    streamRead = new StreamReader(streamResponse);
                }
                if (streamRead != null)
                    responseString = streamRead.ReadToEnd();
                string response = "";
                if (!String.IsNullOrEmpty(responseString))
                    response = Utilities.RemoveNameSpace.RemoveAllNamespaces(responseString);
                DisposeTimer();
                RaiseWebDataAccessEvent(900, response, response, payload);
            }
            catch (Exception ex)
            {

                // StreamReader streamRead = new StreamReader(streamResponse);
                // string responseString = streamRead.ReadToEnd();
                DisposeTimer();
                RaiseWebDataAccessEvent(900, ex.Message, ex.Message, payload);
            }
        }

        private void RaiseWebDataAccessEvent(int StatusCode, string StatusText, string Data, Object Payload)
        {
            RaiseWebDataAccessEvent(new WebAccessStatus(StatusCode, StatusText), Data, Payload);
        }

        private void RaiseWebDataAccessEvent(WebAccessStatus Status, string Data, Object Payload)
        {
            if (OnWebDataAccessEvent != null)
                OnWebDataAccessEvent(this, new WebDataAccessEventArgs(Status, Data, Payload));
        }

        public async Task<string> GetPostResponseAsync(string request, Dictionary<String, string> parameters, string Url = "")
        {


            string result = string.Empty;
            try
            {
                //for ssl certificate


                HttpClient client = new HttpClient();
                if (parameters != null && parameters.Count > 0)
                {
                    foreach (var header in parameters)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);

                    }
                }

                HttpContent content = new StringContent(request);
                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("text/xml");



                var response = await client.PostAsync(Url, content);
                if (response.IsSuccessStatusCode)
                {
                    var soapResponse = await response.Content.ReadAsStringAsync();
                    string resp = Utilities.RemoveNameSpace.RemoveAllNamespaces(soapResponse.ToString());
                    XDocument document = XDocument.Parse(resp);
                    var Station = document.Root.Descendants("StationLocalTime");

                    foreach (var item in Station)
                    {
                        result = item.Value;
                    }


                }
                else
                    result = DateTime.Now.ToString();

                response.Dispose();
                response = null;
                content.Dispose();
                content = null;
                client.Dispose();
                client = null;

                //  filter.IgnorableServerCertificateErrors.Clear();

            }
            catch (Exception ex)
            {
                result = string.Empty;
            }
            return result;
        }
    }
}
