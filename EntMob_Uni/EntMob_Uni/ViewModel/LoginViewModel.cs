using EntMob_Uni.Services;
using EntMob_Uni.Utility;
using EntMob_Uni.View;
using Jogging.DAL;
using Jogging.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EntMob_Uni.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand LoginCommand { get; set; }

        private IUserService userService;

        private string password;
        private string userName;

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                RaisePropertyChanged("Username");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public LoginViewModel(IUserService userService)
        {
            this.userService = userService;
            LoadCommands();
        }

        private void LoadCommands()
        {
            LoginCommand = new CustomCommand(Login, CanLogin);
        }

        private bool CanLogin(object o)
        {
            if (password != null && userName != null)
            {
                return true;
            }  
            return false;
        }

        private void Login(object o)
        {
            User user = new User();
            user.Name = userName;
            user.Password = password;

           if(userService.CheckCredentials(ref user))
            {
                NavigationService.Default.Navigate(typeof(ValuesPage));
                Messenger.Default.Send<User>(user);
            } else
            {
                UserName = "";
                Password = "";
            }
        }
    }
}
