using EntMob_Uni.Services;
using EntMob_Uni.Utility;
using EntMob_Uni.View;
using Jogging.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EntMob_Uni.ViewModel
{
    public class DetailViewModel : INotifyPropertyChanged
    {
        
        public ICommand BackCommand { get; set; }

        private ISessionService sessionService;

        public event PropertyChangedEventHandler PropertyChanged;

        private Session selectedSession { get; set; }

        public Session SelectedSession
        {
            get
            {
                return selectedSession;
            }
            set
            {
                selectedSession = value;
                RaisePropertyChanged("SelectedSession");
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public DetailViewModel(ISessionService sessionService)
        {
            this.sessionService = sessionService;
            LoadCommands();
            RegisterForMessages();
        }

        private void RegisterForMessages()
        {
            Messenger.Default.Register<Session>(this, OnSessionReceived);
        }

        private void OnSessionReceived(Session session)
        {
            SelectedSession = session;
            LoadSessionAverages();
        }

        private async void LoadSessionAverages()
        {
            var result = await Task.Run(() => sessionService.GetAverageForSession(selectedSession));
            SelectedSession = result;
        }

        private void LoadCommands()
        {
            BackCommand = new CustomCommand(Back, null);
        }

        private void Back(object o)
        {
            NavigationService.Default.Navigate(typeof(ValuesPage));
        }

    }
}
