﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EntMob_Xamarin.ViewModels
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        private bool Run = true;
        int Min, Sec, Hours, Tenth;
        private DateTime localDate;
        public String _timerContent;
        public String TimerContent { get { return _timerContent; }  set { _timerContent = value; OnPropertyChanged("TimerContent"); } }

        public event PropertyChangedEventHandler PropertyChanged;

         private void OnPropertyChanged(string prop)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(prop);
                handler(this, e);
            }
        }

        public TimerViewModel()
        {
            localDate = DateTime.Now;
        }

        public void StartTimer() {
            Device.StartTimer(TimeSpan.FromMilliseconds(10), () =>
                {
                    Task.Factory.StartNew(async () =>
                    {
                    // Do the actual request and wait for it to finish.
                    await Task.Delay(0);
                    // Switch back to the UI thread to update the UI
                    Device.BeginInvokeOnMainThread(() =>
                        {
                        // Update the UI
                        // ...
                        // Now repeat by scheduling a new request
                        addTime();
                        });
                    });

                // Don't repeat the timer (we will start a new timer when the request is finished)
                return true;
                });

        }

        public void addTime()
{
            if (Tenth < 99)
            {
                Tenth++;
            }
            else
            {
                Tenth = 0;
                if (Sec < 59)
                {
                    Sec++;
                }
                else
                {
                    Sec = 0;
                    if (Min < 59)
                    {
                        Min++;
                    }
                    else
                    {
                        Min = 0;
                        Hours++;
                    }
                }
            }
    if(Min<10&&Sec<10&&Tenth<10)
    TimerContent = string.Format("0{0}" + ":" + "0{1}" + ":" + "0{2}" + ":0{3}", Hours, Min, Sec, Tenth);
    else if (Min < 10 && Tenth < 10)
    TimerContent = string.Format("0{0}" + ":" + "0{1}" + ":" + "{2}" + ":0{3}", Hours, Min, Sec, Tenth);
    else if (Sec < 10 && Tenth < 10)
    TimerContent = string.Format("0{0}" + ":" + "{1}" + ":" + "0{2}" + ":0{3}", Hours, Min, Sec, Tenth);
    else if (Sec < 10 && Min < 10)
    TimerContent = string.Format("0{0}" + ":" + "0{1}" + ":" + "0{2}" + ":{3}", Hours, Min, Sec, Tenth);
    else if(Min<10)
    TimerContent = string.Format("0{0}" + ":" + "0{1}" + ":" + "{2}" + ":{3}", Hours, Min, Sec, Tenth);
    else if (Sec<10)
    TimerContent = string.Format("0{0}" + ":" + "{1}" + ":" + "{2}" + ":0{3}", Hours, Min, Sec, Tenth);
    else if(Tenth<10)
    TimerContent = string.Format("0{0}" + ":" + "{1}" + ":" + "{2}"+ ":0{3}", Hours, Min, Sec, Tenth);
    


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
