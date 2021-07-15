using ApiDemo.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemo.Domain.Model.ClienteAggregate
{
	/// <summary>
	/// Tarjeta de Credito
	/// </summary>
	public class TarjetaCredito 
	{
		/// <summary>
		/// Constructor
		/// </summary>
		#region Propiedades
		
		public int Id { get; set; }
		
		/// <summary>
		/// Tipo de tarjeta de Credito.
		/// </summary>
		public TarjetaCreditoType Tipo { get; set; }

		/// <summary>
		/// Fecha de Expiración
		/// </summary>
		public string FechaExpiracion { get; set; }

		/// <summary>
		/// Nombre del Propietario.
		/// </summary>
		public string Propietario { get; set; }

		/// <summary>
		/// Número de Tarjeta de Credito.
		/// </summary>
		public string NumeroTarjeta { get; set; }

		/// <summary>
		/// Número de Seguridad.
		/// </summary>
		public string NumeroSeguridad { get; set; }

		/// <summary>
		/// Foreign Key de Cliente.
		/// </summary>
		public int TarjetaOfClienteId { get; set; }
		public Cliente Cliente { get; set; }
        #endregion
	}
}
