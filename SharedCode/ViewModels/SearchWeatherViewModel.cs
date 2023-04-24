using System;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.ComponentModel;
using SharedCode.Interfaces;
using SharedCode.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SharedCode.Utils;
using System.Linq;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace SharedCode.ViewModels
{
	public partial class SearchWeatherViewModel : ObservableObject
    {
        public readonly IClimateService Service = Ioc.Default.GetRequiredService<IClimateService>();
        public ObservableRangeCollection<ListResponse> weatherResponses;
        private ListResponse selectedResponse;

        public SearchWeatherViewModel(IClimateService service)
		{
            weatherResponses = new ObservableRangeCollection<ListResponse>();
            Service = service;
        }

        public ListResponse SelectedResponse
        {
            get => selectedResponse;
            set => SetProperty(ref selectedResponse, value);
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
    }
}

