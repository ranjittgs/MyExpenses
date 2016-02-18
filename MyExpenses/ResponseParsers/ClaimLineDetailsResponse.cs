using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyExpenses.ResponseParsers.CLaimLine
{
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

    [XmlRoot(ElementName = "ClaimDetailsDT")]
    public class ClaimDetailsDT
    {
        [XmlElement(ElementName = "UniqueID")]
        public string UniqueID { get; set; }
        [XmlElement(ElementName = "expense_headerID")]
        public string Expense_headerID { get; set; }
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
        [XmlElement(ElementName = "batch_number")]
        public string Batch_number { get; set; }
        [XmlElement(ElementName = "additional_information")]
        public string Additional_information { get; set; }
        [XmlElement(ElementName = "route_ID")]
        public string Route_ID { get; set; }
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
        [XmlElement(ElementName = "person_ID")]
        public string Person_ID { get; set; }
        [XmlElement(ElementName = "attachment_ID")]
        public string Attachment_ID { get; set; }
        [XmlElement(ElementName = "accountID")]
        public string AccountID { get; set; }
        [XmlElement(ElementName = "project")]
        public string Project { get; set; }
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
        [XmlElement(ElementName = "trip_type")]
        public string Trip_type { get; set; }
        [XmlElement(ElementName = "t_last_modified")]
        public string T_last_modified { get; set; }
        [XmlElement(ElementName = "p11d_flag_include")]
        public string P11d_flag_include { get; set; }
        [XmlElement(ElementName = "reporting_country")]
        public string Reporting_country { get; set; }
        [XmlElement(ElementName = "trans_country")]
        public string Trans_country { get; set; }
        [XmlElement(ElementName = "organisation")]
        public string Organisation { get; set; }
        [XmlElement(ElementName = "reporting_currency")]
        public string Reporting_currency { get; set; }
        [XmlElement(ElementName = "denial_reason1")]
        public string Denial_reason1 { get; set; }

        [XmlElement(ElementName = "receipt_description")]
        public string Receipt_description { get; set; }
        [XmlElement(ElementName = "receipt_original_filename")]
        public string Receipt_original_filename { get; set; }
        [XmlElement(ElementName = "additional_people")]
        public string Additional_people { get; set; }
    }

    [XmlRoot(ElementName = "ClaimDetails")]
    public class ClaimDetails
    {
        [XmlElement(ElementName = "ClaimDetailsDT")]
        public ClaimDetailsDT ClaimDetailsDT { get; set; }
    }

    [XmlRoot(ElementName = "diffgram")]
    public class Diffgram
    {
        [XmlElement(ElementName = "ClaimDetails")]
        public ClaimDetails ClaimDetails { get; set; }
    }

    [XmlRoot(ElementName = "ReturnedDataTable")]
    public class ReturnedDataTable
    {
        [XmlElement(ElementName = "schema")]
        public Schema Schema { get; set; }
        [XmlElement(ElementName = "diffgram")]
        public Diffgram Diffgram { get; set; }
    }

    [XmlRoot(ElementName = "SecondaryReturnedDataTable")]
    public class SecondaryReturnedDataTable
    {
        [XmlElement(ElementName = "schema")]
        public Schema Schema { get; set; }
        [XmlElement(ElementName = "diffgram")]
        public string Diffgram { get; set; }
    }

    [XmlRoot(ElementName = "CreateLineResult")]
    public class CreateLineResult
    {
        [XmlElement(ElementName = "Headers")]
        public Headers Headers { get; set; }
        [XmlElement(ElementName = "ReturnedDataTable")]
        public ReturnedDataTable ReturnedDataTable { get; set; }
        [XmlElement(ElementName = "SecondaryReturnedDataTable")]
        public SecondaryReturnedDataTable SecondaryReturnedDataTable { get; set; }
    }

    [XmlRoot(ElementName = "CreateLineResponse")]
    public class CreateLineResponse
    {
        [XmlElement(ElementName = "CreateLineResult")]
        public CreateLineResult CreateLineResult { get; set; }
    }

    [XmlRoot(ElementName = "Body")]
    public class Body
    {
        [XmlElement(ElementName = "CreateLineResponse")]
        public CreateLineResponse CreateLineResponse { get; set; }
    }

    [XmlRoot(ElementName = "Envelope")]
    public class Envelope
    {
        [XmlElement(ElementName = "Body")]
        public Body Body { get; set; }
    }
}
