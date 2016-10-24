using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntMob_Xamarin.Models;
using System.ComponentModel;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using EntMob_Xamarin.Utility;
using System.Diagnostics;

namespace EntMob_Xamarin.ViewModels
{
    public class RunnerViewModel : INotifyPropertyChanged
    {
        public ICommand LoginCommand { get; set; }

        public RunnerViewModel()
        {
            LoadCommands();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadCommands()
        {
            LoginCommand = new CustomCommand(Login, null);
        }


        private void Login(object o)
        {
            /*NavigationPage navigationPage = new NavigationPage(new MainPage());
            navigationPage.PushAsync(new TimerPage());*/

            /*var msg = new User() { Username = Username };
            Messenger.Default.Send<User>(msg);*/
        }

    }
}
