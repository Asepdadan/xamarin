using App1.Model;
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
	public partial class Picker : ContentPage
	{
		public Picker ()
		{
			InitializeComponent ();

            BindingContext = new PickerViewModel();
        }

    }
}