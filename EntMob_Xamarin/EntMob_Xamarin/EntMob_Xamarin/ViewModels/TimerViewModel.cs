using EntMob_Xamarin.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using EntMob_Xamarin.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using EntMob.Models;
using EntMob_Xamarin.Messages;
using Xamarin.Forms;

namespace EntMob_Xamarin.ViewModels
{
    public class TimerViewModel : INotifyPropertyChanged
    {

		private ISessionService sessionService;
        private INavigation navigation;

        public ICommand StartStopCommand { get; set; }

        private bool Run = true;
		private Session session;
		private DateTime timer { get; set; }


		public DateTime Timer
		{
			get
			{
				return timer;
			}
			set
			{
				this.timer = value;
				OnPropertyChanged("Timer");
			}
		}
        /*public String _timerContent;
        public String TimerContent { get { return _timerContent; }  set { _timerContent = value; OnPropertyChanged("TimerContent"); } }*/

        public event PropertyChangedEventHandler PropertyChanged;

         private void OnPropertyChanged(string prop)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(prop);
                handler(this, e);
            }
        }

		public TimerViewModel(INavigation navigation, ISessionService sessionService)
        {
            LoadCommands();
			SubscribeToMessages();
            this.navigation = navigation;
        }

		private void SubscribeToMessages()
		{
			Messenger.Default.Register<LoggedInUser>(this, OnUserReceived);
		}

		private void OnUserReceived(LoggedInUser user)
		{
			if (session == null)
			{
				session = new Session();
			}
			session.User = user.user;
		}

        private void LoadCommands()
        {
            StartStopCommand = new Command(
            (parameter) =>
            {
                var button = parameter as Xamarin.Forms.Button;
                if (button != null)
                {
                    if (button.Text == "Stop")
                    {
                        button.Text = "Start";
						session.End = DateTime.Now;
                        navigation.PushAsync(new ValuesPage());
                    }
                    else
                    {
						timer = DateTime.Now;
						if (session == null) {
							session = new Session();
						}
						session.Start = DateTime.Now;
                        StartTimer();
                        button.Text = "Stop";
                    }
                }
            });
        }

        public void StartTimer() {
            Device.StartTimer(TimeSpan.FromMilliseconds(10), () =>
                {
                    Task.Factory.StartNew(async () =>
                    {
                    // Do the actual request and wait for it to finish.
                    await Task.Delay(0);
					timer.AddMilliseconds(1);
                    // Switch back to the UI thread to update the UI
                    Device.BeginInvokeOnMainThread(() =>
                        {
                        // Update the UI
                        // ...
                        // Now repeat by scheduling a new reques
                        });
                    });

                // Don't repeat the timer (we will start a new timer when the request is finished)
                return true;
                });
        }

		private async void startSession()
		{
			var result = Task.Run(() =>
			{
				try
				{
					return sessionService.StartSession(session);
				}
				catch {
					return null;
				}
			});
		}
        
    }
}
