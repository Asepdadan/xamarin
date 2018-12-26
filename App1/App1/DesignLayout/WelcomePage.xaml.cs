using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.DesignLayout
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomePage : TabbedPage
	{
		public WelcomePage ()
		{
			InitializeComponent ();
		}
	}
}