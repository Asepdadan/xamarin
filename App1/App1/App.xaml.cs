using App1.ViewModels;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.cobaCamera;
using BottomBar.XamarinForms;
using App1.EventClick;
using App1.TableView;
using App1.DataPage;
using App1.CustomRender;
using App1.Websocket;
using App1.DesignLayout;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new SplashScreenViewModel());//splashscreen
            //MainPage = new DetailMasterLearning();
            //MainPage = new App1.PageTabbed();
            //MainPage = new ClickButton();
            //MainPage = new NavigationPage(new CustomContentPageCS());//camera
            //MainPage = new NavigationPage(new PubNub());//chat
            //MainPage = new NavigationPage(new PageNavigationBottom());//chat
            //MainPage = new NavigationPage(new SplashScreenPage());//login
            //MainPage = new NavigationPage(new CarouselPage4());//carousle page4
            //MainPage = new NavigationPage(new LoginPage());//carousle page4
            MainPage = new GetDataFromApi();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
            Debug.WriteLine("On Start");
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Debug.WriteLine("On Sleep");
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            Debug.WriteLine("On Start");
        }
    }
}
