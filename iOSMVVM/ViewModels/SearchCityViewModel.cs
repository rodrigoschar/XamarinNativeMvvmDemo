using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using SharedCode.Interfaces;
using SharedCode.Models;

namespace iOSMVVM.ViewModels
{
	public partial class SearchCityViewModel : ObservableObject
    {
        private List<ListResponse> weatherList;
        public readonly IClimateService Service = Ioc.Default.GetRequiredService<IClimateService>();

        public SearchCityViewModel(IClimateService service)
        {
            Service = service;
        }

        public List<ListResponse> WeatherList
        {
            get => weatherList;
            set => SetProperty(ref weatherList, value);
        }

        public async void GetWeatherByCityName(string cityName)
        {
            var data = await Service.GetWeatherByCitiName(cityName);
            var list = new List<ListResponse>();
            foreach (var item in data.Value)
            {
                list.Add(item);
            }
            WeatherList = list;
        }
    }
}

