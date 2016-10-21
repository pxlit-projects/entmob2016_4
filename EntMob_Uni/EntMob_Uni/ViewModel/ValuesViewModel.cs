using EntMob_Uni.Services;
using EntMob_Uni.Utility;
using EntMob_Uni.View;
using Jogging.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EntMob_Uni.ViewModel
{
    public class ValuesViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand NextCommand { get; set; }
        public ICommand BackCommand { get; set; }


        public ValuesViewModel()
        {
            LoadCommands();
        }

        private void LoadCommands()
        {
            NextCommand = new CustomCommand(Next, null);
            BackCommand = new CustomCommand(Back, null);

        }

        private void Back(object o)
        {
            NavigationService.Default.Navigate(typeof(LoginPage));
            //Messenger.Default.Send<ParkingsCollectedMessage>(new ParkingsCollectedMessage() { ParkingLots = lots, MyLocation = myLocation });
        }

        private void Next(object o)
        {
            NavigationService.Default.Navigate(typeof(DetailPage));
            //Messenger.Default.Send<ParkingsCollectedMessage>(new ParkingsCollectedMessage() { ParkingLots = lots, MyLocation = myLocation });
        }

        /*private List<Temperature> values = new List<Temperature>();

        public ValuesViewModel()
        {
            values.Add(new Temperature() { Amount = "27" });
            values.Add(new Temperature() { Amount = "25" });
            values.Add(new Temperature() { Amount = "23" });
            values.Add(new Temperature() { Amount = "21" });
            values.Add(new Temperature() { Amount = "29" });
        }



        public List<Temperature> Values
        {
            get
            {
                return values;
            }
        }*/
    }
}
