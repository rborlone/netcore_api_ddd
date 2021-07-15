using ApiDemo.Domain.Model.ClienteAggregate;
using ApiDemo.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ApiDemo.Infra
{
    /// <summary>
    /// Clase Contexto de Base de Datos.
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Propiedad publica para definir el esquema por defecto es dbo.
        /// </summary>
        public const string DEFAULT_SCHEMA = "dbo";

        

        /// <summary>
        /// Constructor de Clase.
        /// </summary>
        public DatabaseContext(){}

        /// <summary>
        /// Aca almacenamos las propiedades DbSet.
        /// </summary>
        #region "Propiedades DbSet"
            public DbSet<Cliente> Cliente { get; set; }
            public DbSet<TarjetaCredito> TarjetaCredito { get; set; }
        #endregion

        /// <summary>
        /// Metodo que Sobreescribe a la clase base al generar el modelo y aplica los mappings.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Agregar lista de Mapping correspondiente para las tablas.

            modelBuilder.ApplyConfiguration(new ClienteMap());
        }

        /// <summary>
        /// Metodo que Sobreescribe a la clase basse para configurar el contexto y la configuración correspondiente al ConnectionString.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
