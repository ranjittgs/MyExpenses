using MyExpenses.ResponseParsers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.DataAccessLayer
{
  public  class DB
    {
      public static void CreateDbAsync()
      {
          try
          {
              Task task = Task.Run(async () =>
              {
                  App.Connection = new SQLiteAsyncConnection("MyExpenses.db");
                  var tblClaimHeadersDTTask = App.Connection.CreateTableAsync<ClaimHeadersDT>();
                  var tblClaimDetailsDTTask = App.Connection.CreateTableAsync<ClaimDetailsDT>();
                  var tblLoginHeadersDTTask = App.Connection.CreateTableAsync<MyExpenses.ResponseParsers.Headers>();
                  var tblClaimTypesTask = App.Connection.CreateTableAsync<ClaimTypes>();
                  var tblCurrenciesTask = App.Connection.CreateTableAsync<Currencies>();
                  var tblCountriesTask = App.Connection.CreateTableAsync<Countries>();
                  var tblProjectsTask = App.Connection.CreateTableAsync<Projects>();
                  var tblCategoriesTask = App.Connection.CreateTableAsync<Categories>();
                  var tblSettingsTask = App.Connection.CreateTableAsync<MyExpenses.ResponseParsers.Settings.MobileSettings>();
                  var tblAuthClaimHeadersDTTask = App.Connection.CreateTableAsync<MyExpenses.ResponseParsers.AuthClaims.AuthClaimHeadersDT>();
                  var tblAuthClaimDetailsDTTask = App.Connection.CreateTableAsync<MyExpenses.ResponseParsers.AuthClaims.AuthClaimDetailsDT>();
                  var tblAccountsTask = App.Connection.CreateTableAsync<MyExpenses.ResponseParsers.Accounts.Accounts>();
                  var tblCostCentersDTTask = App.Connection.CreateTableAsync<MyExpenses.ResponseParsers.CostCentres.CostCentre>();
                  var tblAccountTask = App.Connection.CreateTableAsync<MyExpenses.ResponseParsers.Account.Account>();
                  var tblVatRatesTask = App.Connection.CreateTableAsync<MyExpenses.ResponseParsers.VatRates.VatRates>();
                  await Task.WhenAll(new Task[] { tblClaimHeadersDTTask, tblClaimDetailsDTTask, tblLoginHeadersDTTask, tblClaimTypesTask, tblCurrenciesTask, tblCountriesTask, tblProjectsTask, tblCategoriesTask, tblSettingsTask, tblAuthClaimHeadersDTTask, tblAuthClaimDetailsDTTask, tblAccountsTask, tblCostCentersDTTask, tblAccountTask, tblVatRatesTask });
              });
              task.ConfigureAwait(false);
              task.Wait();
          }
          catch (Exception ex)
          { }
      }
    }
}
