using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.Reflection.Emit;
using System.Diagnostics;

namespace App1.ViewModels
{
    public class SplashScreenViewModel : ContentPage
    {
        Image splashimage;

        public SplashScreenViewModel()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            splashimage = new Image
            {
                Source = "twitter_1.png",
                WidthRequest = 100,
                HeightRequest = 100
            };

            AbsoluteLayout.SetLayoutFlags(splashimage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashimage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashimage);

            this.BackgroundColor = Color.FromHex("#429de3");
            this.Content = sub;
        }
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Debug.WriteLine("star get data profile");
            await splashimage.ScaleTo(1, 2000);
            Debug.WriteLine("get awal");
            await splashimage.ScaleTo(0.9, 1500, Easing.Linear);
            Debug.WriteLine("get awal 1");
            await splashimage.ScaleTo(150, 1200, Easing.Linear);
            Debug.WriteLine("finish get data");
            Application.Current.MainPage = new NavigationPage(new AppLogin());

        }
        
    }
}
