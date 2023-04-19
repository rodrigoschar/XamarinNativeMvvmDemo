using CommunityToolkit.Mvvm.DependencyInjection;
using CoreAudioKit;
using Foundation;
using iOSMVVM.ViewModels;
using iOSMVVM.Views.Cells;
using SharedCode.Models;
using System;
using System.Collections.Generic;
using UIKit;

namespace iOSMVVM
{
    public partial class ViewController : UIViewController
    {
        public SearchCityViewModel viewModel;
        private List<ListResponse> weatherList = new List<ListResponse>();

        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            viewModel = Ioc.Default.GetRequiredService<SearchCityViewModel>();

            weatherTableView.RegisterNibForCellReuse(WeatherTableViewCell.Nib, WeatherTableViewCell.Key);
            weatherTableView.DataSource = new WeatherTableViewSource(this);
            searchWeatherSearchBar.Delegate = new WeatherViewControllerSearchBarDelegate(this);

            viewModel.PropertyChanged += UpdateProperties;
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
        }

        private void UpdateProperties(object sender, EventArgs eventArgs)
        {
            var propWeatherList = sender.GetType().GetProperty("WeatherList");

            if (viewModel.WeatherList != null) // propWeatherList != null && 
            {
                loadingActivityIndicator.StopAnimating();
                loadingActivityIndicator.Hidden = true;
                weatherList = viewModel.WeatherList;
                weatherTableView.ReloadData();
                UIApplication.SharedApplication.KeyWindow.EndEditing(true);
            }
        }

        public class WeatherTableViewSource : UITableViewDataSource
        {
            ViewController viewController;
            public WeatherTableViewSource(ViewController owner)
            {
                this.viewController = owner;
            }
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                WeatherTableViewCell cell = (WeatherTableViewCell)tableView.DequeueReusableCell(WeatherTableViewCell.Key, indexPath);
                var data = viewController.weatherList[indexPath.Row];
                cell.Data = data;
                return cell;
            }
            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return viewController.weatherList.Count;
            }
        }

        public class WeatherViewControllerSearchBarDelegate : UISearchBarDelegate
        {
            ViewController viewController;

            public WeatherViewControllerSearchBarDelegate(ViewController viewController)
            {
                this.viewController = viewController;
            }

            public override void SearchButtonClicked(UISearchBar searchBar)
            {
                var text = searchBar.Text;
                if (text != "")
                {
                    viewController.loadingActivityIndicator.Hidden = false;
                    viewController.loadingActivityIndicator.StartAnimating();
                    viewController.viewModel.GetWeatherByCityName(text);
                }
            }

            public override void CancelButtonClicked(UISearchBar searchBar)
            {
                searchBar.Text = "";
                UIApplication.SharedApplication.KeyWindow.EndEditing(true);
            }
        }
    }
}
