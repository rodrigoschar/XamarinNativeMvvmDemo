using System;
using AndroidMVVM.Views;
using AndroidX.AppCompat.App;
using SharedCode.Interfaces;
using SharedCode.Models;
using Xamarin.Essentials;

namespace AndroidMVVM.Navigation
{
	public class NavigationService : INavigationService
	{
        private AndroidX.Fragment.App.Fragment currentFragment;

        public void ShowDetails(ListResponse selected)
        {
            CityWeatherDetailFragment detailFragment = new CityWeatherDetailFragment();
            detailFragment.selected = selected;

            var appCompatActivity = Platform.CurrentActivity as AppCompatActivity;
            var fragmentTransaction = appCompatActivity?.SupportFragmentManager.BeginTransaction();
            fragmentTransaction.Hide(currentFragment);
            fragmentTransaction.Add(Resource.Id.fragmentContainer, detailFragment, "CityWeatherDetailFragment");
            fragmentTransaction.AddToBackStack("CityWeatherDetailFragment");
            fragmentTransaction.Commit();
            currentFragment = detailFragment;
        }

        public void StartNavigation()
        {
            SearchCityWeatherFragment mainFragment = new SearchCityWeatherFragment();
            currentFragment = mainFragment;
            var appCompatActivity = Platform.CurrentActivity as AppCompatActivity;
            var fragmentTransaction = appCompatActivity?.SupportFragmentManager.BeginTransaction();
            fragmentTransaction.Add(Resource.Id.fragmentContainer, mainFragment, "SearchCityWeatherFragment");
            fragmentTransaction.Commit();
        }
    }
}

