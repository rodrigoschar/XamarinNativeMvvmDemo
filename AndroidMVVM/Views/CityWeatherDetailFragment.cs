
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Messaging;
using SharedCode.Utils;
using SharedCode.ViewModels;
using Xamarin.Essentials;
using static Android.Renderscripts.Sampler;
using static AndroidX.RecyclerView.Widget.RecyclerView;

namespace AndroidMVVM.Views
{
    public class CityWeatherDetailFragment :AndroidX.Fragment.App.Fragment
    {
        private TextView tvCityName;
        private TextView tvWeather;
        private TextView tvCurrentTemp;
        private TextView tvMinTemp;
        private TextView tvMaxTemp;
        public CityWeatherViewModel viewModel;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Android.Views.View view = inflater.Inflate(Resource.Layout.fragment_city_weather_detail, container, false);

            viewModel = Ioc.Default.GetRequiredService<CityWeatherViewModel>();

            tvCityName = view.FindViewById<TextView>(Resource.Id.tv_dtCityName);
            tvWeather = view.FindViewById<TextView>(Resource.Id.tv_dtCurrentWeather);
            tvCurrentTemp = view.FindViewById<TextView>(Resource.Id.tv_dtCurrentTemp);
            tvMinTemp = view.FindViewById<TextView>(Resource.Id.tv_drMinTemp);
            tvMaxTemp = view.FindViewById<TextView>(Resource.Id.tv_dtMaxTemp);
            
            viewModel.PropertyChanged += SetupView;
            viewModel.GetData();
            
            return view;
        }

        private void SetupView(object sender, EventArgs eventArgs)
        {
            if (viewModel.Test != null)
            {
                var result = viewModel.Test;
                tvCityName.Text = result;
            }
                
            //tvCityName.Text = "City Name: " + viewModel.WeatherResponse.Name;
            //tvWeather.Text = "Weather: " + viewModel.WeatherResponse.Weather.FirstOrDefault().Main + ", " + viewModel.WeatherResponse.Weather.FirstOrDefault().Description;
            //tvCurrentTemp.Text = "Current Temp: " + Utils.ConvertKelvinToCelsius(viewModel.WeatherResponse.Main.Temp) + "ºC";
            //tvMinTemp.Text = "Min Temp: " + Utils.ConvertKelvinToCelsius(viewModel.WeatherResponse.Main.TempMin) + "ºC";
            //tvMaxTemp.Text = "Max Temp: " + Utils.ConvertKelvinToCelsius(viewModel.WeatherResponse.Main.TempMax) + "ºC";
        }
    }
}

