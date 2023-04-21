using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using CommunityToolkit.Mvvm.Messaging.Messages;
using SharedCode.Models;

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

