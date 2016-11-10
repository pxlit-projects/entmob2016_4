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
		private IUserService userService;
		private INavigation navigation;

		public RunnerViewModel(INavigation navi, IUserService userService)
		{
			LoadCommands();
			RegisterForMessages();
			navigation = navi;
			this.userService = userService;
		}

		private void LoadCommands()
		{
			RegisterCommand = new Command((obj) => Register(obj));
			LoginCommand = new Command((obj) => Login(obj));
		}

		private string password { get; set; }
		private string username { get; set; }

		public string Password
		{
			get
			{
				return password;
			}
			set
			{
				password = value;
				RaisePropertyChanged("Password");
			}
		}

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

		public ICommand LoginCommand { get; set; }

		public ICommand RegisterCommand { get; set; }

		private void Register(object o)
		{
			navigation.PushAsync(new RegisterPage());
		}

		private async void Login(object o)
		{
			if (Check())
			{
				User user = new User();
				user.Password = password;
				user.Name = username;

				var result = Task.Run(() =>
				{
					try
					{
						return userService.CheckCredentials(user);
					}
					catch
					{
						return null;
					}
				});

				if (result != null)
				{
					await navigation.PushAsync(new TimerPage());
				}
				else {
					Username = "";
					Password = "";
				}
			}
		}

		private bool Check()
		{
			return !(String.IsNullOrEmpty(Username) || String.IsNullOrEmpty(Password));
		}

		private void RegisterForMessages()
		{
			Messenger.Default.Register<User>(this, UserReceived);
		}

		private void UserReceived(User user)
		{
			Username = user.Name;
			Password = user.Password;	
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
