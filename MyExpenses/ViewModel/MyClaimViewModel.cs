using MyExpenses.BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyExpenses.ViewModel
{
    class MyClaimViewModel
    {
        public event Action<int, string> OnSubmitClaimCompleted;
        public event Action<int, string> OnDeleteClaimHeaderCompleted;
        public event Action<int, string> OnDeleteClaimLineCompleted;
        public event Action<int, string> OnMoveClaimLineCompleted;
        public event Action<int, string> OnApproveClaimLineCompleted;

        MyClainBAL MyClainBAL = null;
        public void SubmitClaim(string UserGUID, string passwordShar, string ClaimID)
        {
            MyClainBAL = new MyClainBAL();
            MyClainBAL.SubmitClaim(UserGUID, passwordShar,ClaimID);
            MyClainBAL.OnSubmitClaimCompleted += MyClainBAL_OnSubmitClaimCompleted;

        }
        void MyClainBAL_OnSubmitClaimCompleted(int arg1, string arg2)
        {
            MyClainBAL.OnSubmitClaimCompleted -= MyClainBAL_OnSubmitClaimCompleted;
            if (arg1 == 200 && !string.IsNullOrEmpty(arg2))
            {

                string resp = Utilities.RemoveNameSpace.RemoveAllNamespaces(arg2.ToString());
                XDocument document = XDocument.Parse(resp);
                // var XMLresult = document.Root.Descendants("LoginResponse");
                //LoginResponse _LoginResponse = new LoginResponse();
                //foreach (var item in XMLresult)
                //{
                //    _LoginResponse = CommonFUnction.DeSerializeData<LoginResponse>(_LoginResponse, item.ToString());

                //    break;
                //}

                if (OnSubmitClaimCompleted != null)
                    OnSubmitClaimCompleted(arg1, arg2);

            }
            else
            {
                if (OnSubmitClaimCompleted != null)
                    OnSubmitClaimCompleted(900, arg2);
            }
        }
        public void DeleteClaimHeader(string UserGUID, string passwordShar, string ClaimID)
        {
            MyClainBAL = new MyClainBAL();
            MyClainBAL.DeleteClaimHeader(UserGUID, passwordShar, ClaimID);
            MyClainBAL.OnDeleteClaimHeaderCompleted += MyClainBAL_OnDeleteClaimHeaderCompleted;

        }
        void MyClainBAL_OnDeleteClaimHeaderCompleted(int arg1, string arg2)
        {
            MyClainBAL.OnDeleteClaimHeaderCompleted -= MyClainBAL_OnDeleteClaimHeaderCompleted;
            if (arg1 == 200 && !string.IsNullOrEmpty(arg2))
            {

                string resp = Utilities.RemoveNameSpace.RemoveAllNamespaces(arg2.ToString());
                XDocument document = XDocument.Parse(resp);
                // var XMLresult = document.Root.Descendants("LoginResponse");
                //LoginResponse _LoginResponse = new LoginResponse();
                //foreach (var item in XMLresult)
                //{
                //    _LoginResponse = CommonFUnction.DeSerializeData<LoginResponse>(_LoginResponse, item.ToString());

                //    break;
                //}

                if (OnDeleteClaimHeaderCompleted != null)
                    OnDeleteClaimHeaderCompleted(arg1, arg2);

            }
            else
            {
                if (OnDeleteClaimHeaderCompleted != null)
                    OnDeleteClaimHeaderCompleted(900, arg2);
            }
        }

        public void DeleteClaimLine(string UserGUID, string passwordShar, string ClaimID)
        {
            MyClainBAL = new MyClainBAL();
            MyClainBAL.DeleteClaimLine(UserGUID, passwordShar, ClaimID);
            MyClainBAL.OnDeleteClaimLineCompleted += MyClainBAL_OnDeleteClaimLineCompleted;

        }
        void MyClainBAL_OnDeleteClaimLineCompleted(int arg1, string arg2)
        {
            MyClainBAL.OnDeleteClaimLineCompleted -= MyClainBAL_OnDeleteClaimLineCompleted;
            if (arg1 == 200 && !string.IsNullOrEmpty(arg2))
            {

                string resp = Utilities.RemoveNameSpace.RemoveAllNamespaces(arg2.ToString());
                XDocument document = XDocument.Parse(resp);
                // var XMLresult = document.Root.Descendants("LoginResponse");
                //LoginResponse _LoginResponse = new LoginResponse();
                //foreach (var item in XMLresult)
                //{
                //    _LoginResponse = CommonFUnction.DeSerializeData<LoginResponse>(_LoginResponse, item.ToString());

                //    break;
                //}

                if (OnDeleteClaimLineCompleted != null)
                    OnDeleteClaimLineCompleted(arg1, arg2);

            }
            else
            {
                if (OnDeleteClaimLineCompleted != null)
                    OnDeleteClaimLineCompleted(900, arg2);
            }
        }
        public void MoveClaimLine(string UserGUID, string passwordShar, string UniqueID, string NewClaimID)
        {
            MyClainBAL = new MyClainBAL();
            MyClainBAL.MoveClaimLine(UserGUID, passwordShar, UniqueID,NewClaimID);
            MyClainBAL.OnMoveClaimLineCompleted += MyClainBAL_OnMoveClaimLineCompleted;

        }
        void MyClainBAL_OnMoveClaimLineCompleted(int arg1, string arg2)
        {
            MyClainBAL.OnMoveClaimLineCompleted -= MyClainBAL_OnMoveClaimLineCompleted;
            if (arg1 == 200 && !string.IsNullOrEmpty(arg2))
            {

                string resp = Utilities.RemoveNameSpace.RemoveAllNamespaces(arg2.ToString());
                XDocument document = XDocument.Parse(resp);
                // var XMLresult = document.Root.Descendants("LoginResponse");
                //LoginResponse _LoginResponse = new LoginResponse();
                //foreach (var item in XMLresult)
                //{
                //    _LoginResponse = CommonFUnction.DeSerializeData<LoginResponse>(_LoginResponse, item.ToString());

                //    break;
                //}

                if (OnMoveClaimLineCompleted != null)
                    OnMoveClaimLineCompleted(arg1, arg2);

            }
            else
            {
                if (OnMoveClaimLineCompleted != null)
                    OnMoveClaimLineCompleted(900, arg2);
            }
        }

        public void SetLineApproval(string UserGUID, string passwordShar, string ClaimID, string UniqueID, int linestatus, string deniedReason, double VatAmount, int vatrateID)
        {
            MyClainBAL = new MyClainBAL();
            MyClainBAL.SetLineApproval(UserGUID, passwordShar, ClaimID, UniqueID, linestatus, deniedReason, VatAmount, vatrateID);
            MyClainBAL.OnApproveClaimLineCompleted += MyClainBAL_OnApproveClaimLineCompleted;

        }
        void MyClainBAL_OnApproveClaimLineCompleted(int arg1, string arg2)
        {
            MyClainBAL.OnMoveClaimLineCompleted -= MyClainBAL_OnApproveClaimLineCompleted;
            if (arg1 == 200 && !string.IsNullOrEmpty(arg2))
            {

                string resp = Utilities.RemoveNameSpace.RemoveAllNamespaces(arg2.ToString());
                XDocument document = XDocument.Parse(resp);
                // var XMLresult = document.Root.Descendants("LoginResponse");
                //LoginResponse _LoginResponse = new LoginResponse();
                //foreach (var item in XMLresult)
                //{
                //    _LoginResponse = CommonFUnction.DeSerializeData<LoginResponse>(_LoginResponse, item.ToString());

                //    break;
                //}

                if (OnApproveClaimLineCompleted != null)
                    OnApproveClaimLineCompleted(arg1, arg2);

            }
            else
            {
                if (OnApproveClaimLineCompleted != null)
                    OnApproveClaimLineCompleted(900, arg2);
            }
        }
    }
}
