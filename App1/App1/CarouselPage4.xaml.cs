using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CarouselPage4 : ContentPage
	{
        public ObservableCollection<string> Person { get; set; }

        public CarouselPage4 ()
		{
			InitializeComponent ();

            BindingContext = this;
            

        }
    }
}