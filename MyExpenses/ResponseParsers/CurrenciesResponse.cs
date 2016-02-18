using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyExpenses.ResponseParsers
{
    [XmlRoot(ElementName = "Table")]
    public class Currencies
    {
        [XmlElement(ElementName = "ID")]
        public string ID { get; set; }
        [XmlElement(ElementName = "currency_code")]
        public string Currency_code { get; set; }
        [XmlElement(ElementName = "currency_symbol")]
        public string Currency_symbol { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "currency_format")]
        public string Currency_format { get; set; }
        [XmlElement(ElementName = "list_pos")]
        public string List_pos { get; set; }
        [XmlElement(ElementName = "t_last_modified")]
        public string T_last_modified { get; set; }
        [XmlElement(ElementName = "iso_4217")]
        public string Iso_4217 { get; set; }
        [XmlElement(ElementName = "full_desc")]
        public string Full_desc { get; set; }
    }

    [XmlRoot(ElementName = "NewDataSet")]
    public class CurrenciesDataSet
    {
        [XmlElement(ElementName = "Table")]
        public List<Currencies> Table { get; set; }
    }
}
