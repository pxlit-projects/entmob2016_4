using EntMob_Xamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using EntMob_Xamarin.Services;
using EntMob.DAL;

namespace EntMob_Xamarin
{
    public class ViewModelLocator
    {

		private static IUserService userService = new UserService(new UserRepository());
		private static ISessionService sessionService = new SessionService(new SessionRepository());

		private static RunnerViewModel runnerViewModel;
		private static RegisterViewModel registerViewModel;
		private static TimerViewModel timerViewModel;
		private static ValuesViewModel valuesViewModel;

		public static RunnerViewModel Main()
        {
			return runnerViewModel ?? (runnerViewModel = new RunnerViewModel(userService));
        }

		public static RegisterViewModel Register()
		{
			return registerViewModel ?? (registerViewModel = new RegisterViewModel(userService));
		}

		public static TimerViewModel Timer()
        {
			return timerViewModel ?? (timerViewModel = new TimerViewModel(sessionService));
        }


		public static ValuesViewModel Values()
        {
                return valuesViewModel ?? (valuesViewModel = new ValuesViewModel());
        }
    }
}
