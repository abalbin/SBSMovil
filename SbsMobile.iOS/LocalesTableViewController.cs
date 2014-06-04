using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using SbsMobile.SharedPcl;
using System.Collections.Generic;

namespace SbsMobile.iOS
{
	partial class LocalesTableViewController : UITableViewController
	{
		List<Local> _listaLocales;
		public LocalesTableViewController (IntPtr handle) : base (handle)
		{
		}

		void GetLocales()
		{
			var client = new LocalesClient ();
			_listaLocales = client.GetLocales ();
			LocalesTableView.Source = new LocalesSource (_listaLocales);
			LocalesTableView.ReloadData ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			GetLocales ();
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier.Equals ("LocalInfoSegue")) {
				var navCtrl = segue.DestinationViewController as LocalesInfoViewController;
				if (navCtrl != null) {
					var source = LocalesTableView.Source as LocalesSource;
					var rowPath = LocalesTableView.IndexPathForSelectedRow;
					var item = source.GetItem (rowPath.Row);
					navCtrl.SetLocal (item);
				}
			}
		}
	}
}
