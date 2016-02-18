using MyExpenses.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.WebAccessLayer
{
    public class BookingWA : WebProvider
    {

        public void CheckLogin(string body)
        {
            Dictionary<String, string> parameters = new Dictionary<string, string>();
            parameters.Add("SoapAction", "Login");
            DoPostRequest(AppConstants.BaseURl, parameters, body, "POST");

         //   DoPostRequest("https://halcyontek.myexpensesonline.co.uk/webservices/dx.data/dxdatamobile.asmx?wsdl", parameters, body, "POST");
        }
        public void GetClaimTypes(string body)
        {
            Dictionary<String, string> parameters = new Dictionary<string, string>();
            parameters.Add("SoapAction", "GetClaimTypes");
            DoPostRequest(AppConstants.BaseURl, parameters, body, "POST");
        }

        public void SubmitClaim(string body)
        {
            Dictionary<String, string> parameters = new Dictionary<string, string>();
            parameters.Add("SoapAction", "SubmitClaim");
            DoPostRequest(AppConstants.BaseURl, parameters, body, "POST");
        }
        public void GetCurrencies(string body)
        {
            Dictionary<String, string> parameters = new Dictionary<string, string>();
            parameters.Add("SoapAction", "GetCurrencies");
            DoPostRequest(AppConstants.BaseURl, parameters, body, "POST");
        }
        public void GetCountries(string body)
        {
            Dictionary<String, string> parameters = new Dictionary<string, string>();
            parameters.Add("SoapAction", "GetCountries");
            DoPostRequest(AppConstants.BaseURl, parameters, body, "POST");
        }
        public void DeleteClaimHeader(string body)
        {
            Dictionary<String, string> parameters = new Dictionary<string, string>();
            parameters.Add("SoapAction", "DeleteClaimHeader");
            DoPostRequest(AppConstants.BaseURl, parameters, body, "POST");
        }
        public void DeleteClaimLine(string body)
        {
            Dictionary<String, string> parameters = new Dictionary<string, string>();
            parameters.Add("SoapAction", "DeleteClaimLine");
            DoPostRequest(AppConstants.BaseURl, parameters, body, "POST");
        }
        public void MoveClaimLine(string body)
        {
            Dictionary<String, string> parameters = new Dictionary<string, string>();
            parameters.Add("SoapAction", "MoveClaimLine");
            DoPostRequest(AppConstants.BaseURl, parameters, body, "POST");
        }
        public void GetProjects(string body)
        {
            Dictionary<String, string> parameters = new Dictionary<string, string>();
            parameters.Add("SoapAction", "GetProjects");
            DoPostRequest(AppConstants.BaseURl, parameters, body, "POST");
        }

        public void GetCategories(string body)
        {
            Dictionary<String, string> parameters = new Dictionary<string, string>();
            parameters.Add("SoapAction", "GetCategories");
            DoPostRequest(AppConstants.BaseURl, parameters, body, "POST");
        }
        public void SetLineApproval(string body)
        {
            Dictionary<String, string> parameters = new Dictionary<string, string>();
            parameters.Add("SoapAction", "SetLineApproval");
            DoPostRequest(AppConstants.BaseURl, parameters, body, "POST");
        }
        public void GetSettings(string body)
        {
            Dictionary<String, string> parameters = new Dictionary<string, string>();
            parameters.Add("SoapAction", "GetMobileSettings");
            DoPostRequest(AppConstants.BaseURl, parameters, body, "POST");
        }
        public void GetAccounts(string body)
        {
            Dictionary<String, string> parameters = new Dictionary<string, string>();
            parameters.Add("SoapAction", "GetAccounts");
            DoPostRequest(AppConstants.BaseURl, parameters, body, "POST");
        }
        public void GetCostcentres(string body)
        {
            Dictionary<String, string> parameters = new Dictionary<string, string>();
            parameters.Add("SoapAction", "GetCostcentres");
            DoPostRequest(AppConstants.BaseURl, parameters, body, "POST");
        }

        public void GetAccount(string body)
        {
            Dictionary<String, string> parameters = new Dictionary<string, string>();
            parameters.Add("SoapAction", "GetAccount");
            DoPostRequest(AppConstants.BaseURl, parameters, body, "POST");
        }
        public void GetVatRates(string body)
        {
            Dictionary<String, string> parameters = new Dictionary<string, string>();
            parameters.Add("SoapAction", "GetVatRates");
            DoPostRequest(AppConstants.BaseURl, parameters, body, "POST");
        }

        public void CreateClaimHeader(string body)
        {
            Dictionary<String, string> parameters = new Dictionary<string, string>();
            parameters.Add("SoapAction", "CreateClaimHeader");
            DoPostRequest(AppConstants.BaseURl, parameters, body, "POST");
        }

        public void CreateLine(string body)
        {
            Dictionary<String, string> parameters = new Dictionary<string, string>();
            parameters.Add("SoapAction", "CreateLine");
            DoPostRequest(AppConstants.BaseURl, parameters, body, "POST");
        }
        public void UpdateLine(string body)
        {
            Dictionary<String, string> parameters = new Dictionary<string, string>();
            parameters.Add("SoapAction", "UpdateLine");
            DoPostRequest(AppConstants.BaseURl, parameters, body, "POST");
        }
    }
}
