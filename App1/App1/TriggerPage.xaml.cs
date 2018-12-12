using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.SfAutoComplete.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Model;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TriggerPage : ContentPage
	{
		public TriggerPage ()
		{
			InitializeComponent ();

            BindingContext = new MyTriggerViewModel();

            //loginButton.Clicked += LoginButton_Clicked;

            OrderInfoRepository viewModel = new OrderInfoRepository();
            dataGrid.ItemsSource = viewModel.OrderInfoCollection;
        }

        async void LoginButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppLogin1());
        }
    }
}