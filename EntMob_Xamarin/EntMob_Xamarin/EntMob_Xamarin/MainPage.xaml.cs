﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using EntMob_Xamarin.ViewModels;

namespace EntMob_Xamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new RunnerViewModel(); 
            
        }

        public void ItemClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TimerPage());
        }
    }
}
