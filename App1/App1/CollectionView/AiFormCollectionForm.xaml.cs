using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.CollectionView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AiFormCollectionForm : ContentPage
    {
        public ObservableCollection<PhotoGroup> ItemsSource { get; } = new ObservableCollection<PhotoGroup>();
        HttpClient client;

        public AiFormCollectionForm()
        {
            InitializeComponent();

            var list1 = new List<PhotoItem>();
            for (var i = 0; i < 20; i++)
            {
                list1.Add(new PhotoItem
                {
                    PhotoUrl = $"https://example.com/{i + 1}.jpg",
                    Title = $"Title {i + 1}",
                    Category = "AAA",
                });
            }
            var list2 = new List<PhotoItem>();
            for (var i = 20; i < 40; i++)
            {
                list2.Add(new PhotoItem
                {
                    PhotoUrl = $"https://example.com/{i + 1}.jpg",
                    Title = $"Title {i + 1}",
                    Category = "BBB",
                });
            }

            var group1 = new PhotoGroup(list1) { Head = "SectionA" };
            var group2 = new PhotoGroup(list2) { Head = "SectionB" };

            ItemsSource.Add(group1);
            ItemsSource.Add(group2);

            BindingContext = this;

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;


            //getFromUrlString();
        }

        public async void getFromUrlString()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));// set body 
            client.DefaultRequestHeaders.Add("Go-Api-Secure", "Z29zZWN1cmVhcGk=");// set header custom 
            client.DefaultRequestHeaders.Add("Authorization", "Basic YWRtaW46MTIzNA==");// set header authorization basic u:admin p: 1234
            //HttpResponseMessage response = await client.GetAsync("http://192.168.12.52:5005/api/menu/get_menu_front?flag=1");
            HttpResponseMessage response = await client.GetAsync("http://bdsdago1.ddns.net:903/api/cms/get_front_slider");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.SerializeObject(content);


                Console.WriteLine("============================json==========================");
                Console.WriteLine(json);

            }
        }
    }
}