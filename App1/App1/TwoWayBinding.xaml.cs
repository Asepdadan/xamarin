using App1.ViewModels;
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
	public partial class TwoWayBinding : ContentPage
	{
        public ObservableCollection<DataClass> Data { get; set; }
        public List<string> ListData { get; set; }  


        public TwoWayBinding ()
		{

            Data = new ObservableCollection<DataClass>()
            {
                new DataClass(){ id = 0, Name = "Umair", Details = "Engineer" },
                new DataClass(){ id = 0, Name = "Hassan", Details = "Developer" },
                new DataClass(){ id = 0, Name = "Saleh", Details = "Designer" },
                new DataClass(){ id = 0, Name = "Sanat", Details = "Teacher" },
                new DataClass(){ id = 0, Name = "Mehmood", Details = "Business Man" },
            };

            ListData = new List<string>()
            {
                "String a",
                "String b",
                "String c",
                "String d",
                "String e",
                "String f",
            };

            BindingContext = ListData;

            //monochrome will not appear in the list because it was added
            //after the list was populated.


            InitializeComponent ();
            
            //BindingContext = new HomeViewModel();
        }

        void OnEditTap(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new SwitchPage());
        }

        void OnNameTap(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new EntryPage());
        }

        void listSelection(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }

    public class DataClass
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

    }

}