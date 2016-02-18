using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyExpenses.ResponseParsers
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

        [XmlIgnore]
        public string URL { get; set; }
    }

    [XmlRoot(ElementName = "LoginResult")]
    public class LoginResult
    {
        [XmlElement(ElementName = "Headers")]
        public Headers Headers { get; set; }
    }

    [XmlRoot(ElementName = "LoginResponse")]
    public class LoginResponse
    {
        [XmlElement(ElementName = "LoginResult")]
        public LoginResult LoginResult { get; set; }
    }
}
