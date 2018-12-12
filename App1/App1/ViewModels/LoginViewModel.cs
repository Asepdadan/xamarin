using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace App1.ViewModels
{
    public class LoginViewModel 
    {
        String username = "asdan15";
        String password = "";
        
        public LoginViewModel() { }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public String Username
        {
            get { return username;  }        
            set
            {
                username = value;
                
            }
        }

        public String Password
        {
            get { return password;  }        
            set
            {
                password = value;
            }
        }

        public String DisplayMessage
        {
            get{
                return $" Your new Username {Username} and Your Password {Password } your bestfriend";
            }
        }

      
        
    }
}
