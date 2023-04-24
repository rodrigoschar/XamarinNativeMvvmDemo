using System;
using CoreAudioKit;
using Foundation;
using iOSMVVM.Controllers;
using SharedCode.Interfaces;
using SharedCode.Models;
using SharedCode.Utils;
using UIKit;

namespace iOSMVVM.Navigation
{
    public class CustomNavigationController : UINavigationController { }
	public class NavigationService : INavigationService
	{
        public CustomNavigationController navigationController;
		public NavigationService(CustomNavigationController navigationController)
		{
            this.navigationController = navigationController;
		}

        public void ShowDetails(ListResponse selected)
        {
            try
            {
                var vc = UIStoryboard.FromName("Main", null).InstantiateViewController("WeatherDetailViewController") as WeatherDetailViewController;
                vc.selected = selected;
                navigationController.PushViewController(vc, false);
            } catch (Exception e)
            {
                throw e;
            }
        }

        public void StartNavigation()
        {
            try
            {
                var vc = UIStoryboard.FromName("Main", null).InstantiateViewController("ViewController") as ViewController;
                navigationController.PushViewController(vc, false);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

