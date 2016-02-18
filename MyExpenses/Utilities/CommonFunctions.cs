using System;
using System.Net;
using System.Windows;
using System.Xml.Serialization;
using System.IO;
using System.Globalization;
using Windows.UI.Xaml;
using Windows.Networking.Connectivity;
using System.Text;
using MyExpenses.Utilities;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using System.Text.RegularExpressions;
using Windows.Storage;
using System.Xml;
using System.Xml.Linq;
//using Newtonsoft.Json;
using Windows.UI.Popups;
using System.Threading.Tasks;
using MyExpenses.WebAccessLayer;
using Windows.ApplicationModel.Background;

namespace MyExpenses.Common
{
    public static class CommonFunctions
    {
        public static int GetDaysInMonth(DateTime dt)
        {
            DateTime startOfMonth = new DateTime(dt.Year, dt.Month, 1);
            int daysInMonth = (int)Math.Floor(startOfMonth.AddMonths(1).Subtract(startOfMonth).TotalDays);
            return daysInMonth;
        }
        public static string ObjectToXml<T>(this T source)
        {
            string retVal = string.Empty;
            try
            {
                XmlSerializer xSerzer = new XmlSerializer(typeof(T));
                using (var xWriter = new StringWriter())
                {
                    xSerzer.Serialize(xWriter, source);
                    retVal = xWriter.ToString();
                }
            }
            catch (Exception ex)
            {
            }
            return retVal.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n", "");
        }
        /// <summary>
        /// Deserialization of XML data
        /// </summary>
        /// <typeparam name="T">This is type</typeparam>
        /// <param name="source">This is source</param>
        /// <param name="ResponseString">This is ResponseString</param>
        /// <returns>Deserialize data</returns>
        public static T DeSerializeData<T>(this T source, String ResponseString)
        {
            ResponseString = ResponseString.Replace(" i:nil=\"true\"", "");
            XmlSerializer ser = new XmlSerializer(typeof(T));
            T obj;
            obj = (T)ser.Deserialize(new StringReader(ResponseString));
            return obj;
        }
        /// <summary>
        /// Deserialization of XML data
        /// </summary>
        /// <typeparam name="T">This is type</typeparam>
        /// <param name="source">This is source</param>
        /// <param name="ResponseString">This is ResponseString</param>
        /// <returns>Deserialize data</returns>
        public static T DeSerializeData<T>(this T source, String ResponseString, String nameSpace)
        {
            ResponseString = ResponseString.Replace(" i:nil=\"true\"", "");
            XmlSerializer ser = new XmlSerializer(typeof(T), nameSpace);
            T obj;
            obj = (T)ser.Deserialize(new StringReader(ResponseString));
            return obj;
        }
        /// <summary>
        /// Deserialization of XML data
        /// </summary>
        /// <param name="streamObject">Stream type</param>
        /// <param name="serializedObjectType">Type type</param>
        /// <returns>Deserialize data</returns>
        public static object Deserialize(Stream streamObject, Type serializedObjectType)
        {
            if (serializedObjectType == null || streamObject == null)
                return null;

            XmlSerializer serializer = new XmlSerializer(serializedObjectType);
            return serializer.Deserialize(streamObject);
        }

        public static string AddValue(string currentValue, int MaxValue, UIElement _uiElement)
        {

            string newValue = currentValue;
            try
            {
                int currentVal = Int32.Parse(currentValue);
                if (currentVal < MaxValue)
                {
                    newValue = (currentVal + 1).ToString();
                }
            }
            catch { }
            return newValue;
        }
        public static string MinusValue(string currentValue, int check, UIElement _uiElement)
        {
            string newValue = currentValue;
            try
            {
                int currentVal = Int32.Parse(currentValue);
                if (check != 0 && currentVal > 1)
                {
                    newValue = (currentVal - 1).ToString();
                }
                else if (check == 0 && currentVal >= 1)
                {
                    newValue = (currentVal - 1).ToString();
                }
            }
            catch { }
            return newValue;
        }
        public static DateTime GetDateTime(string text)
        {
            DateTime result = new DateTime();
            bool isParsed;

            //isParsed = DateTime.TryParse(text, out result);

            string format1 = "MM/dd/yyyy hh:mm:ss";
            string format2 = "MM/dd/yyyy";
            string format3 = "MMM dd, yyyy";
            string format4 = "MM/dd/yyyy 23:59:59";

            isParsed = DateTime.TryParseExact(text, new string[] { format1, format2, format3, format4 },
                CultureInfo.InvariantCulture, DateTimeStyles.None, out result);

            if (!isParsed)
            {
                if (text.Contains("/"))
                {
                    int monthIndex = text.IndexOf("/"); //1
                    int dayIndex = text.IndexOf("/", monthIndex + 1);//3

                    string newFormattedText = text.Substring(monthIndex + 1, dayIndex - (monthIndex + 1)) + "/" + text.Substring(0, monthIndex)
                        + "/" + text.Substring(dayIndex + 1, 4);

                    isParsed = DateTime.TryParse(newFormattedText, out result);
                }

                else if (text.Contains("-"))
                {
                    int monthIndex = text.IndexOf("-"); //1
                    int dayIndex = text.IndexOf("-", monthIndex + 1);//3

                    string newFormattedText = text.Substring(monthIndex + 1, dayIndex - (monthIndex + 1)) + "/" + text.Substring(0, monthIndex)
                        + "/" + text.Substring(dayIndex + 1, 4);

                    isParsed = DateTime.TryParse(newFormattedText, out result);
                }
            }
            return result;
        }
        public static string ConvertToUpperText(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                char[] array = value.ToCharArray();
                //if (!string.IsNullOrEmpty(value.Trim()) && (array.Length == 1 || array[array.Length - 2] == ' '))
                //{
                    if (array.Length >= 1)
                    {
                        if (char.IsLower(array[0]))
                        {
                            array[0] = char.ToUpper(array[0]);
                        }
                    }
                    for (int i = 1; i < array.Length; i++)
                    {
                        //if (array[i - 1] == ' ')
                        //{
                            if (char.IsUpper(array[i]))
                            {
                                array[i] = char.ToLower(array[i]);
                            }
                        //}
                    }
                //}
                return value = new string(array);
            }
            else return string.Empty;
        }

        public static string RistrictSpecialCharecters(TextBox textbox)
        {
            string value = textbox.Text;
            //TextBox tb = new TextBox();
            char[] myChars = value.ToCharArray();
            int pos = value.IndexOf(' ');
            if (!string.IsNullOrWhiteSpace(textbox.Text))
            {
                foreach (var item in myChars)
                {
                    if (!char.IsLetter(item))
                    {
                        if (char.IsWhiteSpace(item) && pos > 0)
                        {
                            textbox.Text = textbox.Text.Replace(item.ToString(), " ");
                            textbox.SelectionStart = textbox.Text.Length;
                        }
                        else
                            textbox.Text = textbox.Text.Replace(item.ToString(), string.Empty);
                        textbox.SelectionStart = textbox.Text.Length;
                    }
                }
            }
            return value;
        }
        public static DateTime GetDateTimeOld(string text)
        {
            //text = "05/19/2014";  Month/Day/Year
            //text = "5/19/2014 23:59:59";//May 19, 2014
            DateTime result = new DateTime();
            bool isParsed;
            string format = "M/d/yyyy hh:mm:ss";
            string format1 = "M/dd/yyyy hh:mm:ss";
            string format2 = "MM/d/yyyy hh:mm:ss";
            string format3 = "MM/dd/yyyy hh:mm:ss";
            string format4 = "M/d/yyyy";
            string format5 = "MM/dd/yyyy";
            string format6 = "MM/d/yyyy";
            string format7 = "M/dd/yyyy";
            string format8 = "MMM dd, yyyy";

            isParsed = DateTime.TryParseExact(text, new string[] { format, format1, format2, format3, format4, format5,
                format6, format7,format8 }, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);

            // isParsed = DateTime.TryParseExact(text, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);

            if (!isParsed)
            {
                // Day/Month/Year  (5/9/2014)

                if (text.Contains("/"))
                {
                    int monthIndex = text.IndexOf("/"); //1
                    int dayIndex = text.IndexOf("/", monthIndex + 1);//3

                    string newFormattedText = text.Substring(monthIndex + 1, dayIndex - (monthIndex + 1)) + "/" + text.Substring(0, monthIndex)
                        + "/" + text.Substring(dayIndex + 1, 4);

                    isParsed = DateTime.TryParse(newFormattedText, out result);
                }

                else if (text.Contains("-"))
                {
                    int monthIndex = text.IndexOf("-"); //1
                    int dayIndex = text.IndexOf("-", monthIndex + 1);//3

                    string newFormattedText = text.Substring(monthIndex + 1, dayIndex - (monthIndex + 1)) + "/" + text.Substring(0, monthIndex)
                        + "/" + text.Substring(dayIndex + 1, 4);

                    isParsed = DateTime.TryParse(newFormattedText, out result);
                }
                if (!isParsed)
                { }
            }
            return result;
        }

        public static bool IsInternetAvailable()
        {
            bool isNetworkAvailable = false;
            try
            {
                ConnectionProfile internetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
                if (internetConnectionProfile == null)
                { isNetworkAvailable = false; }
                else
                { isNetworkAvailable = true; }
            }
            catch (Exception ex)
            {
                isNetworkAvailable = false;
            }
            return isNetworkAvailable;
        }

       


        public static bool IsNetworkAvaliable()
        {
            ConnectionProfile InternetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
            if (InternetConnectionProfile == null)
            {
                return false;
            }
            else if (InternetConnectionProfile.GetNetworkConnectivityLevel() >= NetworkConnectivityLevel.InternetAccess)
            {
                //  AppConstants.NoNetworkalertShown = 0;
                return true;
            }
            else
            {
                return false;
            }
            //  return false;
        }

        public static bool ValidedEmailId(string email)
        {
            //Regex EmailRgx = new Regex(@"^(?("")(""[^""]+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
            //                           @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,3}))$");
            //if (EmailRgx.IsMatch(email))
            //{
            //    return false;
            //}
            //else
            //    return true;

            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,1}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,1}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(email))
                return (true);
            else
                return (false);
            //  return Regex.IsMatch(email.ToLower(), @"^[a-zA-Z0-9][\.-]@^[a-zA-Z0-9][\.-]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            // return Regex.IsMatch(email.ToLower(), @"^[a-zA-Z0-9][\w\.-]@[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]$");
        }


            

      
        public static void SaveObject(string key, object value)
        {
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey(key))
            {
                if (ApplicationData.Current.LocalSettings.Values[key].ToString() != null)
                {
                    ApplicationData.Current.LocalSettings.Values[key] = value;
                }
            }
            else
            {
                // do create key and save value, first time only.
                ApplicationData.Current.LocalSettings.CreateContainer(key, ApplicationDataCreateDisposition.Always);
                if (ApplicationData.Current.LocalSettings.Values[key] == null)
                {
                    ApplicationData.Current.LocalSettings.Values[key] = value;
                }
            }
        }

        public static object GetObject(string key)
        {
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey(key))
                return ApplicationData.Current.LocalSettings.Values[key];
            else
                return null;
        }
      
        public static bool isDouble(string amount)
        {
            try
            {
                double value = 0;
                if (double.TryParse(amount, out value))
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;

            }

        }

        public static void RestrictSpecialChar(object sender)
        {
            bool bNeedToUpdate = false;
            StringBuilder sbAlphabets = new StringBuilder();
            TextBox textbox = sender as TextBox;
            string _restChars = string.Empty;

            textbox.Text = textbox.Text.TrimStart();
            textbox.SelectionStart = textbox.Text.Length;

            string previous = textbox.Text;
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(@"[ ]{2,}", options);
            textbox.Text = regex.Replace(textbox.Text, @" ");
            textbox.SelectionStart = textbox.Text.Length;
            if (null == textbox)
                return;
            _restChars = ".0123456789`•!@#$%^&*_-+=\\():;'/~[]|<>,{}?\"€£¥";

            int count = 0;
            foreach (char ch in textbox.Text)
            {
                if ((_restChars).Contains(ch.ToString()))
                {
                    bNeedToUpdate = true;
                }
                else
                {
                    sbAlphabets.Append(ch);
                }
                count++;
            }
            if (bNeedToUpdate)
            {
                textbox.Text = sbAlphabets.ToString();
                textbox.SelectionStart = sbAlphabets.Length;
            }

            string value = (sender as TextBox).Text;

            int po = (sender as TextBox).SelectionStart;
            if (value.Length < (sender as TextBox).Text.Length)
            {
                po = po - 1;
            }
            else if (value.Length > (sender as TextBox).Text.Length)
            {
                po = po + 1;
            }

            (sender as TextBox).Text = value;
            (sender as TextBox).Select(po, 0);
        }

     
       
        public static void ConvertToUpperText(object sender)
        {
            string value = (sender as TextBox).Text;

            int po = (sender as TextBox).SelectionStart;
            value = value.ToUpper();    // CommonFunctions.ConvertToUpperText(value); 
            if (value.Length < (sender as TextBox).Text.Length)
            {
                po = po - 1;
            }
            else if (value.Length > (sender as TextBox).Text.Length)
            {
                po = po + 1;
            }

            (sender as TextBox).Text = value;
            (sender as TextBox).Select(po, 0);
        }
      
    }
}