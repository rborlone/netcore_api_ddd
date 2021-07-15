using System.ComponentModel.DataAnnotations;

namespace ApiDemo.Domain.Common
{
    /// <summary>
    /// Clase comun que se utilizara para heredar en las entidades.
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// Todas las Entidades del dominio tienen un Id.
        /// </summary>
        [Key]
        public int Id { get; protected set; }
    }
}
