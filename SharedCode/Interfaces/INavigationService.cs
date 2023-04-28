using System;
using SharedCode.Models;
using SharedCode.Utils;

namespace SharedCode.Interfaces
{
	public interface INavigationService
	{
		void StartNavigation();
		void ShowDetails(ListResponse selected);
		void ShowGoogleMpas(ListResponse selected);
    }
}

