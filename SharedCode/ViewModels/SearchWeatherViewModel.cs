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
        public ObservableCollection<ListResponse> weatherCollection;
        public ObservableRangeCollection<ListResponse> weatherResponses;
        private ListResponse selectedResponse;

        private INavigationService navigationService;

        public SearchWeatherViewModel(IClimateService service, INavigationService navigationService)
		{
            this.navigationService = navigationService;
            weatherCollection = new ObservableCollection<ListResponse>();
            weatherResponses = new ObservableRangeCollection<ListResponse>();
            Service = service;
        }

        public ObservableCollection<ListResponse> WeatherCollection
        {
            get { return weatherCollection ?? (weatherCollection = new ObservableCollection<ListResponse>()); }
            set { weatherCollection = value; OnPropertyChanged(); }
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
                //WeatherCollection.Add(item);
                list.Add(item);
            }
            weatherResponses.ReplaceRange(list);
        }

        public void RemoveItemList()
        {
            weatherResponses.RemoveAt(1);
        }

        public void SetSelectedCity(int index)
        {
            SelectedResponse = weatherCollection[index];
            //WeakReferenceMessenger.Default.Send(new SelectedItemMessage(SelectedResponse));
            WeakReferenceMessenger.Default.Send(new SelectedSrtItemMessage("It Works"));
        }

        public void GoToDetails(ListResponse selected)
        {
            navigationService.ShowDetails(selected);
        }
    }
}

