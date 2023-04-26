
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using CommunityToolkit.Mvvm.DependencyInjection;
using EBind;
using SharedCode.Models;
using SharedCode.Utils;
using SharedCode.ViewModels;
using Xamarin.Essentials;
using static AndroidX.RecyclerView.Widget.RecyclerView;

namespace AndroidMVVM.Views
{
    public class CityWeatherDetailFragment :AndroidX.Fragment.App.Fragment
    {
        private ImageView ivClimate;
        private TextView tvCityName;
        private TextView tvWeather;
        private TextView tvCurrentTemp;
        private TextView tvMinTemp;
        private TextView tvMaxTemp;
        private TextView tvClouds;
        private TextView tvWind;
        private TextView tvLat;
        private TextView tvLon;
        private CityWeatherViewModel viewModel;
        public ListResponse selected;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Android.Views.View view = inflater.Inflate(Resource.Layout.fragment_city_weather_detail, container, false);

            viewModel = Ioc.Default.GetRequiredService<CityWeatherViewModel>();

            ivClimate = view.FindViewById<ImageView>(Resource.Id.iv_weather);
            tvCityName = view.FindViewById<TextView>(Resource.Id.tv_dtCityName);
            tvWeather = view.FindViewById<TextView>(Resource.Id.tv_dtCurrentWeather);
            tvCurrentTemp = view.FindViewById<TextView>(Resource.Id.tv_dtCurrentTemp);
            tvMinTemp = view.FindViewById<TextView>(Resource.Id.tv_dtMinTemp);
            tvMaxTemp = view.FindViewById<TextView>(Resource.Id.tv_dtMaxTemp);
            tvClouds = view.FindViewById<TextView>(Resource.Id.tv_dtCloudsCoverage);
            tvWind = view.FindViewById<TextView>(Resource.Id.tv_dtWindSpeed);
            tvLat = view.FindViewById<TextView>(Resource.Id.tv_dtLat);
            tvLon = view.FindViewById<TextView>(Resource.Id.tv_dtLon);

            //viewModel.PropertyChanged += SetupView;

            var binding = new EBinding
            {
                BindFlag.None,
                () => UpdateViewDetails(viewModel.WeatherResponse),
                () => UpdateImage(viewModel.ImageBytes)
                //(() => tvCityName.Text == (viewModel.WeatherResponse.Name ?? "No City name"))
                //() => (tvCityName.Text ?? "TEXTO DE PRUEBA") == (viewModel.WeatherResponse.Name ?? "NO TEXT"),
                //() => (tvCityName.Text ?? "TEXTO DE PRUEBA") == viewModel.WeatherResponse.Name,
                //() => (tvWeather.Text ?? "TEXTO DE PRUEBA WHEATHER") == (viewModel.WeatherResponse.Weather.FirstOrDefault().Main ?? "TEST WHEATHER"),
                //() => viewModel.WeatherResponse.Weather.FirstOrDefault().Main == tvWeather.Text,
                //() => viewModel.WeatherResponse.Main.Temp.ToString() == tvCurrentTemp.Text,
                //() => viewModel.WeatherResponse.Clouds.All.ToString() == tvClouds.Text,
                //() => viewModel.WeatherResponse.wind.Speed.ToString() == tvWind.Text,
                //() => viewModel.WeatherResponse.Main.TempMin.ToString() == tvMinTemp.Text,
                //() => viewModel.WeatherResponse.Main.TempMax.ToString() == tvMaxTemp.Text,
                //() => viewModel.WeatherResponse.Coord.Lat.ToString() == tvLat.Text,
                //() => viewModel.WeatherResponse.Coord.Lon.ToString() == tvLon.Text,
            };
            //var binding = new EBinding
            //{
            //    BindFlag.None,
            //    () => (tvCityName.Text ?? "TEXTO DE PRUEBA") == (viewModel.WeatherResponse.Name ?? "No City name"),
            //};

            if (selected != null)
                viewModel.setData(selected);
            
            return view;
        }

        //private void SetupView(object sender, EventArgs eventArgs)
        //{
        //    if (viewModel.WeatherResponse != null)
        //    {
        //        tvCityName.Text = "CITY: " + viewModel.WeatherResponse.Name + ", " + viewModel.WeatherResponse.Sys.Country;
        //        tvWeather.Text = "WEATHER: " + viewModel.WeatherResponse.Weather.FirstOrDefault().Main + ", " + viewModel.WeatherResponse.Weather.FirstOrDefault().Description;
        //        tvCurrentTemp.Text = "CURRENT TEMP: " + Utils.ConvertKelvinToCelsius(viewModel.WeatherResponse.Main.Temp) + "ºC";
        //        if (viewModel.WeatherResponse.Clouds != null)
        //            tvClouds.Text = "CLOUDS COVERAGE: " + viewModel.WeatherResponse.Clouds.All + "%";
        //        tvWind.Text = "WIND SPEED: " + viewModel.WeatherResponse.wind.Speed + " mph";
        //        tvMinTemp.Text = "MIN TEMP: " + Utils.ConvertKelvinToCelsius(viewModel.WeatherResponse.Main.TempMin) + "ºC";
        //        tvMaxTemp.Text = "MAX TEMP: " + Utils.ConvertKelvinToCelsius(viewModel.WeatherResponse.Main.TempMax) + "ºC";
        //        tvLat.Text = "LATITUDE: " + viewModel.WeatherResponse.Coord.Lat;
        //        tvLon.Text = "LONGITUDE: " + viewModel.WeatherResponse.Coord.Lon;
        //    }

        //    if (viewModel.ImageBytes != null)
        //    {
        //        var bitmap = BitmapFactory.DecodeByteArray(viewModel.ImageBytes, 0, viewModel.ImageBytes.Length);
        //        ivClimate.SetImageBitmap(bitmap);
        //    }
        //}

        private void UpdateViewDetails(ListResponse city)
        {
            if (city == null) return;
            tvCityName.Text = "CITY: " + viewModel.WeatherResponse.Name + ", " + viewModel.WeatherResponse.Sys.Country;
            tvWeather.Text = "WEATHER: " + viewModel.WeatherResponse.Weather.FirstOrDefault().Main + ", " + viewModel.WeatherResponse.Weather.FirstOrDefault().Description;
            tvCurrentTemp.Text = "CURRENT TEMP: " + Utils.ConvertKelvinToCelsius(viewModel.WeatherResponse.Main.Temp) + "ºC";
            if (viewModel.WeatherResponse.Clouds != null)
                tvClouds.Text = "CLOUDS COVERAGE: " + viewModel.WeatherResponse.Clouds.All + "%";
            tvWind.Text = "WIND SPEED: " + viewModel.WeatherResponse.wind.Speed + " mph";
            tvMinTemp.Text = "MIN TEMP: " + Utils.ConvertKelvinToCelsius(viewModel.WeatherResponse.Main.TempMin) + "ºC";
            tvMaxTemp.Text = "MAX TEMP: " + Utils.ConvertKelvinToCelsius(viewModel.WeatherResponse.Main.TempMax) + "ºC";
            tvLat.Text = "LATITUDE: " + viewModel.WeatherResponse.Coord.Lat;
            tvLon.Text = "LONGITUDE: " + viewModel.WeatherResponse.Coord.Lon;
        }

        private void UpdateImage(byte[] image)
        {
            if (viewModel.ImageBytes == null) return;
            var bitmap = BitmapFactory.DecodeByteArray(viewModel.ImageBytes, 0, viewModel.ImageBytes.Length);
            ivClimate.SetImageBitmap(bitmap);
        }
    }
}

