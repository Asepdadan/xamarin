using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Date : ContentPage
	{
                

        public Date ()
		{
			InitializeComponent ();
		}

        private async void Navigation_Button(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Calculator());
        }
    }

    
}