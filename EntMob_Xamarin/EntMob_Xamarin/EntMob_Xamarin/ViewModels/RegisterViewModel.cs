using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using EntMob.Models;
using EntMob_Xamarin.Services;
using EntMob_Xamarin.Utility;
using Xamarin.Forms;

namespace EntMob_Xamarin
{
	public class RegisterViewModel: INotifyPropertyChanged
	{

		private string name { get; set;}
		private string lastName { get; set; }
		private string firstName { get; set; }
		private string password { get; set; }

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

		public string LastName
		{
			get
			{
				return lastName;
			}
			set
			{
				lastName = value;
				RaisePropertyChanged("LastName");
			}
		}

		public string FirstName
		{
			get
			{
				return firstName;
			}
			set
			{
				firstName = value;
				RaisePropertyChanged("FirstName");
			}
		}

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

		private IUserService userService;
		private INavigation navigation;

		public RegisterViewModel(IUserService userService)
		{
			//this.navigation = navigation;
			this.userService = userService;
			loadCommands();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		private void loadCommands()
		{
			RegisterCommand = new Command((obj) => Register(obj));
		}

		public ICommand RegisterCommand { get; set; }

		private async void Register(object o)
		{
			if (Check())
			{
				User user = CreateUser();
				var result = await Task.Run(() =>
				{
					try
					{
						return userService.AddUser(user);
					}
					catch
					{
						return null;
					}
				});

				if (result != null)
				{
					result.Password = user.Password;
					Messenger.Default.Send<User>(result);
					//await navigation.PopAsync(true);
					NavigationService.Default.NavigateTo("Login");
				}
				else {
					FirstName = "";
					LastName = "";
					Name = "";
					Password = "";
				}
			}
		}

		private User CreateUser()
		{
			User user = new User();
			user.Password = password;
			user.Name = name;
			user.FirstName = firstName;
			user.LastName = lastName;
			return user;
		}

		private bool Check()
		{
			return !(String.IsNullOrEmpty(lastName) || String.IsNullOrEmpty(firstName) || 
			        String.IsNullOrEmpty(name) || String.IsNullOrEmpty(password));
		}

	}
}
