using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyExpenses.ResponseParsers.CostCentres
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
    public class CostCentre
    {
        [XmlElement(ElementName = "t_last_modified")]
        public string T_last_modified { get; set; }
        [XmlElement(ElementName = "Cost_centre_ID")]
        public string Cost_centre_ID { get; set; }
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "Deleted")]
        public string Deleted { get; set; }
        [XmlElement(ElementName = "code")]
        public string Code { get; set; }
        [XmlElement(ElementName = "guid")]
        public string Guid { get; set; }
        [XmlElement(ElementName = "t_last_modified1")]
        public string T_last_modified1 { get; set; }
        [XmlElement(ElementName = "allowable_cost_centre_ID")]
        public string Allowable_cost_centre_ID { get; set; }
        [XmlElement(ElementName = "cost_centre_ID1")]
        public string Cost_centre_ID1 { get; set; }
        [XmlElement(ElementName = "username")]
        public string Username { get; set; }
        [XmlElement(ElementName = "deleted1")]
        public string Deleted1 { get; set; }
        [XmlElement(ElementName = "t_last_modified2")]
        public string T_last_modified2 { get; set; }
        [XmlElement(ElementName = "default_code")]
        public string Default_code { get; set; }
    }

    [XmlRoot(ElementName = "NewDataSet")]
    public class NewDataSet
    {
        [XmlElement(ElementName = "Table")]
        public List<CostCentre> Table { get; set; }
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

    [XmlRoot(ElementName = "GetCostcentresResult")]
    public class GetCostcentresResult
    {
        [XmlElement(ElementName = "Headers")]
        public Headers Headers { get; set; }
        [XmlElement(ElementName = "ReturnedDataTable")]
        public ReturnedDataTable ReturnedDataTable { get; set; }
    }

    [XmlRoot(ElementName = "GetCostcentresResponse")]
    public class GetCostcentresResponse
    {
        [XmlElement(ElementName = "GetCostcentresResult")]
        public GetCostcentresResult GetCostcentresResult { get; set; }
    }

    [XmlRoot(ElementName = "Body")]
    public class Body
    {
        [XmlElement(ElementName = "GetCostcentresResponse")]
        public GetCostcentresResponse GetCostcentresResponse { get; set; }
    }

    [XmlRoot(ElementName = "Envelope")]
    public class Envelope
    {
        [XmlElement(ElementName = "Body")]
        public Body Body { get; set; }
    }

}
