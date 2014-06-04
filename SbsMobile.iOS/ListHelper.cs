using System;
using MonoTouch.UIKit;
using SbsMobile.SharedPcl;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;

namespace SbsMobile.iOS
{
	public class TipoCambioListViewSource : UITableViewSource
	{
		private List<TipoCambio> TipoCambioList;
		string cellIdentifier = "tipocambiocell";

		public TipoCambioListViewSource (List<TipoCambio> lista)
		{
			TipoCambioList = lista;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return TipoCambioList == null ? 1 : TipoCambioList.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			if (TipoCambioList == null) {
				return new TipoCambioListCell ();
			}
			var cell = tableView.DequeueReusableCell (cellIdentifier) as TipoCambioListCell ?? new TipoCambioListCell ();
			cell.TipoCambio = TipoCambioList [indexPath.Row];
			return cell;
		}
	}

	public class LocalesSource : UITableViewSource
	{
		List<Local> _tableItems;
		string cellIdentifier = "LocalCell";
		public LocalesSource(List<Local> items)
		{
			_tableItems = items;
		}
		public override int RowsInSection(UITableView tableview, int section)
		{
			return _tableItems.Count;
		}

		public Local GetItem(int index)
		{
			return _tableItems [index];
		}

		public override UITableViewCell GetCell(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);

			cell.TextLabel.Text = _tableItems [indexPath.Row].Nombre;
			cell.DetailTextLabel.Text = _tableItems [indexPath.Row].Distrito;

			return cell;
		}
	}

	public class LocalesInfoSource : UITableViewSource
	{
		Local _tableItems;
		string cellIdentifier = "LocalInfoCell";
		public LocalesInfoSource(Local items)
		{
			_tableItems = items;
		}
		public override int RowsInSection(UITableView tableview, int section)
		{
			return _tableItems.Telefonos.Count + 2;
		}

		public override UITableViewCell GetCell(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);

			switch (indexPath.Row) {
			case 0:
				cell.TextLabel.Text = "Dirección";
				cell.DetailTextLabel.Text = _tableItems.Direccion;
				break;
			case 1:
				cell.TextLabel.Text = "Distrito";
				cell.DetailTextLabel.Text = _tableItems.Distrito;
				break;
			default:
				break;
			}
			return cell;
		}
	}
}

