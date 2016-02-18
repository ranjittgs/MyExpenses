using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyExpenses.ResponseParsers
{
    [XmlRoot(ElementName = "Table")]
    public class ClaimTypes
    {
        [XmlElement(ElementName = "expense_typeID")]
        public string Expense_typeID { get; set; }
        [XmlElement(ElementName = "expense_type")]
        public string Expense_type { get; set; }
        [XmlElement(ElementName = "NL_account_code")]
        public string NL_account_code { get; set; }
        [XmlElement(ElementName = "create_journal")]
        public string Create_journal { get; set; }
        [XmlElement(ElementName = "create_payroll_report")]
        public string Create_payroll_report { get; set; }
        [XmlElement(ElementName = "list_position")]
        public string List_position { get; set; }
        [XmlElement(ElementName = "deleted")]
        public string Deleted { get; set; }
        [XmlElement(ElementName = "t_last_modified")]
        public string T_last_modified { get; set; }
        [XmlElement(ElementName = "username")]
        public string Username { get; set; }
        [XmlElement(ElementName = "expense_typeID1")]
        public string Expense_typeID1 { get; set; }
        [XmlElement(ElementName = "date_created")]
        public string Date_created { get; set; }
        [XmlElement(ElementName = "t_last_modified1")]
        public string T_last_modified1 { get; set; }
    }

    [XmlRoot(ElementName = "NewDataSet")]
    public class ClaimTypesDataSet
    {
        [XmlElement(ElementName = "Table")]
        public List<ClaimTypes> Table { get; set; }
    }

}
