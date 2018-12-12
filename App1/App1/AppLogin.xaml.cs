using App1.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class AppLogin : ContentPage
	{
		public AppLogin ()
		{
			InitializeComponent ();
            this.InitializeComponent();
            BindingContext = new LoginViewModel();
            //BindingContext = this;
            this.IsBusy = false;//binding active indicator
            this.button_pindah.IsVisible = true;
            this.button_pindah.Clicked += BtnPindah_Clicked;

            NavigationPage.SetHasNavigationBar(this, false);
            string jsonData = "{ \"FirstName\":\"Jignesh\",\"LastName\":\"Trivedi\" }";
            string googleSearchText = @"{
                'responseData': {
                'results': [
                 {
                 'GsearchResultClass': 'GwebSearch',
                 'unescapedUrl': 'http://en.wikipedia.org/wiki/Paris_Hilton',
                 'url': 'http://en.wikipedia.org/wiki/Paris_Hilton',
                 'visibleUrl': 'en.wikipedia.org',
                 'cacheUrl': 'http://www.google.com/search?q=cache:TwrPfhd22hYJ:en.wikipedia.org',
                 'title': '<b>Paris Hilton</b> - Wikipedia, the free encyclopedia',
                 'titleNoFormatting': 'Paris Hilton - Wikipedia, the free encyclopedia',
                 'content': '[1] In 2006, she released her debut album...'
                 },
                 {
                 'GsearchResultClass': 'GwebSearch',
                 'unescapedUrl': 'http://www.imdb.com/name/nm0385296/',
                 'url': 'http://www.imdb.com/name/nm0385296/',
                 'visibleUrl': 'www.imdb.com',
                 'cacheUrl': 'http://www.google.com/search?q=cache:1i34KkqnsooJ:www.imdb.com',
                 'title': '<b>Paris Hilton</b>',
                 'titleNoFormatting': 'Paris Hilton',
                 'content': 'Self: Zoolander. Socialite <b>Paris Hilton</b>...'
                 }
                ],
                'cursor': {
                 'pages': [
                 {
                 'start': '0',
                 'label': 1
                 },
                 {
                 'start': '4',
                 'label': 2
                 },
                 {
                 'start': '8',
                 'label': 3
                 },
                 {
                 'start': '12',
                 'label': 4
                 }
                 ],
                 'estimatedResultCount': '59600000',
                 'currentPageIndex': 0,
                 'moreResultsUrl': 'http://www.google.com/search?oe=utf8&ie=utf8...'
                }
                },
                'responseDetails': null,
                'responseStatus': 200
                }";

            var JsonObject = JsonConvert.DeserializeObject(jsonData);
            JObject googleSearch = JObject.Parse(googleSearchText);

            Debug.WriteLine(JsonObject);
            Debug.WriteLine("==json parse===");
            Debug.WriteLine(googleSearch["responseData"]);
            Debug.WriteLine("==Json Parse Object===");
            // get JSON result objects into a list
            IList<JToken> results = googleSearch["responseData"]["results"].Children().ToList();

            // serialize JSON results into .NET objects
            IList<SearchResult> searchResults = new List<SearchResult>();
            foreach (JToken result in results)
            {
                SearchResult searchResult = JsonConvert.DeserializeObject<SearchResult>(result.ToString());
                searchResults.Add(searchResult);
            }

            // List the properties of the searchResults IList
            foreach (SearchResult item in searchResults)
            {
                Debug.WriteLine(item.Title);
                Debug.WriteLine(item.Content);
                Debug.WriteLine(item.Url);
            }

            Debug.WriteLine("==from api web ===");
            this.get_data_from_api();
        }

        private async void BtnPindah_Clicked(object sender, EventArgs e)
        {
            this.button_pindah.IsVisible = false;//button di hide
            this.IsBusy = true;
            //set timeout setelah klik button
            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                this.IsBusy = false;

                Navigation.PushAsync(new App1.PageTabbed(), false);
                //Navigation.PushAsync(new Calculator());//pindah halaman ke calculator
                return false; // True = Repeat again, False = Stop the timer
            });
            
        }

        public void Onclick(Object sender, EventArgs args)
        {
            //DisplayAlert("Alert", username.Text, "OK");
        }

        private async void CekData(Object sender, EventArgs args)
        {
            double hasil = 0;
            var myBtn = (Button)sender;//get prop
            //ShowHasil.Text = username.Text.ToString() + " = " + password.Text.ToString();
            //await Navigation.PushAsync(new MasterDetailPage());
        }

        void Handle_Username_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            var _container = BindingContext as LoginViewModel;
            showTes.Text = _container.DisplayMessage;
            Debug.WriteLine(_container.DisplayMessage);
        }

        private async void Navigation_Button(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Calculator());
        }

        private async void get_data_from_api()
        {
            try
            {
                string URL = "https://randomuser.me/api/";

                var httpClient = new HttpClient();
                Task<string> GetDataFromUrl = httpClient.GetStringAsync(URL);
                string content = await GetDataFromUrl;
                
                JObject googleSearch = JObject.Parse(content);
                Debug.WriteLine("Response: \r\n {0}", googleSearch["results"]);
            }
            catch (Exception ex)
            {
                //ToDo Give errormessage to user and possibly log error
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
    }

    public partial class ProfileJson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class SearchResult
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
    }

}