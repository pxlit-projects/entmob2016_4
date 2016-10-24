using EntMob_Xamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntMob_Xamarin
{
    public class ViewModelLocator
    {
        private static RunnerViewModel runnerViewModel;
        private static TimerViewModel timerViewModel;
        private static ValuesViewModel valuesViewModel;

        //private static IDialogService dialogService = new DialogService(parkingLotSelectionViewModel.SelectedParking, routeDetailViewModel.selectedRoute);
        //private static IParkingLotDataService parkingLotDataService = new ParkingLotDataService(new ParkingsRepository());

        public static RunnerViewModel RunnerViewModel
        {
            get
            {
                return runnerViewModel ?? (runnerViewModel = new RunnerViewModel(/*parkingLotDataService, dialogService*/));
            }
        }


        public static TimerViewModel DetailViewModel
        {
            get
            {
                return timerViewModel ?? (timerViewModel = new TimerViewModel(/*parkingLotDataService, dialogService*/));
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
