using ApiDemo.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemo.Domain.Model.UsuarioAggregate
{
    /// <summary>
    /// Clase Usuario Raiz de Agregado.
    /// Esta clase puede ser cambiada se debe verificar que validacion se utilizara.
    /// </summary>
    public class Usuario : Entity, IAggregateRoot
    {
        /// <summary>
        /// Constructor de Clase.
        /// </summary>
        public Usuario(){ }

        /// <summary>
        /// Propiedad Nombre
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Propiedad Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Propiedad User Id
        /// </summary>
        public string UserId { get; set; }
    }
}
