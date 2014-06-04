using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using SbsMobile.SharedPcl;

namespace SbsMobile.iOS
{
	partial class LocalesInfoViewController : UITableViewController
	{
		Local _local;
		public LocalesInfoViewController (IntPtr handle) : base (handle)
		{
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = base.GetCell (tableView, indexPath);
			return cell;
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			LocalInfoTableView.Source = new LocalesInfoSource (_local);
			LocalInfoTableView.ReloadData ();

		}

		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			if (indexPath.Section.Equals (1) && indexPath.Row.Equals (0)) {
				return 300; // para setear el alto de la fila
			}
			return base.GetHeightForRow (tableView, indexPath);
		}

		public void SetLocal(Local item)
		{
			_local = item;
		}
	}
}
