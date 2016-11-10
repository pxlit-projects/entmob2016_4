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

        private RunnerViewModel runnerViewModel;
		private RegisterViewModel registerViewModel;
        private TimerViewModel timerViewModel;
        private ValuesViewModel valuesViewModel;

        public RunnerViewModel Main(INavigation navigation)
        {
            return runnerViewModel ?? (runnerViewModel = new RunnerViewModel(navigation));
        }

		public RegisterViewModel Register(INavigation navigation)
		{
			return registerViewModel ?? (registerViewModel = new RegisterViewModel(navigation, userService));
		}

        public TimerViewModel Timer(INavigation navigation)
        {
                return timerViewModel ?? (timerViewModel = new TimerViewModel(navigation));
        }


        public ValuesViewModel Values(INavigation navigation)
        {
                return valuesViewModel ?? (valuesViewModel = new ValuesViewModel(navigation));
        }
    }
}
