using MyExpenses.Common;
using MyExpenses.ResponseParsers;
using MyExpenses.Utilities;
using MyExpenses.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
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
    public sealed partial class ClaimHeaderDetails : Page
    {
        public ClaimHeaderDetails()
        {
            this.InitializeComponent();
            this.Loaded += ClaimHeaderDetails_Loaded;
        }

       async void ClaimHeaderDetails_Loaded(object sender, RoutedEventArgs e)
        {
            StatusBar statusbar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
            statusbar.ForegroundColor = Color.FromArgb(255, 0, 1, 0);
            statusbar.ShowAsync();
          await  BindData();
        }


        private async Task BindData()
        {

            if (StateUtilities.ListClaimDetailsDT != null)
            {
                if (StateUtilities.ListCurrencies == null)
                {
                    StateUtilities.ListCurrencies = await App.Connection.QueryAsync<Currencies>("select * from Currencies");
                }
                if (StateUtilities.ListCategories == null)
                {
                    StateUtilities.ListCategories = await App.Connection.QueryAsync<MyExpenses.ResponseParsers.Categories>("select * from Categories");
                }
                var listDetails = StateUtilities.ListClaimDetailsDT.Where(i => i.Expense_headerID == _ClaimHeadersDT.H_expense_headerID && i.Deleted=="0").ToList();

                foreach(var item in listDetails)
                {
                    item.CurrencySymbol = StateUtilities.ListCurrencies.Where(i => i.Currency_code == item.Base_currency).FirstOrDefault().Currency_symbol;
                    item.CategoryName = StateUtilities.ListCategories.Where(i => i.CategoryID == item.Category).FirstOrDefault().Name;
                }
                lstData.ItemsSource = listDetails;
            }

        }

        private ClaimHeadersDT _ClaimHeadersDT = null;
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += BackButtonPress;
            if (e.NavigationMode == NavigationMode.New)
            {
                if (e.Parameter != null && e.Parameter.GetType() == typeof(ClaimHeadersDT))
                {
                    _ClaimHeadersDT = e.Parameter as ClaimHeadersDT;
                    txtDesc.Text = _ClaimHeadersDT.H_description;
                    txtref.Text = _ClaimHeadersDT.H_expense_headerID;
                    txtant.Text = _ClaimHeadersDT.H_orig_name;

                    if( AppConstants.SelectedPage==AppConstants.DREAFT)
                    {
                        gridButtons.Visibility = Visibility.Visible;
                    }
                    else
                        if (AppConstants.SelectedPage == AppConstants.SUBMITTED)
                        {
                            gridButtons.Visibility = Visibility.Collapsed;
                        }
                        else
                        {
                            gridButtons.Visibility = Visibility.Collapsed;

                        }


                }
            }
        }
        private async void BackButtonPress(object sender, BackPressedEventArgs e)
        {
            //List<Popup> Popups = VisualTreeHelper.GetOpenPopups(Window.Current).ToList();
            //if (Popups.Count > 1)
            //{
            //    e.Handled = true;
            //}
            if (!e.Handled && this.Frame.CanGoBack)
            {
                e.Handled = true;
                this.Frame.GoBack();
            }


        }

        private async void btnsubmit_Click(object sender, RoutedEventArgs e)
        {
            var messageDialog = new MessageDialog("Submit this Claim?", "Alert!");
            messageDialog.Commands.Add(new UICommand() { Label = "ok" });
            messageDialog.Commands.Add(new UICommand() { Label = "cancel" });
            var res = await messageDialog.ShowAsync();
            if (res.Label.ToLower() == "ok")
            {
                pgRing.Visibility = Visibility.Visible;
                SubmitClaim();
            }
        }

        MyClaimViewModel _MyClaimViewModel = null;
        private void SubmitClaim()
        {
            if (_MyClaimViewModel == null)
                _MyClaimViewModel = new MyClaimViewModel();
            _MyClaimViewModel.SubmitClaim(StateUtilities.LoginHeaders.UserGuid, StateUtilities.LoginHeaders.UserShar, _ClaimHeadersDT.H_expense_headerID);
            _MyClaimViewModel.OnSubmitClaimCompleted += _MyClaimViewModel_OnSubmitClaimCompleted;
        }

       async void _MyClaimViewModel_OnSubmitClaimCompleted(int arg1, string arg2)
        {
            _MyClaimViewModel.OnSubmitClaimCompleted -= _MyClaimViewModel_OnSubmitClaimCompleted;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                pgRing.Visibility = Visibility.Collapsed;
                if (arg1 == 200)
                {

                    StateUtilities.IsAnythingModified = true;
                   
                        try
                        {
                            GoBack();
                        }
                        catch
                        { }
                    
                }
            });
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
        }
        private void DeleteClaimHeader()
        {

            if (_MyClaimViewModel == null)
                _MyClaimViewModel = new MyClaimViewModel();
            _MyClaimViewModel.DeleteClaimHeader(StateUtilities.LoginHeaders.UserGuid, StateUtilities.LoginHeaders.UserShar, _ClaimHeadersDT.H_expense_headerID);
            _MyClaimViewModel.OnDeleteClaimHeaderCompleted += _MyClaimViewModel_OnDeleteClaimHeaderCompleted;
        }

     async   void _MyClaimViewModel_OnDeleteClaimHeaderCompleted(int arg1, string arg2)
        {
            _MyClaimViewModel.OnDeleteClaimHeaderCompleted -= _MyClaimViewModel_OnDeleteClaimHeaderCompleted;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                pgRing.Visibility = Visibility.Collapsed;
                if (arg1 == 200)
                {
                    StateUtilities.IsAnythingModified = true;
                    if (StateUtilities.ListClaimDetailsDT != null)
                    {
                        try
                        {
                            GoBack();
                        }
                        catch
                        { }
                    }
                }
            });
        }

     private void GoBack()
     {
         if (this.Frame.CanGoBack)
         {
             this.Frame.GoBack();
         }

     }

        private void DeleteClaimLine(string UniqueID)
        {
            if (_MyClaimViewModel == null)
                _MyClaimViewModel = new MyClaimViewModel();
            _MyClaimViewModel.DeleteClaimLine(StateUtilities.LoginHeaders.UserGuid, StateUtilities.LoginHeaders.UserShar, UniqueID);
            _MyClaimViewModel.OnDeleteClaimLineCompleted += _MyClaimViewModel_OnDeleteClaimLineCompleted;
        }

     async   void _MyClaimViewModel_OnDeleteClaimLineCompleted(int arg1, string arg2)
        {
            _MyClaimViewModel.OnDeleteClaimLineCompleted -= _MyClaimViewModel_OnDeleteClaimLineCompleted;

            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                pgRing.Visibility = Visibility.Collapsed;
                if (arg1 == 200)
                {
                    StateUtilities.IsAnythingModified = true;
                    if (StateUtilities.ListClaimDetailsDT != null)
                    {
                        try
                        {
                            var listDetails = StateUtilities.ListClaimDetailsDT.Where(i => i.Expense_headerID == _ClaimHeadersDT.H_expense_headerID).ToList();
                            listDetails.Remove(listDetails.Where(Item => Item.UniqueID == _ClaimDetailsDT.UniqueID).FirstOrDefault());
                            lstData.ItemsSource = null;
                            lstData.ItemsSource = listDetails;
                        }
                        catch
                        { }
                    }
                }
            });


        }
        private void MoveClaimLine(string NewClaimID, string UniqueID)
        {
            if (_MyClaimViewModel == null)
                _MyClaimViewModel = new MyClaimViewModel();
            _MyClaimViewModel.MoveClaimLine(StateUtilities.LoginHeaders.UserGuid, StateUtilities.LoginHeaders.UserShar, UniqueID, NewClaimID);
            _MyClaimViewModel.OnMoveClaimLineCompleted += _MyClaimViewModel_OnMoveClaimLineCompleted;
        }

     async   void _MyClaimViewModel_OnMoveClaimLineCompleted(int arg1, string arg2)
        {
            _MyClaimViewModel.OnMoveClaimLineCompleted -= _MyClaimViewModel_OnMoveClaimLineCompleted;

        await    Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                 {
                     if (arg1 == 200)
                     {
                         StateUtilities.IsAnythingModified = true;
                         if (StateUtilities.ListClaimDetailsDT != null)
                         {
                             try
                             {
                                 var listDetails = StateUtilities.ListClaimDetailsDT.Where(i => i.Expense_headerID == _ClaimHeadersDT.H_expense_headerID).ToList();
                                 listDetails.Remove(listDetails.Where(Item => Item.UniqueID == _ClaimDetailsDT.UniqueID).FirstOrDefault());
                                 lstData.ItemsSource = null;
                                 lstData.ItemsSource = listDetails;
                             }
                             catch
                             { }
                         }
                     }
                 });

        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _ClaimDetailsDT = (sender as Grid).DataContext as ClaimDetailsDT;
            if (AppConstants.SelectedPage == AppConstants.DREAFT)
            {

                this.Frame.Navigate(typeof(AddClaimLinePage), _ClaimDetailsDT);

            }
            else
            {

            }
        }
        ClaimDetailsDT _ClaimDetailsDT = null;
        private void Grid_Holding(object sender, HoldingRoutedEventArgs e)
        {
            if (AppConstants.SelectedPage == AppConstants.DREAFT)
            {
                FrameworkElement senderElement = sender as FrameworkElement;
                FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);
                flyoutBase.ShowAt(senderElement);
                _ClaimDetailsDT = (sender as Grid).DataContext as ClaimDetailsDT;
            }
        }

        private async void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {

            string action = (sender as MenuFlyoutItem).Text as string;
            switch (action)
            {
                case "move":
                    if (CommonFunctions.IsNetworkAvaliable())
                    {
                        myClaimsPopup.IsOpen = true;
                        myClaimsUserControl.myClaimsUserControlClosed += myClaimsUserControl_myClaimsUserControlClosed;
                        //    MoveClaimLine("", _ClaimDetailsDT.UniqueID);
                        // callCopyMoveDeleteOperation(AppConstants.COPY, lstMediaItems, AppConstants.CopyText);
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
                        var messageDialog = new MessageDialog("Delete this Claim Line?", "Alert!");
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

        void myClaimsUserControl_myClaimsUserControlClosed(string obj)
        {
            myClaimsUserControl.myClaimsUserControlClosed -= myClaimsUserControl_myClaimsUserControlClosed;
            myClaimsPopup.IsOpen = false;
            if (!string.IsNullOrEmpty(obj))
            {
                MoveClaimLine(obj, _ClaimDetailsDT.UniqueID);
            }
            //throw new NotImplementedException();
        }

        private void CommandInvokedHandler1(IUICommand command)
        {
            if (command.Label.Equals("Ok"))
            {
                pgRing.Visibility = Visibility.Visible;
                DeleteClaimLine(_ClaimDetailsDT.UniqueID);
            }
        }

       

        private async void headerDelete_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (CommonFunctions.IsNetworkAvaliable())
            {
                var messageDialog = new MessageDialog("Delete this Claim?", "Alert!");
                messageDialog.Commands.Add(new UICommand() { Label="ok"});
                messageDialog.Commands.Add(new UICommand() { Label ="cancel"});
             var res=   await messageDialog.ShowAsync();
                if(res.Label.ToLower()=="ok")
                {
                    pgRing.Visibility = Visibility.Visible;
                    DeleteClaimHeader();
                }


            }
            else
            {
                MessageDialog msgDialog = new MessageDialog(AppConstants.NO_INTERNETCONNECTION, "Alert!");
                await msgDialog.ShowAsync();
            }
        }
    }
}
