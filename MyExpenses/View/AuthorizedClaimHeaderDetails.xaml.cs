using MyExpenses.ResponseParsers.AuthClaims;
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
using Windows.UI.Core;
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
    public sealed partial class AuthorizedClaimHeaderDetails : Page
    {
        private AuthClaimHeadersDT _ClaimHeadersDT = null;
        public AuthorizedClaimHeaderDetails()
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
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += BackButtonPress;
            if (e.NavigationMode == NavigationMode.New)
            {
                if (e.Parameter != null && e.Parameter.GetType() == typeof(AuthClaimHeadersDT))
                {
                    _ClaimHeadersDT = e.Parameter as AuthClaimHeadersDT;
                    txtDesc.Text = _ClaimHeadersDT.H_description;
                    txtref.Text = _ClaimHeadersDT.H_expense_headerID;
                    txtant.Text = _ClaimHeadersDT.H_orig_name;

                   


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
              //  SubmitClaim();
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

        private void GoBack()
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }

        }
        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

    }
}
