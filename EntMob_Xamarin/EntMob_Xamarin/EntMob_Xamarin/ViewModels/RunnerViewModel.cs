using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntMob.Models;
using System.ComponentModel;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using EntMob_Xamarin.Utility;
using System.Diagnostics;
using EntMob_Xamarin.Services;

namespace EntMob_Xamarin.ViewModels
{
	public class RunnerViewModel : INotifyPropertyChanged
	{
		private INavigation navigation;

		public RunnerViewModel()
		{
			loadCommands();
		}

		public RunnerViewModel(INavigation navi)
		{
			loadCommands();
			navigation = navi;
		}

		private void loadCommands()
		{
			RegisterCommand = new Command((obj) =>
			{
				Register(obj);
			});
		}

		public ICommand LoginCommand
		{
			get
			{
				return new Command(async () =>
				{
					await navigation.PushAsync(new TimerPage());
				});
			}
		}

		public ICommand RegisterCommand { get; set; }

		public void Register(object o)
		{
			navigation.PushAsync(new RegisterPage());
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
