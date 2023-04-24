using CommunityToolkit.Mvvm.DependencyInjection;
using CoreAudioKit;
using CoreGraphics;
using Foundation;
using iOSMVVM.Controllers;
using iOSMVVM.ViewModels;
using iOSMVVM.Views.Cells;
using SharedCode.Models;
using SharedCode.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace iOSMVVM
{
    public partial class ViewController : UIViewController
    {
        public SearchWeatherViewModel viewModel;
        private List<ListResponse> weatherList = new List<ListResponse>();

        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            viewModel = Ioc.Default.GetRequiredService<SearchWeatherViewModel>();

            weatherTableView.RegisterNibForCellReuse(WeatherTableViewCell.Nib, WeatherTableViewCell.Key);
            weatherTableView.Source = new WeatherTableViewSource(this);
            searchWeatherSearchBar.Delegate = new WeatherViewControllerSearchBarDelegate(this);
            loadingActivityIndicator.Hidden = true;

            viewModel.weatherResponses.CollectionChanged += (s, e) => UpdatedCollectionProp();
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
        }

        private void UpdatedCollectionProp()
        {
            if (viewModel.weatherResponses != null)
            {
                weatherList = viewModel.weatherResponses.ToList();
                loadingActivityIndicator.StopAnimating();
                loadingActivityIndicator.Hidden = true;
                weatherTableView.ReloadData();
                UIApplication.SharedApplication.KeyWindow.EndEditing(true);
            }
        }

        public class WeatherTableViewSource : UITableViewSource
        {
            ViewController viewController;

            public WeatherTableViewSource(ViewController viewController)
            {
                this.viewController = viewController;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                WeatherTableViewCell cell = (WeatherTableViewCell)tableView.DequeueReusableCell(WeatherTableViewCell.Key, indexPath);
                var data = viewController.weatherList[indexPath.Row];
                cell.Data = data;
                return cell;
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                var selected = viewController.weatherList[indexPath.Row];
                viewController.viewModel.GoToDetailView(selected);
                tableView.DeselectRow(indexPath, true);
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
