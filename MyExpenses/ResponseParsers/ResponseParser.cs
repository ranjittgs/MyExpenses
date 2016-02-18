using MyExpenses.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyExpenses
{
    class ResponseParser
    {
    }

    [XmlRoot(ElementName = "Headers")]
    public class Headers
    {
        [XmlElement(ElementName = "Success")]
        public string Success { get; set; }
        [XmlElement(ElementName = "Username")]
        public string Username { get; set; }
        [XmlElement(ElementName = "UserGuid")]
        public string UserGuid { get; set; }
        [XmlElement(ElementName = "UserShar")]
        public string UserShar { get; set; }
        [XmlElement(ElementName = "LoginResponse")]
        public string LoginResponse { get; set; }
    }

    [XmlRoot(ElementName = "sequence")]
    public class Sequence
    {
        [XmlElement(ElementName = "element")]
        public List<string> Element { get; set; }
    }

    [XmlRoot(ElementName = "complexType")]
    public class ComplexType
    {
        [XmlElement(ElementName = "sequence")]
        public Sequence Sequence { get; set; }
        [XmlElement(ElementName = "choice")]
        public Choice Choice { get; set; }
    }

    [XmlRoot(ElementName = "element")]
    public class Element
    {
        [XmlElement(ElementName = "complexType")]
        public ComplexType ComplexType { get; set; }
    }

    [XmlRoot(ElementName = "choice")]
    public class Choice
    {
        [XmlElement(ElementName = "element")]
        public Element Element { get; set; }
    }

    [XmlRoot(ElementName = "schema")]
    public class Schema
    {
        [XmlElement(ElementName = "element")]
        public Element Element { get; set; }
    }

    [XmlRoot(ElementName = "ClaimHeadersDT")]
    public class ClaimHeadersDT
    {
        [XmlElement(ElementName = "h_expense_headerID")]
        public string H_expense_headerID { get; set; }
        [XmlElement(ElementName = "h_originatorID")]
        public string H_originatorID { get; set; }
        [XmlElement(ElementName = "h_assigned_levelID")]
        public string H_assigned_levelID { get; set; }
        [XmlElement(ElementName = "h_assigned_toID")]
        public string H_assigned_toID { get; set; }
        [XmlElement(ElementName = "h_submitted")]
        public string H_submitted { get; set; }
        [XmlElement(ElementName = "h_approved")]
        public string H_approved { get; set; }
        [XmlElement(ElementName = "h_authorised")]
        public string H_authorised { get; set; }
        [XmlElement(ElementName = "h_date_updated")]
        public string H_date_updated { get; set; }
        [XmlElement(ElementName = "h_date_created")]
        public string H_date_created { get; set; }
        [XmlElement(ElementName = "h_expense_form_type")]
        public string H_expense_form_type { get; set; }
        [XmlElement(ElementName = "h_claim_date")]
        public string H_claim_date { get; set; }
        [XmlElement(ElementName = "h_description")]
        public string H_description { get; set; }
        [XmlElement(ElementName = "h_originally_created_by")]
        public string H_originally_created_by { get; set; }
        [XmlElement(ElementName = "h_mobile_claim")]
        public string H_mobile_claim { get; set; }
        [XmlElement(ElementName = "h_t_last_modified")]
        public string H_t_last_modified { get; set; }
        [XmlElement(ElementName = "h_orig_name")]
        public string H_orig_name { get; set; }
        [XmlElement(ElementName = "h_assigned_name")]
        public string H_assigned_name { get; set; }
        [XmlElement(ElementName = "h_deleted")]
        public string H_deleted { get; set; }


        [XmlIgnore]
        private string _FromDate;
        [XmlIgnore]
        public string FromDate
        {

            set
            {
                _FromDate = value;
            }
            get
            {
                if(string.IsNullOrEmpty(_FromDate))
                {

                    string date = H_date_created;
                    if (date.Contains("T"))
                    {
                        string[] strarray = date.Split('T');
                        DateTime dt = DateTime.ParseExact(strarray[0], "yyyy-MM-dd", null);
                        _FromDate = dt.ToString("dd/MM/yyyy");
                    }

                }
                return _FromDate;
            }
        }


        [XmlIgnore]
        private string _ToDate;
        [XmlIgnore]
        public string ToDate
        {

            set
            {
                _ToDate = value;
            }
            get
            {
                if (string.IsNullOrEmpty(_ToDate))
                {

                    string date = H_date_updated;
                    if (date.Contains("T"))
                    {
                        string[] strarray = date.Split('T');
                        DateTime dt = DateTime.ParseExact(strarray[0], "yyyy-MM-dd", null);
                        _ToDate = dt.ToString("dd/MM/yyyy");
                    }

                }
                return _ToDate;
            }
        }

        [XmlIgnore]
        private int _Count;
        [XmlIgnore]
        public int Count
        {

            set
            {
                _Count = value;
            }
            get
            {
                //if (StateUtilities.ListClaimDetailsDT != null && StateUtilities.ListClaimDetailsDT.Count>0)
                //{

                //    try
                //    {
                //        _Count = StateUtilities.ListClaimDetailsDT.Where(i => i.Expense_headerID == H_expense_headerID).ToList().Count;
                //    }
                //    catch (Exception ex) { }

                    
                //}
                return _Count;
            }
        }


        [XmlIgnore]
        private double _Amount;
        [XmlIgnore]
        public double Amount
        {

            set
            {
                _Amount = value;
            }
            get
            {
                //if (StateUtilities.ListClaimDetailsDT != null && StateUtilities.ListClaimDetailsDT.Count > 0)
                //{

                //    try
                //    {
                //      var listdetails   = StateUtilities.ListClaimDetailsDT.Where(i => i.Expense_headerID == H_expense_headerID).ToList();
                //        if(listdetails!=null && listdetails.Count>0)
                //        {
                //            double amt=0;
                //            foreach (var item in listdetails)
                //                amt +=Convert.ToDouble( item.Trans_amount);
                //            _Amount = amt;
                //        }
                //    }
                //    catch (Exception ex) { }

                //}
                return _Amount;
            }
        }

        [XmlIgnore]
        private int _DetailsCount;
        [XmlIgnore]
        public int DetailsCount
        {

            set
            {
                _DetailsCount = value;
            }
            get
            {
                
                return _DetailsCount;
            }
        }

        [XmlIgnore]
        private string _CurrencySymbol;
        [XmlIgnore]
        public string CurrencySymbol
        {

            set
            {
                _CurrencySymbol = value;
            }
            get
            {

                return _CurrencySymbol;
            }
        }

    }

    [XmlRoot(ElementName = "ClaimHeaders")]
    public class ClaimHeaders
    {
        [XmlElement(ElementName = "ClaimHeadersDT")]
        public List<ClaimHeadersDT> ClaimHeadersDT { get; set; }
    }

    [XmlRoot(ElementName = "diffgram")]
    public class Diffgram
    {
        [XmlElement(ElementName = "ClaimHeaders")]
        public ClaimHeaders ClaimHeaders { get; set; }
        [XmlElement(ElementName = "ClaimDetails")]
        public ClaimDetails ClaimDetails { get; set; }
        [XmlElement(ElementName = "ClaimValidation")]
        public ClaimValidation ClaimValidation { get; set; }
    }

    [XmlRoot(ElementName = "ReturnedDataTable")]
    public class ReturnedDataTable
    {
        [XmlElement(ElementName = "schema")]
        public Schema Schema { get; set; }
        [XmlElement(ElementName = "diffgram")]
        public Diffgram Diffgram { get; set; }
    }

    [XmlRoot(ElementName = "ClaimDetailsDT")]
    public class ClaimDetailsDT
    {
        [XmlElement(ElementName = "expense_headerID")]
        public string Expense_headerID { get; set; }
        [XmlElement(ElementName = "UniqueID")]
        public string UniqueID { get; set; }
        [XmlElement(ElementName = "line_number")]
        public string Line_number { get; set; }
        [XmlElement(ElementName = "date")]
        public string Date { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "unit_val")]
        public string Unit_val { get; set; }
        [XmlElement(ElementName = "quantity")]
        public string Quantity { get; set; }
        [XmlElement(ElementName = "nett")]
        public string Nett { get; set; }
        [XmlElement(ElementName = "vat")]
        public string Vat { get; set; }
        [XmlElement(ElementName = "reclaim_amount")]
        public string Reclaim_amount { get; set; }
        [XmlElement(ElementName = "category")]
        public string Category { get; set; }
        [XmlElement(ElementName = "deleted")]
        public string Deleted { get; set; }
        [XmlElement(ElementName = "approved")]
        public string Approved { get; set; }
        [XmlElement(ElementName = "denial_reason")]
        public string Denial_reason { get; set; }
        [XmlElement(ElementName = "cat_reason")]
        public string Cat_reason { get; set; }
        [XmlElement(ElementName = "reference")]
        public string Reference { get; set; }
        [XmlElement(ElementName = "user_group_ID")]
        public string User_group_ID { get; set; }
        [XmlElement(ElementName = "vehicleID")]
        public string VehicleID { get; set; }
        [XmlElement(ElementName = "receipt_available")]
        public string Receipt_available { get; set; }
        [XmlElement(ElementName = "route_ID")]
        public string Route_ID { get; set; }
        [XmlElement(ElementName = "parent_line")]
        public string Parent_line { get; set; }
        [XmlElement(ElementName = "trans_currency")]
        public string Trans_currency { get; set; }
        [XmlElement(ElementName = "base_currency")]
        public string Base_currency { get; set; }
        [XmlElement(ElementName = "trans_value")]
        public string Trans_value { get; set; }
        [XmlElement(ElementName = "trans_base_conv_rate")]
        public string Trans_base_conv_rate { get; set; }
        [XmlElement(ElementName = "trans_amount")]
        public string Trans_amount { get; set; }
        [XmlElement(ElementName = "trans_nett")]
        public string Trans_nett { get; set; }
        [XmlElement(ElementName = "trans_vat")]
        public string Trans_vat { get; set; }
        [XmlElement(ElementName = "vat_rate_ID")]
        public string Vat_rate_ID { get; set; }
        [XmlElement(ElementName = "vat_rate")]
        public string Vat_rate { get; set; }
        [XmlElement(ElementName = "attachment_ID")]
        public string Attachment_ID { get; set; }
        [XmlElement(ElementName = "accountID")]
        public string AccountID { get; set; }
        [XmlElement(ElementName = "project")]
        public string Project { get; set; }
        [XmlElement(ElementName = "cost_centre_ID")]
        public string Cost_centre_ID { get; set; }
        [XmlElement(ElementName = "cost_centre_guid")]
        public string Cost_centre_guid { get; set; }
        [XmlElement(ElementName = "order_no")]
        public string Order_no { get; set; }
        [XmlElement(ElementName = "receipt_checked")]
        public string Receipt_checked { get; set; }
        [XmlElement(ElementName = "collection")]
        public string Collection { get; set; }
        [XmlElement(ElementName = "channel")]
        public string Channel { get; set; }
        [XmlElement(ElementName = "season")]
        public string Season { get; set; }
        [XmlElement(ElementName = "total_mileage")]
        public string Total_mileage { get; set; }
        [XmlElement(ElementName = "receipt_total")]
        public string Receipt_total { get; set; }
        [XmlElement(ElementName = "distance_unit")]
        public string Distance_unit { get; set; }
        [XmlElement(ElementName = "trans_quantity")]
        public string Trans_quantity { get; set; }
        [XmlElement(ElementName = "trans_vat_rate_ID")]
        public string Trans_vat_rate_ID { get; set; }
        [XmlElement(ElementName = "trans_vat_rate")]
        public string Trans_vat_rate { get; set; }
        [XmlElement(ElementName = "person_ID")]
        public string Person_ID { get; set; }
        [XmlElement(ElementName = "t_last_modified")]
        public string T_last_modified { get; set; }
        [XmlElement(ElementName = "trans_country")]
        public string Trans_country { get; set; }
        [XmlElement(ElementName = "reporting_country")]
        public string Reporting_country { get; set; }
        [XmlElement(ElementName = "receipt_description")]
        public string Receipt_description { get; set; }
        [XmlElement(ElementName = "receipt_original_filename")]
        public string Receipt_original_filename { get; set; }
        [XmlElement(ElementName = "additional_people")]
        public string Additional_people { get; set; }
        [XmlElement(ElementName = "additional_information")]
        public string Additional_information { get; set; }


        [XmlIgnore]
        private string _FromDate;
        [XmlIgnore]
        public string FromDate
        {

            set
            {
                _FromDate = value;
            }
            get
            {
                if (string.IsNullOrEmpty(_FromDate))
                {

                    string date = Date;
                    if (date.Contains("T"))
                    {
                        string[] strarray = date.Split('T');
                        DateTime dt = DateTime.ParseExact(strarray[0], "yyyy-MM-dd", null);
                        _FromDate = dt.ToString("dd/MM/yyyy");
                    }

                }
                return _FromDate;
            }
        }


        [XmlIgnore]
        private string _isDenied;
        [XmlIgnore]
        public string IsDenied
        {

            set
            {
                _isDenied = value;
            }
            get
            {
                if (!string.IsNullOrEmpty(Denial_reason))
                {
                    _isDenied = "Denied";
                   
                }
                return _isDenied;
            }
        }

        [XmlIgnore]
        private string _reasonDeniad;
        [XmlIgnore]
        public string ReasonDenied
        {

            set
            {
                _reasonDeniad = value;
            }
            get
            {
                if (!string.IsNullOrEmpty(Denial_reason))
                {
                    _reasonDeniad = "Reason: " + Denial_reason;

                }
                return _reasonDeniad;
            }
        }

        [XmlIgnore]
        private string _CurrencySymbol;
        [XmlIgnore]
        public string CurrencySymbol
        {

            set
            {
                _CurrencySymbol = value;
            }
            get
            {

                return _CurrencySymbol;
            }
        }

        [XmlIgnore]
        private string _CategoryName;
        [XmlIgnore]
        public string CategoryName
        {

            set
            {
                _CategoryName = value;
            }
            get
            {

                return _CategoryName;
            }
        }
    }

    [XmlRoot(ElementName = "ClaimDetails")]
    public class ClaimDetails
    {
        [XmlElement(ElementName = "ClaimDetailsDT")]
        public List<ClaimDetailsDT> ClaimDetailsDT { get; set; }
    }

    [XmlRoot(ElementName = "SecondaryReturnedDataTable")]
    public class SecondaryReturnedDataTable
    {
        [XmlElement(ElementName = "schema")]
        public Schema Schema { get; set; }
        [XmlElement(ElementName = "diffgram")]
        public Diffgram Diffgram { get; set; }
    }

    [XmlRoot(ElementName = "ClaimValidationDT")]
    public class ClaimValidationDT
    {
        [XmlElement(ElementName = "guid")]
        public string Guid { get; set; }
        [XmlElement(ElementName = "formID")]
        public string FormID { get; set; }
        [XmlElement(ElementName = "lineReference")]
        public string LineReference { get; set; }
        [XmlElement(ElementName = "error_level")]
        public string Error_level { get; set; }
        [XmlElement(ElementName = "text")]
        public string Text { get; set; }
        [XmlElement(ElementName = "deleted")]
        public string Deleted { get; set; }
        [XmlElement(ElementName = "date_created")]
        public string Date_created { get; set; }
        [XmlElement(ElementName = "source_line_number")]
        public string Source_line_number { get; set; }
        [XmlElement(ElementName = "t_last_modified")]
        public string T_last_modified { get; set; }
    }

    [XmlRoot(ElementName = "ClaimValidation")]
    public class ClaimValidation
    {
        [XmlElement(ElementName = "ClaimValidationDT")]
        public List<ClaimValidationDT> ClaimValidationDT { get; set; }
    }

    [XmlRoot(ElementName = "ThirdReturnedDataTable")]
    public class ThirdReturnedDataTable
    {
        [XmlElement(ElementName = "schema")]
        public Schema Schema { get; set; }
        [XmlElement(ElementName = "diffgram")]
        public Diffgram Diffgram { get; set; }
    }

    [XmlRoot(ElementName = "ForthReturnedDataTable")]
    public class ForthReturnedDataTable
    {
        [XmlElement(ElementName = "schema")]
        public Schema Schema { get; set; }
        [XmlElement(ElementName = "diffgram")]
        public string Diffgram { get; set; }
    }

    [XmlRoot(ElementName = "GetFullClaimLinesResult")]
    public class GetFullClaimLinesResult
    {
        [XmlElement(ElementName = "Headers")]
        public Headers Headers { get; set; }
        [XmlElement(ElementName = "ReturnedDataTable")]
        public ReturnedDataTable ReturnedDataTable { get; set; }
        [XmlElement(ElementName = "SecondaryReturnedDataTable")]
        public SecondaryReturnedDataTable SecondaryReturnedDataTable { get; set; }
        [XmlElement(ElementName = "ThirdReturnedDataTable")]
        public ThirdReturnedDataTable ThirdReturnedDataTable { get; set; }
        [XmlElement(ElementName = "ForthReturnedDataTable")]
        public ForthReturnedDataTable ForthReturnedDataTable { get; set; }
    }

    [XmlRoot(ElementName = "GetFullClaimLinesResponse")]
    public class GetFullClaimLinesResponse
    {
        [XmlElement(ElementName = "GetFullClaimLinesResult")]
        public GetFullClaimLinesResult GetFullClaimLinesResult { get; set; }
    }

    [XmlRoot(ElementName = "Body")]
    public class Body
    {
        [XmlElement(ElementName = "GetFullClaimLinesResponse")]
        public GetFullClaimLinesResponse GetFullClaimLinesResponse { get; set; }
    }

    [XmlRoot(ElementName = "Envelope")]
    public class Envelope
    {
        [XmlElement(ElementName = "Body")]
        public Body Body { get; set; }
    }
}
