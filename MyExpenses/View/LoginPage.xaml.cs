using MyExpenses.Utilities;
using MyExpenses.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MyExpenses
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            this.Frame.BackStack.Clear();
        }

        private LoginViewModel _LoginViewModel = null;
        private async void Signin_Click(object sender, RoutedEventArgs e)
        {



            if(string.IsNullOrEmpty(txtBoxURL.Text))
            {
                MessageDialog dialog = new MessageDialog("Please Enter URL", "Alert");
                await dialog.ShowAsync();
            }
            else
                if (string.IsNullOrEmpty(txtBoxEmail.Text))
                {
                    MessageDialog dialog = new MessageDialog("Please Enter User Name", "Alert");
                    await dialog.ShowAsync();
                }
                else
                    if (string.IsNullOrEmpty(pbPassword.Password))
                    {
                        MessageDialog dialog = new MessageDialog("Please Enter Password", "Alert");
                        await dialog.ShowAsync();
                    }
                    else
                    {
                        //Validate

                        AppConstants.BaseURl = txtBoxURL.Text + "/webservices/dx.data/dxdatamobile.asmx?wsdl";
                        pgRing.Visibility = Visibility.Visible;
                        if (_LoginViewModel == null)
                            _LoginViewModel = new LoginViewModel();

                        _LoginViewModel.CheckLogin(txtBoxURL.Text, txtBoxEmail.Text, pbPassword.Password);
                        _LoginViewModel.OnLogonCompleted += _LoginViewModel_OnLogonCompleted;
                    }

        }

        private MasterDetailsVieModel _MasterDetailsVieModel = null;
        void _LoginViewModel_OnLogonCompleted(int arg1, string arg2)
        {
            _LoginViewModel.OnLogonCompleted -= _LoginViewModel_OnLogonCompleted;

            try
            {
                Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async() =>
                {

                    if (arg1 == 200)
                    {
                        if (_MasterDetailsVieModel == null)
                            _MasterDetailsVieModel = new MasterDetailsVieModel();
                        _MasterDetailsVieModel.GetClaimTypes(StateUtilities.LoginHeaders.UserGuid,StateUtilities.LoginHeaders.UserShar);
                        _MasterDetailsVieModel.OnGetClaimTypesCompleted += _MasterDetailsVieModel_OnGetClaimTypesCompleted;
                        //this.Frame.Navigate(typeof(MainPage));
                    }
                    else
                    {
                        pgRing.Visibility = Visibility.Collapsed;
                        MessageDialog dialog = new MessageDialog("Please Enter Valid Credentials", "Alert");
                        await dialog.ShowAsync();
                    }

                });

            }
            catch (Exception ex)
            { }
        }
        void _MasterDetailsVieModel_OnGetClaimTypesCompleted(int arg1, string arg2)
        {
            _MasterDetailsVieModel.OnGetClaimTypesCompleted -= _MasterDetailsVieModel_OnGetClaimTypesCompleted;
            try
            {
                Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                {

                    if (arg1 == 200)
                    {
                        if (_MasterDetailsVieModel == null)
                            _MasterDetailsVieModel = new MasterDetailsVieModel();
                        _MasterDetailsVieModel.GetCurrencies(StateUtilities.LoginHeaders.UserGuid, StateUtilities.LoginHeaders.UserShar);
                        _MasterDetailsVieModel.OnGetCurrenciesCompleted += _MasterDetailsVieModel_OnGetCurrenciesCompleted;
                        //this.Frame.Navigate(typeof(MainPage));
                    }
                    else
                    {
                        //pgRing.Visibility = Visibility.Collapsed;
                        //MessageDialog dialog = new MessageDialog("Please Enter Valid Credentials", "Alert");
                        //await dialog.ShowAsync();
                    }

                });

            }
            catch (Exception ex)
            { }

        }

        void _MasterDetailsVieModel_OnGetCurrenciesCompleted(int arg1, string arg2)
        {
            _MasterDetailsVieModel.OnGetCurrenciesCompleted -= _MasterDetailsVieModel_OnGetCurrenciesCompleted;
            try
            {
                Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                {

                    if (arg1 == 200)
                    {
                        if (_MasterDetailsVieModel == null)
                            _MasterDetailsVieModel = new MasterDetailsVieModel();
                        _MasterDetailsVieModel.GetCountries(StateUtilities.LoginHeaders.UserGuid, StateUtilities.LoginHeaders.UserShar);
                        _MasterDetailsVieModel.OnGetCountriesCompleted += _MasterDetailsVieModel_OnGetCountriesCompleted; 
                        //this.Frame.Navigate(typeof(MainPage));
                    }
                    else
                    {
                        //pgRing.Visibility = Visibility.Collapsed;
                        //MessageDialog dialog = new MessageDialog("Please Enter Valid Credentials", "Alert");
                        //await dialog.ShowAsync();
                    }

                });

            }
            catch (Exception ex)
            { }
        }

        void _MasterDetailsVieModel_OnGetCountriesCompleted(int arg1, string arg2)
        {
            _MasterDetailsVieModel.OnGetCountriesCompleted -= _MasterDetailsVieModel_OnGetCountriesCompleted;
            try
            {
                Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                {

                    if (arg1 == 200)
                    {
                        if (_MasterDetailsVieModel == null)
                            _MasterDetailsVieModel = new MasterDetailsVieModel();
                        _MasterDetailsVieModel.GetProjects(StateUtilities.LoginHeaders.UserGuid, StateUtilities.LoginHeaders.UserShar);
                        _MasterDetailsVieModel.OnGetProjectsCompleted+=_MasterDetailsVieModel_OnGetProjectsCompleted;
                        //this.Frame.Navigate(typeof(MainPage));
                    }
                    else
                    {
                        //pgRing.Visibility = Visibility.Collapsed;
                        //MessageDialog dialog = new MessageDialog("Please Enter Valid Credentials", "Alert");
                        //await dialog.ShowAsync();
                    }

                });

            }
            catch (Exception ex)
            { }

        }

        private void _MasterDetailsVieModel_OnGetProjectsCompleted(int arg1, string arg2)
        {
            _MasterDetailsVieModel.OnGetProjectsCompleted -= _MasterDetailsVieModel_OnGetProjectsCompleted;
            try
            {
                Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                {

                    if (arg1 == 200)
                    {

                        if (_MasterDetailsVieModel == null)
                            _MasterDetailsVieModel = new MasterDetailsVieModel();
                        _MasterDetailsVieModel.GetCategories(StateUtilities.LoginHeaders.UserGuid, StateUtilities.LoginHeaders.UserShar);
                        _MasterDetailsVieModel.OnGetCategoriesCompleted += _MasterDetailsVieModel_OnGetCategoriesCompleted;
                       
                       // this.Frame.Navigate(typeof(MainPage));
                    }
                    else
                    {
                        //pgRing.Visibility = Visibility.Collapsed;
                        //MessageDialog dialog = new MessageDialog("Please Enter Valid Credentials", "Alert");
                        //await dialog.ShowAsync();
                    }

                });

            }
            catch (Exception ex)
            { }
        }
        void _MasterDetailsVieModel_OnGetCategoriesCompleted(int arg1, string arg2)
        {
            _MasterDetailsVieModel.OnGetCategoriesCompleted -= _MasterDetailsVieModel_OnGetCategoriesCompleted;

            try
            {
                Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                {

                    if (arg1 == 200)
                    {
                        if (_MasterDetailsVieModel == null)
                            _MasterDetailsVieModel = new MasterDetailsVieModel();
                        _MasterDetailsVieModel.GetSettings(StateUtilities.LoginHeaders.UserGuid, StateUtilities.LoginHeaders.UserShar);
                        _MasterDetailsVieModel.OnGetSettingsCompleted += _MasterDetailsVieModel_OnGetSettingsCompleted;
                     
                        // this.Frame.Navigate(typeof(MainPage),"LoginPage");
                    }
                    else
                    {
                        //pgRing.Visibility = Visibility.Collapsed;
                        //MessageDialog dialog = new MessageDialog("Please Enter Valid Credentials", "Alert");
                        //await dialog.ShowAsync();
                    }

                });

            }
            catch (Exception ex)
            { }
        }

        void _MasterDetailsVieModel_OnGetSettingsCompleted(int arg1, string arg2)
        {
            _MasterDetailsVieModel.OnGetSettingsCompleted -= _MasterDetailsVieModel_OnGetSettingsCompleted;


            try
            {
                Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                {

                    if (arg1 == 200)
                    {
                        if (_MasterDetailsVieModel == null)
                            _MasterDetailsVieModel = new MasterDetailsVieModel();
                        _MasterDetailsVieModel.GetAccounts(StateUtilities.LoginHeaders.UserGuid, StateUtilities.LoginHeaders.UserShar);
                        _MasterDetailsVieModel.OnGetAccountsCompleted += _MasterDetailsVieModel_OnGetAccountsCompleted; 
                     
                        // this.Frame.Navigate(typeof(MainPage),"LoginPage");
                    }
                    else
                    {
                        //pgRing.Visibility = Visibility.Collapsed;
                        //MessageDialog dialog = new MessageDialog("Please Enter Valid Credentials", "Alert");
                        //await dialog.ShowAsync();
                    }

                });

            }
            catch (Exception ex)
            { }
        }

        void _MasterDetailsVieModel_OnGetAccountsCompleted(int arg1, string arg2)
        {
            _MasterDetailsVieModel.OnGetAccountsCompleted -= _MasterDetailsVieModel_OnGetAccountsCompleted;


            try
            {
                Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                {

                    if (arg1 == 200)
                    {
                        if (_MasterDetailsVieModel == null)
                            _MasterDetailsVieModel = new MasterDetailsVieModel();
                        _MasterDetailsVieModel.GetCostcentres(StateUtilities.LoginHeaders.UserGuid, StateUtilities.LoginHeaders.UserShar);
                        _MasterDetailsVieModel.OnGetCostcentresCompleted += _MasterDetailsVieModel_OnGetCostcentresCompleted; 

                        // this.Frame.Navigate(typeof(MainPage),"LoginPage");
                    }
                    else
                    {
                        //pgRing.Visibility = Visibility.Collapsed;
                        //MessageDialog dialog = new MessageDialog("Please Enter Valid Credentials", "Alert");
                        //await dialog.ShowAsync();
                    }

                });

            }
            catch (Exception ex)
            { }
        }

        void _MasterDetailsVieModel_OnGetCostcentresCompleted(int arg1, string arg2)
        {
            _MasterDetailsVieModel.OnGetCostcentresCompleted -= _MasterDetailsVieModel_OnGetCostcentresCompleted;


            try
            {
                Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                {

                    if (arg1 == 200)
                    {
                        if (_MasterDetailsVieModel == null)
                            _MasterDetailsVieModel = new MasterDetailsVieModel();
                        _MasterDetailsVieModel.GetAccount(StateUtilities.LoginHeaders.UserGuid, StateUtilities.LoginHeaders.UserShar);
                        _MasterDetailsVieModel.OnGetAccountCompleted += _MasterDetailsVieModel_OnGetAccountCompleted;
                     
                      //  this.Frame.Navigate(typeof(MainPage),"LoginPage");
                    }
                    else
                    {
                        //pgRing.Visibility = Visibility.Collapsed;
                        //MessageDialog dialog = new MessageDialog("Please Enter Valid Credentials", "Alert");
                        //await dialog.ShowAsync();
                    }

                });

            }
            catch (Exception ex)
            { }
        }

        void _MasterDetailsVieModel_OnGetAccountCompleted(int arg1, string arg2)
        {
            _MasterDetailsVieModel.OnGetAccountCompleted -= _MasterDetailsVieModel_OnGetAccountCompleted;


            try
            {
                Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                {

                    if (arg1 == 200)
                    {
                        if (_MasterDetailsVieModel == null)
                            _MasterDetailsVieModel = new MasterDetailsVieModel();
                        _MasterDetailsVieModel.GetVatRates(StateUtilities.LoginHeaders.UserGuid, StateUtilities.LoginHeaders.UserShar);
                        _MasterDetailsVieModel.OnGetVatRatesCompleted += _MasterDetailsVieModel_OnGetVatRatesCompleted;
                     
                      //  this.Frame.Navigate(typeof(MainPage),"LoginPage");
                    }
                    else
                    {
                        //pgRing.Visibility = Visibility.Collapsed;
                        //MessageDialog dialog = new MessageDialog("Please Enter Valid Credentials", "Alert");
                        //await dialog.ShowAsync();
                    }

                });

            }
            catch (Exception ex)
            { }
        }

        void _MasterDetailsVieModel_OnGetVatRatesCompleted(int arg1, string arg2)
        {
            _MasterDetailsVieModel.OnGetVatRatesCompleted -= _MasterDetailsVieModel_OnGetVatRatesCompleted;


            try
            {
                Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                {

                    if (arg1 == 200)
                    {
                        //if (_MasterDetailsVieModel == null)
                        //    _MasterDetailsVieModel = new MasterDetailsVieModel();
                        //_MasterDetailsVieModel.GetVatRates(StateUtilities.LoginHeaders.UserGuid, StateUtilities.LoginHeaders.UserShar);
                        //_MasterDetailsVieModel.OnGetVatRatesCompleted += _MasterDetailsVieModel_OnGetVatRatesCompleted;

                          this.Frame.Navigate(typeof(MainPage),"LoginPage");
                    }
                    else
                    {
                        //pgRing.Visibility = Visibility.Collapsed;
                        //MessageDialog dialog = new MessageDialog("Please Enter Valid Credentials", "Alert");
                        //await dialog.ShowAsync();
                    }

                });

            }
            catch (Exception ex)
            { }
        }
    }
}
