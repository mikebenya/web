﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using TaskSharpHTTP.Models;
using System;

namespace ProyectoMorenita.Migrations
{
    [DbContext(typeof(MorenitaContext))]
    [Migration("20190716145447_zenky")]
    partial class zenky
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("TaskSharpHTTP.Models.Cliente", b =>
                {
                    b.Property<string>("CLIENTE_ID");

                    b.Property<string>("CLIENTE_APELLIDO1");

                    b.Property<string>("CLIENTE_APELLIDO2");

                    b.Property<string>("CLIENTE_BARRIO");

                    b.Property<string>("CLIENTE_CALLE");

                    b.Property<string>("CLIENTE_CASA");

                    b.Property<string>("CLIENTE_EMAIL");

                    b.Property<DateTime>("CLIENTE_FECHAN");

                    b.Property<string>("CLIENTE_NOMBRE1");

                    b.Property<string>("CLIENTE_NOMBRE2");

                    b.Property<string>("CLIENTE_TELEFONO");

                    b.HasKey("CLIENTE_ID");

                    b.ToTable("CLIENTE");
                });

            modelBuilder.Entity("TaskSharpHTTP.Models.FacturaDetalle", b =>
                {
                    b.Property<string>("DETALLE_ID");

                    b.Property<int>("DETALLE_CANTIDAD");

                    b.Property<DateTime>("DETALLE_FECHA");

                    b.Property<double>("DETALLE_PRECIO");

                    b.Property<double>("DETALLE_SUBTOTAL");

                    b.Property<string>("MAESTRO_ID");

                    b.Property<string>("PRODUCTO_ID");

                    b.HasKey("DETALLE_ID");

                    b.HasIndex("MAESTRO_ID");

                    b.HasIndex("PRODUCTO_ID");

                    b.ToTable("FACTURADETALLE");
                });

            modelBuilder.Entity("TaskSharpHTTP.Models.FacturaMaestro", b =>
                {
                    b.Property<string>("MAESTRO_ID");

                    b.Property<string>("CLIENTE_ID");

                    b.Property<DateTime>("MAESTRO_FECHA");

                    b.Property<double>("MAESTRO_TOTAL");

                    b.Property<string>("VENDEDOR_ID");

                    b.HasKey("MAESTRO_ID");

                    b.HasIndex("CLIENTE_ID");

                    b.HasIndex("VENDEDOR_ID");

                    b.ToTable("FACTURAMAESTRO");
                });

            modelBuilder.Entity("TaskSharpHTTP.Models.Producto", b =>
                {
                    b.Property<string>("PRODUCTO_ID");

                    b.Property<double>("PRODUCTO_COSTO");

                    b.Property<string>("PRODUCTO_DESCRIPCION");

                    b.Property<bool>("PRODUCTO_ESTADO");

                    b.Property<string>("PRODUCTO_IMAGEN");

                    b.Property<double>("PRODUCTO_IVA");

                    b.Property<string>("PRODUCTO_NOMBRE");

                    b.Property<double>("PRODUCTO_PRECIO");

                    b.HasKey("PRODUCTO_ID");

                    b.ToTable("PRODUCTO");
                });

            modelBuilder.Entity("TaskSharpHTTP.Models.Vendedor", b =>
                {
                    b.Property<string>("VENDEDOR_ID");

                    b.Property<string>("VENDEDOR_APELLIDO1_VEN");

                    b.Property<string>("VENDEDOR_APELLIDO2_VEN");

                    b.Property<string>("VENDEDOR_BARRIO_VEN");

                    b.Property<string>("VENDEDOR_CALLE_VEN");

                    b.Property<string>("VENDEDOR_CASA_VEN");

                    b.Property<string>("VENDEDOR_CONTRASENA");

                    b.Property<string>("VENDEDOR_NOMBRE1_VEN");

                    b.Property<string>("VENDEDOR_NOMBRE2_VEN");

                    b.Property<string>("VENDEDOR_TELEFONO_VEN");

                    b.Property<string>("VENDEDOR_USUARIO");

                    b.HasKey("VENDEDOR_ID");

                    b.ToTable("VENDEDOR");
                });

            modelBuilder.Entity("TaskSharpHTTP.Models.FacturaDetalle", b =>
                {
                    b.HasOne("TaskSharpHTTP.Models.FacturaMaestro", "facturaMaestro")
                        .WithMany("facturaDetalles")
                        .HasForeignKey("MAESTRO_ID");

                    b.HasOne("TaskSharpHTTP.Models.Producto", "Producto")
                        .WithMany("facturaDetalles")
                        .HasForeignKey("PRODUCTO_ID");
                });

            modelBuilder.Entity("TaskSharpHTTP.Models.FacturaMaestro", b =>
                {
                    b.HasOne("TaskSharpHTTP.Models.Cliente", "Cliente")
                        .WithMany("facturaMaestros")
                        .HasForeignKey("CLIENTE_ID");

                    b.HasOne("TaskSharpHTTP.Models.Vendedor", "Vendedor")
                        .WithMany("FacturaMaestros")
                        .HasForeignKey("VENDEDOR_ID");
                });
#pragma warning restore 612, 618
        }
    }
}
