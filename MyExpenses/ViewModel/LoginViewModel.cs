using MyExpenses.BussinessLayer;
using MyExpenses.Common;
using MyExpenses.ResponseParsers;
using MyExpenses.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyExpenses.ViewModel
{
    class LoginViewModel
    {
        public event Action<int, string> OnLogonCompleted;
        LoginBAL LoginBAL = null;
        public void CheckLogin(string URL,string UserName,string password)
        {
            LoginBAL = new LoginBAL();
            LoginBAL.CheckLogin( URL, UserName, password);
            LoginBAL.OnLogonCompleted += LoginBAL_OnLogonCompleted;
        }

       async  void LoginBAL_OnLogonCompleted(int arg1, string arg2)
        {
            LoginBAL.OnLogonCompleted -= LoginBAL_OnLogonCompleted;

            if (arg1 == 200 && !string.IsNullOrEmpty(arg2))
            {

                string resp = Utilities.RemoveNameSpace.RemoveAllNamespaces(arg2.ToString());
                XDocument document = XDocument.Parse(resp);
                var XMLresult = document.Root.Descendants("LoginResponse");
                LoginResponse _LoginResponse = new LoginResponse();
                foreach (var item in XMLresult)
                {
                    _LoginResponse = CommonFUnction.DeSerializeData<LoginResponse>(_LoginResponse, item.ToString());
                   
                    break;
                }
                if (_LoginResponse != null && _LoginResponse.LoginResult != null && _LoginResponse.LoginResult.Headers != null)
                {
                    StateUtilities.LoginHeaders = _LoginResponse.LoginResult.Headers;
                    if (StateUtilities.LoginHeaders != null && !string.IsNullOrEmpty(StateUtilities.LoginHeaders.LoginResponse) && (StateUtilities.LoginHeaders.LoginResponse == "UsernameInvalid" || StateUtilities.LoginHeaders.LoginResponse == "PasswordInvalid"))
                    {
                        if (OnLogonCompleted != null)
                            OnLogonCompleted(900, arg2);
                    }
                    else
                    {
                        StateUtilities.LoginHeaders.URL = AppConstants.BaseURl;

                        await App.Connection.ExecuteAsync("delete from Headers");
                        await App.Connection.InsertAsync(StateUtilities.LoginHeaders);

                        if (OnLogonCompleted != null)
                            OnLogonCompleted(arg1, arg2);
                    }
                }
                else
                {
                    if (OnLogonCompleted != null)
                        OnLogonCompleted(arg1, arg2);
                }
            }
            else
            {
                if (OnLogonCompleted != null)
                    OnLogonCompleted(900, arg2);
            }
        }
    }
}
