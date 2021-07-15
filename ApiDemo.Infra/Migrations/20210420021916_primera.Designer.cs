﻿// <auto-generated />
using System;
using ApiDemo.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiDemo.Infra.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210420021916_primera")]
    partial class primera
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiDemo.Domain.Model.ClienteAggregate.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroCelular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTelefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Vigente")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Cliente", "dbo");
                });

            modelBuilder.Entity("ApiDemo.Domain.Model.ClienteAggregate.TarjetaCredito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FechaExpiracion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroSeguridad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTarjeta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Propietario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TarjetaOfClienteId")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TarjetaOfClienteId")
                        .IsUnique();

                    b.ToTable("TarjetaCredito");
                });

            modelBuilder.Entity("ApiDemo.Domain.Model.ClienteAggregate.Cliente", b =>
                {
                    b.OwnsOne("ApiDemo.Domain.Model.ClienteAggregate.Direccion", "Direccion", b1 =>
                        {
                            b1.Property<int>("ClienteId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Calle")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Ciudad")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("CodigoPostal")
                                .HasColumnType("int");

                            b1.Property<string>("Numero")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Pais")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ClienteId");

                            b1.ToTable("Cliente");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });

                    b.Navigation("Direccion");
                });

            modelBuilder.Entity("ApiDemo.Domain.Model.ClienteAggregate.TarjetaCredito", b =>
                {
                    b.HasOne("ApiDemo.Domain.Model.ClienteAggregate.Cliente", "Cliente")
                        .WithOne("TarjetaCredito")
                        .HasForeignKey("ApiDemo.Domain.Model.ClienteAggregate.TarjetaCredito", "TarjetaOfClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("ApiDemo.Domain.Model.ClienteAggregate.Cliente", b =>
                {
                    b.Navigation("TarjetaCredito");
                });
#pragma warning restore 612, 618
        }
    }
}