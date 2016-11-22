﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using EntMob_Xamarin;

namespace SensorTagDemo.Droid
{
    [Activity(Label = "SensorTagDemo", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);

            var a = new Robotics.Mobile.Core.Bluetooth.LE.Adapter();
            App.SetAdapter(a);

            LoadApplication(new App());
        }
    }
}

