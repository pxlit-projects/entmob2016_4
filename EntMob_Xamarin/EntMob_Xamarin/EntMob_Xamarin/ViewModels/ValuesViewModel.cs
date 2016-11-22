using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using EntMob.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EntMob_Xamarin.Utility;
using System.Collections.ObjectModel;

namespace EntMob_Xamarin.ViewModels
{
    public class ValuesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

		private IHumidityService humidityService;

		private ObservableCollection<Humidity> humidities;

		public ObservableCollection<Humidity> Humidities
		{
			get
			{
				return humidities;
			}
			set
			{
				humidities = value;
				RaisePropertyChanged("Humidities");
			}
		}

		public ValuesViewModel(IHumidityService humidityService)
        {
			this.humidityService = humidityService;
			RegisterForMessages();
        }

		private void RegisterForMessages()
		{
			Messenger.Default.Register<Session>(this, OnSessionReceived);
		}

		private async void OnSessionReceived(Session session)
		{
			var result = await humidityService.GetHumiditiesForSession(session);
			Humidities = new ObservableCollection<Humidity>(result);
		}

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
