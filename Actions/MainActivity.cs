using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using System;
using Xamarin.Essentials;

namespace Actions
{
    [IntentFilter(new[] { Xamarin.Essentials.Platform.Intent.ActionAppAction },
           Categories = new[] { Android.Content.Intent.CategoryDefault })]
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);            
            SetContentView(Resource.Layout.activity_main);
            try
            {
                AppActions.SetAsync(
                new AppAction("app_info", "App Info", icon: "app_info_action_icon"),
                new AppAction("battery_info", "Battery Info",icon:"battery"),
                new AppAction("abc", "abc"));
            }

            catch (FeatureNotSupportedException)

            {
                Console.WriteLine("App Actions not supported");
            }


        }
       
        protected override void OnResume()
        {
            base.OnResume();

            Xamarin.Essentials.Platform.OnResume(this);
        }

        protected override void OnNewIntent(Android.Content.Intent intent)
        {
            base.OnNewIntent(intent);

            Xamarin.Essentials.Platform.OnNewIntent(intent);
        }
        

    }
}