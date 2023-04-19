// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace iOSMVVM
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIActivityIndicatorView loadingActivityIndicator { get; set; }

		[Outlet]
		UIKit.UISearchBar searchWeatherSearchBar { get; set; }

		[Outlet]
		UIKit.UITableView weatherTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (searchWeatherSearchBar != null) {
				searchWeatherSearchBar.Dispose ();
				searchWeatherSearchBar = null;
			}

			if (weatherTableView != null) {
				weatherTableView.Dispose ();
				weatherTableView = null;
			}

			if (loadingActivityIndicator != null) {
				loadingActivityIndicator.Dispose ();
				loadingActivityIndicator = null;
			}
		}
	}
}
