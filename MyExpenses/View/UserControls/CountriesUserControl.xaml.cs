using MyExpenses.ResponseParsers;
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
    public sealed partial class CountriesUserControl : UserControl
    {
        public event Action<string,string> ClaimCategoriesUserControlClosed;
        public CountriesUserControl()
        {
            this.InitializeComponent();
            this.Loaded += CountriesUserControl_Loaded;
        }

        void CountriesUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dashBoardListView.ItemsSource = StateUtilities.CountriesList;
        }
        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Countries _Countries = (sender as Grid).DataContext as Countries;
            if (_Countries != null)
            {
                StateUtilities.CurrentClaimDetails.countryCode = _Countries.Country_code;

                StateUtilities.SelectedCurrency = StateUtilities.ListCurrencies.Where(i => i.Currency_code == _Countries.Currency_code).ToList().FirstOrDefault();
                if (ClaimCategoriesUserControlClosed != null)
                    ClaimCategoriesUserControlClosed(_Countries.Country_code, _Countries.Description);
            }

        }
    }
}
