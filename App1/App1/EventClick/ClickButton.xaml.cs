using App1.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.EventClick
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClickButton : ContentPage
    {
        public ObservableCollection<MyListModel> MyListCollector { get; set; }
        public int no;
        HttpClient client;

        public ClickButton()
        {


            InitializeComponent();
            MyListCollector = new ObservableCollection<MyListModel>()
            {
                new MyListModel(){ MyName="Asep Dadan" , MyDetail="Popular amongst literary  " , Image = "https://res.cloudinary.com/demo/image/upload/w_400,h_400,c_crop,g_face,r_max/w_200/lady.jpg" },
                new MyListModel(){ MyName="Alexa" , MyDetail="Popular amongst literary  " , Image = "https://res.cloudinary.com/demo/image/upload/w_400,h_400,c_crop,g_face,r_max/w_200/lady.jpg" },
                new MyListModel(){ MyName="Amaya" ,   MyDetail="If you are lucky enough to beauty surrounding your home." , Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTr8hbJMPoCcTm9jss9otFgeL-zJx5Ve8mP1v3yq3oTl0FecoO6"},
                new MyListModel(){ MyName="Rose" , MyDetail="Giving the impression of an idyllic way of life. ",Image="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTCTuJWZbbnmUl5HGDn7s0V40HTYjRZ8WCbkhU2M3flAg3k44DB"},
                new MyListModel(){ MyName="Benny" , MyDetail="Giving the impression of an idyllic way of life. ",Image="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQq2AQqPeiJXiPjuos3LPJWTDJzv7Sq68ccRc7dUO3O1JXEbam0"},

                new MyListModel(){ MyName="Mary" , MyDetail="Popular amongst literary  " , Image = "https://res.cloudinary.com/demo/image/upload/w_400,h_400,c_crop,g_face,r_max/w_200/lady.jpg" },
                new MyListModel(){ MyName="Prexya" ,   MyDetail="If you are lucky enough to beauty surrounding your home." , Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTr8hbJMPoCcTm9jss9otFgeL-zJx5Ve8mP1v3yq3oTl0FecoO6"},
                new MyListModel(){ MyName="Suzan" , MyDetail="Giving the impression of an idyllic way of life. ",Image="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTCTuJWZbbnmUl5HGDn7s0V40HTYjRZ8WCbkhU2M3flAg3k44DB"},
                new MyListModel(){ MyName="Saluz" , MyDetail="Giving the impression of an idyllic way of life. ",Image="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQq2AQqPeiJXiPjuos3LPJWTDJzv7Sq68ccRc7dUO3O1JXEbam0"},

                new MyListModel(){ MyName="Suzan" , MyDetail="Popular amongst literary  " , Image = "https://res.cloudinary.com/demo/image/upload/w_400,h_400,c_crop,g_face,r_max/w_200/lady.jpg" },
                new MyListModel(){ MyName="Pikasa" ,   MyDetail="If you are lucky enough to beauty surrounding your home." , Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTr8hbJMPoCcTm9jss9otFgeL-zJx5Ve8mP1v3yq3oTl0FecoO6"},
                new MyListModel(){ MyName="Dispa" , MyDetail="Giving the impression of an idyllic way of life. ",Image="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTCTuJWZbbnmUl5HGDn7s0V40HTYjRZ8WCbkhU2M3flAg3k44DB"},
                new MyListModel(){ MyName="Mae" , MyDetail="Giving the impression of an idyllic way of life. ",Image="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQq2AQqPeiJXiPjuos3LPJWTDJzv7Sq68ccRc7dUO3O1JXEbam0"},

            };

            BindingContext = this;

            add.Clicked += Tambah_Element;
        }

        private async void Tambah_Element(Object sender, EventArgs args)
        {
            no += 1;
            MyListCollector.Add(
                new MyListModel() { MyName = "Test Baru " + no, MyDetail = "Giving the impression of an idyllic way of life. ", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQq2AQqPeiJXiPjuos3LPJWTDJzv7Sq68ccRc7dUO3O1JXEbam0" }
           );


            //scroll auto bottom
            var v = listViewDynamic.ItemsSource.Cast<object>().LastOrDefault();
            listViewDynamic.ScrollTo(v, ScrollToPosition.End, true);

            //string URL = "https://randomuser.me/api/?page=1&results=10";

            //var httpClient = new HttpClient();
            //client.MaxResponseContentBufferSize = 256000;
            //Task<string> GetDataFromUrl = httpClient.GetStringAsync(URL);
            //string content = await GetDataFromUrl;

            //JObject getDataResult = JObject.Parse(content);
            //Debug.WriteLine(getDataResult["results"]);

        }
    }

    public class Profil{
        public string name { get; set; }
        public string gender { get; set; }
        public string image { get; set; }
    }
}