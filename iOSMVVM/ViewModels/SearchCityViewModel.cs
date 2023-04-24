using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using iOSMVVM.Managers;
using SharedCode.Interfaces;
using SharedCode.Models;
using SharedCode.Utils;

namespace iOSMVVM.ViewModels
{
	public partial class SearchCityViewModel : ObservableObject
    {
        public readonly IClimateService Service = Ioc.Default.GetRequiredService<IClimateService>();
        public readonly INavigationService NavigationService = Ioc.Default.GetRequiredService<INavigationService>();
        public ObservableRangeCollection<ListResponse> weatherResponses;
        private ListResponse selectedResponse;

        public SearchCityViewModel(IClimateService service, INavigationService navigationService)
        {
            weatherResponses = new ObservableRangeCollection<ListResponse>();
            Service = service;
            NavigationService = navigationService;
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

        public void GoToDetailView(ListResponse selected, ViewController controller)
        {
            NavigationService.GoToWeatherDetail(selected, controller);
        }
    }
}

