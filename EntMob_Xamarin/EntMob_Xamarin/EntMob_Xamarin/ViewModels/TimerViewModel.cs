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
using Newtonsoft.Json;
using System.Net.Http;

namespace EntMob_Xamarin.ViewModels
{
	public class TimerViewModel : INotifyPropertyChanged
	{

		private ISessionService sessionService;

		public ICommand StartStopCommand { get; set; }

		private bool run;
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
				if (session.User != null)
				{
					return session.User.Name;
				}
				return "";
			}
		}

		public DateTime Time
		{
			get
			{
				return time;
			}
			set
			{
				time = value;
				RaisePropertyChanged("Time");
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
			this.sessionService = sessionService;
			session = new Session();
			User jonas = new User();
			jonas.Name = "Jonas";
			jonas.Password = "123456";
			jonas.Id = 2;
			session.User = jonas;
            LoadCommands();
			SubscribeToMessages();
			run = false;
        }

		private void SubscribeToMessages()
		{
			
			Messenger.Default.Register<LoggedInUser>(this, OnUserReceived);
		}

		private void OnUserReceived(LoggedInUser user)
		{
			session.User = user.user;
			RaisePropertyChanged("UserName");
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
						run = false;
						NavigationService.Default.NavigateTo("Values");
                    }
					else if(session.Name != null)
                    {
						Time = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Local);
						StartSession();
						run = true;
                        StartTimer();
                        button.Text = "Stop";
                    }
                }
            });
        }

        public void StartTimer() {
            Device.StartTimer(TimeSpan.FromMilliseconds(10), () =>
                {
                    Task.Factory.StartNew(() =>
                    {
						// Do the actual request and wait for it to finish.
						//Time.AddSeconds(1);
						Time = time.AddMilliseconds(20);
						
                    // Switch back to the UI thread to update the UI
                    Device.BeginInvokeOnMainThread(() =>
                        {
                        // Update the UI
                        // ...
                        // Now repeat by scheduling a new reques
                        });
                    });

                // Don't repeat the timer (we will start a new timer when the request is finished)
                return run;
                });
        }

		private async void StartSession()
		{
			session.Start = DateTime.Now;
			var user = session.User;
			var result = await sessionService.StartSession(session);
			session = result;
			session.User = user;
			try
			{
				
			}
			catch
			{
				
			}
		}

		private async void StopSession()
		{
			session.End = DateTime.Now;
			var result = await sessionService.StopSession(session);
			session = result;
			try
			{
				
			}
			catch
			{
				
			}
		}
        
    }
}
