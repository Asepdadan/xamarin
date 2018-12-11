using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App1.ViewModels
{
    class MyTriggerViewModel
    {

        public MyTriggerViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string user;
        public string User
        {
            get => user;
            set
            {
                if (user != value) { user = value; }
                OnPropertyChanged();
            }
        }
        private string pass;
        public string Pass
        {
            get => pass;
            set
            {
                if (pass != value) { pass = value; }
                OnPropertyChanged();
            }
        }
    }
}
