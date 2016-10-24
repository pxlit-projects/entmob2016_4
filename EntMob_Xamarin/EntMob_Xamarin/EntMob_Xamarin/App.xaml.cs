﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntMob_Xamarin;

using Xamarin.Forms;
using EntMob_Xamarin.Converters;

namespace EntMob_Xamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Resources = new ResourceDictionary();
            Resources.Add("Locator", new ViewModelLocator());
            Resources.Add("ValueToDegreesConverter", new ValueToDegreesConverter());
            Resources.Add("ValueToKmConverter", new ValueToKmConverter());

            MainPage = new MainPage();
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
