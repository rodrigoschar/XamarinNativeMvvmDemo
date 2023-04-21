﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidMVVM.Adapters;
using AndroidMVVM.ViewModels;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Google.Android.Material.TextField;
using SharedCode.Interfaces;
using SharedCode.Models;
using SharedCode.Utils;
using SharedCode.ViewModels;
using Xamarin.Essentials;
using static AndroidX.RecyclerView.Widget.RecyclerView;
using static Java.Util.Jar.Attributes;

namespace AndroidMVVM.Views
{
    public class SearchCityWeatherFragment : AndroidX.Fragment.App.Fragment
    {
        private TextInputEditText searchInput;
        public SearchWeatherViewModel viewModel; 
        private RecyclerView recyclerView;
        private RecyclerView.LayoutManager mLayoutManager;
        private List<ListResponse> weatherList;
        private WeatherAdapter adapter;
        private AndroidX.AppCompat.App.AlertDialog progressDialog;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Android.Views.View view = inflater.Inflate(Resource.Layout.fragment_search_city_weather, container, false);

            viewModel = Ioc.Default.GetRequiredService<SearchWeatherViewModel>();

            weatherList = new List<ListResponse>();
            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.rv_weatherList);
            mLayoutManager = new LinearLayoutManager(view.Context);
            recyclerView.SetLayoutManager(mLayoutManager);
            adapter = new WeatherAdapter(weatherList);
            adapter.ItemClick += GoToDetailItemClick;
            recyclerView.SetAdapter(adapter);

            AndroidX.AppCompat.App.AlertDialog.Builder dialogBuilder = new AndroidX.AppCompat.App.AlertDialog.Builder(view.Context);
            dialogBuilder.SetView(Resource.Layout.progress_bar);
            progressDialog = dialogBuilder.Create();

            searchInput = view.FindViewById<TextInputEditText>(Resource.Id.edt_searchWeather);
            Button searchButton = view.FindViewById<Button>(Resource.Id.btn_search);
            searchButton.Click += SearchWeather;

            //viewModel.PropertyChanged += UpdateProperties;
            viewModel.weatherCollection.CollectionChanged += (s, e) => UpdatedCollectionProp();

            return view;
        }

        private void SearchWeather(object sender, EventArgs eventArgs)
        {
            var city = searchInput.Text;
            if (!string.IsNullOrEmpty(city))
            {
                progressDialog.Show();
                viewModel.GetWeatherByCityName(city);
            } else
            {
                viewModel.RemoveItemList();
            }  
        }

        private void UpdateProperties(object sender, EventArgs eventArgs)
        {
            var propTest = sender.GetType().GetProperty("Test");
            var propWeatherList = sender.GetType().GetProperty("WeatherList");
            
            if (viewModel.WeatherList != null) // propWeatherList != null && 
            {
                weatherList = viewModel.WeatherList;
                (recyclerView.GetAdapter() as WeatherAdapter).UpdateList(weatherList);
                progressDialog.Dismiss();
            }
        }

        private void UpdatedCollectionProp()
        {
            if (viewModel.weatherCollection != null) // propWeatherList != null && 
            {
                weatherList = viewModel.weatherCollection.ToList();
                (recyclerView.GetAdapter() as WeatherAdapter).UpdateList(weatherList);
                progressDialog.Dismiss();
            }
        }

        private void GoToDetailItemClick(object sender, int e)
        {
            CityWeatherDetailFragment detailFragment = new CityWeatherDetailFragment();

            var appCompatActivity = Platform.CurrentActivity as AppCompatActivity;
            var fragmentTransaction = appCompatActivity?.SupportFragmentManager.BeginTransaction();
            fragmentTransaction.Hide(this);
            fragmentTransaction.Add(Resource.Id.fragmentContainer, detailFragment, "CityWeatherDetailFragment");
            fragmentTransaction.AddToBackStack("CityWeatherDetailFragment");
            fragmentTransaction.Commit();
            viewModel.SetSelectedCity(e);
        }
    }
}

