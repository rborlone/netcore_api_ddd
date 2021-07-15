using ApiDemo.Domain.Common;
using System.Collections.Generic;

namespace ApiDemo.Domain.Model.ClienteAggregate
{
    /// <summary>
    /// Interfaz de tipo Repositorio Cliente.
    /// </summary>
    public interface IClienteRepository : IRepository<Cliente>
	{
        /// <summary>
        /// Metodo para agregar Cliente.
        /// </summary>
        /// <param name="cliente">Recibe el Cliente</param>
        void Add(Cliente cliente);

        /// <summary>
        /// Obtener el id del Cliente.
        /// </summary>
        /// <param name="id">Recibe el id.</param>
        /// <returns>Retorna la entidad de Cliente.</returns>
        Cliente GetByID(int id);

        /// <summary>
        /// Obtener una lista de Clientes.
        /// </summary>
        /// <returns>Retorna una lista de clientes.</returns>
        IList<Cliente> GetAll();

        /// <summary>
        /// Metodo para actualizar un cliente.
        /// </summary>
        /// <param name="cliente">Recibe la entidad Cliente.</param>
        void Update(Cliente cliente);
        
        /// <summary>
        /// Metodo para eliminar un cliente.
        /// </summary>
        /// <param name="cliente">Recibe la entidad cliente.</param>
        void Remove(Cliente cliente);
        
        /// <summary>
        /// Metodo para impactar los cambios.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
