using MyExpenses.Utilities;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MyExpenses.View.UserControls
{
    public sealed partial class MyClaimsUserControl : UserControl
    {
        public event Action<string> myClaimsUserControlClosed;
        public MyClaimsUserControl()
        {
            this.InitializeComponent();
            this.Loaded += MyClaimsUserControl_Loaded;
        }

        void MyClaimsUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = StateUtilities.MyClaimsViewModel;
            //throw new NotImplementedException();
        }


        private async void claim_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ClaimHeadersDT _ClaimHeadersDT = (sender as FrameworkElement).DataContext as ClaimHeadersDT;
            var messageDialog = new MessageDialog("Move selected line to this claim ?", "Confirm");
            messageDialog.Commands.Add(new UICommand { Label = "Yes" });
            messageDialog.Commands.Add(new UICommand() { Label = "No" });
            var res = await messageDialog.ShowAsync();
            if (res.Label != null && res.Label.ToLower() == "yes")
            {
                if (_ClaimHeadersDT != null && !string.IsNullOrEmpty(_ClaimHeadersDT.H_expense_headerID))
                {
                    if (myClaimsUserControlClosed != null)
                    {
                        myClaimsUserControlClosed(_ClaimHeadersDT.H_expense_headerID);
                    }
                }
            }
           
        }
    }
}
