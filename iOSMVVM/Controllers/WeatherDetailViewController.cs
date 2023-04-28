using System;
using System.Linq;
using CommunityToolkit.Mvvm.DependencyInjection;
using CoreGraphics;
using Foundation;
using Google.Maps;
using SharedCode.Interfaces;
using SharedCode.Models;
using SharedCode.Utils;
using SharedCode.ViewModels;
using UIKit;
namespace iOSMVVM.Controllers
{
	public partial class WeatherDetailViewController : UIViewController
	{
        private CityWeatherViewModel viewModel;
        public ListResponse selected;

        public WeatherDetailViewController(IntPtr handle) : base(handle)
        {
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad();
            viewModel = Ioc.Default.GetRequiredService<CityWeatherViewModel>();

            viewModel.PropertyChanged += SetupView;
            if (selected != null)
                viewModel.setData(selected);

            gotoMapsButton.TouchUpInside += GoToGoogleMapsClick;
        }

        private void SetupView(object sender, EventArgs eventArgs)
        {
            if (viewModel.WeatherResponse != null)
            {
                cityNameLabel.Text = "CITY: " + viewModel.WeatherResponse.Name + ", " + viewModel.WeatherResponse.Sys.Country;
                weatherLabel.Text = "WEATHER: " + viewModel.WeatherResponse.Weather.FirstOrDefault().Main + ", " + viewModel.WeatherResponse.Weather.FirstOrDefault().Description;
                if (viewModel.WeatherResponse.Clouds != null)
                    cloudsCoverageLabel.Text = "CLOUDS COVERAGE: " + viewModel.WeatherResponse.Clouds.All + "%";
                windSpeedLabel.Text = "WIND SPEED: " + viewModel.WeatherResponse.wind.Speed + " mph";
                currentTemp.Text = "CURRENT TEMP: " + Utils.ConvertKelvinToCelsius(viewModel.WeatherResponse.Main.Temp) + "ºC";
                minTemp.Text = "MIN TEMP: " + Utils.ConvertKelvinToCelsius(viewModel.WeatherResponse.Main.TempMin) + "ºC";
                maxTemp.Text = "MAX TEMP: " + Utils.ConvertKelvinToCelsius(viewModel.WeatherResponse.Main.TempMax) + "ºC";
                latLabel.Text = "LATITUDE: " + viewModel.WeatherResponse.Coord.Lat;
                lonLabel.Text = "LONGITUDE: " + viewModel.WeatherResponse.Coord.Lon;
            }

            if (viewModel.ImageBytes != null)
            {
                weatherImageView.Image = UIImage.LoadFromData(NSData.FromArray(viewModel.ImageBytes));
            }
        }

        private void GoToGoogleMapsClick(object sender, EventArgs e)
        {
            viewModel.GoToGoogleMaps(selected);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}


