using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyExpenses.ResponseParsers
{
    [XmlRoot(ElementName = "Table")]
    public class Projects
    {
        [XmlElement(ElementName = "guid")]
        public string Guid { get; set; }
        [XmlElement(ElementName = "project")]
        public string Project { get; set; }
        [XmlElement(ElementName = "code")]
        public string Code { get; set; }
        [XmlElement(ElementName = "deleted")]
        public string Deleted { get; set; }
        [XmlElement(ElementName = "default_code")]
        public string Default_code { get; set; }
        [XmlElement(ElementName = "t_last_modified")]
        public string T_last_modified { get; set; }
    }

    [XmlRoot(ElementName = "NewDataSet")]
    public class ProjectsDataSet
    {
        [XmlElement(ElementName = "Table")]
        public List<Projects> Table { get; set; }
    }
}
