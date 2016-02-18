using MyExpenses.BussinessLayer;
using MyExpenses.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyExpenses.ViewModel
{
    class AddEditClaimViewModel
    {
        public event Action<int, string> OnAddClaimHeaderCompleted;
        public event Action<int, string> OnAddClaimLineCompleted;
        public event Action<int, string> OnUpdateLineCompleted;
        AddEditClaimBAL AddEditClaimBAL = null;
        public void CreateClaimHeader(string UserGUID, string passwordShar, MyExpenses.Model.BussinessObjects.ClaimDetails ClaimDetails)
        {
            AddEditClaimBAL = new AddEditClaimBAL();
            AddEditClaimBAL.CreateClaimHeader(UserGUID, passwordShar,ClaimDetails);
            AddEditClaimBAL.OnAddClaimHeaderCompleted +=AddEditClaimBAL_OnAddClaimHeaderCompleted;

        }
        async void AddEditClaimBAL_OnAddClaimHeaderCompleted(int arg1, string arg2)
        {
            AddEditClaimBAL.OnAddClaimHeaderCompleted -= AddEditClaimBAL_OnAddClaimHeaderCompleted;

            if (arg1 == 200 && !string.IsNullOrEmpty(arg2))
            {

                string resp = Utilities.RemoveNameSpace.RemoveAllNamespaces(arg2.ToString());
                XDocument document = XDocument.Parse(resp);
                var XMLresult = document.Root.Descendants("CreateClaimHeaderResponse");
                MyExpenses.ResponseParsers.CreateHeader.CreateClaimHeaderResponse CreateClaimHeaderResponse = new MyExpenses.ResponseParsers.CreateHeader.CreateClaimHeaderResponse();
                foreach (var item in XMLresult)
                {
                    CreateClaimHeaderResponse = CommonFUnction.DeSerializeData<MyExpenses.ResponseParsers.CreateHeader.CreateClaimHeaderResponse>(CreateClaimHeaderResponse, item.ToString());
                        break;
                }

                if (CreateClaimHeaderResponse != null && CreateClaimHeaderResponse.CreateClaimHeaderResult != null && CreateClaimHeaderResponse.CreateClaimHeaderResult.ReturnedDataTable != null && CreateClaimHeaderResponse.CreateClaimHeaderResult.ReturnedDataTable.Diffgram != null && CreateClaimHeaderResponse.CreateClaimHeaderResult.ReturnedDataTable.Diffgram.ClaimHeaders != null && CreateClaimHeaderResponse.CreateClaimHeaderResult.ReturnedDataTable.Diffgram.ClaimHeaders.ClaimHeadersDT != null)
                {
                    try
                    {
                        MyExpenses.ResponseParsers.CreateHeader.ClaimHeadersDT _respobj = CreateClaimHeaderResponse.CreateClaimHeaderResult.ReturnedDataTable.Diffgram.ClaimHeaders.ClaimHeadersDT;
                        StateUtilities.CurrentClaimDetails.ClaimID = _respobj.H_expense_headerID;
                        ClaimHeadersDT _ClaimHeadersDT = new ClaimHeadersDT()
                        {
                            H_expense_headerID = _respobj.H_expense_headerID,
                            H_originatorID = _respobj.H_originatorID,
                            H_assigned_levelID = _respobj.H_assigned_levelID,
                            H_assigned_toID = _respobj.H_assigned_toID,
                            H_submitted = _respobj.H_submitted,
                            H_approved = _respobj.H_approved,
                            H_authorised = _respobj.H_authorised,
                            H_date_updated = _respobj.H_date_updated,
                            H_date_created = _respobj.H_date_created,
                            H_expense_form_type = _respobj.H_expense_form_type,
                            H_claim_date = _respobj.H_claim_date,
                            H_description = _respobj.H_description,
                            H_originally_created_by = _respobj.H_originally_created_by,
                            H_mobile_claim = _respobj.H_mobile_claim,
                            H_deleted = _respobj.H_deleted

                        };



                        await App.Connection.InsertAsync(_ClaimHeadersDT);
                    }
                    catch (Exception ex) { }

                    if (OnAddClaimHeaderCompleted != null)
                        OnAddClaimHeaderCompleted(arg1, arg2);
                }
                else
                {
                    if (OnAddClaimHeaderCompleted != null)
                        OnAddClaimHeaderCompleted(900, arg2);
                }

            }
            else
            {
                if (OnAddClaimHeaderCompleted != null)
                    OnAddClaimHeaderCompleted(900, arg2);
            }
        }

        public void CreateClaimLine(string UserGUID, string passwordShar, MyExpenses.Model.BussinessObjects.ClaimDetails ClaimDetails)
        {
            AddEditClaimBAL = new AddEditClaimBAL();
            AddEditClaimBAL.CreateClaimLine(UserGUID, passwordShar, ClaimDetails);
            AddEditClaimBAL.OnAddClaimLineCompleted += AddEditClaimBAL_OnAddClaimLineCompleted;

        }
        async void AddEditClaimBAL_OnAddClaimLineCompleted(int arg1, string arg2)
        {
            AddEditClaimBAL.OnAddClaimLineCompleted -= AddEditClaimBAL_OnAddClaimLineCompleted;

            if (arg1 == 200 && !string.IsNullOrEmpty(arg2))
            {

                string resp = Utilities.RemoveNameSpace.RemoveAllNamespaces(arg2.ToString());
                XDocument document = XDocument.Parse(resp);
                var XMLresult = document.Root.Descendants("CreateLineResponse");
                MyExpenses.ResponseParsers.CLaimLine.CreateLineResponse CreateLineResponse = new MyExpenses.ResponseParsers.CLaimLine.CreateLineResponse();
                foreach (var item in XMLresult)
                {
                    CreateLineResponse = CommonFUnction.DeSerializeData<MyExpenses.ResponseParsers.CLaimLine.CreateLineResponse>(CreateLineResponse, item.ToString());
                    break;
                }

                if (CreateLineResponse != null && CreateLineResponse.CreateLineResult != null && CreateLineResponse.CreateLineResult.ReturnedDataTable != null && CreateLineResponse.CreateLineResult.ReturnedDataTable.Diffgram != null && CreateLineResponse.CreateLineResult.ReturnedDataTable.Diffgram.ClaimDetails != null && CreateLineResponse.CreateLineResult.ReturnedDataTable.Diffgram.ClaimDetails.ClaimDetailsDT != null)
                {
                    try
                    {
                        MyExpenses.ResponseParsers.CLaimLine.ClaimDetailsDT _respobj = CreateLineResponse.CreateLineResult.ReturnedDataTable.Diffgram.ClaimDetails.ClaimDetailsDT;

                        ClaimDetailsDT _ClaimHeadersDT = new ClaimDetailsDT()
                        {
                            Expense_headerID = _respobj.Expense_headerID,
                            UniqueID = _respobj.UniqueID,
                            Line_number = _respobj.Line_number,
                            Date = _respobj.Date,
                            Description = _respobj.Description,
                            Unit_val = _respobj.Unit_val,
                            Quantity = _respobj.Quantity,
                            Nett = _respobj.Nett,
                            Vat = _respobj.Vat,
                            Reclaim_amount = _respobj.Reclaim_amount,
                            Category = _respobj.Category,
                            Deleted = _respobj.Deleted,
                            Approved = _respobj.Approved,
                            Denial_reason = _respobj.Denial_reason,
                            Cat_reason = _respobj.Cat_reason,
                            Reference = _respobj.Reference,
                            User_group_ID = _respobj.User_group_ID,
                            VehicleID = _respobj.VehicleID,
                            Receipt_available = _respobj.Receipt_available,
                            Route_ID = _respobj.Route_ID,
                            Trans_currency = _respobj.Trans_currency,
                            Base_currency = _respobj.Base_currency,
                            Trans_value = _respobj.Trans_value,
                            Trans_base_conv_rate = _respobj.Trans_base_conv_rate,
                            Trans_amount = _respobj.Trans_amount,
                            Trans_nett = _respobj.Trans_nett,
                            Trans_vat = _respobj.Trans_vat,
                            Vat_rate_ID = _respobj.Vat_rate_ID,
                            Vat_rate = _respobj.Vat_rate,
                            Attachment_ID = _respobj.Attachment_ID,
                            AccountID = _respobj.AccountID,
                            Project = _respobj.Project,
                            Order_no = _respobj.Order_no,
                            Receipt_checked = _respobj.Receipt_checked,
                            Collection = _respobj.Collection,
                            Channel = _respobj.Channel,
                            Season = _respobj.Season,
                            Total_mileage = _respobj.Total_mileage,
                            Receipt_total = _respobj.Receipt_total,
                            Distance_unit = _respobj.Distance_unit,
                            Trans_quantity = _respobj.Trans_quantity,
                            Trans_vat_rate_ID = _respobj.Trans_vat_rate_ID,
                            Trans_vat_rate = _respobj.Trans_vat_rate,
                            Person_ID = _respobj.Person_ID,
                            T_last_modified = _respobj.T_last_modified,
                            Trans_country = _respobj.Trans_country,
                            Reporting_country = _respobj.Reporting_country,
                            Additional_information = _respobj.Additional_information,
                            Receipt_description = _respobj.Receipt_description,
                            Receipt_original_filename = _respobj.Receipt_original_filename,
                            Additional_people = _respobj.Additional_people,

                        };



                        await App.Connection.InsertAsync(_ClaimHeadersDT);
                    }
                    catch (Exception ex) { }

                    if (OnAddClaimLineCompleted != null)
                        OnAddClaimLineCompleted(arg1, arg2);
                }
                else
                {
                    if (OnAddClaimLineCompleted != null)
                        OnAddClaimLineCompleted(900, arg2);
                }
               

            }
            else
            {
                if (OnAddClaimLineCompleted != null)
                    OnAddClaimLineCompleted(900, arg2);
            }
        }

        public void UpdateLine(string UserGUID, string passwordShar, MyExpenses.Model.BussinessObjects.ClaimDetails ClaimDetails)
        {
            AddEditClaimBAL = new AddEditClaimBAL();
            AddEditClaimBAL.UpdateLine(UserGUID, passwordShar, ClaimDetails);
            AddEditClaimBAL.OnUpdateLineCompleted += AddEditClaimBAL_OnUpdateLineCompleted;

        }
        async void AddEditClaimBAL_OnUpdateLineCompleted(int arg1, string arg2)
        {
            AddEditClaimBAL.OnUpdateLineCompleted -= AddEditClaimBAL_OnUpdateLineCompleted;

            if (arg1 == 200 && !string.IsNullOrEmpty(arg2))
            {

                string resp = Utilities.RemoveNameSpace.RemoveAllNamespaces(arg2.ToString());
                XDocument document = XDocument.Parse(resp);
                //var XMLresult = document.Root.Descendants("CreateClaimHeaderResponse");
                //MyExpenses.ResponseParsers.CreateHeader.CreateClaimHeaderResponse CreateClaimHeaderResponse = new MyExpenses.ResponseParsers.CreateHeader.CreateClaimHeaderResponse();
                //foreach (var item in XMLresult)
                //{
                //    CreateClaimHeaderResponse = CommonFUnction.DeSerializeData<MyExpenses.ResponseParsers.CreateHeader.CreateClaimHeaderResponse>(CreateClaimHeaderResponse, item.ToString());
                //    break;
                //}

                //if (CreateClaimHeaderResponse != null && CreateClaimHeaderResponse.CreateClaimHeaderResult != null && CreateClaimHeaderResponse.CreateClaimHeaderResult.ReturnedDataTable != null && CreateClaimHeaderResponse.CreateClaimHeaderResult.ReturnedDataTable.Diffgram != null && CreateClaimHeaderResponse.CreateClaimHeaderResult.ReturnedDataTable.Diffgram.ClaimHeaders != null && CreateClaimHeaderResponse.CreateClaimHeaderResult.ReturnedDataTable.Diffgram.ClaimHeaders.ClaimHeadersDT != null)
                //{
                //    try
                //    {
                //        MyExpenses.ResponseParsers.CreateHeader.ClaimHeadersDT _respobj = CreateClaimHeaderResponse.CreateClaimHeaderResult.ReturnedDataTable.Diffgram.ClaimHeaders.ClaimHeadersDT;
                //        StateUtilities.CurrentClaimDetails.ClaimID = _respobj.H_expense_headerID;
                //        ClaimHeadersDT _ClaimHeadersDT = new ClaimHeadersDT()
                //        {
                //            H_expense_headerID = _respobj.H_expense_headerID,
                //            H_originatorID = _respobj.H_originatorID,
                //            H_assigned_levelID = _respobj.H_assigned_levelID,
                //            H_assigned_toID = _respobj.H_assigned_toID,
                //            H_submitted = _respobj.H_submitted,
                //            H_approved = _respobj.H_approved,
                //            H_authorised = _respobj.H_authorised,
                //            H_date_updated = _respobj.H_date_updated,
                //            H_date_created = _respobj.H_date_created,
                //            H_expense_form_type = _respobj.H_expense_form_type,
                //            H_claim_date = _respobj.H_claim_date,
                //            H_description = _respobj.H_description,
                //            H_originally_created_by = _respobj.H_originally_created_by,
                //            H_mobile_claim = _respobj.H_mobile_claim,
                //            H_deleted = _respobj.H_deleted

                //        };



                //        await App.Connection.InsertAsync(_ClaimHeadersDT);
                //    }
                //    catch (Exception ex) { }

                //    if (OnAddClaimHeaderCompleted != null)
                //        OnAddClaimHeaderCompleted(arg1, arg2);
                //}
                //else
                //{
                if (OnUpdateLineCompleted != null)
                    OnUpdateLineCompleted(900, arg2);
              //  }

            }
            else
            {
                if (OnUpdateLineCompleted != null)
                    OnUpdateLineCompleted(900, arg2);
            }
        }


    }
}
