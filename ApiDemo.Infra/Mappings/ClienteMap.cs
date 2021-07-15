using ApiDemo.Domain.Model.ClienteAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemo.Infra.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente", DatabaseContext.DEFAULT_SCHEMA);

            builder.OwnsOne(customer => customer.Direccion);


            builder
                .HasOne<TarjetaCredito>(cliente => cliente.TarjetaCredito)
                .WithOne(tarjeta => tarjeta.Cliente)
                .HasForeignKey<TarjetaCredito>(tar => tar.TarjetaOfClienteId);

        }
    }
}