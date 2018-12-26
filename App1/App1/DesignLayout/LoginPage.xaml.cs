using Newtonsoft.Json;
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
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent ();
            BindingContext = this;
            this.IsBusy = false;//binding active indicator
            this.btnLogin.Clicked += FbtnLogin;
        }

        private async void FbtnLogin(object sender, EventArgs e)
        {
            this.IsBusy = true;

            var Vusername = username.Text.Replace(" ","");
            var Vpassword = password.Text.Replace(" ", "");

            try
            {
                string URL = "http://erp.gs1id.org/getMBL-INUX-VERIFY.asp?c="+ Vusername +"&d="+ Vpassword + "";
                //var json = JsonConvert.SerializeObject(item);
                var httpClient = new HttpClient();
                Task<string> GetDataFromUrl = httpClient.GetStringAsync(URL);
                string content = await GetDataFromUrl;
                var response = JObject.Parse(content);
                string status = response["status"].ToString();//conver ke string dulu
                if (status.Equals("1"))
                {
                    DisplayAlert("Info", "Berhasil", "Ok");

                    await Navigation.PushAsync(new WelcomePage());
                }
                else
                {
                    DisplayAlert("Info", "Gagal", "Ok");
                }

                this.IsBusy = false;

            }
            catch (Exception ex)
            {
                //ToDo Give errormessage to user and possibly log error
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
    }
}