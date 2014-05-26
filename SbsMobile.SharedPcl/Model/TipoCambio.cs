using System;

namespace SbsMobile.SharedPcl
{
    public class TipoCambio
    {
        public Moneda Moneda { get; set; }
        public DateTime Fecha { get; set; }
        public string Compra { get; set; }
        public string Venta { get; set; }
    }
}
