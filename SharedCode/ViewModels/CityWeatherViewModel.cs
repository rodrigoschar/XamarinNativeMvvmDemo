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
	public partial class CityWeatherViewModel : ObservableObject, IRecipient<SelectedSrtItemMessage>
    {
        private ListResponse weatherResponse;
        private string test;
        public readonly IClimateService Service = Ioc.Default.GetRequiredService<IClimateService>();

        public CityWeatherViewModel(IClimateService service)
		{
            Service = service;
            //WeakReferenceMessenger.Default.Register<SelectedSrtItemMessage>(this);
            /*WeakReferenceMessenger.Default.Register<SelectedSrtItemMessage>(this, (r, m) =>
            {
                //MainThread.BeginInvokeOnMainThread(() =>
                //{
                Test = m.Value;
                //});
            });*/
            /*WeakReferenceMessenger.Default.Register<SelectedSrtItemMessage>(this, (r, m) =>
            {
                OnMessageReceived(m.Value);
            });*/
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

        public void GetData()
        {
            //Test = "Hola";
            /*WeakReferenceMessenger.Default.Register<SelectedItemMessage>(this, (r, m) =>
            {
                WeatherResponse = m.Value;
            });*/

            /*StrongReferenceMessenger.Default.Register<SelectedSrtItemMessage>(this, (r, m) =>
            {
                //MainThread.BeginInvokeOnMainThread(() =>
                //{
                    Test = m.Value;
                //});
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

        public void Receive(SelectedSrtItemMessage message)
        {
            Test = message.Value;
            /*WeakReferenceMessenger.Default.Register<SelectedSrtItemMessage>(this, (r, m) =>
            {
                //MainThread.BeginInvokeOnMainThread(() =>
                //{
                Test = m.Value;
                //});
            });*/
        }

        /*protected override void OnActivated()
        {
            // We use a method group here, but a lambda expression is also valid
            Messenger.Register<CityWeatherViewModel, WeatherChangedMessage>(this, (r, m) => r.WeatherResponse = m.Value);
            //Messenger.Register<CityWeatherViewModel, PropertyChangedMessage<ListResponse>>(this, (r, m) => r.Receive(m));
        }*/

        /*public void Receive(PropertyChangedMessage<ListResponse> message)
        {
            if (message.Sender.GetType() == typeof(SearchWeatherViewModel) &&
            message.PropertyName == nameof(SearchWeatherViewModel.SelectedResponse))
            {
                WeatherResponse = WeakReferenceMessenger.Default.Send<CurrentWeatherRequestMessage>();
                WeatherResponse = message.NewValue;
            }
        }*/
    }
}

