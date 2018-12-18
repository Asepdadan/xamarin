using App1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.NewFolder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
        
        public Page1 ()
		{
			InitializeComponent ();
            BindingContext = this;

            var names = new List<Slides>
           {
               new Slides("http://developeraplikasi.com/wp-content/uploads/2018/08/landing-page-1.jpg","lorem ipsum"),
               new Slides("http://developeraplikasi.com/wp-content/uploads/2018/08/landing-page-1.jpg","lorem ipsum"),
               new Slides("http://developeraplikasi.com/wp-content/uploads/2018/08/landing-page-1.jpg","lorem ipsum"),
           };

            MainCarouselView.ItemsSource = names;

        }

        

	}
}