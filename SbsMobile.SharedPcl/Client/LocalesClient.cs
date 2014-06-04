using System;
using System.Collections.Generic;

namespace SbsMobile.SharedPcl
{
	public class LocalesClient
	{
		public LocalesClient ()
		{

		}
		public List<Local> GetLocales()
		{
			var local1 = new Local {
				Nombre = "Sede Principal",
				Titulo = "Sede Principal",
				Direccion = "Calle Los Laureles 214",
				Distrito = "San Isidro",
				Telefonos = new List<Telefono> {
					new Telefono { Nombre = "Principal", Numero = "(01)630-9000" },
					new Telefono { Nombre = "Fax", Numero = "(01)630-9239" }
				}
			};
			var local2 = new Local {
				Nombre = "Plataforma de Atención al Usuario",
				Titulo = "Plataforma de Atención al Usuario",
				Direccion = "Jr. Junìn 270",
				Distrito = "Cercado de Lima",
				Telefonos = new List<Telefono> {
					new Telefono { Nombre = "Central", Numero = "(01)630-9005" },
					new Telefono { Nombre = "Teléfono", Numero = "(01)428-0555" },
					new Telefono { Nombre = "Lìnea gratuita", Numero = "0800-10840" }
				}
			};
			var local3 = new Local {
				Nombre = "Oficina Arequipa",
				Titulo = "Oficina Descentralizada de Arequipa",
				Direccion = "Calle Los Arces Nº 302",
				Distrito = "Cayma",
				Referencia = "Calle diagonal entre Av. Ejercito y Av. Trinidad Morán",
				Telefonos = new List<Telefono> {
					new Telefono { Nombre = "Central", Numero = "(01)630-9000" },
					new Telefono { Nombre = "Oficina", Numero = "(054)272-990" },
					new Telefono { Nombre = "Fax", Numero = "(01)630-9237" }
				}
			};
			var lista = new List<Local> ();
			lista.Add (local1);
			lista.Add (local2);
			lista.Add (local3);
			return lista;
		}
	}
}

