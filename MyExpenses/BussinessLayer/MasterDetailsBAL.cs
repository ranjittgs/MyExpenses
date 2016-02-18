using MyExpenses.Common;
using MyExpenses.WebAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.BussinessLayer
{
 public   class MasterDetailsBAL
    {
        public event Action<int, string> OnGetClaimTypesCompleted;
        public event Action<int, string> OnGetCurrenciesCompleted;
        public event Action<int, string> OnGetCountriesCompleted;
        public event Action<int, string> OnGetProjectsCompleted;
        public event Action<int, string> OnGetCategoriesCompleted;
        public event Action<int, string> OnGetSettingsCompleted;
        public event Action<int, string> OnGetCostcentresCompleted;
        public event Action<int, string> OnGetAccountsCompleted;
        public event Action<int, string> OnGetAccountCompleted;
        public event Action<int, string> OnGetVatRatesCompleted;
        BookingWA bookingWA = null;
        public void GetClaimTypes( string UserGUID, string password)
        {
            if (CommonFunctions.IsInternetAvailable())
            {
                if (bookingWA == null)
                bookingWA = new BookingWA();

                bookingWA.GetClaimTypes(Utilities.BuildRequestXml.GetClaimTypes(UserGUID, password));
                bookingWA.OnWebDataAccessEvent += bookingWA_OnWebDataAccessEvent;
            }
            else
            {
                if (OnGetClaimTypesCompleted!=null)
                    OnGetClaimTypesCompleted(900, null);
            }
        }
        void bookingWA_OnWebDataAccessEvent(object sender, WebDataAccessEventArgs e)
        {
            bookingWA.OnWebDataAccessEvent -= bookingWA_OnWebDataAccessEvent;
            if (e.WebAccessStatus.StatusCode == 200)
            {
                if (OnGetClaimTypesCompleted != null)
                OnGetClaimTypesCompleted(e.WebAccessStatus.StatusCode, e.Data);
            }
            else
            {
                if (OnGetClaimTypesCompleted != null)
                OnGetClaimTypesCompleted(e.WebAccessStatus.StatusCode, null);
            }
        }
        public void GetCurrencies(string UserGUID, string password)
        {
            if (CommonFunctions.IsInternetAvailable())
            {
                if (bookingWA == null)
                bookingWA = new BookingWA();

                bookingWA.GetCurrencies(Utilities.BuildRequestXml.GetCurrencies(UserGUID, password));
                bookingWA.OnWebDataAccessEvent += bookingWA_OnWebDataAccessEvent1;
            }
            else
            {
                if (OnGetCurrenciesCompleted != null)
                    OnGetCurrenciesCompleted(900, null);
            }
        }
        void bookingWA_OnWebDataAccessEvent1(object sender, WebDataAccessEventArgs e)
        {
            bookingWA.OnWebDataAccessEvent -= bookingWA_OnWebDataAccessEvent1;
            if (e.WebAccessStatus.StatusCode == 200)
            {
                if (OnGetCurrenciesCompleted != null)
                    OnGetCurrenciesCompleted(e.WebAccessStatus.StatusCode, e.Data);
            }
            else
            {
                if (OnGetCurrenciesCompleted != null)
                    OnGetCurrenciesCompleted(e.WebAccessStatus.StatusCode, null);
            }
        }

        public void GetCountries(string UserGUID, string password)
        {
            if (CommonFunctions.IsInternetAvailable())
            {
                if (bookingWA == null)
                bookingWA = new BookingWA();

                bookingWA.GetCountries(Utilities.BuildRequestXml.GetCountries(UserGUID, password));
                bookingWA.OnWebDataAccessEvent += bookingWA_OnWebDataAccessEvent2;
            }
            else
            {
                if (OnGetCountriesCompleted != null)
                    OnGetCountriesCompleted(900, null);
            }
        }
        void bookingWA_OnWebDataAccessEvent2(object sender, WebDataAccessEventArgs e)
        {
            bookingWA.OnWebDataAccessEvent -= bookingWA_OnWebDataAccessEvent2;
            if (e.WebAccessStatus.StatusCode == 200)
            {
                if (OnGetCountriesCompleted != null)
                    OnGetCountriesCompleted(e.WebAccessStatus.StatusCode, e.Data);
            }
            else
            {
                if (OnGetCountriesCompleted != null)
                    OnGetCountriesCompleted(e.WebAccessStatus.StatusCode, null);
            }
        }

        public void GetProjects(string UserGUID, string password)
        {
            if (CommonFunctions.IsInternetAvailable())
            {
                if (bookingWA == null)
                bookingWA = new BookingWA();

                bookingWA.GetProjects(Utilities.BuildRequestXml.GetProjects(UserGUID, password));
                bookingWA.OnWebDataAccessEvent += bookingWA_OnWebDataAccessEvent3;
            }
            else
            {
                if (OnGetProjectsCompleted != null)
                    OnGetProjectsCompleted(900, null);
            }
        }
        void bookingWA_OnWebDataAccessEvent3(object sender, WebDataAccessEventArgs e)
        {
            bookingWA.OnWebDataAccessEvent -= bookingWA_OnWebDataAccessEvent3;
            if (e.WebAccessStatus.StatusCode == 200)
            {
                if (OnGetProjectsCompleted != null)
                    OnGetProjectsCompleted(e.WebAccessStatus.StatusCode, e.Data);
            }
            else
            {
                if (OnGetProjectsCompleted != null)
                    OnGetProjectsCompleted(e.WebAccessStatus.StatusCode, null);
            }
        }


        public void GetCategories(string UserGUID, string password)
        {
            if (CommonFunctions.IsInternetAvailable())
            {
                if (bookingWA==null)
                bookingWA = new BookingWA();

                bookingWA.GetCategories(Utilities.BuildRequestXml.GetCategories(UserGUID, password));
                bookingWA.OnWebDataAccessEvent += bookingWA_OnWebDataAccessEvent4;
            }
            else
            {
                if (OnGetCategoriesCompleted != null)
                    OnGetCategoriesCompleted(900, null);
            }
        }
        void bookingWA_OnWebDataAccessEvent4(object sender, WebDataAccessEventArgs e)
        {
            bookingWA.OnWebDataAccessEvent -= bookingWA_OnWebDataAccessEvent4;
            if (e.WebAccessStatus.StatusCode == 200)
            {
                if (OnGetCategoriesCompleted != null)
                    OnGetCategoriesCompleted(e.WebAccessStatus.StatusCode, e.Data);
            }
            else
            {
                if (OnGetCategoriesCompleted != null)
                    OnGetCategoriesCompleted(e.WebAccessStatus.StatusCode, null);
            }
        }


        public void GetSettings(string UserGUID, string password)
        {
            if (CommonFunctions.IsInternetAvailable())
            {
                if (bookingWA == null)
                    bookingWA = new BookingWA();

                bookingWA.GetSettings(Utilities.BuildRequestXml.GetMobileSettings(UserGUID, password));
                bookingWA.OnWebDataAccessEvent += bookingWA_OnWebDataAccessEvent5;
            }
            else
            {
                if (OnGetSettingsCompleted != null)
                    OnGetSettingsCompleted(900, null);
            }
        }
        void bookingWA_OnWebDataAccessEvent5(object sender, WebDataAccessEventArgs e)
        {
            bookingWA.OnWebDataAccessEvent -= bookingWA_OnWebDataAccessEvent5;
            if (e.WebAccessStatus.StatusCode == 200)
            {
                if (OnGetSettingsCompleted != null)
                    OnGetSettingsCompleted(e.WebAccessStatus.StatusCode, e.Data);
            }
            else
            {
                if (OnGetSettingsCompleted != null)
                    OnGetSettingsCompleted(e.WebAccessStatus.StatusCode, null);
            }
        }

        public void GetAccounts(string UserGUID, string password)
        {
            if (CommonFunctions.IsInternetAvailable())
            {
                if (bookingWA == null)
                    bookingWA = new BookingWA();

                bookingWA.GetAccounts(Utilities.BuildRequestXml.GetAccounts(UserGUID, password));
                bookingWA.OnWebDataAccessEvent += bookingWA_OnWebDataAccessEvent6;
            }
            else
            {
                if (OnGetAccountsCompleted != null)
                    OnGetAccountsCompleted(900, null);
            }
        }
        void bookingWA_OnWebDataAccessEvent6(object sender, WebDataAccessEventArgs e)
        {
            bookingWA.OnWebDataAccessEvent -= bookingWA_OnWebDataAccessEvent6;
            if (e.WebAccessStatus.StatusCode == 200)
            {
                if (OnGetAccountsCompleted != null)
                    OnGetAccountsCompleted(e.WebAccessStatus.StatusCode, e.Data);
            }
            else
            {
                if (OnGetAccountsCompleted != null)
                    OnGetAccountsCompleted(e.WebAccessStatus.StatusCode, null);
            }
        }

        public void GetCostcentres(string UserGUID, string password)
        {
            if (CommonFunctions.IsInternetAvailable())
            {
                if (bookingWA == null)
                    bookingWA = new BookingWA();

                bookingWA.GetCostcentres(Utilities.BuildRequestXml.GetCostcentres(UserGUID, password));
                bookingWA.OnWebDataAccessEvent += bookingWA_OnWebDataAccessEvent7;
            }
            else
            {
                if (OnGetCostcentresCompleted != null)
                    OnGetCostcentresCompleted(900, null);
            }
        }
        void bookingWA_OnWebDataAccessEvent7(object sender, WebDataAccessEventArgs e)
        {
            bookingWA.OnWebDataAccessEvent -= bookingWA_OnWebDataAccessEvent7;
            if (e.WebAccessStatus.StatusCode == 200)
            {
                if (OnGetCostcentresCompleted != null)
                    OnGetCostcentresCompleted(e.WebAccessStatus.StatusCode, e.Data);
            }
            else
            {
                if (OnGetCostcentresCompleted != null)
                    OnGetCostcentresCompleted(e.WebAccessStatus.StatusCode, null);
            }
        }

        public void GetAccount(string UserGUID, string password)
        {
            if (CommonFunctions.IsInternetAvailable())
            {
                if (bookingWA == null)
                    bookingWA = new BookingWA();

                bookingWA.GetAccount(Utilities.BuildRequestXml.GetAccount(UserGUID, password));
                bookingWA.OnWebDataAccessEvent += bookingWA_OnWebDataAccessEvent8;
            }
            else
            {
                if (OnGetAccountCompleted != null)
                    OnGetAccountCompleted(900, null);
            }
        }
        void bookingWA_OnWebDataAccessEvent8(object sender, WebDataAccessEventArgs e)
        {
            bookingWA.OnWebDataAccessEvent -= bookingWA_OnWebDataAccessEvent8;
            if (e.WebAccessStatus.StatusCode == 200)
            {
                if (OnGetAccountCompleted != null)
                    OnGetAccountCompleted(e.WebAccessStatus.StatusCode, e.Data);
            }
            else
            {
                if (OnGetAccountCompleted != null)
                    OnGetAccountCompleted(e.WebAccessStatus.StatusCode, null);
            }
        }
        public void GetVatRates(string UserGUID, string password)
        {
            if (CommonFunctions.IsInternetAvailable())
            {
                if (bookingWA == null)
                    bookingWA = new BookingWA();

                bookingWA.GetVatRates(Utilities.BuildRequestXml.GetVatRates(UserGUID, password));
                bookingWA.OnWebDataAccessEvent += bookingWA_OnWebDataAccessEvent9;
            }
            else
            {
                if (OnGetVatRatesCompleted != null)
                    OnGetVatRatesCompleted(900, null);
            }
        }
        void bookingWA_OnWebDataAccessEvent9(object sender, WebDataAccessEventArgs e)
        {
            bookingWA.OnWebDataAccessEvent -= bookingWA_OnWebDataAccessEvent9;
            if (e.WebAccessStatus.StatusCode == 200)
            {
                if (OnGetVatRatesCompleted != null)
                    OnGetVatRatesCompleted(e.WebAccessStatus.StatusCode, e.Data);
            }
            else
            {
                if (OnGetVatRatesCompleted != null)
                    OnGetVatRatesCompleted(e.WebAccessStatus.StatusCode, null);
            }
        }
  
 
 }
}
