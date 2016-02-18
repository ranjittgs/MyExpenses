using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyExpenses.ResponseParsers.Settings
{
  
    [XmlRoot(ElementName="Headers")]
	public class Headers {
		[XmlElement(ElementName="Success")]
		public string Success { get; set; }
		[XmlElement(ElementName="Username")]
		public string Username { get; set; }
		[XmlElement(ElementName="UserGuid")]
		public string UserGuid { get; set; }
		[XmlElement(ElementName="UserShar")]
		public string UserShar { get; set; }
		[XmlElement(ElementName="LoginResponse")]
		public string LoginResponse { get; set; }
	}

	[XmlRoot(ElementName="sequence")]
	public class Sequence {
		[XmlElement(ElementName="element")]
		public List<string> Element { get; set; }
	}

	[XmlRoot(ElementName="complexType")]
	public class ComplexType {
		[XmlElement(ElementName="sequence")]
		public Sequence Sequence { get; set; }
	}

	[XmlRoot(ElementName="element")]
	public class Element {
		[XmlElement(ElementName="complexType")]
		public ComplexType ComplexType { get; set; }
	}

	[XmlRoot(ElementName="choice")]
	public class Choice {
		[XmlElement(ElementName="element")]
		public Element Element { get; set; }
	}

	[XmlRoot(ElementName="schema")]
	public class Schema {
		[XmlElement(ElementName="element")]
		public Element Element { get; set; }
	}

	[XmlRoot(ElementName="MobileSettings")]
	public class MobileSettings {
		[XmlElement(ElementName="EmployeeStartDate")]
		public string EmployeeStartDate { get; set; }
		[XmlElement(ElementName="MoneyFormat")]
		public string MoneyFormat { get; set; }
		[XmlElement(ElementName="BaseCurrency")]
		public string BaseCurrency { get; set; }
		[XmlElement(ElementName="ExchangeRateEditable")]
		public string ExchangeRateEditable { get; set; }
		[XmlElement(ElementName="AuthVatEditable")]
		public string AuthVatEditable { get; set; }
		[XmlElement(ElementName="AuthLevel")]
		public string AuthLevel { get; set; }
		[XmlElement(ElementName="AuthLevelDesc")]
		public string AuthLevelDesc { get; set; }
		[XmlElement(ElementName="LiveCoding")]
		public string LiveCoding { get; set; }
		[XmlElement(ElementName="DefaultDistanceUnit")]
		public string DefaultDistanceUnit { get; set; }
		[XmlElement(ElementName="LiveCodingPageSize")]
		public string LiveCodingPageSize { get; set; }
		[XmlElement(ElementName="TriggersOn")]
		public string TriggersOn { get; set; }
		[XmlElement(ElementName="FullName")]
		public string FullName { get; set; }
		[XmlElement(ElementName="CodingCostCentreEdit")]
		public string CodingCostCentreEdit { get; set; }
		[XmlElement(ElementName="CodingProjectEdit")]
		public string CodingProjectEdit { get; set; }
		[XmlElement(ElementName="CodingOrderNoEdit")]
		public string CodingOrderNoEdit { get; set; }
		[XmlElement(ElementName="CodingChannelEdit")]
		public string CodingChannelEdit { get; set; }
		[XmlElement(ElementName="CodingCollectionEdit")]
		public string CodingCollectionEdit { get; set; }
		[XmlElement(ElementName="CodingSeasonEdit")]
		public string CodingSeasonEdit { get; set; }
		[XmlElement(ElementName="CodingCategoryTag")]
		public string CodingCategoryTag { get; set; }
		[XmlElement(ElementName="CodingCostCentreTag")]
		public string CodingCostCentreTag { get; set; }
		[XmlElement(ElementName="CodingProjectTag")]
		public string CodingProjectTag { get; set; }
		[XmlElement(ElementName="CodingOrderNoTag")]
		public string CodingOrderNoTag { get; set; }
		[XmlElement(ElementName="CodingChannelTag")]
		public string CodingChannelTag { get; set; }
		[XmlElement(ElementName="CodingCollectionTag")]
		public string CodingCollectionTag { get; set; }
		[XmlElement(ElementName="CodingSeasonTag")]
		public string CodingSeasonTag { get; set; }
		[XmlElement(ElementName="DescriptionTag")]
		public string DescriptionTag { get; set; }
		[XmlElement(ElementName="ReferenceTag")]
		public string ReferenceTag { get; set; }
		[XmlElement(ElementName="CodingCostCentreActive")]
		public string CodingCostCentreActive { get; set; }
		[XmlElement(ElementName="CodingProjectActive")]
		public string CodingProjectActive { get; set; }
		[XmlElement(ElementName="CodingOrderNoActive")]
		public string CodingOrderNoActive { get; set; }
		[XmlElement(ElementName="CodingChannelActive")]
		public string CodingChannelActive { get; set; }
		[XmlElement(ElementName="CodingCollectionActive")]
		public string CodingCollectionActive { get; set; }
		[XmlElement(ElementName="CodingSeasonActive")]
		public string CodingSeasonActive { get; set; }
		[XmlElement(ElementName="BaseCountry")]
		public string BaseCountry { get; set; }
		[XmlElement(ElementName="OrigVatEditable")]
		public string OrigVatEditable { get; set; }
	}

	[XmlRoot(ElementName="dsMobileSettings")]
	public class DsMobileSettings {
		[XmlElement(ElementName="MobileSettings")]
		public MobileSettings MobileSettings { get; set; }
	}

	[XmlRoot(ElementName="diffgram")]
	public class Diffgram {
		[XmlElement(ElementName="dsMobileSettings")]
		public DsMobileSettings DsMobileSettings { get; set; }
	}

	[XmlRoot(ElementName="ReturnedDataTable")]
	public class ReturnedDataTable {
		[XmlElement(ElementName="schema")]
		public Schema Schema { get; set; }
		[XmlElement(ElementName="diffgram")]
		public Diffgram Diffgram { get; set; }
	}

	[XmlRoot(ElementName="GetMobileSettingsResult")]
	public class GetMobileSettingsResult {
		[XmlElement(ElementName="Headers")]
		public Headers Headers { get; set; }
		[XmlElement(ElementName="ReturnedDataTable")]
		public ReturnedDataTable ReturnedDataTable { get; set; }
	}

	[XmlRoot(ElementName="GetMobileSettingsResponse")]
	public class GetMobileSettingsResponse {
		[XmlElement(ElementName="GetMobileSettingsResult")]
		public GetMobileSettingsResult GetMobileSettingsResult { get; set; }
	}

	[XmlRoot(ElementName="Body")]
	public class Body {
		[XmlElement(ElementName="GetMobileSettingsResponse")]
		public GetMobileSettingsResponse GetMobileSettingsResponse { get; set; }
	}

	[XmlRoot(ElementName="Envelope")]
	public class Envelope {
		[XmlElement(ElementName="Body")]
		public Body Body { get; set; }
	}
}
