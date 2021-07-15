using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemo.Domain.Common
{
    /// <summary>
    /// Clase especializada para entregar las respuestas.
    /// </summary>
    public class Respuesta
    {
        #region Propiedades
        /// <summary>
        /// Propiedad Success.
        /// </summary>
        public string Success{ get; set; }
        /// <summary>
        /// Propiedad Trace.
        /// </summary>
        public string Trace { get; set; }
        /// <summary>
        /// Propiedad Resultado.
        /// </summary>
        public Object Resultado { get; set; }
        /// <summary>
        /// Propiedad Lista de Errores.
        /// </summary>
        public IList<Error> Errores { get; set; }
        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        public Respuesta()
        {
            this.Errores = new List<Error>();
        }


    }
}
