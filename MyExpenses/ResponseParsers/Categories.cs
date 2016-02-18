using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyExpenses.ResponseParsers
{

    [XmlRoot(ElementName = "Categories")]
    public class Categories
    {
        [XmlElement(ElementName = "categoryID")]
        public string CategoryID { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "esr_tag")]
        public string Esr_tag { get; set; }
        [XmlElement(ElementName = "NL_account_name")]
        public string NL_account_name { get; set; }
        [XmlElement(ElementName = "claim_limit")]
        public string Claim_limit { get; set; }
        [XmlElement(ElementName = "limit_days")]
        public string Limit_days { get; set; }
        [XmlElement(ElementName = "details_required")]
        public string Details_required { get; set; }
        [XmlElement(ElementName = "list_position")]
        public string List_position { get; set; }
        [XmlElement(ElementName = "deleted")]
        public string Deleted { get; set; }
        [XmlElement(ElementName = "mileage_cat")]
        public string Mileage_cat { get; set; }
        [XmlElement(ElementName = "require_receipt")]
        public string Require_receipt { get; set; }
        [XmlElement(ElementName = "default_vatrate_id")]
        public string Default_vatrate_id { get; set; }
        [XmlElement(ElementName = "esr_type")]
        public string Esr_type { get; set; }
        [XmlElement(ElementName = "mileage_cap")]
        public string Mileage_cap { get; set; }
        [XmlElement(ElementName = "reference_required")]
        public string Reference_required { get; set; }
        [XmlElement(ElementName = "max_age_days")]
        public string Max_age_days { get; set; }
        [XmlElement(ElementName = "limit_type")]
        public string Limit_type { get; set; }
        [XmlElement(ElementName = "limit_type_max_age_days")]
        public string Limit_type_max_age_days { get; set; }
        [XmlElement(ElementName = "rate_change_type")]
        public string Rate_change_type { get; set; }
        [XmlElement(ElementName = "p11d_flag_include")]
        public string P11d_flag_include { get; set; }
        [XmlElement(ElementName = "cc_enabled")]
        public string Cc_enabled { get; set; }
        [XmlElement(ElementName = "cc_required")]
        public string Cc_required { get; set; }
        [XmlElement(ElementName = "cc_create")]
        public string Cc_create { get; set; }
        [XmlElement(ElementName = "proj_enabled")]
        public string Proj_enabled { get; set; }
        [XmlElement(ElementName = "proj_required")]
        public string Proj_required { get; set; }
        [XmlElement(ElementName = "proj_create")]
        public string Proj_create { get; set; }
        [XmlElement(ElementName = "ord_enabled")]
        public string Ord_enabled { get; set; }
        [XmlElement(ElementName = "ord_required")]
        public string Ord_required { get; set; }
        [XmlElement(ElementName = "ord_create")]
        public string Ord_create { get; set; }
        [XmlElement(ElementName = "guid")]
        public string Guid { get; set; }
        [XmlElement(ElementName = "collection_enabled")]
        public string Collection_enabled { get; set; }
        [XmlElement(ElementName = "collection_required")]
        public string Collection_required { get; set; }
        [XmlElement(ElementName = "collection_create")]
        public string Collection_create { get; set; }
        [XmlElement(ElementName = "channel_enabled")]
        public string Channel_enabled { get; set; }
        [XmlElement(ElementName = "channel_required")]
        public string Channel_required { get; set; }
        [XmlElement(ElementName = "channel_create")]
        public string Channel_create { get; set; }
        [XmlElement(ElementName = "season_enabled")]
        public string Season_enabled { get; set; }
        [XmlElement(ElementName = "season_required")]
        public string Season_required { get; set; }
        [XmlElement(ElementName = "season_create")]
        public string Season_create { get; set; }
        [XmlElement(ElementName = "noreceipt_vatrate_id")]
        public string Noreceipt_vatrate_id { get; set; }
        [XmlElement(ElementName = "foreign_vatrate_id")]
        public string Foreign_vatrate_id { get; set; }
        [XmlElement(ElementName = "mileage_deduction")]
        public string Mileage_deduction { get; set; }
        [XmlElement(ElementName = "category_groupID")]
        public string Category_groupID { get; set; }
        [XmlElement(ElementName = "t_last_modified")]
        public string T_last_modified { get; set; }
        [XmlElement(ElementName = "default_account_type")]
        public string Default_account_type { get; set; }
        [XmlElement(ElementName = "message_tag")]
        public string Message_tag { get; set; }
    }

    [XmlRoot(ElementName = "NewDataSet")]
    public class CategoriesDataSet
    {
        [XmlElement(ElementName = "Categories")]
        public List<Categories> Categories { get; set; }
    }
}
