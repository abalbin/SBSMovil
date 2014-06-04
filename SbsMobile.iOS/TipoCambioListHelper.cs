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

//	public class TipoCambioListCell : UITableViewCell
//	{
//		public const string CellId = "TipoCambioListCell";
//		TipoCambio _tipoCambio;
//
//		UILabel monedaLabel, compraLabel, ventaLabel;
//
//		public TipoCambio TipoCambio {
//			get { return _tipoCambio; }
//			set {
//				_tipoCambio = value;
//
//				monedaLabel.Text = _tipoCambio.Moneda.Descripcion;
////				compraLabel.Text = _tipoCambio.Compra;
////				ventaLabel.Text = _tipoCambio.Venta;
//			}
//		}
//
//		public TipoCambioListCell ()
//		{
//			SelectionStyle = UITableViewCellSelectionStyle.None;
//
////			monedaLabel = new UILabel {
////				TextColor = UIColor.Black,
////				TextAlignment = UITextAlignment.Left,
////				Font = UIFont.FromName ("HelveticaNeue-Light", 22),
////				//ShadowColor = UIColor.DarkGray,
////				//ShadowOffset = new System.Drawing.SizeF(.5f,.5f),
////				Layer = {
////					ShadowRadius = 3,
////					ShadowColor = UIColor.Black.CGColor,
////					ShadowOpacity = .5f,
////				}
////			};
//			monedaLabel = new UILabel {
//
//			};
//
////			compraLabel = new UILabel {
////				TextColor = UIColor.Black,
////				TextAlignment = UITextAlignment.Left,
////				Font = UIFont.FromName ("HelveticaNeue-Light", 22),
////				//ShadowColor = UIColor.DarkGray,
////				//ShadowOffset = new System.Drawing.SizeF(.5f,.5f),
////				Layer = {
////					ShadowRadius = 3,
////					ShadowColor = UIColor.Black.CGColor,
////					ShadowOffset = new System.Drawing.SizeF(0,1f),
////					ShadowOpacity = .5f,
////				}
////			};
////
////			ventaLabel = new UILabel {
////				TextColor = UIColor.Black,
////				TextAlignment = UITextAlignment.Left,
////				Font = UIFont.FromName ("HelveticaNeue-Light", 22),
////				//ShadowColor = UIColor.DarkGray,
////				//ShadowOffset = new System.Drawing.SizeF(.5f,.5f),
////				Layer = {
////					ShadowRadius = 3,
////					ShadowColor = UIColor.Black.CGColor,
////					ShadowOffset = new System.Drawing.SizeF(0,1f),
////					ShadowOpacity = .5f,
////				}
////			};
//
//			ContentView.AddSubviews (monedaLabel);
//		}
//	}
}

