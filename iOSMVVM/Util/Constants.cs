using System;
using Foundation;

namespace iOSMVVM.Util
{
	public static class Constants
	{
        public static string SearchLocalizable = "Search";
        public static string CountryLozalizable = "Country";
        public static string CityNameLocalizable = "CityName";
        public static string CityLocalizable = "City";
        public static string WeatherLocalizable = "Weather";
        public static string CloudsCoverageLocalizable = "CloudsCoverage";
        public static string WindSpeedLocalizable = "WindSpeed";
        public static string CurrentTempLocalizable = "CurrentTemp";
        public static string MinTempLocalizable = "MinTemp";
        public static string MaxTempLocalizable = "MaxTemp";
        public static string LatitudeLocalizable = "Latitude";
        public static string LongitudLocalizable = "Longitud";

        public static string GetLocalizable(string key)
        {
            var localizedString = NSBundle.MainBundle.GetLocalizedString(key, null);
            return localizedString;
        }
    }
}

