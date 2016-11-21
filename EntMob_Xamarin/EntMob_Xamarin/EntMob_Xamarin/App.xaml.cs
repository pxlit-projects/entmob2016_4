using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntMob_Xamarin;

using Xamarin.Forms;
using EntMob_Xamarin.Converters;
using EntMob_Xamarin.Services;
using EntMob_Xamarin.ViewModels;

namespace EntMob_Xamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
			Resources = new ResourceDictionary();
			Resources.Add("TimeConverter", new TimeConverter());
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
