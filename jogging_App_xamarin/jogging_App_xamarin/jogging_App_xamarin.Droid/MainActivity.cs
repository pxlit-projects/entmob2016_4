using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace jogging_App_xamarin.Droid
{
    [Activity(Label = "jogging_App_xamarin", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
           /* TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            */
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
           // Xamarin.FormsMaps.init(this, bundle);
            LoadApplication(new App());
        }
    }
}

