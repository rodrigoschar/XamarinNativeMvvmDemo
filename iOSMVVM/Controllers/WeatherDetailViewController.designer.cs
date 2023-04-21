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
		UIKit.UILabel currentTemp { get; set; }

		[Outlet]
		UIKit.UILabel maxTemp { get; set; }

		[Outlet]
		UIKit.UILabel minTemp { get; set; }

		[Outlet]
		UIKit.UIImageView weatherImageView { get; set; }

		[Outlet]
		UIKit.UILabel weatherLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (weatherImageView != null) {
				weatherImageView.Dispose ();
				weatherImageView = null;
			}

			if (cityNameLabel != null) {
				cityNameLabel.Dispose ();
				cityNameLabel = null;
			}

			if (weatherLabel != null) {
				weatherLabel.Dispose ();
				weatherLabel = null;
			}

			if (currentTemp != null) {
				currentTemp.Dispose ();
				currentTemp = null;
			}

			if (minTemp != null) {
				minTemp.Dispose ();
				minTemp = null;
			}

			if (maxTemp != null) {
				maxTemp.Dispose ();
				maxTemp = null;
			}
		}
	}
}
