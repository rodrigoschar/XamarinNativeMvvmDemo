using System;
using SharedCode.Models;

namespace SharedCode.Interfaces
{
	public interface INavigationService
	{
        void GoToWeatherDetail(ListResponse selectedItem);
    }
}

