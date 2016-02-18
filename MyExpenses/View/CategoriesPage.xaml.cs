using MyExpenses.ResponseParsers;
using MyExpenses.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
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
    public sealed partial class CategoriesPage : Page
    {
        private List<Categories> listCat = null;
        public CategoriesPage()
        {
            this.InitializeComponent();
            this.Loaded += Categories_Loaded;
        }

        async void Categories_Loaded(object sender, RoutedEventArgs e)
        {
             listCat = await App.Connection.QueryAsync<Categories>("select * from Categories");
            //if(listCat!=null && listCat.Count>0)
            //{

            //}

            List<CategoryGroup> listCg = new List<CategoryGroup>();
            listCg.Add(new CategoryGroup { GroupId = "1", GroupName = "CarHire" });
            listCg.Add(new CategoryGroup { GroupId = "2", GroupName = "Rail" });
            listCg.Add(new CategoryGroup { GroupId = "3", GroupName = "Hotel" });
            listCg.Add(new CategoryGroup { GroupId = "4", GroupName = "Meal" });
            listCg.Add(new CategoryGroup { GroupId = "5", GroupName = "Parking" });
            listCg.Add(new CategoryGroup { GroupId = "6", GroupName = "Mileage" });
            listCg.Add(new CategoryGroup { GroupId = "7", GroupName = "Flight" });
            listCg.Add(new CategoryGroup { GroupId = "8", GroupName = "Taxi" });
            listCg.Add(new CategoryGroup { GroupId = "9", GroupName = "Office" });
            listCg.Add(new CategoryGroup { GroupId = "10", GroupName = "Misc" });

            dashBoardListView.ItemsSource = listCg;

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += BackButtonPress;
        }
        private async void BackButtonPress(object sender, BackPressedEventArgs e)
        {
            List<Popup> Popups = VisualTreeHelper.GetOpenPopups(Window.Current).ToList();
            if (Popups.Count > 1)
            {
                myClaimsPopup.IsOpen = false;
                e.Handled = true;
            }
            else if (!e.Handled && this.Frame.CanGoBack)
            {
                e.Handled = true;
                this.Frame.GoBack();
            }


        }

        private async void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {

            CategoryGroup _CategoryGroup = (sender as Grid).DataContext as CategoryGroup;
              if(_CategoryGroup!=null && listCat!=null && listCat.Count>0)
              {
                  var catlist = listCat.Where(i => i.Category_groupID == _CategoryGroup.GroupId).ToList() ;
                  if(catlist!=null && catlist.Count>0)
                  {
                      if(catlist.Count==1)
                      {
                          StateUtilities.CurrentClaimDetails.categoryID = catlist.FirstOrDefault().CategoryID;
                          StateUtilities.CurrentClaimDetails.categoryName = catlist.FirstOrDefault().Name;
                          this.Frame.Navigate(typeof(AddClaimLinePage));
                      }
                      else
                      {
                          StateUtilities.SelectedCatlist = catlist;
                          myClaimsPopup.IsOpen = true;
                          ClaimCategoriesUserControl.ClaimCategoriesUserControlClosed += ClaimCategoriesUserControl_ClaimCategoriesUserControlClosed;
                         // ClaimCategoriesUserControl.DataContext = catlist;
                      }


                  }

              }
            
        
        }

        void ClaimCategoriesUserControl_ClaimCategoriesUserControlClosed(string obj)
        {
            ClaimCategoriesUserControl.ClaimCategoriesUserControlClosed -= ClaimCategoriesUserControl_ClaimCategoriesUserControlClosed;
            myClaimsPopup.IsOpen = false;
            this.Frame.Navigate(typeof(AddClaimLinePage));
        }
    }

    public class CategoryGroup
    {
        public string GroupId { set; get; }
        public string GroupName { set; get; }

        public string ImageURL { set; get; }
    }
}
