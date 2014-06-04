using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using SbsMobile.SharedPcl;

namespace SbsMobile.iOS
{
	partial class TipoCambioListCell : UITableViewCell
	{
		private TipoCambio _tipoCambio;
		public TipoCambio TipoCambio{
			get{return _tipoCambio;}
			set{
				_tipoCambio = value;
				lblMoneda.Text = _tipoCambio.Moneda.Descripcion;
				lblCompra.Text = _tipoCambio.Compra;
				lblVenta.Text = _tipoCambio.Venta;
			}
		}
		public TipoCambioListCell () : base()
		{
		}
		public TipoCambioListCell (IntPtr handle) : base (handle)
		{
		}
	}
}
