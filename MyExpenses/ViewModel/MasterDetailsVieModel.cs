using MyExpenses.BussinessLayer;
using MyExpenses.ResponseParsers;
using MyExpenses.ResponseParsers.Settings;
using MyExpenses.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyExpenses.ViewModel
{
  public  class MasterDetailsVieModel
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
      MasterDetailsBAL MasterDetailsBAL = null;
      public void GetClaimTypes(string UserGUID, string passwordShar)
      {
          MasterDetailsBAL = new MasterDetailsBAL();
          MasterDetailsBAL.GetClaimTypes(UserGUID, passwordShar);
          MasterDetailsBAL.OnGetClaimTypesCompleted += MasterDetailsBAL_OnGetClaimTypesCompleted;

      }
    async  void MasterDetailsBAL_OnGetClaimTypesCompleted(int arg1, string arg2)
      {
          MasterDetailsBAL.OnGetClaimTypesCompleted -= MasterDetailsBAL_OnGetClaimTypesCompleted;

          if (arg1 == 200 && !string.IsNullOrEmpty(arg2))
          {

              string resp = Utilities.RemoveNameSpace.RemoveAllNamespaces(arg2.ToString());
              XDocument document = XDocument.Parse(resp);
              var XMLresult = document.Root.Descendants("NewDataSet");
              ClaimTypesDataSet ClaimTypesDataSet = new ClaimTypesDataSet();
              foreach (var item in XMLresult)
              {
                  ClaimTypesDataSet = CommonFUnction.DeSerializeData<ClaimTypesDataSet>(ClaimTypesDataSet, item.ToString());
              //    break;
              }

              if (ClaimTypesDataSet != null && ClaimTypesDataSet.Table != null && ClaimTypesDataSet.Table.Count>0)
              {
                  await App.Connection.ExecuteAsync("delete from ClaimTypes");
                  await App.Connection.InsertAllAsync(ClaimTypesDataSet.Table);

              }

              if (OnGetClaimTypesCompleted != null)
                  OnGetClaimTypesCompleted(arg1, arg2);
             
          }
          else
          {
              if (OnGetClaimTypesCompleted != null)
                  OnGetClaimTypesCompleted(900, arg2);
          }
      }

      public void GetCurrencies(string UserGUID, string passwordShar)
      {
          MasterDetailsBAL = new MasterDetailsBAL();
          MasterDetailsBAL.GetCurrencies(UserGUID, passwordShar);
          MasterDetailsBAL.OnGetCurrenciesCompleted += MasterDetailsBAL_OnGetCurrenciesCompleted;
      }
     async void MasterDetailsBAL_OnGetCurrenciesCompleted(int arg1, string arg2)
      {
          MasterDetailsBAL.OnGetCurrenciesCompleted -= MasterDetailsBAL_OnGetCurrenciesCompleted;
          if (arg1 == 200 && !string.IsNullOrEmpty(arg2))
          {
              string resp = Utilities.RemoveNameSpace.RemoveAllNamespaces(arg2.ToString());
              XDocument document = XDocument.Parse(resp);
              var XMLresult = document.Root.Descendants("NewDataSet");
              CurrenciesDataSet CurrenciesDataSet = new CurrenciesDataSet();
              foreach (var item in XMLresult)
              {
                  CurrenciesDataSet = CommonFUnction.DeSerializeData<CurrenciesDataSet>(CurrenciesDataSet, item.ToString());
                  //    break;
              }

              if (CurrenciesDataSet != null && CurrenciesDataSet.Table != null && CurrenciesDataSet.Table.Count > 0)
              {
                  await App.Connection.ExecuteAsync("delete from Currencies");
                  await App.Connection.InsertAllAsync(CurrenciesDataSet.Table);

              }
              if (OnGetCurrenciesCompleted != null)
                  OnGetCurrenciesCompleted(arg1, arg2);
          }
          else
          {
              if (OnGetCurrenciesCompleted != null)
                  OnGetCurrenciesCompleted(900, arg2);
          }
      }

      public void GetCountries(string UserGUID, string passwordShar)
      {
          MasterDetailsBAL = new MasterDetailsBAL();
          MasterDetailsBAL.GetCountries(UserGUID, passwordShar);
          MasterDetailsBAL.OnGetCountriesCompleted += MasterDetailsBAL_OnGetCountriesCompleted;
      }
    async  void MasterDetailsBAL_OnGetCountriesCompleted(int arg1, string arg2)
      {
          MasterDetailsBAL.OnGetCountriesCompleted -= MasterDetailsBAL_OnGetCountriesCompleted;
          if (arg1 == 200 && !string.IsNullOrEmpty(arg2))
          {
              string resp = Utilities.RemoveNameSpace.RemoveAllNamespaces(arg2.ToString());
              XDocument document = XDocument.Parse(resp);
              var XMLresult = document.Root.Descendants("NewDataSet");
              CountriesDataSet CountriesDataSet = new CountriesDataSet();
              foreach (var item in XMLresult)
              {
                  CountriesDataSet = CommonFUnction.DeSerializeData<CountriesDataSet>(CountriesDataSet, item.ToString());
                  //    break;
              }

              if (CountriesDataSet != null && CountriesDataSet.Table != null && CountriesDataSet.Table.Count > 0)
              {
                  await App.Connection.ExecuteAsync("delete from Countries");
                  await App.Connection.InsertAllAsync(CountriesDataSet.Table);

              }
              if (OnGetCountriesCompleted != null)
                  OnGetCountriesCompleted(arg1, arg2);
          }
          else
          {
              if (OnGetCountriesCompleted != null)
                  OnGetCountriesCompleted(900, arg2);
          }
      }

      public void GetProjects(string UserGUID, string passwordShar)
      {
          MasterDetailsBAL = new MasterDetailsBAL();
          MasterDetailsBAL.GetProjects(UserGUID, passwordShar);
          MasterDetailsBAL.OnGetProjectsCompleted += MasterDetailsBAL_OnGetProjectsCompleted;
      }
     async void MasterDetailsBAL_OnGetProjectsCompleted(int arg1, string arg2)
      {
          MasterDetailsBAL.OnGetProjectsCompleted -= MasterDetailsBAL_OnGetProjectsCompleted;
          if (arg1 == 200 && !string.IsNullOrEmpty(arg2))
          {
              string resp = Utilities.RemoveNameSpace.RemoveAllNamespaces(arg2.ToString());
              XDocument document = XDocument.Parse(resp);
              var XMLresult = document.Root.Descendants("NewDataSet");
              ProjectsDataSet ProjectsDataSet = new ProjectsDataSet();
              foreach (var item in XMLresult)
              {
                  ProjectsDataSet = CommonFUnction.DeSerializeData<ProjectsDataSet>(ProjectsDataSet, item.ToString());
                  //    break;
              }

              if (ProjectsDataSet != null && ProjectsDataSet.Table != null && ProjectsDataSet.Table.Count > 0)
              {
                  await App.Connection.ExecuteAsync("delete from Projects");
                  await App.Connection.InsertAllAsync(ProjectsDataSet.Table);

              }
              if (OnGetProjectsCompleted != null)
                  OnGetProjectsCompleted(arg1, arg2);
          }
          else
          {
              if (OnGetProjectsCompleted != null)
                  OnGetProjectsCompleted(900, arg2);
          }
      }

     public void GetCategories(string UserGUID, string passwordShar)
     {
         MasterDetailsBAL = new MasterDetailsBAL();
         MasterDetailsBAL.GetCategories(UserGUID, passwordShar);
         MasterDetailsBAL.OnGetCategoriesCompleted += MasterDetailsBAL_OnGetCategoriesCompleted;
     }
     async void MasterDetailsBAL_OnGetCategoriesCompleted(int arg1, string arg2)
     {
         MasterDetailsBAL.OnGetCategoriesCompleted -= MasterDetailsBAL_OnGetCategoriesCompleted;
         if (arg1 == 200 && !string.IsNullOrEmpty(arg2))
         {
             string resp = Utilities.RemoveNameSpace.RemoveAllNamespaces(arg2.ToString());
             XDocument document = XDocument.Parse(resp);
             var XMLresult = document.Root.Descendants("NewDataSet");
             CategoriesDataSet CategoriesDataSet = new CategoriesDataSet();
             foreach (var item in XMLresult)
             {
                 CategoriesDataSet = CommonFUnction.DeSerializeData<CategoriesDataSet>(CategoriesDataSet, item.ToString());
                 //    break;
             }

             if (CategoriesDataSet != null && CategoriesDataSet.Categories != null && CategoriesDataSet.Categories.Count > 0)
             {
                 await App.Connection.ExecuteAsync("delete from Categories");
                 await App.Connection.InsertAllAsync(CategoriesDataSet.Categories);
             }
             if (OnGetCategoriesCompleted != null)
                 OnGetCategoriesCompleted(arg1, arg2);
         }
         else
         {
             if (OnGetCategoriesCompleted != null)
                 OnGetCategoriesCompleted(900, arg2);
         }
     }

     public void GetSettings(string UserGUID, string passwordShar)
     {
         MasterDetailsBAL = new MasterDetailsBAL();
         MasterDetailsBAL.GetSettings(UserGUID, passwordShar);
         MasterDetailsBAL.OnGetSettingsCompleted += MasterDetailsBAL_OnGetSettingsCompleted;
     }
     async void MasterDetailsBAL_OnGetSettingsCompleted(int arg1, string arg2)
     {
         MasterDetailsBAL.OnGetSettingsCompleted -= MasterDetailsBAL_OnGetSettingsCompleted;
         if (arg1 == 200 && !string.IsNullOrEmpty(arg2))
         {
             string resp = Utilities.RemoveNameSpace.RemoveAllNamespaces(arg2.ToString());
             XDocument document = XDocument.Parse(resp);
             var XMLresult = document.Root.Descendants("dsMobileSettings");
             DsMobileSettings DsMobileSettings = new DsMobileSettings();
             foreach (var item in XMLresult)
             {
                 DsMobileSettings = CommonFUnction.DeSerializeData<DsMobileSettings>(DsMobileSettings, item.ToString());
                     break;
             }

             if (DsMobileSettings != null && DsMobileSettings.MobileSettings != null )
             {
                 StateUtilities.MobileSettings = DsMobileSettings.MobileSettings;
                 await App.Connection.ExecuteAsync("delete from MobileSettings");
                 await App.Connection.InsertAsync(DsMobileSettings.MobileSettings);

                 if(DsMobileSettings.MobileSettings.AuthLevel.ToUpper()=="REQ")
                     AppStorage.SaveKeyValue(AppConstants.AUTHORIZED, 1);
                 else
                     AppStorage.SaveKeyValue(AppConstants.AUTHORIZED, 0);
             }
             if (OnGetSettingsCompleted != null)
                 OnGetSettingsCompleted(arg1, arg2);
         }
         else
         {
             if (OnGetSettingsCompleted != null)
                 OnGetSettingsCompleted(900, arg2);
         }
     }

     public void GetAccounts(string UserGUID, string passwordShar)
     {
         MasterDetailsBAL = new MasterDetailsBAL();
         MasterDetailsBAL.GetAccounts(UserGUID, passwordShar);
         MasterDetailsBAL.OnGetAccountsCompleted += MasterDetailsBAL_OnGetAccountsCompleted;
     }
     async void MasterDetailsBAL_OnGetAccountsCompleted(int arg1, string arg2)
     {
         MasterDetailsBAL.OnGetAccountsCompleted -= MasterDetailsBAL_OnGetAccountsCompleted;
         if (arg1 == 200 && !string.IsNullOrEmpty(arg2))
         {
             string resp = Utilities.RemoveNameSpace.RemoveAllNamespaces(arg2.ToString());
             XDocument document = XDocument.Parse(resp);
             var XMLresult = document.Root.Descendants("NewDataSet");
             MyExpenses.ResponseParsers.Accounts.NewDataSet Accounts = new MyExpenses.ResponseParsers.Accounts.NewDataSet();
             foreach (var item in XMLresult)
             {
                 Accounts = CommonFUnction.DeSerializeData<MyExpenses.ResponseParsers.Accounts.NewDataSet>(Accounts, item.ToString());
                 //    break;
             }

             if (Accounts != null )
             {
                 StateUtilities.CurrentAccount = Accounts.Accounts;
                 await App.Connection.ExecuteAsync("delete from Accounts");
                 await App.Connection.InsertAsync(Accounts.Accounts);
             }
             if (OnGetAccountsCompleted != null)
                 OnGetAccountsCompleted(arg1, arg2);
         }
         else
         {
             if (OnGetAccountsCompleted != null)
                 OnGetAccountsCompleted(900, arg2);
         }
     }

     public void GetCostcentres(string UserGUID, string passwordShar)
     {
         MasterDetailsBAL = new MasterDetailsBAL();
         MasterDetailsBAL.GetCostcentres(UserGUID, passwordShar);
         MasterDetailsBAL.OnGetCostcentresCompleted += MasterDetailsBAL_OnGetCostcentresCompleted;
     }
     async void MasterDetailsBAL_OnGetCostcentresCompleted(int arg1, string arg2)
     {
         MasterDetailsBAL.OnGetCostcentresCompleted -= MasterDetailsBAL_OnGetCostcentresCompleted;
         if (arg1 == 200 && !string.IsNullOrEmpty(arg2))
         {
             string resp = Utilities.RemoveNameSpace.RemoveAllNamespaces(arg2.ToString());
             XDocument document = XDocument.Parse(resp);
             var XMLresult = document.Root.Descendants("NewDataSet");
             MyExpenses.ResponseParsers.CostCentres.NewDataSet NewDataSet = new MyExpenses.ResponseParsers.CostCentres.NewDataSet();
             foreach (var item in XMLresult)
             {
                 NewDataSet = CommonFUnction.DeSerializeData<MyExpenses.ResponseParsers.CostCentres.NewDataSet>(NewDataSet, item.ToString());
                 break;
             }

             if (NewDataSet != null && NewDataSet.Table != null && NewDataSet.Table.Count > 0)
             {
                 await App.Connection.ExecuteAsync("delete from CostCentre");
                 await App.Connection.InsertAllAsync(NewDataSet.Table);
             }
             if (OnGetCostcentresCompleted != null)
                 OnGetCostcentresCompleted(arg1, arg2);
         }
         else
         {
             if (OnGetCostcentresCompleted != null)
                 OnGetCostcentresCompleted(900, arg2);
         }
     }

     public void GetAccount(string UserGUID, string passwordShar)
     {
         MasterDetailsBAL = new MasterDetailsBAL();
         MasterDetailsBAL.GetAccount(UserGUID, passwordShar);
         MasterDetailsBAL.OnGetAccountCompleted += MasterDetailsBAL_OnGetAccountCompleted;
     }
     async void MasterDetailsBAL_OnGetAccountCompleted(int arg1, string arg2)
     {
         MasterDetailsBAL.OnGetAccountCompleted -= MasterDetailsBAL_OnGetAccountCompleted;
         if (arg1 == 200 && !string.IsNullOrEmpty(arg2))
         {
             string resp = Utilities.RemoveNameSpace.RemoveAllNamespaces(arg2.ToString());
             XDocument document = XDocument.Parse(resp);
             var XMLresult = document.Root.Descendants("NewDataSet");
             MyExpenses.ResponseParsers.Account.NewDataSet Accounts = new MyExpenses.ResponseParsers.Account.NewDataSet();
             foreach (var item in XMLresult)
             {
                 Accounts = CommonFUnction.DeSerializeData<MyExpenses.ResponseParsers.Account.NewDataSet>(Accounts, item.ToString());
                 //    break;
             }

             if (Accounts != null && Accounts.Table != null && Accounts.Table.Count>0)
             {
                // StateUtilities.CurrentAccount = Accounts;
                 await App.Connection.ExecuteAsync("delete from Account");
                 await App.Connection.InsertAllAsync(Accounts.Table);
             }
             if (OnGetAccountCompleted != null)
                 OnGetAccountCompleted(arg1, arg2);
         }
         else
         {
             if (OnGetAccountCompleted != null)
                 OnGetAccountCompleted(900, arg2);
         }
     }

     public void GetVatRates(string UserGUID, string passwordShar)
     {
         MasterDetailsBAL = new MasterDetailsBAL();
         MasterDetailsBAL.GetVatRates(UserGUID, passwordShar);
         MasterDetailsBAL.OnGetVatRatesCompleted += MasterDetailsBAL_OnGetVatRatesCompleted;
     }
     async void MasterDetailsBAL_OnGetVatRatesCompleted(int arg1, string arg2)
     {
         MasterDetailsBAL.OnGetAccountCompleted -= MasterDetailsBAL_OnGetVatRatesCompleted;
         if (arg1 == 200 && !string.IsNullOrEmpty(arg2))
         {
             string resp = Utilities.RemoveNameSpace.RemoveAllNamespaces(arg2.ToString());
             XDocument document = XDocument.Parse(resp);
             var XMLresult = document.Root.Descendants("NewDataSet");
             MyExpenses.ResponseParsers.VatRates.NewDataSet Accounts = new MyExpenses.ResponseParsers.VatRates.NewDataSet();
             foreach (var item in XMLresult)
             {
                 Accounts = CommonFUnction.DeSerializeData<MyExpenses.ResponseParsers.VatRates.NewDataSet>(Accounts, item.ToString());
                 //    break;
             }

             if (Accounts != null && Accounts.Table != null && Accounts.Table.Count>0)
             {
                
                 await App.Connection.ExecuteAsync("delete from VatRates");
                 await App.Connection.InsertAllAsync(Accounts.Table);
             }
             if (OnGetVatRatesCompleted != null)
                 OnGetVatRatesCompleted(arg1, arg2);
         }
         else
         {
             if (OnGetVatRatesCompleted != null)
                 OnGetVatRatesCompleted(900, arg2);
         }
     }

    }
}
