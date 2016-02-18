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
    public sealed partial class ClaimCategoriesUserControl : UserControl
    {
        public event Action<string> ClaimCategoriesUserControlClosed;

        string Type = "";

        public ClaimCategoriesUserControl()
        {
            this.InitializeComponent();
            this.Loaded += ClaimCategoriesUserControl_Loaded;
        }

        void ClaimCategoriesUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dashBoardListView.ItemsSource = StateUtilities.SelectedCatlist;
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Categories _Categories = (sender as Grid).DataContext as Categories;
            if(_Categories!=null)
            {
                StateUtilities.CurrentClaimDetails.categoryID = _Categories.CategoryID;
                StateUtilities.CurrentClaimDetails.categoryName = _Categories.Name;
                if (ClaimCategoriesUserControlClosed != null)
                    ClaimCategoriesUserControlClosed(StateUtilities.CurrentClaimDetails.categoryID);
            }

        }
    }
}
