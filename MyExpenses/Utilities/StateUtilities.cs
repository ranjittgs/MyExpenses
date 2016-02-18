using MyExpenses.ResponseParsers;
using MyExpenses.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Utilities
{
   public static class StateUtilities
    {

       public static MyClaimsViewModel MyClaimsViewModel { set; get; }
       public static List<ClaimDetailsDT> ListClaimDetailsDT { set; get; }

       public static MyExpenses.ResponseParsers.Headers LoginHeaders { set; get; }

       public static List<Currencies> ListCurrencies { set; get; }
       public static bool IsAnythingModified = false;
       public static List<Categories> ListCategories { set; get; }
       public static List<MyExpenses.ResponseParsers.AuthClaims.AuthClaimDetailsDT> ListAuthClaimDetailsDT { set; get; }

       public static MyExpenses.Model.BussinessObjects.ClaimDetails CurrentClaimDetails { set; get; }

       public static List<Categories> SelectedCatlist { set; get; }
       public static MyExpenses.ResponseParsers.Accounts.Accounts CurrentAccount { set; get; }
       public static MyExpenses.ResponseParsers.Settings.MobileSettings MobileSettings { set; get; }
       public static List<Countries> CountriesList { set; get; }

       public static Currencies SelectedCurrency { set; get; }

       public static List<MyExpenses.ResponseParsers.VatRates.VatRates> ListVatRates{ set; get; }
    }
}
