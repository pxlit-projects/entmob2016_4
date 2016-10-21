using EntMob_Uni.Messages;
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

        private ISessionDataService sessionDataService;

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
            }
        }

        public DetailViewModel()
        {
            LoadCommands();
            RegisterForMessages();

        }

        public DetailViewModel(ISessionDataService sessionDataService)
        {
            this.sessionDataService = sessionDataService;
        }

        private void RegisterForMessages()
        {
            Messenger.Default.Register<SessionSelectedMessage>(this, OnSessionReceived);
        }

        private void OnSessionReceived(SessionSelectedMessage m)
        {
            selectedSession = m.SelectedSession;

            Messenger.Default.Send<DrawSessionMessage>(new DrawSessionMessage() { SelectedSession = selectedSession });
        }


        private void LoadCommands()
        {
            BackCommand = new CustomCommand(Back, null);
        }

        private void Back(object o)
        {
            NavigationService.Default.Navigate(typeof(ValuesPage));
            //Messenger.Default.Send<ParkingsCollectedMessage>(new ParkingsCollectedMessage() { ParkingLots = lots, MyLocation = myLocation });
        }

    }
}
