using MyExpenses.ResponseParsers;
using MyExpenses.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Windows.Phone.UI.Input;
using MyExpenses.ViewModel;
using Windows.UI.Popups;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MyExpenses.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddClaimLinePage : Page
    {
        ClaimDetailsDT _ClaimDetailsDT = null;
        private bool isEditClaim = false;
        public AddClaimLinePage()
        {
            this.InitializeComponent();
            this.Loaded += AddClaimLinePage_Loaded;
        }

      async  void AddClaimLinePage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isEditClaim)
                await BindValues();
            else
                await EditValues();
        }


        private async Task BindValues()
        {
            txtCatName.Text = StateUtilities.CurrentClaimDetails.categoryName;
            if(StateUtilities.ListCurrencies==null)
            {
                StateUtilities.ListCurrencies = await App.Connection.QueryAsync<Currencies>("select * from Currencies");
            }
            if (StateUtilities.ListVatRates == null)
            {
                StateUtilities.ListVatRates = await App.Connection.QueryAsync<MyExpenses.ResponseParsers.VatRates.VatRates>("select * from VatRates");
            }
            List<Countries> lstCountries = await App.Connection.QueryAsync<Countries>("select * from Countries");
            if(lstCountries!=null)
            {
                StateUtilities.CountriesList = lstCountries;
                 Countries _Countries = lstCountries.Where(i => i.Country_code == StateUtilities.MobileSettings.BaseCountry).ToList().FirstOrDefault();
                if (_Countries != null)
                {
                    StateUtilities.CurrentClaimDetails.countryCode = _Countries.Country_code;
                    btnCountry.Content = _Countries.Description;
                    StateUtilities.SelectedCurrency = StateUtilities.ListCurrencies.Where(i => i.Currency_code == _Countries.Currency_code).ToList().FirstOrDefault();                   
                    if (StateUtilities.SelectedCurrency != null)
                    {
                        txtcurrencySymbol.Text = StateUtilities.SelectedCurrency.Currency_symbol;
                        txtcurrencyCode.Text = StateUtilities.SelectedCurrency.Currency_code + " (" + StateUtilities.SelectedCurrency.Description+ ")";
                        txtVATcurrencySymbol.Text = StateUtilities.SelectedCurrency.Currency_symbol;
                        txtVATcurrencyCode.Text = StateUtilities.SelectedCurrency.Currency_code + " (" + StateUtilities.SelectedCurrency.Description + ")";
                        StateUtilities.CurrentClaimDetails.currency = StateUtilities.SelectedCurrency.Currency_code;
                    }
                }

            }
            this.DataContext = StateUtilities.CurrentClaimDetails;
            List<MyExpenses.ResponseParsers.Account.Account> lstAccount = await App.Connection.QueryAsync<MyExpenses.ResponseParsers.Account.Account>("select * from Account");
            if (lstAccount != null)
            {
                ddlAccount.ItemsSource = lstAccount;
                ddlAccount.SelectedIndex = 0;
            }

            List<Projects> lstProjects = await App.Connection.QueryAsync<Projects>("select * from Projects");
            if (lstProjects != null)
            {
                ddlProject.ItemsSource = lstProjects;
                ddlProject.SelectedIndex = 0;
            }

            List<MyExpenses.ResponseParsers.CostCentres.CostCentre> lstCostCentre = await App.Connection.QueryAsync<MyExpenses.ResponseParsers.CostCentres.CostCentre>("select * from CostCentre");
            if (lstCostCentre != null)
            {
                ddlCost.ItemsSource = lstCostCentre;
                ddlCost.SelectedIndex = 0;
            }

        }


        private async Task EditValues()
        {
            if(_ClaimDetailsDT!=null)
            {
                if (StateUtilities.CurrentClaimDetails == null)
                    StateUtilities.CurrentClaimDetails = new Model.BussinessObjects.ClaimDetails();
                StateUtilities.CurrentClaimDetails.UniqueID = _ClaimDetailsDT.UniqueID;
                StateUtilities.CurrentClaimDetails.ClaimID = _ClaimDetailsDT.Expense_headerID;
                StateUtilities.CurrentClaimDetails.vatRateID=_ClaimDetailsDT.Vat_rate_ID;

                dtpClaimData.Date = StateUtilities.CurrentClaimDetails.ClaimLineDate = Convert.ToDateTime(_ClaimDetailsDT.Date);
                if (StateUtilities.ListCurrencies == null)
                {
                    StateUtilities.ListCurrencies = await App.Connection.QueryAsync<Currencies>("select * from Currencies");
                }
                if (StateUtilities.ListVatRates == null)
                {
                    StateUtilities.ListVatRates = await App.Connection.QueryAsync<MyExpenses.ResponseParsers.VatRates.VatRates>("select * from VatRates");
                }

                List<Countries> lstCountries = await App.Connection.QueryAsync<Countries>("select * from Countries");
                if (lstCountries != null)
                {
                    StateUtilities.CountriesList = lstCountries;
                    Countries _Countries = lstCountries.Where(i => i.Country_code == _ClaimDetailsDT.Base_currency).ToList().FirstOrDefault();
                    if (_Countries != null)
                    {
                        StateUtilities.CurrentClaimDetails.countryCode = _Countries.Country_code;
                        btnCountry.Content = _Countries.Description;
                        StateUtilities.SelectedCurrency = StateUtilities.ListCurrencies.Where(i => i.Currency_code == _Countries.Currency_code).ToList().FirstOrDefault();
                        if (StateUtilities.SelectedCurrency != null)
                        {
                            txtcurrencySymbol.Text = StateUtilities.SelectedCurrency.Currency_symbol;
                            txtcurrencyCode.Text = StateUtilities.SelectedCurrency.Currency_code + " (" + StateUtilities.SelectedCurrency.Description + ")";
                            txtVATcurrencySymbol.Text = StateUtilities.SelectedCurrency.Currency_symbol;
                            txtVATcurrencyCode.Text = StateUtilities.SelectedCurrency.Currency_code + " (" + StateUtilities.SelectedCurrency.Description + ")";
                            StateUtilities.CurrentClaimDetails.currency = StateUtilities.SelectedCurrency.Currency_code;
                        }
                    }

                }

                List<MyExpenses.ResponseParsers.Account.Account> lstAccount = await App.Connection.QueryAsync<MyExpenses.ResponseParsers.Account.Account>("select * from Account");
                if (lstAccount != null)
                {
                    ddlAccount.ItemsSource = lstAccount;
                    ddlAccount.SelectedIndex = 0;

                    ddlAccount.SelectedValue = _ClaimDetailsDT.AccountID;
                }

                List<Projects> lstProjects = await App.Connection.QueryAsync<Projects>("select * from Projects");
                if (lstProjects != null)
                {
                    ddlProject.ItemsSource = lstProjects;
                    ddlProject.SelectedIndex = 0;

                    ddlProject.SelectedValue = _ClaimDetailsDT.Project;
                }

                List<MyExpenses.ResponseParsers.CostCentres.CostCentre> lstCostCentre = await App.Connection.QueryAsync<MyExpenses.ResponseParsers.CostCentres.CostCentre>("select * from CostCentre");
                if (lstCostCentre != null)
                {
                    ddlCost.ItemsSource = lstCostCentre;
                    ddlCost.SelectedIndex = 0;
                    ddlCost.SelectedValue = _ClaimDetailsDT.Cost_centre_guid;
                }

                List<MyExpenses.ResponseParsers.Categories> lstCategories = await App.Connection.QueryAsync<MyExpenses.ResponseParsers.Categories>("select * from Categories");
                if (lstCategories!=null)
                {
                    var selectedcat = lstCategories.Where(i => i.CategoryID == _ClaimDetailsDT.Category).ToList().FirstOrDefault();
                    if (selectedcat != null)
                    {
                        StateUtilities.CurrentClaimDetails.categoryID = selectedcat.CategoryID;
                        txtCatName.Text = StateUtilities.CurrentClaimDetails.categoryName = selectedcat.Name;
                    }
                }

                txtAmount.Text = _ClaimDetailsDT.Trans_amount;
                txtVatAmount.Text = _ClaimDetailsDT.Trans_vat;

            }


        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += BackButtonPress;
            CreateApplicationBar();

            if(e.Parameter!=null && e.Parameter.GetType()==typeof(ClaimDetailsDT))
            {
                isEditClaim = true;
                _ClaimDetailsDT = e.Parameter as ClaimDetailsDT;
            }

        }
        private async void BackButtonPress(object sender, BackPressedEventArgs e)
        {
            List<Popup> Popups = VisualTreeHelper.GetOpenPopups(Window.Current).ToList();
            if (Popups.Count > 1)
            {
                myClaimsPopup.IsOpen = false;
                myVatRatesPopup.IsOpen = false;
                e.Handled = true;
            }
            else  if (!e.Handled && this.Frame.CanGoBack)
            {
                e.Handled = true;
                this.Frame.GoBack();
            }


        }
        private CommandBar bottomAppBar;
        private AppBarButton btnSettings;

        private void CreateApplicationBar()
        {

            bottomAppBar = new CommandBar();
            //      bottomAppBar.Style = (Style)App.Current.Resources["ApplicationBarStyle"];



            btnSettings = new AppBarButton();
            btnSettings.Label = "Done";
            btnSettings.Icon = new SymbolIcon(Symbol.Save);
            bottomAppBar.PrimaryCommands.Add(btnSettings);
            btnSettings.Click += btnSettings_Click;




            this.BottomAppBar = bottomAppBar;
        }

        AddEditClaimViewModel _AddEditClaimViewModel = null;
        void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pgRing.Visibility = Visibility.Visible;
                //Validate
                if (!isEditClaim)
                {
                   

                    StateUtilities.CurrentClaimDetails.ClaimLineDate = dtpClaimData.Date.DateTime;
                    StateUtilities.CurrentClaimDetails.amount = txtAmount.Text;
                    StateUtilities.CurrentClaimDetails.baseAmount = txtAmount.Text;
                    StateUtilities.CurrentClaimDetails.description = txtdesc.Text;
                    StateUtilities.CurrentClaimDetails.reference = txtref.Text;
                    //   StateUtilities.CurrentClaimDetails.additionalPeople = txtref.Text;
                    StateUtilities.CurrentClaimDetails.projectGUID = ddlProject.SelectedValue.ToString();
                    StateUtilities.CurrentClaimDetails.accountGUID = ddlAccount.SelectedValue.ToString();
                    StateUtilities.CurrentClaimDetails.costCenterGUID = ddlCost.SelectedValue.ToString();
                    StateUtilities.CurrentClaimDetails.vat = txtVatAmount.Text;

                    if (_AddEditClaimViewModel == null)
                        _AddEditClaimViewModel = new AddEditClaimViewModel();
                    _AddEditClaimViewModel.CreateClaimHeader(StateUtilities.LoginHeaders.UserGuid, StateUtilities.LoginHeaders.UserShar, StateUtilities.CurrentClaimDetails);
                    _AddEditClaimViewModel.OnAddClaimHeaderCompleted += _AddEditClaimViewModel_OnAddClaimHeaderCompleted;
                }
                else
                {
                    StateUtilities.CurrentClaimDetails.ClaimLineDate = dtpClaimData.Date.DateTime;
                    StateUtilities.CurrentClaimDetails.amount = txtAmount.Text;
                    StateUtilities.CurrentClaimDetails.baseAmount = txtAmount.Text;
                    StateUtilities.CurrentClaimDetails.description = txtdesc.Text;
                    StateUtilities.CurrentClaimDetails.reference = txtref.Text;
                    //   StateUtilities.CurrentClaimDetails.additionalPeople = txtref.Text;
                    StateUtilities.CurrentClaimDetails.projectGUID = ddlProject.SelectedValue.ToString();
                    StateUtilities.CurrentClaimDetails.accountGUID = ddlAccount.SelectedValue.ToString();
                    StateUtilities.CurrentClaimDetails.costCenterGUID = ddlCost.SelectedValue.ToString();
                    StateUtilities.CurrentClaimDetails.vat = txtVatAmount.Text;

                    if (_AddEditClaimViewModel == null)
                        _AddEditClaimViewModel = new AddEditClaimViewModel();
                    _AddEditClaimViewModel.UpdateLine(StateUtilities.LoginHeaders.UserGuid, StateUtilities.LoginHeaders.UserShar, StateUtilities.CurrentClaimDetails);
                    _AddEditClaimViewModel.OnUpdateLineCompleted += _AddEditClaimViewModel_OnUpdateLineCompleted;
                }
            }
            catch (Exception ex) { }
        }

        void _AddEditClaimViewModel_OnUpdateLineCompleted(int arg1, string arg2)
        {
            
        }

        void _AddEditClaimViewModel_OnAddClaimHeaderCompleted(int arg1, string arg2)
        {
            _AddEditClaimViewModel.OnAddClaimHeaderCompleted -= _AddEditClaimViewModel_OnAddClaimHeaderCompleted;
            try
            {
                Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                {

                    if (arg1 == 200)
                    {
                        if (_AddEditClaimViewModel == null)
                            _AddEditClaimViewModel = new AddEditClaimViewModel();
                        _AddEditClaimViewModel.CreateClaimLine(StateUtilities.LoginHeaders.UserGuid, StateUtilities.LoginHeaders.UserShar, StateUtilities.CurrentClaimDetails);
                        _AddEditClaimViewModel.OnAddClaimLineCompleted += _AddEditClaimViewModel_OnAddClaimLineCompleted;

                    }
                    else
                    {
                        pgRing.Visibility = Visibility.Collapsed;
                        MessageDialog dialog = new MessageDialog("Add Claim failed", "Alert");
                        await dialog.ShowAsync();
                    }

                });

            }
            catch (Exception ex)
            { }
        }

        void _AddEditClaimViewModel_OnAddClaimLineCompleted(int arg1, string arg2)
        {
            _AddEditClaimViewModel.OnAddClaimLineCompleted -= _AddEditClaimViewModel_OnAddClaimLineCompleted;
            try
            {
                Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                {

                    if (arg1 == 200)
                    {
                         this.Frame.Navigate(typeof(MainPage));
                    }
                    else
                    {
                        pgRing.Visibility = Visibility.Collapsed;
                        MessageDialog dialog = new MessageDialog("Add Claim failed", "Alert");
                        await dialog.ShowAsync();
                    }

                });

            }
            catch (Exception ex)
            { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myClaimsPopup.IsOpen = true;
            CountriesUserControl.ClaimCategoriesUserControlClosed += CountriesUserControl_ClaimCategoriesUserControlClosed;
        }

        void CountriesUserControl_ClaimCategoriesUserControlClosed(string arg1, string arg2)
        {
            CountriesUserControl.ClaimCategoriesUserControlClosed -= CountriesUserControl_ClaimCategoriesUserControlClosed;

            if(!string.IsNullOrEmpty(arg1) && !string.IsNullOrEmpty(arg2))
            {
                btnCountry.Content = arg2;
                if (StateUtilities.SelectedCurrency != null)
                {
                    txtcurrencySymbol.Text = StateUtilities.SelectedCurrency.Currency_symbol;
                    txtcurrencyCode.Text = StateUtilities.SelectedCurrency.Currency_code + " (" + StateUtilities.SelectedCurrency.Description + ")";
                    txtVATcurrencySymbol.Text = StateUtilities.SelectedCurrency.Currency_symbol;
                    txtVATcurrencyCode.Text = StateUtilities.SelectedCurrency.Currency_code + " (" + StateUtilities.SelectedCurrency.Description + ")";
                    StateUtilities.CurrentClaimDetails.currency = StateUtilities.SelectedCurrency.Currency_code;

                }
            }
            myClaimsPopup.IsOpen = false;
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            myVatRatesPopup.IsOpen = true;
            VatRatesUserControl.VatRatesUserControlClosed += VatRatesUserControl_VatRatesUserControlClosed;
        }

        void VatRatesUserControl_VatRatesUserControlClosed(string obj)
        {
            VatRatesUserControl.VatRatesUserControlClosed -= VatRatesUserControl_VatRatesUserControlClosed;
            myVatRatesPopup.IsOpen = false;
            if (!string.IsNullOrEmpty(obj))
            {
                //CalculateVAT
            }
        }
    }
}
