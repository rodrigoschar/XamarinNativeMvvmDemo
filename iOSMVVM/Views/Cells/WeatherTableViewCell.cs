using System;
using System.Linq;
using Foundation;
using SharedCode.Models;
using SharedCode.Utils;
using UIKit;

namespace iOSMVVM.Views.Cells
{
	public partial class WeatherTableViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("WeatherTableViewCell");
		public static readonly UINib Nib = UINib.FromName("WeatherTableViewCell", NSBundle.MainBundle);

		protected WeatherTableViewCell (IntPtr handle) : base (handle)
		{
			
		}

		public ListResponse Data
		{
			get { return Data; }
			set
			{
				containerView.Layer.CornerRadius = 10;
				containerView.BackgroundColor = UIColor.FromName("backgroundColor").ColorWithAlpha(0.6f);
                cityNameLabel.Text = "City Name: " + value.Name;
                countryLabel.Text = "Country: " + value.Sys.Country;
                weatherLabel.Text = "Weather: " + value.Weather.FirstOrDefault().Main + ", " + value.Weather.FirstOrDefault().Description;
                currentTempLabel.Text = "Current Temp: " + Utils.ConvertKelvinToCelsius(value.Main.Temp) + "ºC";
                minTempLabel.Text = "Min Temp: " + Utils.ConvertKelvinToCelsius(value.Main.TempMin) + "ºC";
                maxTempLabel.Text = "Max Temp: " + Utils.ConvertKelvinToCelsius(value.Main.TempMax) + "ºC";
            }
		}
	}
}
