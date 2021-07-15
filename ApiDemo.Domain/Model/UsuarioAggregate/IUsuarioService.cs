using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemo.Domain.Model.UsuarioAggregate
{
    /// <summary>
    /// Interfaz Usuario Service TODO se deben implementar mas metodos correspondiente al agregado de usuario y otros que se iran defininendo.
    /// </summary>
    public interface IUsuarioService
    {
        /// <summary>
        /// Metodo login para loguear un usuario.
        /// </summary>
        /// <param name="usuario">Recibe el usuario.</param>
        /// <param name="keyStr">Recibe el keyString.</param>
        /// <returns></returns>
        public string LoginToken(Usuario usuario, string keyStr);
    }
}
