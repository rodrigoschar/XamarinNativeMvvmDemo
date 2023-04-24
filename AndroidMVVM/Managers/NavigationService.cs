using System;
using AndroidMVVM.Views;
using AndroidX.AppCompat.App;
using SharedCode.Interfaces;
using SharedCode.Models;
using Xamarin.Essentials;

namespace AndroidMVVM.Managers
{
    public class NavigationService : INavigationService
	{
		public NavigationService()
		{
		}

        public void GoToWeatherDetail(ListResponse selectedItem)
        {
            CityWeatherDetailFragment detailFragment = new CityWeatherDetailFragment();
            ListResponse selected = selectedItem;
            detailFragment.selected = selected;

            var appCompatActivity = Platform.CurrentActivity as AppCompatActivity;
            var fragmentTransaction = appCompatActivity?.SupportFragmentManager.BeginTransaction();
            var currentFragment = appCompatActivity?.SupportFragmentManager.FindFragmentByTag("SearchCityWeatherFragment");
            fragmentTransaction.Hide(currentFragment);
            fragmentTransaction.Add(Resource.Id.fragmentContainer, detailFragment, "CityWeatherDetailFragment");
            fragmentTransaction.AddToBackStack("CityWeatherDetailFragment");
            fragmentTransaction.Commit();
        }
    }
}

