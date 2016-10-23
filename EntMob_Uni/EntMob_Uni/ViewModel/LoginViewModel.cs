using EntMob_Uni.Services;
using EntMob_Uni.Utility;
using EntMob_Uni.View;
using Jogging.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private string userName;

        public string Username
        {
            get { return userName; }
            set
            {
                    userName = value;
                    RaisePropertyChanged("Username");
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public LoginViewModel()
        {

            LoadCommands();

        }

        private void LoadCommands()
        {
            LoginCommand = new CustomCommand(Login, null);
        }


        private void Login(object o)
        {
            NavigationService.Default.Navigate(typeof(ValuesPage));

            var msg = new User() { Username = Username };
            Messenger.Default.Send<User>(msg);
        }
    }
}
