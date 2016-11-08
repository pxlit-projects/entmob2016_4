using EntMob_Uni.Services;
using EntMob_Uni.ViewModel;
using Jogging.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntMob_Uni
{
    public class ViewModelLocator
    {

        private static IUserService userService = new UserService(new UserRepository());

        private static LoginViewModel loginViewModel;
        private static DetailViewModel detailViewModel;
        private static ValuesViewModel valuesViewModel;

        //private static IDialogService dialogService = new DialogService(parkingLotSelectionViewModel.SelectedParking, routeDetailViewModel.selectedRoute);
        //private static IParkingLotDataService parkingLotDataService = new ParkingLotDataService(new ParkingsRepository());

        public static LoginViewModel LoginViewModel
        {
            get
            {
                return loginViewModel ?? (loginViewModel = new LoginViewModel(userService));
            }
        }


        public static DetailViewModel DetailViewModel
        {
            get
            {
                return detailViewModel ?? (detailViewModel = new DetailViewModel(/*parkingLotDataService, dialogService*/));
            }
        }


        public static ValuesViewModel ValuesViewModel
        {
            get
            {
                return valuesViewModel ?? (valuesViewModel = new ValuesViewModel(/*parkingLotDataService, dialogService*/));
            }
        }
    }
}
