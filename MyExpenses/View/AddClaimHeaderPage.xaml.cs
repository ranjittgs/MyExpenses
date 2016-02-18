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
    public sealed partial class AddClaimHeaderPage : Page
    {
        private List<ClaimTypes> lstTypes = null;
        public AddClaimHeaderPage()
        {
            this.InitializeComponent();
            this.Loaded += AddClaimHeaderPage_Loaded;
        }

       async void AddClaimHeaderPage_Loaded(object sender, RoutedEventArgs e)
        {
          await  BindDropDown();
        }

        private async Task BindDropDown()
        {
             lstTypes = await App.Connection.QueryAsync<ClaimTypes>("select * from ClaimTypes");
            if (lstTypes != null && lstTypes.Count>0)
            {
                List<string> lst = new List<string>();
                foreach (var text in lstTypes)
                    lst.Add(text.Expense_type);



                ddlClaimType.ItemsSource = lst;
                if(lstTypes.Count==1)
                {
                    ddlClaimType.SelectedIndex = 0;
                }
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

        void btnSettings_Click(object sender, RoutedEventArgs e)
        {
          if(lstTypes!=null)
          {

              var cat = lstTypes.Where(i=>i.Expense_type==ddlClaimType.SelectedValue.ToString()).ToList().FirstOrDefault();
              if (cat != null)
              {
                  StateUtilities.CurrentClaimDetails = null;
                  StateUtilities.CurrentClaimDetails = new Model.BussinessObjects.ClaimDetails();
                  StateUtilities.CurrentClaimDetails.claimType = cat.Expense_typeID;
                  StateUtilities.CurrentClaimDetails.Headerdescription = txtdesc.Text.Trim();

                  this.Frame.Navigate(typeof(CategoriesPage));
              
              }
          }
        }
    }
}
