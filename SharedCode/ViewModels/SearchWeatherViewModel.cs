﻿using System;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.ComponentModel;
using SharedCode.Interfaces;
using SharedCode.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SharedCode.Utils;
using System.Linq;
using System.Windows.Input;

namespace SharedCode.ViewModels
{
	public partial class SearchWeatherViewModel : ObservableObject
    {
        public readonly IClimateService Service = Ioc.Default.GetRequiredService<IClimateService>();
        public ObservableRangeCollection<ListResponse> weatherResponses;

        private INavigationService navigationService;

        public SearchWeatherViewModel(IClimateService service, INavigationService navigationService)
		{
            this.navigationService = navigationService;
            weatherResponses = new ObservableRangeCollection<ListResponse>();
            Service = service;
        }

        public async void GetWeatherByCityName(string cityName)
        {
            var data = await Service.GetWeatherByCitiName(cityName);
            var list = new List<ListResponse>();
            foreach (var item in data.Value)
            {
                list.Add(item);
            }
            weatherResponses.ReplaceRange(list);
        }

        public void GoToDetails(ListResponse selected)
        {
            navigationService.ShowDetails(selected);
        }
    }
}

