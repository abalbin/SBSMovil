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
	[Register ("LocalesTableViewController")]
	partial class LocalesTableViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView LocalesTableView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (LocalesTableView != null) {
				LocalesTableView.Dispose ();
				LocalesTableView = null;
			}
		}
	}
}
