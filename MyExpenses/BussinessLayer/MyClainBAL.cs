using MyExpenses.Common;
using MyExpenses.WebAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.BussinessLayer
{
    class MyClainBAL
    {
        public event Action<int, string> OnSubmitClaimCompleted;
        public event Action<int, string> OnDeleteClaimHeaderCompleted;
        public event Action<int, string> OnDeleteClaimLineCompleted;
        public event Action<int, string> OnMoveClaimLineCompleted;
        public event Action<int, string> OnApproveClaimLineCompleted;

        BookingWA bookingWA = null;
        public void SubmitClaim(string UserGUID, string passwordshar,string ClaimID)
        {
            if (CommonFunctions.IsInternetAvailable())
            {
                bookingWA = new BookingWA();

                bookingWA.SubmitClaim(Utilities.BuildRequestXml.SubmitClaim(UserGUID, passwordshar, ClaimID));
                bookingWA.OnWebDataAccessEvent += bookingWA_OnWebDataAccessEvent;
            }
            else
            {
                if (OnSubmitClaimCompleted != null)
                    OnSubmitClaimCompleted(900, null);
            }
        }
        void bookingWA_OnWebDataAccessEvent(object sender, WebDataAccessEventArgs e)
        {
            bookingWA.OnWebDataAccessEvent -= bookingWA_OnWebDataAccessEvent;
            if (e.WebAccessStatus.StatusCode == 200)
            {
                if (OnSubmitClaimCompleted != null)
                    OnSubmitClaimCompleted(e.WebAccessStatus.StatusCode, e.Data);
            }
            else
            {
                if (OnSubmitClaimCompleted != null)
                    OnSubmitClaimCompleted(e.WebAccessStatus.StatusCode, null);
            }
        }

        public void DeleteClaimHeader(string UserGUID, string passwordshar, string ClaimID)
        {
            if (CommonFunctions.IsInternetAvailable())
            {
                bookingWA = new BookingWA();

                bookingWA.DeleteClaimHeader(Utilities.BuildRequestXml.DeleteCLaimHeader(UserGUID, passwordshar, ClaimID));
                bookingWA.OnWebDataAccessEvent += bookingWA_OnWebDataAccessEvent1;
            }
            else
            {
                if (OnDeleteClaimHeaderCompleted != null)
                    OnDeleteClaimHeaderCompleted(900, null);
            }
        }
        void bookingWA_OnWebDataAccessEvent1(object sender, WebDataAccessEventArgs e)
        {
            bookingWA.OnWebDataAccessEvent -= bookingWA_OnWebDataAccessEvent1;
            if (e.WebAccessStatus.StatusCode == 200)
            {
                if (OnDeleteClaimHeaderCompleted != null)
                    OnDeleteClaimHeaderCompleted(e.WebAccessStatus.StatusCode, e.Data);
            }
            else
            {
                if (OnDeleteClaimHeaderCompleted != null)
                    OnDeleteClaimHeaderCompleted(e.WebAccessStatus.StatusCode, null);
            }
        }

        public void DeleteClaimLine(string UserGUID, string passwordshar, string ClaimID)
        {
            if (CommonFunctions.IsInternetAvailable())
            {
                bookingWA = new BookingWA();

                bookingWA.DeleteClaimLine(Utilities.BuildRequestXml.DeleteCLaimLine(UserGUID, passwordshar, ClaimID));
                bookingWA.OnWebDataAccessEvent += bookingWA_OnWebDataAccessEvent2;
            }
            else
            {
                if (OnDeleteClaimLineCompleted != null)
                    OnDeleteClaimLineCompleted(900, null);
            }
        }
        void bookingWA_OnWebDataAccessEvent2(object sender, WebDataAccessEventArgs e)
        {
            bookingWA.OnWebDataAccessEvent -= bookingWA_OnWebDataAccessEvent2;
            if (e.WebAccessStatus.StatusCode == 200)
            {
                if (OnDeleteClaimLineCompleted != null)
                    OnDeleteClaimLineCompleted(e.WebAccessStatus.StatusCode, e.Data);
            }
            else
            {
                if (OnDeleteClaimLineCompleted != null)
                    OnDeleteClaimLineCompleted(e.WebAccessStatus.StatusCode, null);
            }
        }

        public void MoveClaimLine(string UserGUID, string passwordshar, string UniqueID, string NewClaimID)
        {
            if (CommonFunctions.IsInternetAvailable())
            {
                bookingWA = new BookingWA();

                bookingWA.MoveClaimLine(Utilities.BuildRequestXml.MoveClaimLine(UserGUID, passwordshar, UniqueID,NewClaimID));
                bookingWA.OnWebDataAccessEvent += bookingWA_OnWebDataAccessEvent3;
            }
            else
            {
                if (OnMoveClaimLineCompleted != null)
                    OnMoveClaimLineCompleted(900, null);
            }
        }
        void bookingWA_OnWebDataAccessEvent3(object sender, WebDataAccessEventArgs e)
        {
            bookingWA.OnWebDataAccessEvent -= bookingWA_OnWebDataAccessEvent3;
            if (e.WebAccessStatus.StatusCode == 200)
            {
                if (OnMoveClaimLineCompleted != null)
                    OnMoveClaimLineCompleted(e.WebAccessStatus.StatusCode, e.Data);
            }
            else
            {
                if (OnMoveClaimLineCompleted != null)
                    OnMoveClaimLineCompleted(e.WebAccessStatus.StatusCode, null);
            }
        }

        public void SetLineApproval(string UserGUID, string passwordShar, string ClaimID, string UniqueID, int linestatus, string deniedReason, double VatAmount, int vatrateID)
        {
            if (CommonFunctions.IsInternetAvailable())
            {
                bookingWA = new BookingWA();

                bookingWA.SetLineApproval(Utilities.BuildRequestXml.SetLineApproval(UserGUID, passwordShar, ClaimID, UniqueID, linestatus, deniedReason, VatAmount, vatrateID));
                bookingWA.OnWebDataAccessEvent += bookingWA_OnWebDataAccessEvent4;
            }
            else
            {
                if (OnApproveClaimLineCompleted != null)
                    OnApproveClaimLineCompleted(900, null);
            }
        }
        void bookingWA_OnWebDataAccessEvent4(object sender, WebDataAccessEventArgs e)
        {
            bookingWA.OnWebDataAccessEvent -= bookingWA_OnWebDataAccessEvent4;
            if (e.WebAccessStatus.StatusCode == 200)
            {
                if (OnApproveClaimLineCompleted != null)
                    OnApproveClaimLineCompleted(e.WebAccessStatus.StatusCode, e.Data);
            }
            else
            {
                if (OnApproveClaimLineCompleted != null)
                    OnApproveClaimLineCompleted(e.WebAccessStatus.StatusCode, null);
            }
        }
    }
}
