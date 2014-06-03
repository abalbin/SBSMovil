using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using SbsMobile.SharedPcl;

namespace SbsMobile.iOS
{
    partial class TipoCambioViewController : UITableViewController
    {
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

        public override void LoadView()
        {
            base.LoadView();
            var table = new UITableView(View.Bounds);
            GetTipoCambio(new DateTime(2010, 12, 15), table);
            Add(table);
        }
        private List<TipoCambio> _listaTipoCambio;

        async void GetTipoCambio(DateTime queryDate, UITableView table)
        {
            var client = new TipoCambioClient();
            _listaTipoCambio = await client.GetTipoCambio(new TipoCambio { Fecha = queryDate });
            table.Source = new TableSource(_listaTipoCambio.Select(l => l.Moneda.Descripcion).ToArray());
        }

        async void GetData(DateTime queryDate)
        {
            var client = new TipoCambioClient();
            _listaTipoCambio = await client.GetTipoCambio(new TipoCambio { Fecha = queryDate });
            TableView.Source = new TableSource(_listaTipoCambio.Select(l => l.Moneda.Descripcion).ToArray());
            TableView.ReloadData();
        }

		public TipoCambioViewController(IntPtr handle) : base (handle)
        {
            
        }
        //public TipoCambioViewController()
        //{
        //    GetData(new DateTime(2010, 12, 15));
        //}
    }
}
