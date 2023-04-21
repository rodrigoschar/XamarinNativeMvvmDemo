using System;
using System.Collections.Generic;
using System.Linq;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using SharedCode.Models;
using SharedCode.Utils;

namespace AndroidMVVM.Adapters
{
    public class WeatherAdapter : RecyclerView.Adapter
    {
        public List<ListResponse> weatherList;
        public event EventHandler<int> ItemClick;

        public WeatherAdapter(List<ListResponse> list)
        {
            weatherList = list;
        }

        public override int ItemCount
        {
            get { return weatherList.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            WeatherViewHolder viewHolder = holder as WeatherViewHolder;
            var value = weatherList[position];

            viewHolder.tvCityName.Text = "City Name: " + value.Name;
            viewHolder.tvCountryName.Text = "Country: " + value.Sys.Country;
            viewHolder.tvWeather.Text = "Weather: " + value.Weather.FirstOrDefault().Main + ", " + value.Weather.FirstOrDefault().Description;
            viewHolder.tvCurrentTemp.Text = "Current Temp: " + Utils.ConvertKelvinToCelsius(value.Main.Temp) + "ºC";
            viewHolder.tvMinTemp.Text = "Min Temp: " + Utils.ConvertKelvinToCelsius(value.Main.TempMin) + "ºC";
            viewHolder.tvMaxTemp.Text = "Max Temp: " + Utils.ConvertKelvinToCelsius(value.Main.TempMax) + "ºC";
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            Android.Views.View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.weather_card, parent, false);
            WeatherViewHolder viewHolder = new WeatherViewHolder(view, OnClick);
            return viewHolder;
        }

        public class WeatherViewHolder : RecyclerView.ViewHolder
        {
            public TextView tvCityName { get; set; }
            public TextView tvCountryName { get; set; }
            public TextView tvWeather { get; set; }
            public TextView tvCurrentTemp { get; set; }
            public TextView tvMinTemp { get; set; }
            public TextView tvMaxTemp { get; set; }

            public WeatherViewHolder(Android.Views.View card, Action<int> listener) : base(card)
            {
                tvCityName = card.FindViewById<TextView>(Resource.Id.tv_cityName);
                tvCountryName = card.FindViewById<TextView>(Resource.Id.tv_countryName);
                tvWeather = card.FindViewById<TextView>(Resource.Id.tv_weather);
                tvCurrentTemp = card.FindViewById<TextView>(Resource.Id.tv_currentTemp);
                tvMinTemp = card.FindViewById<TextView>(Resource.Id.tv_minTemp);
                tvMaxTemp = card.FindViewById<TextView>(Resource.Id.tv_maxTemp);
                card.Click += (sender, e) => listener(base.AdapterPosition);
            }
        }

        public void UpdateList(List<ListResponse> newList)
        {
            var oldSize = this.weatherList.Count();
            this.weatherList = newList;
            if (newList.Count() <= oldSize)
            {
                NotifyItemRangeRemoved(0, oldSize);
                NotifyItemRangeInserted(0, newList.Count());
            } else
            {
                NotifyItemRangeChanged(0, this.weatherList.Count());
            }
        }

        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}

