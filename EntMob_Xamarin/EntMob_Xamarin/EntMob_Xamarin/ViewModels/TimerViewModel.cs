using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EntMob_Xamarin.ViewModels
{
    public class TimerViewModel
    {
        private DateTime localDate;

        public TimerViewModel()
        {
            localDate = DateTime.Now;
            
        }

        public string Now {
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
