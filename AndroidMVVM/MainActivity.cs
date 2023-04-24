using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Xamarin.Essentials;
using AndroidMVVM.Views;
using SharedCode.Models;
using SharedCode.Interfaces;
using AndroidMVVM.Navigation;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace AndroidMVVM
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public INavigationService navigationService = Ioc.Default.GetRequiredService<INavigationService>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            navigationService.StartNavigation();
        }
	}
}

