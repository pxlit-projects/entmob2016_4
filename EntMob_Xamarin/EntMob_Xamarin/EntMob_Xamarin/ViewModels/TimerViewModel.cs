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

		public ICommand StartStopCommand { get; set; }

		private bool Run = true;
		private Session session;
		private DateTime time;

		public string Name
		{
			get
			{
				return session.Name;
			}
			set
			{
				session.Name = value;
				RaisePropertyChanged("Name");
			}
		}

		public string UserName
		{
			get
			{
				return session.User.Name;
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

		public TimerViewModel(ISessionService sessionService)
        {
            LoadCommands();
			SubscribeToMessages();
			if (session == null)
			{
				session = new Session();
			}
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
						NavigationService.Default.NavigateTo("Values");
                    }
                    else
                    {
						time = DateTime.Now;
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
                    await Task.Delay(1);
					time.AddMilliseconds(1);
					RaisePropertyChanged("Timer");

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
