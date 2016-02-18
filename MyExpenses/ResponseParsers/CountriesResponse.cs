using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyExpenses.ResponseParsers
{
    [XmlRoot(ElementName = "Table")]
    public class Countries
    {
        [XmlElement(ElementName = "country_code")]
        public string Country_code { get; set; }
        [XmlElement(ElementName = "country_code_3char")]
        public string Country_code_3char { get; set; }
        [XmlElement(ElementName = "dial_code")]
        public string Dial_code { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "currency_code")]
        public string Currency_code { get; set; }
        [XmlElement(ElementName = "deleted")]
        public string Deleted { get; set; }
        [XmlElement(ElementName = "t_last_modified")]
        public string T_last_modified { get; set; }
    }

    [XmlRoot(ElementName = "NewDataSet")]
    public class CountriesDataSet
    {
        [XmlElement(ElementName = "Table")]
        public List<Countries> Table { get; set; }
    }
}
