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

		public static RunnerViewModel Main(INavigation navigation)
        {
			return runnerViewModel ?? (runnerViewModel = new RunnerViewModel(navigation, userService));
        }

		public static RegisterViewModel Register(INavigation navigation)
		{
			return registerViewModel ?? (registerViewModel = new RegisterViewModel(navigation, userService));
		}

		public static TimerViewModel Timer(INavigation navigation)
        {
			return timerViewModel ?? (timerViewModel = new TimerViewModel(navigation, sessionService));
        }


		public static ValuesViewModel Values(INavigation navigation)
        {
                return valuesViewModel ?? (valuesViewModel = new ValuesViewModel(navigation));
        }
    }
}
