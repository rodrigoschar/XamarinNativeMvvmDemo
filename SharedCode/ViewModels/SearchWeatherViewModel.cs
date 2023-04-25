using System;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.ComponentModel;
using SharedCode.Interfaces;
using SharedCode.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SharedCode.Utils;
using System.Linq;

namespace SharedCode.ViewModels
{
	public partial class SearchWeatherViewModel : ObservableObject
    {
        public readonly IClimateService Service = Ioc.Default.GetRequiredService<IClimateService>();
        public ObservableRangeCollection<ListResponse> weatherResponses;
        private string errorMessage;

        private INavigationService navigationService;

        public SearchWeatherViewModel(IClimateService service, INavigationService navigationService)
		{
            this.navigationService = navigationService;
            weatherResponses = new ObservableRangeCollection<ListResponse>();
            Service = service;
        }

        public string ErrorMessage
        {
            get => errorMessage;
            set => SetProperty(ref errorMessage, value);
        }

        public async void GetWeatherByCityName(string cityName)
        {
            var data = await Service.GetWeatherByCitiName(cityName);
            if (data.Success)
            {
                if (data.Value.Count == 0)
                {
                    weatherResponses.Clear();
                    ErrorMessage = "Error " + cityName + " is not a valid city name";
                }
                else
                {
                    var list = new List<ListResponse>();
                    foreach (var item in data.Value)
                    {
                        list.Add(item);
                    }
                    weatherResponses.ReplaceRange(list);
                }
            }
            else
            {
                weatherResponses.Clear();
                ErrorMessage = data.Error;
            } 
        }

        public void GoToDetails(ListResponse selected)
        {
            navigationService.ShowDetails(selected);
        }
    }
}

