using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using EntMob.Models;
using EntMob_Xamarin.Services;
using Xamarin.Forms;

namespace EntMob_Xamarin
{
	public class RegisterViewModel: INotifyPropertyChanged
	{

		private IUserService userService;
		private INavigation navigation;

		public RegisterViewModel(INavigation navigation, IUserService userService)
		{
			this.navigation = navigation;
			this.userService = userService;
			loadCommands();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private void loadCommands()
		{
			RegisterCommand = new Command((obj) => Register(obj));
		}

		private User user { get; set; }

		public User User
		{
			get
			{
				return user;
			}
			set
			{
				user = value;
				OnPropertyChanged("User");
			}
		}

		public ICommand RegisterCommand { get; set; }

		private void Register(object o)
		{
			var result = Task.Run(() =>
			{
				try
				{
					return userService.AddUser(user);
				}
				catch (Exception ex)
				{
					Debug.WriteLine("Test" + ex.Message);
					return null;
				}
			});
			//navigation.PopAsync(true);
		}

	}
}
