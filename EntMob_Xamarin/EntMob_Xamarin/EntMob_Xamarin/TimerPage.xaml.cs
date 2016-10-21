using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntMob_Xamarin.ViewModels;



using Xamarin.Forms;
using Java.Util;

namespace EntMob_Xamarin
{
    public partial class TimerPage : ContentPage
    {
        TimerViewModel _TimerViewModel;

        public TimerPage()
        {
            InitializeComponent();
            _TimerViewModel = new TimerViewModel();
            BindingContext = _TimerViewModel;
          

        }

        public void ItemClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (button.Text == "Stop")
            {
                button.Text = "Start";
                Navigation.PushAsync(new ValuesPage());

            }else
            {
                _TimerViewModel.StartTimer();
                button.Text = "Stop";
            }

        }
       

    }
}
