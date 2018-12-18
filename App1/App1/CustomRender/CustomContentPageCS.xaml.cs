using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.CustomRender
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomContentPageCS : ContentPage
	{
		public CustomContentPageCS()
		{
			InitializeComponent ();
		}
	}
}