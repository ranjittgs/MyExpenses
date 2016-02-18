using MyExpenses.Common;
using MyExpenses.WebAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.BussinessLayer
{
    class AddEditClaimBAL
    {
        public event Action<int, string> OnAddClaimHeaderCompleted;
        public event Action<int, string> OnAddClaimLineCompleted;
        public event Action<int, string> OnUpdateLineCompleted;

        BookingWA bookingWA = null;
        public void CreateClaimHeader(string UserGUID, string password, MyExpenses.Model.BussinessObjects.ClaimDetails ClaimDetails)
        {
            if (CommonFunctions.IsInternetAvailable())
            {
                bookingWA = new BookingWA();

                bookingWA.CreateClaimHeader(Utilities.BuildRequestXml.CreateClaimHeader(UserGUID, password, ClaimDetails));
                bookingWA.OnWebDataAccessEvent += bookingWA_OnWebDataAccessEvent;
            }
            else
            {
                OnAddClaimHeaderCompleted(900, null);
            }
        }

        void bookingWA_OnWebDataAccessEvent(object sender, WebDataAccessEventArgs e)
        {
            bookingWA.OnWebDataAccessEvent -= bookingWA_OnWebDataAccessEvent;
            if (e.WebAccessStatus.StatusCode == 200)
            {

                OnAddClaimHeaderCompleted(e.WebAccessStatus.StatusCode, e.Data);
            }
            else
            {
                OnAddClaimHeaderCompleted(e.WebAccessStatus.StatusCode, null);
            }
        }


        public void CreateClaimLine(string UserGUID, string password, MyExpenses.Model.BussinessObjects.ClaimDetails ClaimDetails)
        {
            if (CommonFunctions.IsInternetAvailable())
            {
                bookingWA = new BookingWA();

                bookingWA.CreateLine(Utilities.BuildRequestXml.CreateLine(UserGUID, password, ClaimDetails));
                bookingWA.OnWebDataAccessEvent += bookingWA_OnWebDataAccessEvent1;
            }
            else
            {
                OnAddClaimLineCompleted(900, null);
            }
        }

        void bookingWA_OnWebDataAccessEvent1(object sender, WebDataAccessEventArgs e)
        {
            bookingWA.OnWebDataAccessEvent -= bookingWA_OnWebDataAccessEvent1;
            if (e.WebAccessStatus.StatusCode == 200)
            {

                OnAddClaimLineCompleted(e.WebAccessStatus.StatusCode, e.Data);
            }
            else
            {
                OnAddClaimLineCompleted(e.WebAccessStatus.StatusCode, null);
            }
        }

        public void UpdateLine(string UserGUID, string password, MyExpenses.Model.BussinessObjects.ClaimDetails ClaimDetails)
        {
            if (CommonFunctions.IsInternetAvailable())
            {
                bookingWA = new BookingWA();

                bookingWA.UpdateLine(Utilities.BuildRequestXml.UpdateLine(UserGUID, password, ClaimDetails));
                bookingWA.OnWebDataAccessEvent += bookingWA_OnWebDataAccessEvent11;
            }
            else
            {
                OnUpdateLineCompleted(900, null);
            }
        }

        void bookingWA_OnWebDataAccessEvent11(object sender, WebDataAccessEventArgs e)
        {
            bookingWA.OnWebDataAccessEvent -= bookingWA_OnWebDataAccessEvent11;
            if (e.WebAccessStatus.StatusCode == 200)
            {

                OnUpdateLineCompleted(e.WebAccessStatus.StatusCode, e.Data);
            }
            else
            {
                OnUpdateLineCompleted(e.WebAccessStatus.StatusCode, null);
            }
        }
    }
}
