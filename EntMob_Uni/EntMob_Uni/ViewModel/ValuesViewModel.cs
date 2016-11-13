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

        private ISessionService sessionService;

        public DelegateCommand<ItemClickEventArgs> ItemClickedCommand { get; set; }

        public ICommand NextCommand { get; set; }
        public ICommand BackCommand { get; set; }

        public ValuesViewModel(ISessionService sessionService)
        {
            this.sessionService = sessionService;
            LoadCommands();
            RegisterForMessages();
        }

        private void RegisterForMessages()
        {
            Messenger.Default.Register<User>(this, ReceiveMessage);
        }

        private void ReceiveMessage(User user)
        {
            this.User = user;
            LoadSessions();
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private User user;
        public User User {
            get
            {
                return user;
            }
            set
            {
                user = value;
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

        private async void LoadSessions()
        {
            var result = await sessionService.GetAllSessions(user);
            Sessions = new ObservableCollection<Session>(result);
        }

        private void OnItemClicked(ItemClickEventArgs args)
        {
            Session session = args.ClickedItem as Session;
            session.User = user;
            NavigationService.Default.Navigate(typeof(DetailPage));
            Messenger.Default.Send<Session>(session);
        }

        private void LoadCommands()
        {
            NextCommand = new CustomCommand(Next, null);
            BackCommand = new CustomCommand(Back, null);
            ItemClickedCommand = new DelegateCommand<ItemClickEventArgs>(OnItemClicked);
        }

        private void Back(object o)
        {
            NavigationService.Default.Navigate(typeof(LoginPage));
        }

        private void Next(object o)
        {
            NavigationService.Default.Navigate(typeof(DetailPage));
        }


    }

}
