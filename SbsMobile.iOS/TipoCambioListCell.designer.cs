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
	[Register ("TipoCambioListCell")]
	partial class TipoCambioListCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblCompra { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblMoneda { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblVenta { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (lblCompra != null) {
				lblCompra.Dispose ();
				lblCompra = null;
			}
			if (lblMoneda != null) {
				lblMoneda.Dispose ();
				lblMoneda = null;
			}
			if (lblVenta != null) {
				lblVenta.Dispose ();
				lblVenta = null;
			}
		}
	}
}
