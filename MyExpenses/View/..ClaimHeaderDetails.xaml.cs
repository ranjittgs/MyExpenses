using MyExpenses.Common;
using MyExpenses.Utilities;
using MyExpenses.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Popups;
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
            if(e.NavigationMode==NavigationMode.New)
            {
                if(e.Parameter!=null && e.Parameter.GetType()==typeof(ClaimHeadersDT))
                {
                     _ClaimHeadersDT = e.Parameter as ClaimHeadersDT;
                    txtDesc.Text = _ClaimHeadersDT.H_description;
                    txtref.Text = _ClaimHeadersDT.H_expense_headerID;
                    txtant.Text = _ClaimHeadersDT.H_orig_name;

                    if(StateUtilities.ListClaimDetailsDT!=null)
                    {

                        var listDetails = StateUtilities.ListClaimDetailsDT.Where(i => i.Expense_headerID == _ClaimHeadersDT.H_expense_headerID).ToList();

                        lstData.ItemsSource = listDetails;
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

        private void btnsubmit_Click(object sender, RoutedEventArgs e)
        {

        }

        MyClaimViewModel _MyClaimViewModel = null;
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

        void _MyClaimViewModel_OnDeleteClaimHeaderCompleted(int arg1, string arg2)
        {
            _MyClaimViewModel.OnDeleteClaimHeaderCompleted -= _MyClaimViewModel_OnDeleteClaimHeaderCompleted;
        }

        private void DeleteClaimLine(string UniqueID)
        {
            if (_MyClaimViewModel == null)
                _MyClaimViewModel = new MyClaimViewModel();
            _MyClaimViewModel.DeleteClaimLine(StateUtilities.LoginHeaders.UserGuid, StateUtilities.LoginHeaders.UserShar, UniqueID);
            _MyClaimViewModel.OnDeleteClaimLineCompleted += _MyClaimViewModel_OnDeleteClaimLineCompleted;
        }

        void _MyClaimViewModel_OnDeleteClaimLineCompleted(int arg1, string arg2)
        {
            _MyClaimViewModel.OnDeleteClaimLineCompleted -= _MyClaimViewModel_OnDeleteClaimLineCompleted;
          
        }
        private void MoveClaimLine(string NewClaimID,string UniqueID)
        {
            if (_MyClaimViewModel == null)
                _MyClaimViewModel = new MyClaimViewModel();
            _MyClaimViewModel.MoveClaimLine(StateUtilities.LoginHeaders.UserGuid, StateUtilities.LoginHeaders.UserShar, UniqueID, NewClaimID);
            _MyClaimViewModel.OnMoveClaimLineCompleted += _MyClaimViewModel_OnMoveClaimLineCompleted;
        }

        void _MyClaimViewModel_OnMoveClaimLineCompleted(int arg1, string arg2)
        {
            _MyClaimViewModel.OnMoveClaimLineCompleted -= _MyClaimViewModel_OnMoveClaimLineCompleted;

        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
        ClaimDetailsDT _ClaimDetailsDT=null;
        private void Grid_Holding(object sender, HoldingRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);
            flyoutBase.ShowAt(senderElement);
            _ClaimDetailsDT = (sender as Grid).DataContext as ClaimDetailsDT;
        }

        private async void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
          
            string action = (sender as MenuFlyoutItem).Text as string;
            switch (action)
            {
                case "move":
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

        private void CommandInvokedHandler1(IUICommand command)
        {
            if (command.Label.Equals("Ok"))
            {
                DeleteClaimLine(_ClaimDetailsDT.UniqueID);
            }
        }
    }
}
