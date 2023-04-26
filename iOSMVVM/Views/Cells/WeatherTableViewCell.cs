using System;
using System.Linq;
using Foundation;
using SharedCode.Models;
using SharedCode.Utils;
using iOSMVVM.Util;
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
                cityNameLabel.Text = Util.Constants.GetLocalizable(Util.Constants.CityNameLocalizable) + value.Name;
                countryLabel.Text = Util.Constants.GetLocalizable(Util.Constants.CountryLozalizable) + value.Sys.Country;
                weatherLabel.Text = Util.Constants.GetLocalizable(Util.Constants.WeatherLocalizable) + value.Weather.FirstOrDefault().Main + ", " + value.Weather.FirstOrDefault().Description;
                currentTempLabel.Text = Util.Constants.GetLocalizable(Util.Constants.CurrentTempLocalizable) + Utils.ConvertKelvinToCelsius(value.Main.Temp) + "ºC";
                minTempLabel.Text = Util.Constants.GetLocalizable(Util.Constants.MinTempLocalizable) + Utils.ConvertKelvinToCelsius(value.Main.TempMin) + "ºC";
                maxTempLabel.Text = Util.Constants.GetLocalizable(Util.Constants.MaxTempLocalizable) + Utils.ConvertKelvinToCelsius(value.Main.TempMax) + "ºC";
            }
		}
	}
}
