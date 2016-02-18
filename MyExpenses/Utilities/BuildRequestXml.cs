

using MyExpenses.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using System.Threading;
using System.Globalization;

namespace MyExpenses.Utilities
{
    public static class BuildRequestXml
    {
        public static StringBuilder ReqXml = null;
//        public static string LogonXML(Logon Logon)
//        {
//            ReqXml = new StringBuilder();
//            ReqXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
//            ReqXml.Append("<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\">");
//            ReqXml.Append("<s:Header>");
//            ReqXml.Append("<h:ContractVersion xmlns:h=\"http://schemas.navitaire.com/WebServices\">");
//            ReqXml.Append("346"); //Code to add
//            ReqXml.Append("</h:ContractVersion>");
//            ReqXml.Append("</s:Header>");
//            ReqXml.Append("<s:Body>");
//            ReqXml.Append("<LogonRequest xmlns=\"http://schemas.navitaire.com/WebServices/ServiceContracts/SessionService\">");
//            ReqXml.Append("<logonRequestData xmlns:a=\"http://schemas.navitaire.com/WebServices/DataContracts/Session\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\">");
//            ReqXml.AppendFormat("<a:RoleCode>{0}</a:RoleCode>", "APMO"); //Code
//            ReqXml.Append("</logonRequestData>");
//            ReqXml.Append("</LogonRequest>");
//            ReqXml.Append("</s:Body>");
//            ReqXml.Append("</s:Envelope>");
//            return ReqXml.ToString();
//        }

        public static string GetLoginRequest(string URL, string UserName, string password)
        {
            ReqXml = new StringBuilder();
            ReqXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            ReqXml.Append("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");            
            ReqXml.Append("<soap:Body>");
            ReqXml.Append("<Login  xmlns=\"http://pointprogress.com/\">");
            ReqXml.AppendFormat("<_login>{0}</_login>",UserName);
            ReqXml.AppendFormat("<password>{0}</password>", password);
            ReqXml.Append("</Login>");
            ReqXml.Append("</soap:Body>");
            ReqXml.Append("</soap:Envelope>");
            return ReqXml.ToString();
        }
        public static string GetClaimTypes(string UserGUID, string passwordShar)
        {
            string DateFrom = DateTime.Now.AddMonths(-12).ToString("yyyy-MM-ddTHH:mm:ss") + ".000Z";
            ReqXml = new StringBuilder();
            ReqXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            ReqXml.Append("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            ReqXml.Append("<soap:Body>");
            ReqXml.Append("<GetClaimTypes   xmlns=\"http://pointprogress.com/\">");
            ReqXml.AppendFormat("<userGuid>{0}</userGuid>", UserGUID);
            ReqXml.AppendFormat("<passwordShar>{0}</passwordShar>", passwordShar);
            ReqXml.AppendFormat("<fromDate>{0}</fromDate>", DateFrom);
            ReqXml.Append("</GetClaimTypes>");
            ReqXml.Append("</soap:Body>");
            ReqXml.Append("</soap:Envelope>");
            return ReqXml.ToString();
        }

        public static string SubmitClaim(string UserGUID, string passwordShar,string ClaimID)
        {
          //  string DateFrom = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + ".000Z";
            ReqXml = new StringBuilder();
            ReqXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            ReqXml.Append("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            ReqXml.Append("<soap:Body>");
            ReqXml.Append("<SubmitClaim    xmlns=\"http://pointprogress.com/\">");
            ReqXml.AppendFormat("<userGuid>{0}</userGuid>", UserGUID);
            ReqXml.AppendFormat("<passwordShar>{0}</passwordShar>", passwordShar);
            ReqXml.AppendFormat("<claimID>{0}</claimID>", ClaimID);
            ReqXml.Append("</SubmitClaim>");
            ReqXml.Append("</soap:Body>");
            ReqXml.Append("</soap:Envelope>");
            return ReqXml.ToString();
        }
        public static string GetCurrencies(string UserGUID, string passwordShar)
        {
            string DateFrom = DateTime.Now.AddMonths(-12).ToString("yyyy-MM-ddTHH:mm:ss") + ".000Z";
            ReqXml = new StringBuilder();
            ReqXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            ReqXml.Append("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            ReqXml.Append("<soap:Body>");
            ReqXml.Append("<GetCurrencies     xmlns=\"http://pointprogress.com/\">");
            ReqXml.AppendFormat("<userGuid>{0}</userGuid>", UserGUID);
            ReqXml.AppendFormat("<passwordShar>{0}</passwordShar>", passwordShar);
            ReqXml.AppendFormat("<fromDate>{0}</fromDate>", DateFrom);
            ReqXml.Append("</GetCurrencies>");
            ReqXml.Append("</soap:Body>");
            ReqXml.Append("</soap:Envelope>");
            return ReqXml.ToString();
        }

        public static string GetCountries(string UserGUID, string passwordShar)
        {
            string DateFrom = DateTime.Now.AddMonths(-12).ToString("yyyy-MM-ddTHH:mm:ss") + ".000Z";
            ReqXml = new StringBuilder();
            ReqXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            ReqXml.Append("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            ReqXml.Append("<soap:Body>");
            ReqXml.Append("<GetCountries      xmlns=\"http://pointprogress.com/\">");
            ReqXml.AppendFormat("<userGuid>{0}</userGuid>", UserGUID);
            ReqXml.AppendFormat("<passwordShar>{0}</passwordShar>", passwordShar);
            ReqXml.AppendFormat("<fromDate>{0}</fromDate>", DateFrom);
            ReqXml.Append("</GetCountries>");
            ReqXml.Append("</soap:Body>");
            ReqXml.Append("</soap:Envelope>");
            return ReqXml.ToString();
        }

        public static string DeleteCLaimHeader(string UserGUID, string passwordShar, string ClaimID)
        {
            //  string DateFrom = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + ".000Z";
            ReqXml = new StringBuilder();
            ReqXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            ReqXml.Append("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            ReqXml.Append("<soap:Body>");
            ReqXml.Append("<DeleteClaimHeader  xmlns=\"http://pointprogress.com/\">");
            ReqXml.AppendFormat("<userGuid>{0}</userGuid>", UserGUID);
            ReqXml.AppendFormat("<passwordShar>{0}</passwordShar>", passwordShar);
            ReqXml.AppendFormat("<claimID>{0}</claimID>", ClaimID);
            ReqXml.Append("</DeleteClaimHeader>");
            ReqXml.Append("</soap:Body>");
            ReqXml.Append("</soap:Envelope>");
            return ReqXml.ToString();
        }
        public static string DeleteCLaimLine(string UserGUID, string passwordShar, string UniqieID)
        {
            //  string DateFrom = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + ".000Z";
            ReqXml = new StringBuilder();
            ReqXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            ReqXml.Append("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            ReqXml.Append("<soap:Body>");
            ReqXml.Append("<DeleteClaimLine  xmlns=\"http://pointprogress.com/\">");
            ReqXml.AppendFormat("<userGuid>{0}</userGuid>", UserGUID);
            ReqXml.AppendFormat("<passwordShar>{0}</passwordShar>", passwordShar);
            ReqXml.AppendFormat("<uniqueID>{0}</uniqueID>", UniqieID);
            ReqXml.Append("</DeleteClaimLine>");
            ReqXml.Append("</soap:Body>");
            ReqXml.Append("</soap:Envelope>");
            return ReqXml.ToString();
        }
        public static string GetProjects(string UserGUID, string passwordShar)
        {
            string DateFrom = DateTime.Now.AddMonths(-12).ToString("yyyy-MM-ddTHH:mm:ss") + ".000Z";
            ReqXml = new StringBuilder();
            ReqXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            ReqXml.Append("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            ReqXml.Append("<soap:Body>");
            ReqXml.Append("<GetProjects xmlns=\"http://pointprogress.com/\">");
            ReqXml.AppendFormat("<userGuid>{0}</userGuid>", UserGUID);
            ReqXml.AppendFormat("<passwordShar>{0}</passwordShar>", passwordShar);
            ReqXml.AppendFormat("<fromDate>{0}</fromDate>", DateFrom);
            ReqXml.Append("</GetProjects>");
            ReqXml.Append("</soap:Body>");
            ReqXml.Append("</soap:Envelope>");
            return ReqXml.ToString();
        }

        public static string MoveClaimLine(string UserGUID, string passwordShar, string UniqieID, string NewCLaimID)
        {
            //  string DateFrom = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + ".000Z";
            ReqXml = new StringBuilder();
            ReqXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            ReqXml.Append("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            ReqXml.Append("<soap:Body>");
            ReqXml.Append("<MoveClaimLine  xmlns=\"http://pointprogress.com/\">");
            ReqXml.AppendFormat("<userGuid>{0}</userGuid>", UserGUID);
            ReqXml.AppendFormat("<passwordShar>{0}</passwordShar>", passwordShar);
            ReqXml.AppendFormat("<uniqueID>{0}</uniqueID>", UniqieID);
            ReqXml.AppendFormat("<newClaimID>{0}</newClaimID>", NewCLaimID);
            ReqXml.Append("</MoveClaimLine>");
            ReqXml.Append("</soap:Body>");
            ReqXml.Append("</soap:Envelope>");
            return ReqXml.ToString();
        }

        public static string GetCategories(string UserGUID, string passwordShar)
        {
            string DateFrom = DateTime.Now.AddMonths(-12).ToString("yyyy-MM-ddTHH:mm:ss") + ".000Z";
            ReqXml = new StringBuilder();
            ReqXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            ReqXml.Append("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            ReqXml.Append("<soap:Body>");
            ReqXml.Append("<GetCategories     xmlns=\"http://pointprogress.com/\">");
            ReqXml.AppendFormat("<userGuid>{0}</userGuid>", UserGUID);
            ReqXml.AppendFormat("<passwordShar>{0}</passwordShar>", passwordShar);
            ReqXml.AppendFormat("<fromDate>{0}</fromDate>", DateFrom);
            ReqXml.Append("</GetCategories>");
            ReqXml.Append("</soap:Body>");
            ReqXml.Append("</soap:Envelope>");
            return ReqXml.ToString();
        }


        public static string SetLineApproval(string UserGUID, string passwordShar, string ClaimID, string UniqueID,int linestatus,string deniedReason,double VatAmount,int vatrateID)
        {
            //  string DateFrom = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + ".000Z";
            ReqXml = new StringBuilder();
            ReqXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            ReqXml.Append("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            ReqXml.Append("<soap:Body>");
            ReqXml.Append("<SetLineApproval     xmlns=\"http://pointprogress.com/\">");
            ReqXml.AppendFormat("<userGuid>{0}</userGuid>", UserGUID);
            ReqXml.AppendFormat("<passwordShar>{0}</passwordShar>", passwordShar);
            ReqXml.AppendFormat("<uniqueID>{0}</uniqueID>", UniqueID);
            ReqXml.AppendFormat("<lineStatus>{0}</lineStatus>", linestatus);
            ReqXml.AppendFormat("<claimID>{0}</claimID>", ClaimID);
            ReqXml.AppendFormat("<denialReason>{0}</denialReason>", deniedReason);
            ReqXml.AppendFormat("<costCentre>{0}</costCentre>", UserGUID);
            ReqXml.AppendFormat("<project>{0}</project>", UserGUID);
            ReqXml.AppendFormat("<orderNo>{0}</orderNo>", UserGUID);
            ReqXml.AppendFormat("<collection>{0}</collection>", UserGUID);
            ReqXml.AppendFormat("<channel>{0}</channel>", UserGUID);
            ReqXml.AppendFormat("<season>{0}</season>", UserGUID);
            ReqXml.AppendFormat("<vatAmount>{0}</vatAmount>", VatAmount);
            ReqXml.AppendFormat("<vatRateID>{0}</vatRateID>", vatrateID);
            ReqXml.Append("</SetLineApproval >");
            ReqXml.Append("</soap:Body>");
            ReqXml.Append("</soap:Envelope>");
            return ReqXml.ToString();
        }

        public static string GetMobileSettings(string UserGUID, string passwordShar)
        {
           
            ReqXml = new StringBuilder();
            ReqXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            ReqXml.Append("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            ReqXml.Append("<soap:Body>");
            ReqXml.Append("<GetMobileSettings   xmlns=\"http://pointprogress.com/\">");
            ReqXml.AppendFormat("<userGuid>{0}</userGuid>", UserGUID);
            ReqXml.AppendFormat("<passwordShar>{0}</passwordShar>", passwordShar);
            ReqXml.Append("</GetMobileSettings>");
            ReqXml.Append("</soap:Body>");
            ReqXml.Append("</soap:Envelope>");
            return ReqXml.ToString();
        }

       
        public static string GetAccounts(string UserGUID, string passwordShar)
        {
            string DateFrom = DateTime.Now.AddMonths(-12).ToString("yyyy-MM-ddTHH:mm:ss") + ".000Z";
            ReqXml = new StringBuilder();
            ReqXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            ReqXml.Append("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            ReqXml.Append("<soap:Body>");
            ReqXml.Append("<GetAccounts  xmlns=\"http://pointprogress.com/\">");
            ReqXml.AppendFormat("<userGuid>{0}</userGuid>", UserGUID);
            ReqXml.AppendFormat("<passwordShar>{0}</passwordShar>", passwordShar);
            ReqXml.AppendFormat("<fromDate>{0}</fromDate>", DateFrom);
            ReqXml.Append("</GetAccounts>");
            ReqXml.Append("</soap:Body>");
            ReqXml.Append("</soap:Envelope>");
            return ReqXml.ToString();
        }

        public static string GetCostcentres(string UserGUID, string passwordShar)
        {
            string DateFrom = DateTime.Now.AddMonths(-12).ToString("yyyy-MM-ddTHH:mm:ss") + ".000Z";
            ReqXml = new StringBuilder();
            ReqXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            ReqXml.Append("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            ReqXml.Append("<soap:Body>");
            ReqXml.Append("<GetCostcentres   xmlns=\"http://pointprogress.com/\">");
            ReqXml.AppendFormat("<userGuid>{0}</userGuid>", UserGUID);
            ReqXml.AppendFormat("<passwordShar>{0}</passwordShar>", passwordShar);
            ReqXml.AppendFormat("<fromDate>{0}</fromDate>", DateFrom);
            ReqXml.Append("</GetCostcentres>");
            ReqXml.Append("</soap:Body>");
            ReqXml.Append("</soap:Envelope>");
            return ReqXml.ToString();
        }


        public static string GetAccount(string UserGUID, string passwordShar)
        {
            string DateFrom = DateTime.Now.AddMonths(-12).ToString("yyyy-MM-ddTHH:mm:ss") + ".000Z";
            ReqXml = new StringBuilder();
            ReqXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            ReqXml.Append("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            ReqXml.Append("<soap:Body>");
            ReqXml.Append("<GetAccount  xmlns=\"http://pointprogress.com/\">");
            ReqXml.AppendFormat("<userGuid>{0}</userGuid>", UserGUID);
            ReqXml.AppendFormat("<passwordShar>{0}</passwordShar>", passwordShar);
            ReqXml.AppendFormat("<account>{0}</account>", StateUtilities.CurrentAccount.ID);
            ReqXml.Append("</GetAccount>");
            ReqXml.Append("</soap:Body>");
            ReqXml.Append("</soap:Envelope>");
            return ReqXml.ToString();
        }

        public static string GetVatRates(string UserGUID, string passwordShar)
        {
            string DateFrom = DateTime.Now.AddMonths(-12).ToString("yyyy-MM-ddTHH:mm:ss") + ".000Z";
            ReqXml = new StringBuilder();
            ReqXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            ReqXml.Append("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            ReqXml.Append("<soap:Body>");
            ReqXml.Append("<GetVatRates   xmlns=\"http://pointprogress.com/\">");
            ReqXml.AppendFormat("<userGuid>{0}</userGuid>", UserGUID);
            ReqXml.AppendFormat("<passwordShar>{0}</passwordShar>", passwordShar);
            ReqXml.AppendFormat("<fromDate>{0}</fromDate>", DateFrom);
            ReqXml.Append("</GetVatRates>");
            ReqXml.Append("</soap:Body>");
            ReqXml.Append("</soap:Envelope>");
            return ReqXml.ToString();
        }

        public static string GetExchangeRate(string UserGUID, string passwordShar, string currencyCodeFrom, string currencyCodeTo)
        {
            string DateFrom = DateTime.Now.AddMonths(-12).ToString("yyyy-MM-ddTHH:mm:ss") + ".000Z";
            ReqXml = new StringBuilder();
            ReqXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            ReqXml.Append("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            ReqXml.Append("<soap:Body>");
            ReqXml.Append("<GetExchangeRate   xmlns=\"http://pointprogress.com/\">");
            ReqXml.AppendFormat("<userGuid>{0}</userGuid>", UserGUID);
            ReqXml.AppendFormat("<passwordShar>{0}</passwordShar>", passwordShar);
            ReqXml.AppendFormat("<currencyCodeFrom>{0}</currencyCodeFrom>", currencyCodeFrom);
            ReqXml.AppendFormat("<currencyCodeTo>{0}</currencyCodeTo>", currencyCodeTo);
            ReqXml.AppendFormat("<expenseDate>{0}</expenseDate>", DateFrom);          
            ReqXml.Append("</GetExchangeRate>");
            ReqXml.Append("</soap:Body>");
            ReqXml.Append("</soap:Envelope>");
            return ReqXml.ToString();
        }
        public static string CreateClaimHeader(string UserGUID, string passwordShar, MyExpenses.Model.BussinessObjects.ClaimDetails ClaimDetails)
        {
            string DateFrom = DateTime.Now.AddMonths(-12).ToString("yyyy-MM-ddTHH:mm:ss") + ".000Z";
            ReqXml = new StringBuilder();
            ReqXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            ReqXml.Append("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            ReqXml.Append("<soap:Body>");
            ReqXml.Append("<CreateClaimHeader     xmlns=\"http://pointprogress.com/\">");
            ReqXml.AppendFormat("<userGuid>{0}</userGuid>", UserGUID);
            ReqXml.AppendFormat("<passwordShar>{0}</passwordShar>", passwordShar);
            ReqXml.AppendFormat("<claimType>{0}</claimType>", ClaimDetails.claimType);
            ReqXml.AppendFormat("<description>{0}</description>", ClaimDetails.Headerdescription);
            ReqXml.AppendFormat("<dateCreated>{0}</dateCreated>", DateFrom);
            ReqXml.AppendFormat("<claimID>{0}</claimID>", "");
            ReqXml.Append("</CreateClaimHeader>");
            ReqXml.Append("</soap:Body>");
            ReqXml.Append("</soap:Envelope>");
            return ReqXml.ToString();
        }
        public static string CreateLine(string UserGUID, string passwordShar, MyExpenses.Model.BussinessObjects.ClaimDetails ClaimDetails)
        {

            ClaimDetails.conversionRate = "1";
            ClaimDetails.collection = "324f1c05-f261-409a-b82f-e8d0f27faa5e";
            ClaimDetails.season = "85c9bcb5-aec0-4424-890c-312d7225202f";
            ClaimDetails.channel = "26326fb3-7275-4f0e-87e7-b88d51087914";
            ClaimDetails.orderNo = "b8d8570f-7220-4e50-bc28-97f1798334be";

            string DateFrom = ClaimDetails.ClaimLineDate.ToString("yyyy-MM-ddTHH:mm:ss") + ".000Z";
            ReqXml = new StringBuilder();
            ReqXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            ReqXml.Append("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            ReqXml.Append("<soap:Body>");
            ReqXml.Append("<CreateLine     xmlns=\"http://pointprogress.com/\">");
            ReqXml.AppendFormat("<userGuid>{0}</userGuid>", UserGUID);
            ReqXml.AppendFormat("<passwordShar>{0}</passwordShar>", passwordShar);
            ReqXml.AppendFormat("<claimID>{0}</claimID>", ClaimDetails.ClaimID);
            ReqXml.AppendFormat("<claimDate>{0}</claimDate>", DateFrom);
            ReqXml.AppendFormat("<categoryID>{0}</categoryID>", ClaimDetails.categoryID);
            ReqXml.AppendFormat("<amount>{0}</amount>", ClaimDetails.amount);
           
            ReqXml.AppendFormat("<currency>{0}</currency>", ClaimDetails.currency);

            ReqXml.AppendFormat("<vat>{0}</vat>", ClaimDetails.vat);
            ReqXml.AppendFormat("<description>{0}</description>", ClaimDetails.description);
            ReqXml.AppendFormat("<additionalPeople>{0}</additionalPeople>", ClaimDetails.additionalPeople);
            ReqXml.AppendFormat("<costCentre>{0}</costCentre>", ClaimDetails.costCenterGUID);
            ReqXml.AppendFormat("<project>{0}</project>", ClaimDetails.projectGUID);
            ReqXml.AppendFormat("<orderNo>{0}</orderNo>", ClaimDetails.orderNo);
            ReqXml.AppendFormat("<channel>{0}</channel>", ClaimDetails.channel);
            ReqXml.AppendFormat("<collection>{0}</collection>", ClaimDetails.collection);
            ReqXml.AppendFormat("<season>{0}</season>", ClaimDetails.season);

            ReqXml.AppendFormat("<account>{0}</account>", ClaimDetails.accountGUID);
            ReqXml.AppendFormat("<vatRateID>{0}</vatRateID>", ClaimDetails.vatRateID);
            ReqXml.AppendFormat("<conversionRate>{0}</conversionRate>", ClaimDetails.conversionRate);
            ReqXml.AppendFormat("<baseAmount>{0}</baseAmount>", ClaimDetails.amount);
            ReqXml.AppendFormat("<receiptReason>{0}</receiptReason>", ClaimDetails.receiptReason);
            ReqXml.AppendFormat("<receipt>{0}</receipt>", ClaimDetails.receipt);

            ReqXml.AppendFormat("<reference>{0}</reference>", ClaimDetails.reference);
            ReqXml.AppendFormat("<countryCode>{0}</countryCode>", ClaimDetails.countryCode);
          //  ReqXml.AppendFormat("<vatReceiptAvailable>{0}</vatReceiptAvailable>", ClaimDetails.vatReceiptAvailable);

            ReqXml.Append("</CreateLine>");
            ReqXml.Append("</soap:Body>");
            ReqXml.Append("</soap:Envelope>");
            return ReqXml.ToString();
        }

        public static string UpdateLine(string UserGUID, string passwordShar, MyExpenses.Model.BussinessObjects.ClaimDetails ClaimDetails)
        {

          
            string DateFrom = ClaimDetails.ClaimLineDate.ToString("yyyy-MM-ddTHH:mm:ss") + ".000Z";
            ReqXml = new StringBuilder();
            ReqXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            ReqXml.Append("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            ReqXml.Append("<soap:Body>");
            ReqXml.Append("<UpdateLine      xmlns=\"http://pointprogress.com/\">");
            ReqXml.AppendFormat("<userGuid>{0}</userGuid>", UserGUID);
            ReqXml.AppendFormat("<passwordShar>{0}</passwordShar>", passwordShar);
            ReqXml.AppendFormat("<claimID>{0}</claimID>", ClaimDetails.ClaimID);
            ReqXml.AppendFormat("<claimDate>{0}</claimDate>", DateFrom);
            ReqXml.AppendFormat("<categoryID>{0}</categoryID>", ClaimDetails.categoryID);
            ReqXml.AppendFormat("<amount>{0}</amount>", ClaimDetails.amount);

            ReqXml.AppendFormat("<currency>{0}</currency>", ClaimDetails.currency);

            ReqXml.AppendFormat("<vat>{0}</vat>", ClaimDetails.vat);
            ReqXml.AppendFormat("<description>{0}</description>", ClaimDetails.description);
            ReqXml.AppendFormat("<additionalPeople>{0}</additionalPeople>", ClaimDetails.additionalPeople);
            ReqXml.AppendFormat("<costCentre>{0}</costCentre>", ClaimDetails.costCenterGUID);
            ReqXml.AppendFormat("<project>{0}</project>", ClaimDetails.projectGUID);
            ReqXml.AppendFormat("<orderNo>{0}</orderNo>", ClaimDetails.orderNo);
            ReqXml.AppendFormat("<channel>{0}</channel>", ClaimDetails.channel);
            ReqXml.AppendFormat("<collection>{0}</collection>", ClaimDetails.collection);
            ReqXml.AppendFormat("<season>{0}</season>", ClaimDetails.season);

            ReqXml.AppendFormat("<account>{0}</account>", ClaimDetails.accountGUID);
            ReqXml.AppendFormat("<vatRateID>{0}</vatRateID>", ClaimDetails.vatRateID);
            ReqXml.AppendFormat("<conversionRate>{0}</conversionRate>", ClaimDetails.conversionRate);
            ReqXml.AppendFormat("<baseAmount>{0}</baseAmount>", ClaimDetails.amount);
            ReqXml.AppendFormat("<uniqueID>{0}</uniqueID>", ClaimDetails.UniqueID);
            ReqXml.AppendFormat("<receiptReason>{0}</receiptReason>", ClaimDetails.receiptReason);
            ReqXml.AppendFormat("<receipt>{0}</receipt>", ClaimDetails.receipt);

            ReqXml.AppendFormat("<reference>{0}</reference>", ClaimDetails.reference);
            ReqXml.AppendFormat("<countryCode>{0}</countryCode>", ClaimDetails.countryCode);
            //  ReqXml.AppendFormat("<vatReceiptAvailable>{0}</vatReceiptAvailable>", ClaimDetails.vatReceiptAvailable);

            ReqXml.Append("</UpdateLine >");
            ReqXml.Append("</soap:Body>");
            ReqXml.Append("</soap:Envelope>");
            return ReqXml.ToString();
        }
    }
}
