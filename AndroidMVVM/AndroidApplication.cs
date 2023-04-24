using System;
using Android.App;
using Android.Service.QuickSettings;
using static Android.Telephony.CarrierConfigManager;
using SharedCode.Interfaces;
using SharedCode.Managers;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Java.Util.Logging;
using SharedCode.ViewModels;
using AndroidMVVM.Navigation;

namespace AndroidMVVM
{
    [Application]
    public class AndroidApplication : Application
	{
        public AndroidApplication(IntPtr javaReference, Android.Runtime.JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            
        }

        public override void OnCreate()
        {
            base.OnCreate();
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddSingleton<INetworkHandler, NetworkHandlerManager>()
                .AddSingleton<IClimateService, ClimateService>()
                .AddSingleton<INavigationService, NavigationService>()
                .AddTransient<SearchWeatherViewModel>()
                .AddTransient<CityWeatherViewModel>()
                .BuildServiceProvider());
        }
    }
}

