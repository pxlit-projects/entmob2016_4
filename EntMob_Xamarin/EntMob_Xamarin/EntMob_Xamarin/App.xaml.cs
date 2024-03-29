﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntMob_Xamarin;

using Xamarin.Forms;
using EntMob_Xamarin.Converters;
using EntMob_Xamarin.Services;
using EntMob_Xamarin.ViewModels;
using Robotics.Mobile.Core.Bluetooth.LE;

namespace EntMob_Xamarin
{
    public partial class App : Application
    {

        static IAdapter Adapter;

        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());

            MainPage = new NavigationPage(new DevicePage(Adapter));

            Resources = new ResourceDictionary();
			Resources.Add("TimeConverter", new TimeConverter());
			Resources.Add("HumidityConverter", new HumidityConverter());
        }

        public static void SetAdapter(IAdapter adapter)
        {
            Adapter = adapter;
        }
        public static Page GetMainPage()
        {
            return new NavigationPage(new DevicePage(Adapter));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
