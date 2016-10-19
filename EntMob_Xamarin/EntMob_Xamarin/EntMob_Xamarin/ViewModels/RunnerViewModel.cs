using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntMob_Xamarin.Models;
using System.ComponentModel;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace EntMob_Xamarin.ViewModels
{
    public class RunnerViewModel : INotifyPropertyChanged
    {
        private string _message;
        private User _user;

        public User user
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChanged();
            }

        }

        public RunnerViewModel()
        {
            user = new User() {
                Username = "Jonas",
                Password = "Allard"
            };
        }

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public Command ShowCommand
        {
            get
            {
                return new Command(() =>
                {
                    Message = "User show : Username = " + user.Username + "\n";
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
