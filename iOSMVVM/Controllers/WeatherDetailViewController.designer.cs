// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace iOSMVVM.Controllers
{
	[Register ("WeatherDetailViewController")]
	partial class WeatherDetailViewController
	{
		[Outlet]
		UIKit.UILabel cityNameLabel { get; set; }

		[Outlet]
		UIKit.UILabel cloudsCoverageLabel { get; set; }

		[Outlet]
		UIKit.UILabel currentTemp { get; set; }

		[Outlet]
		UIKit.UIButton gotoMapsButton { get; set; }

		[Outlet]
		UIKit.UILabel latLabel { get; set; }

		[Outlet]
		UIKit.UILabel lonLabel { get; set; }

		[Outlet]
		UIKit.UIView mapView { get; set; }

		[Outlet]
		UIKit.UILabel maxTemp { get; set; }

		[Outlet]
		UIKit.UILabel minTemp { get; set; }

		[Outlet]
		UIKit.UIImageView weatherImageView { get; set; }

		[Outlet]
		UIKit.UILabel weatherLabel { get; set; }

		[Outlet]
		UIKit.UILabel windSpeedLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (cityNameLabel != null) {
				cityNameLabel.Dispose ();
				cityNameLabel = null;
			}

			if (cloudsCoverageLabel != null) {
				cloudsCoverageLabel.Dispose ();
				cloudsCoverageLabel = null;
			}

			if (currentTemp != null) {
				currentTemp.Dispose ();
				currentTemp = null;
			}

			if (latLabel != null) {
				latLabel.Dispose ();
				latLabel = null;
			}

			if (lonLabel != null) {
				lonLabel.Dispose ();
				lonLabel = null;
			}

			if (mapView != null) {
				mapView.Dispose ();
				mapView = null;
			}

			if (maxTemp != null) {
				maxTemp.Dispose ();
				maxTemp = null;
			}

			if (minTemp != null) {
				minTemp.Dispose ();
				minTemp = null;
			}

			if (weatherImageView != null) {
				weatherImageView.Dispose ();
				weatherImageView = null;
			}

			if (weatherLabel != null) {
				weatherLabel.Dispose ();
				weatherLabel = null;
			}

			if (windSpeedLabel != null) {
				windSpeedLabel.Dispose ();
				windSpeedLabel = null;
			}

			if (gotoMapsButton != null) {
				gotoMapsButton.Dispose ();
				gotoMapsButton = null;
			}
		}
	}
}
