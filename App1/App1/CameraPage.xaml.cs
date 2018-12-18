using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CameraPage : ContentPage
	{

        public CameraPage ()
		{
			InitializeComponent ();
            TakePhotoButton.Clicked += TakePhotoButton_Clicked;

            //takePhoto.Clicked += async (sender, args) =>
            //{

            //    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            //    {
            //        await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
            //        return;
            //    }

            //    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            //    {
            //        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
            //        Directory = "Sample",
            //        Name = "test.jpg"
            //    });

            //    if (file == null)
            //        return;

            //    await DisplayAlert("File Location", file.Path, "OK");

            //    image.Source = ImageSource.FromStream(() =>
            //    {
            //        var stream = file.GetStream();
            //        file.Dispose();
            //        return stream;
            //    });
            //};

            //pickPhoto.Clicked += async (sender, args) =>
            //{
            //    if (!CrossMedia.Current.IsPickPhotoSupported)
            //    {
            //        await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
            //        return;
            //    }
            //    var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            //    {
            //        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            //    });


            //    if (file == null)
            //        return;

            //    image.Source = ImageSource.FromStream(() =>
            //    {
            //        var stream = file.GetStream();
            //        file.Dispose();
            //        return stream;
            //    });
            //};

            //takeVideo.Clicked += async (sender, args) =>
            //{
            //    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
            //    {
            //        await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
            //        return;
            //    }

            //    var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
            //    {
            //        Name = "video.mp4",
            //        Directory = "DefaultVideos",
            //    });

            //    if (file == null)
            //        return;

            //    await DisplayAlert("Video Recorded", "Location: " + file.Path, "OK");

            //    file.Dispose();
            //};

            //pickVideo.Clicked += async (sender, args) =>
            //{
            //    if (!CrossMedia.Current.IsPickVideoSupported)
            //    {
            //        await DisplayAlert("Videos Not Supported", ":( Permission not granted to videos.", "OK");
            //        return;
            //    }
            //    var file = await CrossMedia.Current.PickVideoAsync();

            //    if (file == null)
            //        return;

            //    await DisplayAlert("Video Selected", "Location: " + file.Path, "OK");
            //    file.Dispose();
            //};
        }

        async void TakePhotoButton_Clicked(object sender, System.EventArgs e)
        {
            var cameraPage = new CameraPageC();
            //cameraPage.OnPhotoResult += CameraPage_OnPhotoResult;
            cameraPage.Navigation.PopModalAsync();
            //await Navigation.PushModalAsync(cameraPage, false);
        }

        async void CameraPage_OnPhotoResult(App1.PhotoResultEventArgs result)
        {
            await Navigation.PopModalAsync();
            if (!result.Success)
                return;

            Photo.Source = ImageSource.FromStream(() => new MemoryStream(result.Image));
        }

    }
}