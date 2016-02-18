using MyExpenses.Common;
using MyExpenses.WebAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.BussinessLayer
{
    class LoginBAL
    {
        public event Action<int, string> OnLogonCompleted;
        BookingWA bookingWA = null;
        public void CheckLogin(string URL, string UserName, string password)
        {
            if (CommonFunctions.IsInternetAvailable())
            {
                bookingWA = new BookingWA();

                bookingWA.CheckLogin(Utilities.BuildRequestXml.GetLoginRequest( URL,  UserName,  password));
                bookingWA.OnWebDataAccessEvent += bookingWA_OnWebDataAccessEvent;
            }
            else
            {
                FireGetLogonSignatureCompleted(900, null);
            }
        }

        void bookingWA_OnWebDataAccessEvent(object sender, WebDataAccessEventArgs e)
        {
            bookingWA.OnWebDataAccessEvent -= bookingWA_OnWebDataAccessEvent;
            if (e.WebAccessStatus.StatusCode == 200)
            {
               
                FireGetLogonSignatureCompleted(e.WebAccessStatus.StatusCode, e.Data);
            }
            else
            {
                FireGetLogonSignatureCompleted(e.WebAccessStatus.StatusCode, null);
            }
        }

        public void FireGetLogonSignatureCompleted(int StatusCode, string LoginnResponse)
        {
            if (OnLogonCompleted != null)
            {
                OnLogonCompleted(StatusCode, LoginnResponse);
            }
        }
    }
}
