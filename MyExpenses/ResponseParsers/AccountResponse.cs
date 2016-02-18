using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyExpenses.ResponseParsers.Account
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

    [XmlRoot(ElementName = "Table")]
    public class Account
    {
        [XmlElement(ElementName = "ID")]
        public string ID { get; set; }
        [XmlElement(ElementName = "account_type")]
        public string Account_type { get; set; }
        [XmlElement(ElementName = "username")]
        public string Username { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "reference")]
        public string Reference { get; set; }
        [XmlElement(ElementName = "currency_ID")]
        public string Currency_ID { get; set; }
        [XmlElement(ElementName = "amount_balance")]
        public string Amount_balance { get; set; }
        [XmlElement(ElementName = "mileage_balance")]
        public string Mileage_balance { get; set; }
        [XmlElement(ElementName = "date_created")]
        public string Date_created { get; set; }
        [XmlElement(ElementName = "deleted")]
        public string Deleted { get; set; }
        [XmlElement(ElementName = "list_position")]
        public string List_position { get; set; }
        [XmlElement(ElementName = "nominal_payment")]
        public string Nominal_payment { get; set; }
        [XmlElement(ElementName = "nominal_payment_description")]
        public string Nominal_payment_description { get; set; }
        [XmlElement(ElementName = "nominal_suspense")]
        public string Nominal_suspense { get; set; }
        [XmlElement(ElementName = "nominal_suspense_description")]
        public string Nominal_suspense_description { get; set; }
        [XmlElement(ElementName = "t_last_modified")]
        public string T_last_modified { get; set; }
    }

    [XmlRoot(ElementName = "NewDataSet")]
    public class NewDataSet
    {
        [XmlElement(ElementName = "Table")]
        public List<Account> Table { get; set; }
    }

    [XmlRoot(ElementName = "diffgram")]
    public class Diffgram
    {
        [XmlElement(ElementName = "NewDataSet")]
        public NewDataSet NewDataSet { get; set; }
    }

    [XmlRoot(ElementName = "ReturnedDataTable")]
    public class ReturnedDataTable
    {
        [XmlElement(ElementName = "schema")]
        public Schema Schema { get; set; }
        [XmlElement(ElementName = "diffgram")]
        public Diffgram Diffgram { get; set; }
    }

    [XmlRoot(ElementName = "GetAccountResult")]
    public class GetAccountResult
    {
        [XmlElement(ElementName = "Headers")]
        public Headers Headers { get; set; }
        [XmlElement(ElementName = "ReturnedDataTable")]
        public ReturnedDataTable ReturnedDataTable { get; set; }
    }

    [XmlRoot(ElementName = "GetAccountResponse")]
    public class GetAccountResponse
    {
        [XmlElement(ElementName = "GetAccountResult")]
        public GetAccountResult GetAccountResult { get; set; }
    }

    [XmlRoot(ElementName = "Body")]
    public class Body
    {
        [XmlElement(ElementName = "GetAccountResponse")]
        public GetAccountResponse GetAccountResponse { get; set; }
    }

    [XmlRoot(ElementName = "Envelope")]
    public class Envelope
    {
        [XmlElement(ElementName = "Body")]
        public Body Body { get; set; }
    }

}
