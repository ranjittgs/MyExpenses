using MyExpenses.ResponseParsers.VatRates;
using MyExpenses.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class VatRatesUserControl : UserControl
    {
        public event Action<string> VatRatesUserControlClosed;
        public VatRatesUserControl()
        {
            this.InitializeComponent();
            this.Loaded += VatRatesUserControl_Loaded;
        }

        void VatRatesUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dashBoardListView.ItemsSource = StateUtilities.ListVatRates;
        }
        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            VatRates VatRates = (sender as Grid).DataContext as VatRates;
            if (VatRates != null)
            {
                StateUtilities.CurrentClaimDetails.vatRateID = VatRates.Vat_rate_ID;
                StateUtilities.CurrentClaimDetails.VATPercentage = VatRates.Percentage;
                if (VatRatesUserControlClosed != null)
                    VatRatesUserControlClosed(StateUtilities.CurrentClaimDetails.vatRateID);
            }
        }
    }
}
