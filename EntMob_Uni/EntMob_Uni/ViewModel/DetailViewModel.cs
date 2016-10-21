using EntMob_Uni.Services;
using EntMob_Uni.Utility;
using EntMob_Uni.View;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EntMob_Uni.ViewModel
{
    public class DetailViewModel
    {
        public ICommand BackCommand { get; set; }

        private DateTime localDate;

        public DetailViewModel()
        {
            localDate = DateTime.Now;
            LoadCommands();

        }


        private void LoadCommands()
        {
            BackCommand = new CustomCommand(Back, null);
        }

        private void Back(object o)
        {
            NavigationService.Default.Navigate(typeof(ValuesPage));
            //Messenger.Default.Send<ParkingsCollectedMessage>(new ParkingsCollectedMessage() { ParkingLots = lots, MyLocation = myLocation });
        }

        public string Now
        {
            get
            {
                var culture = new CultureInfo("nl-BE");
                return localDate.ToString(culture);
            }
        }

        /*private void CountDown()
        {

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;


        }

        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {

        }*/
    }
}
