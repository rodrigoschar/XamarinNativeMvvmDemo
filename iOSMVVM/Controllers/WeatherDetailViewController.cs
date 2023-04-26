using System;
using System.Linq;
using CommunityToolkit.Mvvm.DependencyInjection;
using Foundation;
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
        }

        private void SetupView(object sender, EventArgs eventArgs)
        {
            if (viewModel.WeatherResponse != null)
            {
                cityNameLabel.Text = Util.Constants.GetLocalizable(Util.Constants.CityLocalizable) + viewModel.WeatherResponse.Name + ", " + viewModel.WeatherResponse.Sys.Country;
                weatherLabel.Text = Util.Constants.GetLocalizable(Util.Constants.WeatherLocalizable) + viewModel.WeatherResponse.Weather.FirstOrDefault().Main + ", " + viewModel.WeatherResponse.Weather.FirstOrDefault().Description;
                if (viewModel.WeatherResponse.Clouds != null)
                    cloudsCoverageLabel.Text = Util.Constants.GetLocalizable(Util.Constants.CloudsCoverageLocalizable) + viewModel.WeatherResponse.Clouds.All + "%";
                windSpeedLabel.Text = Util.Constants.GetLocalizable(Util.Constants.WindSpeedLocalizable) + viewModel.WeatherResponse.wind.Speed + " mph";
                currentTemp.Text = Util.Constants.GetLocalizable(Util.Constants.CurrentTempLocalizable) + Utils.ConvertKelvinToCelsius(viewModel.WeatherResponse.Main.Temp) + "ºC";
                minTemp.Text = Util.Constants.GetLocalizable(Util.Constants.MinTempLocalizable) + Utils.ConvertKelvinToCelsius(viewModel.WeatherResponse.Main.TempMin) + "ºC";
                maxTemp.Text = Util.Constants.GetLocalizable(Util.Constants.MaxTempLocalizable) + Utils.ConvertKelvinToCelsius(viewModel.WeatherResponse.Main.TempMax) + "ºC";
                latLabel.Text = Util.Constants.GetLocalizable(Util.Constants.LatitudeLocalizable) + viewModel.WeatherResponse.Coord.Lat;
                lonLabel.Text = Util.Constants.GetLocalizable(Util.Constants.LongitudLocalizable) + viewModel.WeatherResponse.Coord.Lon;
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


