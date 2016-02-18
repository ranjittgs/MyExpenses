using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyExpenses.ResponseParsers.CreateHeader
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
        [XmlElement(ElementName = "h_deleted")]
        public string H_deleted { get; set; }
        [XmlElement(ElementName = "view_section")]
        public string View_section { get; set; }
    }

    [XmlRoot(ElementName = "ClaimHeaders")]
    public class ClaimHeaders
    {
        [XmlElement(ElementName = "ClaimHeadersDT")]
        public ClaimHeadersDT ClaimHeadersDT { get; set; }
    }

    [XmlRoot(ElementName = "diffgram")]
    public class Diffgram
    {
        [XmlElement(ElementName = "ClaimHeaders")]
        public ClaimHeaders ClaimHeaders { get; set; }
    }

    [XmlRoot(ElementName = "ReturnedDataTable")]
    public class ReturnedDataTable
    {
        [XmlElement(ElementName = "schema")]
        public Schema Schema { get; set; }
        [XmlElement(ElementName = "diffgram")]
        public Diffgram Diffgram { get; set; }
    }

    [XmlRoot(ElementName = "CreateClaimHeaderResult")]
    public class CreateClaimHeaderResult
    {
        [XmlElement(ElementName = "Headers")]
        public Headers Headers { get; set; }
        [XmlElement(ElementName = "ReturnedDataTable")]
        public ReturnedDataTable ReturnedDataTable { get; set; }
    }

    [XmlRoot(ElementName = "CreateClaimHeaderResponse")]
    public class CreateClaimHeaderResponse
    {
        [XmlElement(ElementName = "CreateClaimHeaderResult")]
        public CreateClaimHeaderResult CreateClaimHeaderResult { get; set; }
    }

    [XmlRoot(ElementName = "Body")]
    public class Body
    {
        [XmlElement(ElementName = "CreateClaimHeaderResponse")]
        public CreateClaimHeaderResponse CreateClaimHeaderResponse { get; set; }
    }

    [XmlRoot(ElementName = "Envelope")]
    public class Envelope
    {
        [XmlElement(ElementName = "Body")]
        public Body Body { get; set; }
    }
}
