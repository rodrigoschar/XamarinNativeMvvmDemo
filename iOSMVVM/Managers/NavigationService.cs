using System;
using Foundation;
using iOSMVVM.Controllers;
using NewSingleViewTemplate;
using SharedCode.Models;
using UIKit;

namespace iOSMVVM.Managers
{
    public interface INavigationService
    {
        void GoToWeatherDetail(ListResponse selectedItem, ViewController viewController);
    }

    public class NavigationService : INavigationService
	{
		public NavigationService()
		{
		}

        public void GoToWeatherDetail(ListResponse selectedItem, ViewController viewController)
        {
            WeatherDetailViewController detailViewController = viewController.Storyboard.InstantiateViewController("WeatherDetailViewController") as WeatherDetailViewController;
            if (detailViewController != null)
            {
                detailViewController.selected = selectedItem;
                viewController.NavigationController.PushViewController(detailViewController, true);
            }
        }
    }
}

