// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace SbsMobile.iOS
{
	[Register ("TipoCambioViewController")]
	partial class TipoCambioViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UIBarButtonItem bbtnChangeDate { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UINavigationItem nvgTipoCambio { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UITableView TipoCambioTableView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (bbtnChangeDate != null) {
				bbtnChangeDate.Dispose ();
				bbtnChangeDate = null;
			}
			if (nvgTipoCambio != null) {
				nvgTipoCambio.Dispose ();
				nvgTipoCambio = null;
			}
			if (TipoCambioTableView != null) {
				TipoCambioTableView.Dispose ();
				TipoCambioTableView = null;
			}
		}
	}
}
