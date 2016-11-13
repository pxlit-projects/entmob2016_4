using System;
namespace EntMob_Xamarin
{
	public class NavigationService : INavigationService
	{

		private static readonly object CreationLock = new Object();
		private static NavigationService _instance;

		public static NavigationService Default
		{
			get
			{
				if (_instance == null)
				{
					lock(CreationLock)
					{
						if (_instance == null)
						{
							_instance = new NavigationService();
						}
					}
				}
				return _instance;
			}
		}

		private NavigationService() { }

		public void NavigateTo(string pageKey)
		{
			if (pageKey == "Login")
			{
				App.Current.MainPage = new MainPage();
			}
			else if (pageKey == "Register")
			{
				App.Current.MainPage = new RegisterPage();
			}
			else if (pageKey == "Timer")
			{
				App.Current.MainPage = new TimerPage();
			}
			else if (pageKey == "Values")
			{
				App.Current.MainPage = new ValuesPage();
			}
		}
	}
}
