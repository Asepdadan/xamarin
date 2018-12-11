using App1.ViewModels;
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
	public partial class MyListPage : ContentPage
	{
		public MyListPage ()
		{
			InitializeComponent ();

            BindingContext = new MyListViewModel();
        }

        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            var _container = BindingContext as MyListViewModel;
            EmployeeListView.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                EmployeeListView.ItemsSource = _container.MyListCollector;
            else
                EmployeeListView.ItemsSource = _container.MyListCollector.Where(i => 
                    i.MyName.Contains(e.NewTextValue)
                );

            EmployeeListView.EndRefresh();
        }


        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var _container = BindingContext as MyListViewModel;
            //do work over here
            DisplayAlert("Sucess", "You have Subscribed", "OK", "Cancel");
        }
    }
}