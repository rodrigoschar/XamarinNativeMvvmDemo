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
        private List<ListResponse> weatherList;
        public readonly IClimateService Service = Ioc.Default.GetRequiredService<IClimateService>();
        public ObservableCollection<ListResponse> weatherCollection; //{ get; }//new ObservableCollection<ListResponse>();//new();//{ get; }
        private ListResponse selectedResponse;
        //public ICommand RequestCurrentUsernameCommand { get; }
        //[ObservableProperty]
        //public RelayCommand PlayStopCommand;

        public SearchWeatherViewModel(IClimateService service)
		{
            //RequestCurrentUsernameCommand = new RelayCommand(RequestCurrentUsername);
            weatherCollection = new ObservableCollection<ListResponse>();
            Service = service;

           
        }

        public List<ListResponse> WeatherList
        {
            get => weatherList;
            set => SetProperty(ref weatherList, value);
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

        /*protected override void OnActivated()
        {
            Messenger.Register<SearchWeatherViewModel, CurrentWeatherRequestMessage>(this, (r, m) => m.Reply(r.SelectedResponse));
        }*/

        public async void GetWeatherByCityName(string cityName)
        {
            var data = await Service.GetWeatherByCitiName(cityName);
            var list = new List<ListResponse>();
            foreach (var item in data.Value)
            {
                weatherCollection.Add(item);
                list.Add(item);
            }
            WeatherList = list;
            //WeatherCollection.AddRange(list);
            //var collection = new ObservableCollection<ListResponse>(list);
            //WeatherCollection = new ObservableCollection<ListResponse>(list);//(ObservableCollection<ListResponse>)list.ToCollection<ListResponse>();
            //weatherCollection = (ObservableCollection<ListResponse>)list.ToCollection<ListResponse>();
        }

        public void RemoveItemList()
        {
            WeatherList.RemoveAt(1);
            weatherCollection.RemoveAt(1);
        }

        //[RelayCommand]
        public void SetSelectedCity(int index)
        {
            SelectedResponse = weatherCollection[index];
            //WeakReferenceMessenger.Default.Send(new SelectedItemMessage(SelectedResponse));
            WeakReferenceMessenger.Default.Send(new SelectedSrtItemMessage("It Works"));
            //Messenger.Send(new WeatherChangedMessage(SelectedResponse));
            //PlayStopCommand = new RelayCommand(() => RequestCurrentUsername("It Works"));
            //weatherCollection.ToList().I;
        }

        /*[RelayCommand]
        public void RequestCurrentUsername(string name)
        {
            WeakReferenceMessenger.Default.Send(new SelectedSrtItemMessage("It Works"));
        }*/
    }
}

