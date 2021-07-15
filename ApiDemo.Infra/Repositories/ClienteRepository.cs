using System.Collections.Generic;
using System.Linq;
using ApiDemo.Domain.Model.ClienteAggregate;
using Microsoft.EntityFrameworkCore;

namespace ApiDemo.Infra.Repositories
{
    /// <summary>
    /// Clase Repositorio Cliente implementa interfaz ClienteRepositorio del Dominio.
    /// Clase encargada de guardar y almacenar los datos correspondientes al cliente.
    /// </summary>
    public class ClienteRepository : IClienteRepository
    {
        private readonly DatabaseContext _db;
        private readonly DbSet<Cliente> _dbSet;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Recibe el contexto.</param>
        public ClienteRepository(DatabaseContext context)
        {
            _db = context;
            _dbSet = _db.Set<Cliente>();
        }

        /// <summary>
        /// Metodo para guardar el cliente.
        /// </summary>
        /// <param name="cliente">Recibe el cliente.</param>
        public void Add(Cliente cliente)
        {
            _dbSet.Add(cliente);
        }

        /// <summary>
        /// Metodo para obtener una lista de los clientes.
        /// </summary>
        /// <returns>Retorna una lista de clientes.</returns>
        public IList<Cliente> GetAll()
        {
            return _dbSet.Include("TarjetaCredito").ToList();
        }

        /// <summary>
        /// Metodo para obtener un cliente por Id.
        /// </summary>
        /// <param name="id">Recibe el id del cliente.</param>
        /// <returns>Retorna la entidad correspondiente al cliente.</returns>
        public Cliente GetByID(int id)
        {
            return _dbSet.Include("TarjetaCredito").AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Metodo para eliminar un cliente.
        /// </summary>
        /// <param name="cliente">Recibe el id de cliente.</param>
        public void Remove(Cliente cliente)
        {
            _dbSet.Remove(cliente);
        }

        /// <summary>
        /// Metodo para impactar la base de datos.
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        /// <summary>
        /// Metodo para actualizar un cliente.
        /// </summary>
        /// <param name="cliente">Recibe el cliente.</param>
        public void Update(Cliente cliente)
        {
            _db.Entry(cliente).State = EntityState.Modified;
            _dbSet.Update(cliente);
        }
    }
}
