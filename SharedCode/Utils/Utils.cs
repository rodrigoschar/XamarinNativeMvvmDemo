using System;
namespace SharedCode.Utils
{
	public static class Utils
	{
		public static int ConvertKelvinToCelsius(double kelvin)
		{
			var result = kelvin - 273.15;
			var intRes = Convert.ToInt32(result);
			return intRes;
		}
	}
}

