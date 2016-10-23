using EntMob_Uni.Services;
using EntMob_Uni.Utility;
using EntMob_Uni.View;
using Jogging.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace EntMob_Uni.ViewModel
{
    public class ValuesViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private SessionDataService SessionDataService;

        public List<Session> ListOfSessions { get; set; }
        public DelegateCommand<ItemClickEventArgs> ItemClickedCommand { get; set; }

        public ICommand NextCommand { get; set; }
        public ICommand BackCommand { get; set; }


        public ValuesViewModel()
        {
            LoadCommands();
            LoadSessions();
            RegisterForMessages();
        }

        private void RegisterForMessages()
        {
            Messenger.Default.Register<User>
            (
                 this,
                 (action) => ReceiveMessage(action)
            );
        }

        private string username;

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                RaisePropertyChanged("Username");
            }
        }

        private void ReceiveMessage(User message)
        {
            Username = message.Username;
        }


        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ObservableCollection<Session> sessions;
        public ObservableCollection<Session> Sessions
        {
            get
            {
                return sessions;
            }
            set
            {
                sessions = value;
                RaisePropertyChanged("Sessions");
            }
        }


        private void LoadSessions()
        {
            ListOfSessions = Session.GetSessions();
            ItemClickedCommand = new DelegateCommand<ItemClickEventArgs>(OnItemClicked);
        }

        private void OnItemClicked(ItemClickEventArgs args)
        {
            Session session = args.ClickedItem as Session;
            NavigationService.Default.Navigate(typeof(DetailPage));
        }

        private void LoadCommands()
        {
            NextCommand = new CustomCommand(Next, null);
            BackCommand = new CustomCommand(Back, null);
        }

        private void Back(object o)
        {
            NavigationService.Default.Navigate(typeof(LoginPage));
            //Messenger.Default.Send<ParkingsCollectedMessage>(new ParkingsCollectedMessage() { ParkingLots = lots, MyLocation = myLocation });
        }

        private void Next(object o)
        {
            NavigationService.Default.Navigate(typeof(DetailPage));
            //Messenger.Default.Send<ParkingsCollectedMessage>(new ParkingsCollectedMessage() { ParkingLots = lots, MyLocation = myLocation });
        }


    }

}
