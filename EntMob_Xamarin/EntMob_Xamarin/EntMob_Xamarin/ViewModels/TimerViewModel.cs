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
		private Session session { get; set; }
		private DateTime timer { get; set; }

		private string name { get; set; }

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
				RaisePropertyChanged("Name");
			}
		}

		public DateTime Timer
		{
			get
			{
				return timer;
			}
			set
			{
				this.timer = value;
				RaisePropertyChanged("Timer");
			}
		}

        public event PropertyChangedEventHandler PropertyChanged;

         private void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
						StopSession();
                        navigation.PushAsync(new ValuesPage());
                    }
                    else
                    {
						Timer = DateTime.Now;
						if (session == null) {
							session = new Session();
						}
						session.Start = DateTime.Now;
                        StartTimer();
						StartSession();
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
					Timer.AddMilliseconds(1);
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

		private async void StartSession()
		{
			var result = await Task.Run(() =>
			{
				try
				{
					return sessionService.StartSession(session);
				}
				catch {
					return null;
				}
			});

			if (result != null)
			{
				session = result;
			}
		}

		private async void StopSession()
		{
			var result = await Task.Run(() =>
			{
				try
				{
					return sessionService.StopSession(session);
				}
				catch
				{
					return null;
				}
			});

			if (result != null)
			{
				session = result;
			}

		}
        
    }
}
