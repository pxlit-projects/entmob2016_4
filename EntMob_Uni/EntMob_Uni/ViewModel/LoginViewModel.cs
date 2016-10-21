using EntMob_Uni.Services;
using EntMob_Uni.Utility;
using EntMob_Uni.View;
using Jogging.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EntMob_Uni.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand LoginCommand { get; set; }


        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public LoginViewModel()
        {

            LoadCommands();

        }


        /*private void RegisterMessages()
        {
            Messenger.Default.Register<GeoLocationMessage>(this, MyLocationRecieved);
        }

        private async void MyLocationRecieved(GeoLocationMessage obj)
        {
            myLocation = obj.MyLocation;
            lots = await GetParkingLotsAsync();

            IsReady = true;
        }*/

        /*private async Task<List<ParkingLot>> GetParkingLotsAsync()
        {
            ParkingLotDataService ps = new ParkingLotDataService();
            List<ParkingLot> list = await ps.GetAllParkingLots();
            return list;
        }*/

        private void LoadCommands()
        {
            LoginCommand = new CustomCommand(Login, null);
        }


        private void Login(object o)
        {
            NavigationService.Default.Navigate(typeof(ValuesPage));
            //Messenger.Default.Send<ParkingsCollectedMessage>(new ParkingsCollectedMessage() { ParkingLots = lots, MyLocation = myLocation });
        }
    }
}
