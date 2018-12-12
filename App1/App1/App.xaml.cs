using App1.ViewModels;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SplashScreenViewModel());
            //MainPage = new DetailMasterLearning();
            //MainPage = new App1.PageTabbed();
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
