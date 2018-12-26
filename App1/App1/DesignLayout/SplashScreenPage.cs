using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.DesignLayout
{
    public class SplashScreenPage : ContentPage
    {
        Image splashimage;

        public SplashScreenPage()
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

            this.BackgroundColor = Color.FromHex("#a7b8d1");
            this.Content = sub;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //await splashimage.RotateTo(90, 2000);

            //await splashimage.RotateTo(180, 2000);

            //await splashimage.RotateTo(360, 2000);

            //await splashimage.ScaleTo(1, 3000);

            await splashimage.TranslateTo(0, 200, 2000, Easing.BounceIn);//turun ke awah
            await splashimage.ScaleTo(2, 2000, Easing.CubicIn);
            //await splashimage.RotateTo(360, 2000, Easing.SinInOut); //mutar
            await splashimage.ScaleTo(1, 2000, Easing.CubicOut);
            await splashimage.TranslateTo(0, -100, 2000, Easing.BounceOut);//naik ke atas dengan seperti balon naik

            //await splashimage.ScaleTo(0.9, 2000, Easing.SinIn);

            //await splashimage.ScaleTo(150, 1000, Easing.SinInOut);

            Application.Current.MainPage = new NavigationPage(new LoginPage());

        }
    }
}
