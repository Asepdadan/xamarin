using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.CobaGrid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LayoutGrid : ContentPage
    {

        int clickTotal;
        public LayoutGrid()
        {
            InitializeComponent();

            BindingContext = this;
        }

        void OnImageButtonClicked(object sender, EventArgs e)
        {
            clickTotal += 1;
            //label.Text = $"{clickTotal} ImageButton click{(clickTotal == 1 ? "" : "s")}";
        }

        void OnTappedStackLayout(object sender, EventArgs e)
        {
            string data = ((StackLayout)sender).BindingContext as string;
            StackLayout stackLayout = (StackLayout)sender;
            //Label label = (Label)sender;
            //Image image = (Image)sender;

            Console.WriteLine(stackLayout.BindingContext.ToString());
            //DisplayAlert("info", "Sip Clicked", "ok");
            if (stackLayout.BindingContext.ToString() == "home")
            {
                home.BackgroundColor = Color.FromHex("#2189ce");
                pembelian.BackgroundColor = Color.FromHex("#f2f8fc");
            }
            else if (stackLayout.BindingContext.ToString() == "pembelian")
            {   
                pembelian.BackgroundColor = Color.FromHex("#2189ce");
                home.BackgroundColor = Color.FromHex("#f2f8fc");   
            }
           
        }

        void OnTappedImage(object sender, EventArgs e)
        {
            string data = ((Image)sender).BindingContext as string;
            Image image = (Image)sender;
            //Image label = (Label)sender;
            //Image image = (Image)sender;

            Console.WriteLine(image.BindingContext.ToString());
            //DisplayAlert("info", "Sip Clicked", "ok");
            if (image.BindingContext.ToString() == "home")
            {
                home.BackgroundColor = Color.FromHex("#2189ce");
                pembelian.BackgroundColor = Color.FromHex("#f2f8fc");
            }
            else if (image.BindingContext.ToString() == "pembelian")
            {
                pembelian.BackgroundColor = Color.FromHex("#2189ce");
                home.BackgroundColor = Color.FromHex("#f2f8fc");
            }

        }
    }
}