using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace App1.ViewModels
{
    public class LatihanViewModel : INotifyPropertyChanged
    {
        public LatihanViewModel() {

        }

        string name = "Asep Dadan";
        string website = "bdg.dago1.net";
        bool bestFriend;
        bool isBusy;
        string showUsername = "";

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public bool BestFriend {
            get { return bestFriend;  }
            set
            {
                bestFriend = true;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        public String ShowName
        {
            get
            {
               return $"Nama anda adalah { name}";
            }
        }

        public String DisplayMessage
        {
            get {
                return $" Your new Friend is Named {Name} and " + $"{(bestFriend ? "is" : "is not")} your bestfriend";
            }
        }

        public String Name {
            get { return name; }
            set {
                name = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayMessage));

                if (name=="Asdan") {
                    OnPropertyChanged(nameof(ShowName));
                }
                else
                {
                    
                    OnPropertyChanged();
                }
            }
        }

        public String Website {
            get { return website; }
            set {
                website = value;
                OnPropertyChanged();
            }
        }

        public bool IsBusy {
            get { return isBusy; }
            set
            {
                isBusy = true;

                OnPropertyChanged();
            }
        }


    }
}
