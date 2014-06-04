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
	[Register ("LocalesInfoViewController")]
	partial class LocalesInfoViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell InfoViewCell { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView LocalInfoTableView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (InfoViewCell != null) {
				InfoViewCell.Dispose ();
				InfoViewCell = null;
			}
			if (LocalInfoTableView != null) {
				LocalInfoTableView.Dispose ();
				LocalInfoTableView = null;
			}
		}
	}
}
