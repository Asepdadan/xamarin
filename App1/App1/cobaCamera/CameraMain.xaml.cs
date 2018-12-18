﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.cobaCamera;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.cobaCamera
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CameraMain : ContentPage
	{
		public CameraMain ()
		{
			InitializeComponent ();

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Camera Preview:" },
                    new CameraPreview {
                            Camera = CameraOptions.Rear,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            VerticalOptions = LayoutOptions.FillAndExpand
                        }
                    }
                };
        }
	}
}