using App1.FMasterDetailPage;
using App1.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailMasterLearning : MasterDetailPage
	{
        public int RowHeight { get; set; }
        public List<MasterPageItem> Menulist{ get; set; }

		public DetailMasterLearning ()
		{
			InitializeComponent ();

            Detail = new NavigationPage(new Page1());
            IsPresented = false;

            Menulist = new List<MasterPageItem>() {
                   new MasterPageItem(){ Title= "Page 1", Icon = "baseline_shopping_cart_black_18.png", TargetType = typeof(Page1) },
                   new MasterPageItem(){ Title= "Page 2", Icon = "baseline_search_black_18.png", TargetType = typeof(Page2) },
            };

            navigationDrawerList.ItemsSource = Menulist;

            this.BindingContext = new
            {
                 Header = "App",
                 Image = "drawerback.jpg",
                 Footer = "Welcome Xamarin"
            };

            navigationDrawerList.RowHeight = 40;//height list view
            
        }

        void OnMenuSelected(Object Sender, SelectedItemChangedEventArgs e) 
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }

        void Pindah_page(Object Sender, EventArgs args) {
            Detail = new NavigationPage(new Page1());
            IsPresented = false;
        }

        void Pindah_page2(Object Sender, EventArgs args)
        {
            Detail = new NavigationPage(new Page2());
            IsPresented = false;
        }

        async void Search_Button(object sender, EventArgs e) {
            await Navigation.PushModalAsync(new Date(), false);
        }


    }
}