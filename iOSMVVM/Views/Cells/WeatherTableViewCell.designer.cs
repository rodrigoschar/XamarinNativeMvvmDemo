// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace iOSMVVM.Views.Cells
{
	[Register ("WeatherTableViewCell")]
	partial class WeatherTableViewCell
	{
		[Outlet]
		UIKit.UILabel cityNameLabel { get; set; }

		[Outlet]
		UIKit.UIView containerView { get; set; }

		[Outlet]
		UIKit.UILabel countryLabel { get; set; }

		[Outlet]
		UIKit.UILabel currentTempLabel { get; set; }

		[Outlet]
		UIKit.UILabel maxTempLabel { get; set; }

		[Outlet]
		UIKit.UILabel minTempLabel { get; set; }

		[Outlet]
		UIKit.UILabel weatherLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (containerView != null) {
				containerView.Dispose ();
				containerView = null;
			}

			if (cityNameLabel != null) {
				cityNameLabel.Dispose ();
				cityNameLabel = null;
			}

			if (countryLabel != null) {
				countryLabel.Dispose ();
				countryLabel = null;
			}

			if (weatherLabel != null) {
				weatherLabel.Dispose ();
				weatherLabel = null;
			}

			if (currentTempLabel != null) {
				currentTempLabel.Dispose ();
				currentTempLabel = null;
			}

			if (minTempLabel != null) {
				minTempLabel.Dispose ();
				minTempLabel = null;
			}

			if (maxTempLabel != null) {
				maxTempLabel.Dispose ();
				maxTempLabel = null;
			}
		}
	}
}
