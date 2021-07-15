using ApiDemo.Domain.Model.ClienteAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemo.Infra.Repositories
{
    /// <summary>
    /// Clase Repositorio de Tarjeta de Credito.
    /// </summary>
    public class TarjetaCreditoRepository
    {
        private readonly DatabaseContext _db;
        private readonly DbSet<TarjetaCredito> _dbSet;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context">Recibe el contexto.</param>
        public TarjetaCreditoRepository(DatabaseContext context)
        {
            _db = context;
            _dbSet = _db.Set<TarjetaCredito>();
        }

        /// <summary>
        /// Metodo para actualizar la tarjeta de credito.
        /// </summary>
        /// <param name="tarjeta">Recibe la tarjeta</param>
        public void Update(TarjetaCredito tarjeta)
        {
            _db.Entry(tarjeta).State = EntityState.Modified;
            _dbSet.Update(tarjeta);
        }
    }
}
