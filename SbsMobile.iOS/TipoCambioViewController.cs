using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using SbsMobile.SharedPcl;
using System.Collections.Generic;
using System.Linq;

namespace SbsMobile.iOS
{
	partial class TipoCambioViewController : UITableViewController
	{
		DateTime _queryDate;
		private List<TipoCambio> _listaTipoCambio;

		public class TableSource : UITableViewSource
		{
			string[] tableItems;
			string cellIdentifier = "TableCell";
			public TableSource(string[] items)
			{
				tableItems = items;
			}
			public override int RowsInSection(UITableView tableview, int section)
			{
				return tableItems.Length;
			}
			public override UITableViewCell GetCell(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
				// if there are no cells to reuse, create a new one
				if (cell == null)
					cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);

				cell.TextLabel.Text = tableItems[indexPath.Row];
				return cell;
			}
		}
			
		public TipoCambioViewController (IntPtr handle) : base (handle)
		{
			_queryDate = new DateTime (2010, 12, 15);
		}

		public override void LoadView()
		{
			base.LoadView();
//			_table = new UITableView(View.Bounds);
//			_queryDate = new DateTime (2010, 12, 15);
//			TableView.Source = _source = new TipoCambioListViewSource ();
//			Add(_table);

		}

		async void GetTipoCambio()
		{
			var client = new TipoCambioClient();
			_listaTipoCambio = await client.GetTipoCambio(new TipoCambio { Fecha = _queryDate });
//			_listaTipoCambio = new List<TipoCambio>{ new TipoCambio{ Moneda = new Moneda{ Descripcion = "asdasd" } } };
//			_source = new TipoCambioListViewSource (_listaTipoCambio);
//			_source.TipoCambioList = _listaTipoCambio;
//			TableView.ReloadData ();
			TipoCambioTableView.Source = new TipoCambioListViewSource (_listaTipoCambio);
//			_table.Source = new TipoCambioListViewSource(_listaTipoCambio);
//			_table.ReloadData ();
			TipoCambioTableView.ReloadData ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			var actionSheet = new ActionSheetDatePicker (this.View);
			actionSheet.DatePicker.Mode = UIDatePickerMode.Date;
			actionSheet.DoneButton.TouchUpInside += (sender, e) => {
				DateTime dt = actionSheet.DatePicker.Date;
				nvgTipoCambio.Title = dt.ToString("dd MMMMM yyyy");
				_queryDate = dt;
				GetTipoCambio();
				actionSheet.Hide(true);
			};
			bbtnChangeDate.Clicked += (sender, e) => {
				actionSheet.DatePicker.SetDate(_queryDate,false);
				actionSheet.Show();
			};

			nvgTipoCambio.Title = _queryDate.ToString("dd MMMMM yyyy");
			GetTipoCambio();
		}
	}
}
