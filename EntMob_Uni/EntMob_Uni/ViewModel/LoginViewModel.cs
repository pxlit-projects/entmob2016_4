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
                RaisePropertyChanged("UserName");
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
            LoginCommand = new CustomCommand(Login, null);
        }    

        private async void Login(object o)
        {
            User user = new User();
            user.Name = userName;
            user.Password = password;

            User result = await userService.CheckCredentials(user);

            if (result != null)
            {
                NavigationService.Default.Navigate(typeof(ValuesPage));
                result.Password =  user.Password;
                Messenger.Default.Send<User>(result);
            }
            else
            {
                UserName = "";
                Password = "";
            }
        }
    }
}
