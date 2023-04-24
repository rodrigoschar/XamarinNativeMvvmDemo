using System;
using CommunityToolkit.Mvvm.DependencyInjection;
using Foundation;
using iOSMVVM.Controllers;
using iOSMVVM.Utils;
using NewSingleViewTemplate;
using SharedCode.Interfaces;
using SharedCode.Models;
using UIKit;

namespace iOSMVVM.Managers
{
    public class NavigationService : UIViewController, INavigationService
	{
        
        public NavigationService()
        {
            
        }

        public void GoToWeatherDetail(ListResponse selectedItem)
        {
            //WeatherDetailViewController detailViewController = viewController.Storyboard.InstantiateViewController("WeatherDetailViewController") as WeatherDetailViewController;
            //if (detailViewController != null)
            //{  
            //    detailViewController.selected = selectedItem;
            //    viewController.NavigationController.PushViewController(detailViewController, true);
            //}
        }
    }
}

