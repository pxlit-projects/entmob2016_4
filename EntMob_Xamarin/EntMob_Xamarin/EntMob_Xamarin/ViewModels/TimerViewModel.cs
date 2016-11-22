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
using EntMob.DAL;

namespace EntMob_Xamarin.ViewModels
{
	public class TimerViewModel : INotifyPropertyChanged
	{

		private ISessionService sessionService;
		private ITemperatureService temperatureService;
		private IHumidityService humidityService;

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

		public TimerViewModel(ISessionService sessionService, ITemperatureService temperatureService, IHumidityService humdityService)
        {
			this.sessionService = sessionService;
			this.temperatureService = temperatureService;
			this.humidityService = humdityService;
			session = new Session();
			LoadCommands();
			SubscribeToMessages();
			run = false;

			User jonas = new User();
			jonas.Name = "Jonas";
			jonas.Password = "123456";
			jonas.Id = 2;
			session.User = jonas;
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
						run = false;
                        button.Text = "Start";
						session.End = DateTime.Now;
						StopSession();
						NavigationService.Default.NavigateTo("Values");
						Messenger.Default.Send<Session>(session);
						ResetSession();
                    }
					else if(session.Name != null)
                    {
						StartSession();
						run = true;
                        StartTimer();
                        button.Text = "Stop";
                    }
                }
            });
        }

		private void ResetSession()
		{
			var user = session.User;
			session = new Session();
			session.Name = null;
			session.User = user;
			Time = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Local);
			RaisePropertyChanged("Name");
		}

        private void StartTimer() {
			Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    Task.Factory.StartNew(() =>
                    {
						SaveHumidity();
                    	Device.BeginInvokeOnMainThread(() =>
                        {
							Time = time.AddSeconds(1);
                        });
                    });
               
                return run;
                });
        }

		private async void StartSession()
		{
			try
			{
				session.Start = DateTime.Now;
				var user = session.User;
				var result = await sessionService.StartSession(session);
				session = result;
				session.User = user;
			}
			catch
			{
				
			}
		}

		private async void StopSession()
		{
			try
			{
				session.End = DateTime.Now;
				var user = session.User;
				var result = await sessionService.StopSession(session);
				session = result;
				session.User = user;
			}
			catch
			{
				
			}
		}

		private async void SaveHumidity()
		{
			try
			{
				Random random = new Random();
				Humidity humdity = new Humidity();
				humdity.Amount = random.Next(0,100);
				humdity.Date = DateTime.Now;
				humdity.Session = session;
				await humidityService.AddHumidity(humdity);
			}
			catch
			{
			}
		}

		private async void SaveTemperature()
		{
			Random random = new Random();
			Temperature temperature = new Temperature();
			temperature.Date = DateTime.Now;
			temperature.Amount = random.Next(-20, 20);
			temperature.Session = session;
			await temperatureService.AddTemperature(temperature);
			try
			{
				
			}
			catch
			{
			}
		}
        
    }
}