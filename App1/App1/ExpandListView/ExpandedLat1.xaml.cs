using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.ExpandListView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExpandedLat1 : ContentPage
	{
		public ExpandedLat1 ()
		{
			InitializeComponent ();
		}

        private void ListViewItem_Tabbed(object sender, ItemTappedEventArgs e)
        {
            var product = e.Item as Product;
            var vm = BindingContext as ExpandedModel;
            vm?.ShoworHiddenProducts(product);//maksudna naon ieu? wkwwk

            
        }
    }
}