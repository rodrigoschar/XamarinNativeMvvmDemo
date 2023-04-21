using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using SharedCode.Interfaces;
using SharedCode.Models;
using SharedCode.Utils;
using Xamarin.Essentials;

namespace SharedCode.ViewModels
{
	public partial class CityWeatherViewModel : ObservableObject
    {
        private ListResponse weatherResponse;
        private string test;
        public readonly IClimateService Service = Ioc.Default.GetRequiredService<IClimateService>();

        public CityWeatherViewModel(IClimateService service)
		{
            Service = service;
        }

        public ListResponse WeatherResponse
        {
            get => weatherResponse;
            private set => SetProperty(ref weatherResponse, value);
        }

        public string Test
        {
            get => test;
            private set => SetProperty(ref test, value);
        }

        public void setData(ListResponse data)
        {
            WeatherResponse = data;
            /*WeakReferenceMessenger.Default.Register<SelectedItemMessage>(this, (r, m) =>
            {
                WeatherResponse = m.Value;
            });*/
            Console.WriteLine(1);
            WeakReferenceMessenger.Default.Register<SelectedSrtItemMessage>(this, (r, m) =>
            {
                OnMessageReceived(m.Value);
                Console.WriteLine(m.Value);
            });
        }

        private void OnMessageReceived(string value)
        {
            Console.WriteLine($"New message received: {value}");
        } 
    }
}

