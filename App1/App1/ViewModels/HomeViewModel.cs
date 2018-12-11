using App1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1.ViewModels
{
    public class HomeViewModel
    {
        public static ObservableCollection<light> lights { get; set; }

        static HomeViewModel()
        {
            lights = DataSource.getLights();
        }
    }
}
