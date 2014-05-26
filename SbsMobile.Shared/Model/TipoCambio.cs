using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbsMobile.Shared
{
    public class TipoCambio
    {
        public Moneda Moneda { get; set; }
        public DateTime Fecha { get; set; }
        public string Compra { get; set; }
        public string Venta { get; set; }
    }
}
