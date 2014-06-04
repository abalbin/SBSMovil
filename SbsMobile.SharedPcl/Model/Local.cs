using System;
using System.Collections.Generic;

namespace SbsMobile.SharedPcl
{
	public class Local
	{
		public string Titulo { get; set; }
		public string Nombre { get; set; } 
		public string Direccion { get; set; }
		public string Referencia { get; set; }
		public string Distrito { get; set; }
		public List<Telefono> Telefonos { get; set; }
	}
}

