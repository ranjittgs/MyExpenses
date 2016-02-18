using MyExpenses.Common;
using MyExpenses.Utilities;
using MyExpenses.View;
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
using System.Xml.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace MyExpenses
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            this.Loaded += MainPage_Loaded;
        }

        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            await GetPostResponseAsync();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CreateApplicationBar();

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
            btnSettings.Label = "Settings";
            btnSettings.Icon = new SymbolIcon(Symbol.Setting);
            bottomAppBar.PrimaryCommands.Add(btnSettings);
            btnSettings.Click += btnSettings_Click;

            btnLogout = new AppBarButton();
            btnLogout.Label = "Logout";
           // btnLogout.Icon = new SymbolIcon(Symbol.);
            bottomAppBar.SecondaryCommands.Add(btnLogout);
          //  btnSettings.Click += btnSettings_Click;

            btnAuthoriseClaims = new AppBarButton();
            btnAuthoriseClaims.Label = "Authorise Claims";
           // btnAuthoriseClaims.Icon = new SymbolIcon(Symbol.Setting);
            bottomAppBar.SecondaryCommands.Add(btnAuthoriseClaims);



            this.BottomAppBar = bottomAppBar;
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
"<ns1:GetFullClaimLines>" +
"<ns1:userGuid>" + StateUtilities.LoginHeaders.UserGuid + "</ns1:userGuid>" +
"<ns1:passwordShar>" + StateUtilities.LoginHeaders.UserShar + "</ns1:passwordShar>" +
"<ns1:stage></ns1:stage>" +
"<ns1:headerFromDate>" + DateFrom + "</ns1:headerFromDate>" +
"<ns1:detailFromDate>" + DateFrom + "</ns1:detailFromDate>" +
"</ns1:GetFullClaimLines>" +
"</SOAP-ENV:Body>" +
"</SOAP-ENV:Envelope>";

            //2015-12-04T14:47:52.740Z

            Dictionary<String, string> parameters = new Dictionary<string, string>();
            parameters.Add("SoapAction", "GetFullClaimLines");

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
                    var XMLresult = document.Root.Descendants("GetFullClaimLinesResponse");
                    GetFullClaimLinesResponse GetTripAvailabilityResponse = new GetFullClaimLinesResponse();
                    foreach (var item in XMLresult)
                    {
                        GetTripAvailabilityResponse = CommonFUnction.DeSerializeData<GetFullClaimLinesResponse>(GetTripAvailabilityResponse, item.ToString());
                    }
                    if (GetTripAvailabilityResponse != null)
                    {

                        List<ClaimHeadersDT> listClaimHeadersDT = GetTripAvailabilityResponse.GetFullClaimLinesResult.ReturnedDataTable.Diffgram.ClaimHeaders.ClaimHeadersDT;

                       
                        StateUtilities.ListClaimDetailsDT = GetTripAvailabilityResponse.GetFullClaimLinesResult.SecondaryReturnedDataTable.Diffgram.ClaimDetails.ClaimDetailsDT;

                      await  InserttoDB(listClaimHeadersDT, StateUtilities.ListClaimDetailsDT);
                    await  BindData(listClaimHeadersDT, StateUtilities.ListClaimDetailsDT);

                    





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


        private async  Task BindData(List<ClaimHeadersDT> listClaimHeadersDT, List<ClaimDetailsDT> DeatilsList)
        {
            MyClaimsViewModel _MyClaimsViewModel = new MyClaimsViewModel();
            _MyClaimsViewModel.ListClaimHeadersDTDraft = new System.Collections.ObjectModel.ObservableCollection<ClaimHeadersDT>(listClaimHeadersDT.Where(i => i.H_submitted == "0" && i.H_approved == "0" && i.H_originatorID == StateUtilities.LoginHeaders.Username && i.H_deleted == "0" && (i.H_assigned_levelID.ToUpper() == "ORIG" || i.H_assigned_levelID.ToUpper() == "RETURNED")).ToList());
            _MyClaimsViewModel.ListClaimHeadersDTSubmitted = new System.Collections.ObjectModel.ObservableCollection<ClaimHeadersDT>(listClaimHeadersDT.Where(i => i.H_submitted == "1" && i.H_approved == "0" && i.H_originatorID == StateUtilities.LoginHeaders.Username && i.H_assigned_levelID.ToUpper() != "ORIG" && i.H_assigned_levelID.ToUpper() != "RETURNED" && i.H_assigned_levelID.ToUpper() != "COMPLETE").ToList());
            _MyClaimsViewModel.ListClaimHeadersDTCompleted = new System.Collections.ObjectModel.ObservableCollection<ClaimHeadersDT>(listClaimHeadersDT.Where(i => i.H_approved == "1" && i.H_originatorID == StateUtilities.LoginHeaders.Username && i.H_assigned_levelID.ToUpper() == "COMPLETE").ToList());

            if (_MyClaimsViewModel.ListClaimHeadersDTDraft != null)
            {
                foreach (var item in _MyClaimsViewModel.ListClaimHeadersDTDraft)
                {
                    int _Count = 0;
                    try
                    {
                        var mappedlist = StateUtilities.ListClaimDetailsDT.Where(i => i.Expense_headerID == item.H_expense_headerID).ToList();
                        if (mappedlist != null && mappedlist.Count > 0)
                        {
                            item.DetailsCount = mappedlist.Count;
                            double amt = 0;
                            foreach (var item1 in mappedlist)
                                amt += Convert.ToDouble(item1.Trans_amount);
                            item.Amount = Math.Round(amt, 2);
                        }
                        else
                            item.DetailsCount = _Count;
                    }
                    catch (Exception ex) { }

                    // item.DetailsCount = _Count;
                }
                _MyClaimsViewModel.ListClaimHeadersDTDraft = new System.Collections.ObjectModel.ObservableCollection<ClaimHeadersDT>(_MyClaimsViewModel.ListClaimHeadersDTDraft.Where(i => i.DetailsCount > 0).ToList());
            }

            if (_MyClaimsViewModel.ListClaimHeadersDTSubmitted != null)
            {
                foreach (var item in _MyClaimsViewModel.ListClaimHeadersDTSubmitted)
                {
                    int _Count = 0;
                    try
                    {
                        var mappedlist = StateUtilities.ListClaimDetailsDT.Where(i => i.Expense_headerID == item.H_expense_headerID).ToList();
                        if (mappedlist != null && mappedlist.Count > 0)
                        {
                            item.DetailsCount = mappedlist.Count;
                            double amt = 0;
                            foreach (var item1 in mappedlist)
                                amt += Convert.ToDouble(item1.Trans_amount);
                            item.Amount = amt;
                        }
                        else
                            item.DetailsCount = _Count;
                    }
                    catch (Exception ex) { }

                    // item.DetailsCount = _Count;
                }
                _MyClaimsViewModel.ListClaimHeadersDTSubmitted = new System.Collections.ObjectModel.ObservableCollection<ClaimHeadersDT>(_MyClaimsViewModel.ListClaimHeadersDTSubmitted.Where(i => i.DetailsCount > 0).ToList());
            }

            if (_MyClaimsViewModel.ListClaimHeadersDTCompleted != null)
            {
                foreach (var item in _MyClaimsViewModel.ListClaimHeadersDTCompleted)
                {
                    int _Count = 0;
                    try
                    {
                        var mappedlist = StateUtilities.ListClaimDetailsDT.Where(i => i.Expense_headerID == item.H_expense_headerID).ToList();
                        if (mappedlist != null && mappedlist.Count > 0)
                        {
                            item.DetailsCount = mappedlist.Count;
                            double amt = 0;
                            foreach (var item1 in mappedlist)
                                amt += Convert.ToDouble(item1.Trans_amount);
                            item.Amount = amt;
                        }
                        else
                            item.DetailsCount = _Count;
                    }
                    catch (Exception ex) { }

                    // item.DetailsCount = _Count;
                }
                _MyClaimsViewModel.ListClaimHeadersDTCompleted = new System.Collections.ObjectModel.ObservableCollection<ClaimHeadersDT>(_MyClaimsViewModel.ListClaimHeadersDTCompleted.Where(i => i.DetailsCount > 0).ToList());
            }




            this.DataContext = _MyClaimsViewModel;
        }


        private async Task InserttoDB(List<ClaimHeadersDT> HeadersList,List<ClaimDetailsDT> DeatilsList)
        {
            try
            {

                if (HeadersList != null && HeadersList.Count > 0)
                {
                    await App.Connection.ExecuteAsync("delete from ClaimHeadersDT");
                    // foreach (var item in HeadersList)
                    await App.Connection.InsertAllAsync(HeadersList);

                }

                if (DeatilsList != null && DeatilsList.Count > 0)
                {
                    await App.Connection.ExecuteAsync("delete from ClaimDetailsDT");
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

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pvt.SelectedIndex == 0)
            {
                txtheader.Text = "Draft Claims";
            }
            else  if (pvt.SelectedIndex == 1)
            {
                txtheader.Text = "Submitted Claims";

            }
            else  if (pvt.SelectedIndex == 2)
            {
                txtheader.Text = "Completed Claims";

            }



        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {

            ClaimHeadersDT _ClaimHeadersDT = (sender as Grid).DataContext as ClaimHeadersDT;
            if(_ClaimHeadersDT!=null)
            {
                AppConstants.SelectedPage = 1;
                this.Frame.Navigate(typeof(ClaimHeaderDetails), _ClaimHeadersDT);
            }

        }

        ClaimHeadersDT _ClaimHeadersDT = null;

        private void Grid_Holding(object sender, HoldingRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);
            flyoutBase.ShowAt(senderElement);
            _ClaimHeadersDT = (sender as Grid).DataContext as ClaimHeadersDT;
        }

        private void Grid_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            ClaimHeadersDT _ClaimHeadersDT = (sender as Grid).DataContext as ClaimHeadersDT;
            if (_ClaimHeadersDT != null)
            {
                AppConstants.SelectedPage = 2;
                this.Frame.Navigate(typeof(ClaimHeaderDetails), _ClaimHeadersDT);
            }
        }

        private void Grid_Tapped_2(object sender, TappedRoutedEventArgs e)
        {
            ClaimHeadersDT _ClaimHeadersDT = (sender as Grid).DataContext as ClaimHeadersDT;
            if (_ClaimHeadersDT != null)
            {
                AppConstants.SelectedPage = 3;
                this.Frame.Navigate(typeof(ClaimHeaderDetails), _ClaimHeadersDT);
            }
        }
        private async void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
          
            string action = (sender as MenuFlyoutItem).Text as string;
            switch (action)
            {
                case "submit":
                    if (CommonFunctions.IsNetworkAvaliable())
                    {
                        //callCopyMoveDeleteOperation(AppConstants.COPY, lstMediaItems, AppConstants.CopyText);
                    }
                    else
                    {
                        MessageDialog msgDialog = new MessageDialog(AppConstants.NO_INTERNETCONNECTION, "Alert!");
                        await msgDialog.ShowAsync();
                    }
                    break;
                case "delete":
                    if (CommonFunctions.IsNetworkAvaliable())
                    {
                        var messageDialog = new MessageDialog("Delete this Claim?", "Alert!");
                        messageDialog.Commands.Add(new UICommand("Ok", new UICommandInvokedHandler(CommandInvokedHandler1)));
                        messageDialog.Commands.Add(new UICommand("Cancel", new UICommandInvokedHandler(CommandInvokedHandler1)));
                        await messageDialog.ShowAsync();


                    }
                    else
                    {
                        MessageDialog msgDialog = new MessageDialog(AppConstants.NO_INTERNETCONNECTION, "Alert!");
                        await msgDialog.ShowAsync();
                    }
                    break;
            }
        }

        private void CommandInvokedHandler1(IUICommand command)
        {
            if (command.Label.Equals("Ok"))
            {
                pgRing.Visibility = Visibility.Visible;
                DeleteClaimHeader(_ClaimHeadersDT.H_expense_headerID);
            }
        }
        MyClaimViewModel _MyClaimViewModel;
        private void DeleteClaimHeader(string CLiamID)
        {

            if (_MyClaimViewModel == null)
                _MyClaimViewModel = new MyClaimViewModel();
            _MyClaimViewModel.DeleteClaimHeader(StateUtilities.LoginHeaders.UserGuid, StateUtilities.LoginHeaders.UserShar, CLiamID);
            _MyClaimViewModel.OnDeleteClaimHeaderCompleted += _MyClaimViewModel_OnDeleteClaimHeaderCompleted;
        }

        void _MyClaimViewModel_OnDeleteClaimHeaderCompleted(int arg1, string arg2)
        {
            _MyClaimViewModel.OnDeleteClaimHeaderCompleted -= _MyClaimViewModel_OnDeleteClaimHeaderCompleted;
            try
            {
                Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                {

                    if (arg1 == 200)
                    {
                    MyClaimsViewModel _MyClaimsViewModel=    this.DataContext as MyClaimsViewModel;
                    _MyClaimsViewModel.ListClaimHeadersDTDraft.Remove(_ClaimHeadersDT);
                    _ClaimHeadersDT = null;
                    }
                    else
                    {
                       
                       // MessageDialog dialog = new MessageDialog("Please Enter Valid Credentials", "Alert");
                       // await dialog.ShowAsync();
                    }
                    pgRing.Visibility = Visibility.Collapsed;
                });

            }
            catch (Exception ex)
            { }
        }

        private void SubmitClaim()
        {
            if (_MyClaimViewModel == null)
                _MyClaimViewModel = new MyClaimViewModel();
            _MyClaimViewModel.SubmitClaim(StateUtilities.LoginHeaders.UserGuid, StateUtilities.LoginHeaders.UserShar, _ClaimHeadersDT.H_expense_headerID);
            _MyClaimViewModel.OnSubmitClaimCompleted += _MyClaimViewModel_OnSubmitClaimCompleted;
        }

        void _MyClaimViewModel_OnSubmitClaimCompleted(int arg1, string arg2)
        {
            _MyClaimViewModel.OnSubmitClaimCompleted -= _MyClaimViewModel_OnSubmitClaimCompleted;
        }


    }

    public static class CommonFUnction
    {

        public static T DeSerializeData<T>(this T source, String ResponseString)
        {
            ResponseString = ResponseString.Replace(" i:nil=\"true\"", "");
            XmlSerializer ser = new XmlSerializer(typeof(T));
            T obj;
            obj = (T)ser.Deserialize(new StringReader(ResponseString));
            return obj;
        }
    }
}
