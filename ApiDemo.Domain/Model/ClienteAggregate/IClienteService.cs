using System.Collections.Generic;

namespace ApiDemo.Domain.Model.ClienteAggregate
{
    /// <summary>
    /// Interfaz de Tipo Servicio Cliente.
    /// </summary>
    public interface IClienteService
    {
        /// <summary>
        /// Metodo para Agregar un cliente.
        /// </summary>
        /// <param name="cliente">Recibe la entidad Cliente.</param>
        void Add(Cliente cliente);

        /// <summary>
        /// Metodo para obtener el cliente por id.
        /// </summary>
        /// <param name="id">Recibe el id.</param>
        /// <returns>Retorna una entidad cliente.</returns>
        Cliente GetByID(int id);
        
        /// <summary>
        /// Metodo para Obtener una lista de clientes.
        /// </summary>
        /// <returns></returns>
        IList<Cliente> GetAll();

        /// <summary>
        /// Metodo para actualizar un cliente.
        /// </summary>
        /// <param name="cliente">Recibe el cliente.</param>
        void Update(Cliente cliente);

        /// <summary>
        /// Metodo para eliminar un cliente.
        /// </summary>
        /// <param name="cliente">Recibe el cliente.</param>
        void Remove(Cliente cliente);
    }
}
