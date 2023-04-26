﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidMVVM.Adapters;
using AndroidMVVM.Navigation;
using AndroidMVVM.Util;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using EBind;
using Google.Android.Material.TextField;
using SharedCode.Interfaces;
using SharedCode.Models;
using SharedCode.Utils;
using SharedCode.ViewModels;
using Xamarin.Essentials;
using static AndroidX.RecyclerView.Widget.RecyclerView;

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
        private HideAndShowKeyboard hideAndShowKeyboard;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Android.Views.View view = inflater.Inflate(Resource.Layout.fragment_search_city_weather, container, false);

            viewModel = Ioc.Default.GetRequiredService<SearchWeatherViewModel>();
            hideAndShowKeyboard = Ioc.Default.GetRequiredService<HideAndShowKeyboard>();

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
            //searchButton.Click += SearchWeather;

            var binding = new EBinding
            {
                BindFlag.None,
                (searchButton, nameof(searchButton.Click), () => viewModel.GetWeatherByCityName(searchInput.Text)),
                //(adapter, nameof(adapter.ItemClick), () => GoToDetailItemClick(null, 2 )),
            };

            viewModel.PropertyChanged += PropertiesChanged;
            viewModel.weatherResponses.CollectionChanged += (s, e) => UpdatedCollectionProp();

            return view;
        }

        private void SearchWeather(object sender, EventArgs eventArgs)
        {
            var city = searchInput.Text;
            if (!string.IsNullOrEmpty(city))
            {
                progressDialog.Show();
                viewModel.GetWeatherByCityName(city);
            } 
        }

        private void PropertiesChanged(object sender, EventArgs eventArgs)
        {
            hideAndShowKeyboard.hideSoftKeyboard(this.RequireActivity());
            if (viewModel.ErrorMessage != null)
            {
                progressDialog.Dismiss();
                Toast.MakeText(Application.Context, viewModel.ErrorMessage, ToastLength.Short).Show();
            }
        }

        private void UpdatedCollectionProp()
        {
            if (viewModel.weatherResponses != null)
            {
                weatherList = viewModel.weatherResponses.ToList();
                (recyclerView.GetAdapter() as WeatherAdapter).UpdateList(weatherList);
                progressDialog.Dismiss();
            }
        }

        private void GoToDetailItemClick(object sender, int e)
        {
            hideAndShowKeyboard.hideSoftKeyboard(this.RequireActivity());
            ListResponse selected = weatherList[e];
            viewModel.GoToDetails(selected);
        }
    }
}

