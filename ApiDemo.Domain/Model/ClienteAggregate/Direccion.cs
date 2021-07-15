using ApiDemo.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemo.Domain.Model.ClienteAggregate
{
	/// <summary>
	/// Clase Direccion.
	/// </summary>
    public class Direccion 
	{
		/// <summary>
		/// Propiedad Dirección
		/// </summary>
		public string Calle { get; set; }
		
		/// <summary>
		/// Propiedad Número
		/// </summary>
		public string Numero { get; set; }

		/// <summary>
		/// Propiedad Ciudad
		/// </summary>
		public string Ciudad { get; set; }

		/// <summary>
		/// Propiedad Codigo Postal
		/// </summary>
		public int CodigoPostal { get; set; }

		/// <summary>
		/// Propiedad Pais
		/// </summary>
		public string Pais { get; set; }
	}
}
