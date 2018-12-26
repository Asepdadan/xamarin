using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GetDataFromApi : ContentPage
	{

        HttpClient client;
        private Uri loginURL;
        public ObservableCollection<getMenuFront> MyListCollector { get; set; }

        public GetDataFromApi ()
		{
			InitializeComponent ();
            
            MyListCollector = new ObservableCollection<getMenuFront>()
            {
                new getMenuFront(){
                    ID = "121",
                    CAPTION = "TEST",
                    CODE = "TEST CODE",
                    NAMA = "TEST NAMA",
                },
            };

            BindingContext = this;

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            getFromUrlString();
        }

        public async void getFromUrlString()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));// set body 
            client.DefaultRequestHeaders.Add("X-API-KEY", "Z29zZWN1cmVhcGk=");// set header custom 
            client.DefaultRequestHeaders.Add("Authorization", "Basic YWRtaW46MTIzNA==");// set header authorization basic u:admin p: 1234
            HttpResponseMessage response = await client.GetAsync("http://192.168.12.52:5005/api/menu/get_menu_front?flag=1");
            var result = response.Content.ReadAsStringAsync().Result; ;

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.SerializeObject(content);

                ObservableCollection<getMenuFront> list = JsonConvert.DeserializeObject<ObservableCollection<getMenuFront>>(content);

                //Console.WriteLine(list[0].CODE);
                //Console.WriteLine(list[0].CAPTION);

                foreach (var obj in list)
                {
                    Console.WriteLine("======================================================");
                    Console.WriteLine(obj.ID);
                    Console.WriteLine(obj.NAMA);
                    Console.WriteLine(obj.CAPTION);
                    Console.WriteLine(obj.CODE);
                    Console.WriteLine("======================================================");

                    MyListCollector.Add(
                        new getMenuFront()
                        {
                            ID = obj.ID,
                            CAPTION = obj.CAPTION,
                            NAMA = obj.NAMA,
                            CODE = obj.CODE 
                        }
                    );
                }

            }

        }


    }
}