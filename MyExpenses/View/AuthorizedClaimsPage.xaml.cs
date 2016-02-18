using MyExpenses.ResponseParsers;
using MyExpenses.ResponseParsers.AuthClaims;
using MyExpenses.Utilities;
using MyExpenses.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MyExpenses.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AuthorizedClaimsPage : Page
    {
        private NavigationMode _navigationMode;
        private bool IsfromLoginPage = false;
        public AuthorizedClaimsPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            this.Loaded += AuthorizedClaimsPage_Loaded;
        }

       async void AuthorizedClaimsPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (_navigationMode == NavigationMode.New)
            {
                //if (IsfromLoginPage)
                    await GetPostResponseAsync();
                //else
                //{
                //    await BindFromDatabase();
                //}
            }
            else if (_navigationMode == NavigationMode.Back && StateUtilities.IsAnythingModified)
            {
                pgRing.Visibility = Visibility.Visible;
                await GetPostResponseAsync();
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CreateApplicationBar();
            _navigationMode = e.NavigationMode;
            IsfromLoginPage = false;
            if (e.Parameter != null && e.Parameter.GetType() == typeof(string) && e.Parameter.ToString() == "LoginPage")
            {
                IsfromLoginPage = true;
               // this.Frame.BackStack.Clear();
            }
        }

        private async Task BindFromDatabase()
        {
            try
            {
                List<AuthClaimHeadersDT> ListClaimHeadersDT = await App.Connection.QueryAsync<AuthClaimHeadersDT>("select * from AuthClaimHeadersDT");
                if (ListClaimHeadersDT != null && ListClaimHeadersDT.Count > 0)
                {
                    pgRing.Visibility = Visibility.Visible;
                    List<AuthClaimDetailsDT> ListClaimDetailsDTDT = await App.Connection.QueryAsync<AuthClaimDetailsDT>("select * from AuthClaimDetailsDT");
                    StateUtilities.ListAuthClaimDetailsDT = ListClaimDetailsDTDT;
                    await BindDataFromDB(ListClaimHeadersDT, ListClaimDetailsDTDT);
                    pgRing.Visibility = Visibility.Collapsed;
                    //  GetPostResponseAsync();
                }
                else
                {
                    await GetPostResponseAsync();
                }
            }
            catch (Exception ex) { }

        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {

            ClaimHeadersDT _ClaimHeadersDT = (sender as Grid).DataContext as ClaimHeadersDT;
            if (_ClaimHeadersDT != null)
            {
                AppConstants.SelectedPage = 1;
                this.Frame.Navigate(typeof(ClaimHeaderDetails), _ClaimHeadersDT);
            }

        }

        private CommandBar bottomAppBar;
        private AppBarButton btnSettings;
        private AppBarButton btnLogout;
        private AppBarButton btnAuthoriseClaims;

        private void CreateApplicationBar()
        {

            bottomAppBar = new CommandBar();
            //      bottomAppBar.Style = (Style)App.Current.Resources["ApplicationBarStyle"];



            btnSettings = new AppBarButton();
            btnSettings.Label = "settings";
            btnSettings.Icon = new SymbolIcon(Symbol.Setting);
            bottomAppBar.PrimaryCommands.Add(btnSettings);
            btnSettings.Click += btnSettings_Click;

            btnLogout = new AppBarButton();
            btnLogout.Label = "logout";
            btnLogout.Click += btnLogout_Click;
            bottomAppBar.SecondaryCommands.Add(btnLogout);
            //  btnSettings.Click += btnSettings_Click;

            int result = AppStorage.GetIntValue(AppConstants.AUTHORIZED);
            if (result == 1)
            {
                btnAuthoriseClaims = new AppBarButton();
                btnAuthoriseClaims.Label = "authorise Claims";
                // btnAuthoriseClaims.Icon = new SymbolIcon(Symbol.Setting);
                bottomAppBar.SecondaryCommands.Add(btnAuthoriseClaims);
            }


            this.BottomAppBar = bottomAppBar;
        }

        async void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await App.Connection.ExecuteAsync("delete from Headers");
                AppStorage.RemoveKey(AppConstants.AUTHORIZED);

                this.Frame.Navigate(typeof(LoginPage));
            }
            catch (Exception ex) { }
        }
        void btnSettings_Click(object sender, RoutedEventArgs e)
        {
        }

        public async Task<string> GetPostResponseAsync()
        {

            string DateFrom = DateTime.Now.AddMonths(-12).ToString("yyyy-MM-ddTHH:mm:ss") + ".000Z";
            string request = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
"<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ns1=\"http://pointprogress.com/\">" +
"<SOAP-ENV:Body>" +
"<ns1:GetFullClaimLinesAuth >" +
"<ns1:userGuid>" + StateUtilities.LoginHeaders.UserGuid + "</ns1:userGuid>" +
"<ns1:passwordShar>" + StateUtilities.LoginHeaders.UserShar + "</ns1:passwordShar>" +
"<ns1:headerFromDate>" + DateFrom + "</ns1:headerFromDate>" +
"<ns1:detailFromDate>" + DateFrom + "</ns1:detailFromDate>" +
"</ns1:GetFullClaimLinesAuth>" +
"</SOAP-ENV:Body>" +
"</SOAP-ENV:Envelope>";

            //2015-12-04T14:47:52.740Z

            Dictionary<String, string> parameters = new Dictionary<string, string>();
            parameters.Add("SoapAction", "GetFullClaimLinesAuth");

            string Url = "https://halcyontek.myexpensesonline.co.uk/webservices/dx.data/dxdatamobile.asmx?wsdl";
            Url = AppConstants.BaseURl;

            string result = string.Empty;
            try
            {
                //for ssl certificate


                HttpClient client = new HttpClient();
                if (parameters != null && parameters.Count > 0)
                {
                    foreach (var header in parameters)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);

                    }
                }

                HttpContent content = new StringContent(request);
                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("text/xml");



                var response = await client.PostAsync(Url, content);
                if (response.IsSuccessStatusCode)
                {
                    var soapResponse = await response.Content.ReadAsStringAsync();
                    string resp = await RemoveAllNamespaces(soapResponse.ToString());
                    XDocument document = XDocument.Parse(resp);
                    var XMLresult = document.Root.Descendants("GetFullClaimLinesAuthResponse");
                    GetFullClaimLinesAuthResponse GetFullClaimLinesAuthResponse = new GetFullClaimLinesAuthResponse();
                    foreach (var item in XMLresult)
                    {
                        GetFullClaimLinesAuthResponse = CommonFUnction.DeSerializeData<GetFullClaimLinesAuthResponse>(GetFullClaimLinesAuthResponse, item.ToString());
                    }
                    if (GetFullClaimLinesAuthResponse != null)
                    {

                        List<AuthClaimHeadersDT> listClaimHeadersDT = GetFullClaimLinesAuthResponse.GetFullClaimLinesAuthResult.ReturnedDataTable.Diffgram.ClaimHeaders.AuthClaimHeadersDT;


                        StateUtilities.ListAuthClaimDetailsDT = GetFullClaimLinesAuthResponse.GetFullClaimLinesAuthResult.SecondaryReturnedDataTable.Diffgram.ClaimDetails.AuthClaimDetailsDT;

                        await InserttoDB(listClaimHeadersDT, StateUtilities.ListAuthClaimDetailsDT);
                        await BindData(listClaimHeadersDT, StateUtilities.ListAuthClaimDetailsDT);







                        pgRing.Visibility = Visibility.Collapsed;
                    }

                }
                else
                    result = DateTime.Now.ToString();

                response.Dispose();
                response = null;
                content.Dispose();
                content = null;
                client.Dispose();
                client = null;

                //  filter.IgnorableServerCertificateErrors.Clear();

            }
            catch (Exception ex)
            {
                result = string.Empty;
            }
            return result;
        }


        private async Task BindData(List<MyExpenses.ResponseParsers.AuthClaims.AuthClaimHeadersDT> listClaimHeadersDT, List<MyExpenses.ResponseParsers.AuthClaims.AuthClaimDetailsDT> DeatilsList)
        {

            if (StateUtilities.ListCurrencies == null)
            {
                StateUtilities.ListCurrencies = await App.Connection.QueryAsync<Currencies>("select * from Currencies");
            }

            if (StateUtilities.MyClaimsViewModel == null)
            {
                StateUtilities.MyClaimsViewModel = new MyClaimsViewModel();
            }
            StateUtilities.MyClaimsViewModel.ListAuthClaimHeadersDT =new System.Collections.ObjectModel.ObservableCollection<AuthClaimHeadersDT>( listClaimHeadersDT);
            if (StateUtilities.MyClaimsViewModel.ListAuthClaimHeadersDT != null)
            {
                foreach (var item in StateUtilities.MyClaimsViewModel.ListAuthClaimHeadersDT)
                {
                    int _Count = 0;
                    string CurrencySymbol = "";
                    try
                    {
                        var mappedlist = StateUtilities.ListAuthClaimDetailsDT.Where(i => i.Expense_headerID == item.H_expense_headerID && i.Deleted == "0").ToList();
                        if (mappedlist != null && mappedlist.Count > 0)
                        {
                            item.DetailsCount = mappedlist.Count;
                            double amt = 0;
                            foreach (var item1 in mappedlist)
                                amt += Convert.ToDouble(item1.Trans_amount);
                            item.Amount = Math.Round(amt, 2);
                            item.CurrencySymbol = CurrencySymbol = StateUtilities.ListCurrencies.Where(i => i.Currency_code == mappedlist.FirstOrDefault().Base_currency).FirstOrDefault().Currency_symbol;
                        }
                        else
                            item.DetailsCount = _Count;
                    }
                    catch (Exception ex) { }


                    try
                    {
                        string raw = "Update AuthClaimHeadersDT set Amount='{0}',DetailsCount='{1}',CurrencySymbol='{3}' where H_expense_headerID='{2}'";
                        await App.Connection.ExecuteAsync(string.Format(raw, item.Amount, item.DetailsCount, item.H_expense_headerID, CurrencySymbol));
                    }
                    catch (Exception ex1) { }

                    // item.DetailsCount = _Count;
                }
                StateUtilities.MyClaimsViewModel.ListAuthClaimHeadersDT = new System.Collections.ObjectModel.ObservableCollection<AuthClaimHeadersDT>(StateUtilities.MyClaimsViewModel.ListAuthClaimHeadersDT.Where(i => i.DetailsCount > 0).ToList());
            }

           




            this.DataContext = StateUtilities.MyClaimsViewModel;
        }


        private async Task BindDataFromDB(List<AuthClaimHeadersDT> listClaimHeadersDT, List<AuthClaimDetailsDT> DeatilsList)
        {
            if (StateUtilities.MyClaimsViewModel == null)
            {
                StateUtilities.MyClaimsViewModel = new MyClaimsViewModel();
            }
            StateUtilities.MyClaimsViewModel.ListAuthClaimHeadersDT = new System.Collections.ObjectModel.ObservableCollection<AuthClaimHeadersDT>(listClaimHeadersDT);
            if (StateUtilities.MyClaimsViewModel.ListAuthClaimHeadersDT != null)
            {

                StateUtilities.MyClaimsViewModel.ListAuthClaimHeadersDT = new System.Collections.ObjectModel.ObservableCollection<AuthClaimHeadersDT>(StateUtilities.MyClaimsViewModel.ListAuthClaimHeadersDT.Where(i => i.DetailsCount > 0).ToList());
            }


           




            this.DataContext = StateUtilities.MyClaimsViewModel;
        }


        private async Task InserttoDB(List<AuthClaimHeadersDT> HeadersList, List<AuthClaimDetailsDT> DeatilsList)
        {
            try
            {

                if (HeadersList != null && HeadersList.Count > 0)
                {
                    await App.Connection.ExecuteAsync("delete from AuthClaimHeadersDT");
                    // foreach (var item in HeadersList)
                    await App.Connection.InsertAllAsync(HeadersList);

                }

                if (DeatilsList != null && DeatilsList.Count > 0)
                {
                    await App.Connection.ExecuteAsync("delete from AuthClaimDetailsDT");
                    // foreach (var item in HeadersList)
                    await App.Connection.InsertAllAsync(DeatilsList);

                }
            }
            catch (Exception ex) { }

        }

        public async Task<string> RemoveAllNamespaces(string xmlDocument)
        {
            try
            {
                XElement xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(xmlDocument));

                return xmlDocumentWithoutNs.ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;
                return xElement;
            }
            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
        }

    }
}
