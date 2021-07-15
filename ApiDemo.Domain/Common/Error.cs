using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemo.Domain.Common
{
    /// <summary>
    /// Clase para trabajar los errores.
    /// </summary>
    public class Error
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
