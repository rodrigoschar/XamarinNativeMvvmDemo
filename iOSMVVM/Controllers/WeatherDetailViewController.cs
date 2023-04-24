using System;
using System.Linq;
using CommunityToolkit.Mvvm.DependencyInjection;
using Foundation;
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
        }

        private void SetupView(object sender, EventArgs eventArgs)
        {
            if (viewModel.WeatherResponse != null)
            {
                cityNameLabel.Text = "City Name: " + viewModel.WeatherResponse.Name;
                weatherLabel.Text = "Weather: " + viewModel.WeatherResponse.Weather.FirstOrDefault().Main + ", " + viewModel.WeatherResponse.Weather.FirstOrDefault().Description;
                currentTemp.Text = "Current Temp: " + SharedCode.Utils.Utils.ConvertKelvinToCelsius(viewModel.WeatherResponse.Main.Temp) + "ºC";
                minTemp.Text = "Min Temp: " + SharedCode.Utils.Utils.ConvertKelvinToCelsius(viewModel.WeatherResponse.Main.TempMin) + "ºC";
                maxTemp.Text = "Max Temp: " + SharedCode.Utils.Utils.ConvertKelvinToCelsius(viewModel.WeatherResponse.Main.TempMax) + "ºC";
            }

            if (viewModel.ImageBytes != null)
            {
                weatherImageView.Image = UIImage.LoadFromData(NSData.FromArray(viewModel.ImageBytes));
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}


