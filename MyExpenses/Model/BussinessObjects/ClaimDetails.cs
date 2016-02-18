using MyExpenses.ResponseParsers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Model.BussinessObjects
{
  public  class ClaimDetails
    {
        public string ClaimID { set; get; }
        public string UniqueID { set; get; }
        public string Headerdescription { set; get; }
        public string claimType { set; get; }
        public string dateCreated { set; get; }
        public string categoryID { set; get; }

        public string categoryName { set; get; }
        public string amount { set; get; }
        public string currency { set; get; }
        public string vat { set; get; }
        public string description { set; get; }
        public string additionalPeople { set; get; }
        public string vatRateID { set; get; }
        public string conversionRate { set; get; }
        public string baseAmount { set; get; }
        public string receiptReason { set; get; }
        public string receipt { set; get; }
        public string reference { set; get; }
        public string countryCode { set; get; }
        public bool vatReceiptAvailable { set; get; }
        public string costCenterGUID { set; get; }
        public string projectGUID { set; get; }
        public string orderNo { set; get; }
        public string channel { set; get; }
        public string collection { set; get; }
        public string season { set; get; }
        public string accountGUID { set; get; }
        public DateTime ClaimLineDate { set; get; }
        public string VATPercentage { set; get; }
        public ObservableCollection<Countries> listCountries { set; get; }
    }
}
