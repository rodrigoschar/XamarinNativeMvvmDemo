using System;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.ComponentModel;
using SharedCode.Interfaces;
using SharedCode.Models;
using System.Collections.Generic;

namespace SharedCode.ViewModels
{
	public class SearchWeatherViewModel : ObservableObject
    {
        private List<ListResponse> weatherList;
        public readonly IClimateService Service = Ioc.Default.GetRequiredService<IClimateService>();

        public SearchWeatherViewModel(IClimateService service)
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

