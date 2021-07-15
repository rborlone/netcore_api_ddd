using ApiDemo.Domain.Common;
using ApiDemo.Domain.Model.ClienteAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemo.Domain.Model.ClienteAggregate
{
	/// <summary>
	/// Clase Clietne de tipo Entidad e implementa interfaz IAggregateRoot
	/// </summary>
    public class Cliente : Entity, IAggregateRoot
	{
		/// <summary>
		/// Constructor de Clase.
		/// </summary>
		public Cliente(){}

		/// <summary>
		/// Propiedad Nombre.
		/// </summary>
        public string Nombre { get; set; }

		/// <summary>
		/// Propiedad Numero de Telefono.
		/// </summary>
		public string NumeroTelefono { get; set; }

		/// <summary>
		/// Propiedad Numero de Celular.
		/// </summary>
		public string NumeroCelular { get; set; }

		/// <summary>
		/// Propiedad Fecha de Creación.
		/// </summary>
		public DateTime FechaCreacion { get; set; }

		/// <summary>
		/// Propiedad para verificar si esta activo o no.
		/// </summary>
		public bool Vigente { get; set; }

		/// <summary>
		/// Propiedad Direccion esta corresponde a una Entidad Completa que funciona en conjunto al Agregado del Dominio.
		/// </summary>
        public Direccion Direccion { get; set; }

		/// <summary>
		/// Propiedad TarjetaCredito que corresponde a una relacion uno a uno que funciona en conjunto al agregado del Dominio.
		/// </summary>
		public TarjetaCredito TarjetaCredito { get; set; }
	}
}
