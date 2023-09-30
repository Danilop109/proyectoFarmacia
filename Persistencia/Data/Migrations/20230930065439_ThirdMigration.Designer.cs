﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

#nullable disable

namespace Persistencia.Data.Migrations
{
    [DbContext(typeof(ApiFarmaciaContext))]
    [Migration("20230930065439_ThirdMigration")]
    partial class ThirdMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dominio.Entities.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdDepartamentoFk")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.HasIndex("IdDepartamentoFk");

                    b.ToTable("ciudad", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.ContactoPersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdPersonaFk")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoContactoFk")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombre");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar")
                        .HasColumnName("numero");

                    b.HasKey("Id");

                    b.HasIndex("IdPersonaFk");

                    b.HasIndex("IdTipoContactoFk");

                    b.ToTable("contactoPersona", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdPaisFk")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.HasIndex("IdPaisFk");

                    b.ToTable("departamento", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.DetalleMovInventario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasMaxLength(3)
                        .HasColumnType("int")
                        .HasColumnName("cantidad");

                    b.Property<int>("IdInventarioFk")
                        .HasColumnType("int");

                    b.Property<int>("IdMovimientoInvFk")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("double")
                        .HasColumnName("precio");

                    b.HasKey("Id");

                    b.HasIndex("IdInventarioFk");

                    b.HasIndex("IdMovimientoInvFk");

                    b.ToTable("DetalleMovInventario", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Direccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Descripcion");

                    b.Property<int>("IdCiudadFk")
                        .HasColumnType("int");

                    b.Property<int>("IdPersonaFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCiudadFk");

                    b.HasIndex("IdPersonaFk");

                    b.ToTable("direccion", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.FormaPago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.ToTable("formaPago", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Inventario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdPresentacionFk")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("stock");

                    b.Property<int>("StockMax")
                        .HasColumnType("int")
                        .HasColumnName("stockMax");

                    b.Property<int>("StockMin")
                        .HasColumnType("int")
                        .HasColumnName("stockMin");

                    b.HasKey("Id");

                    b.HasIndex("IdPresentacionFk");

                    b.ToTable("inventario", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("marca", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.MedicamentoRecetado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar")
                        .HasColumnName("descripcion");

                    b.Property<int>("IdInventarioFk")
                        .HasColumnType("int");

                    b.Property<int>("IdRecetaMedicaFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdInventarioFk");

                    b.HasIndex("IdRecetaMedicaFk");

                    b.ToTable("medicamentoRecetado", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.MovimientoInventario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaMovimiento")
                        .HasColumnType("DateTime")
                        .HasColumnName("fechaMovimiento");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("DateTime")
                        .HasColumnName("fechaVencimiento");

                    b.Property<int>("IdFormaPagoFk")
                        .HasColumnType("int");

                    b.Property<int>("IdReceptorFk")
                        .HasColumnType("int");

                    b.Property<int>("IdRecetaMedicaFk")
                        .HasColumnType("int");

                    b.Property<int>("IdResponsableFk")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoMovInventarioFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdFormaPagoFk");

                    b.HasIndex("IdReceptorFk");

                    b.HasIndex("IdRecetaMedicaFk")
                        .IsUnique();

                    b.HasIndex("IdResponsableFk");

                    b.HasIndex("IdTipoMovInventarioFk");

                    b.ToTable("movimientoInventario", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("pais", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Apellido");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar")
                        .HasColumnName("Documento");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("DateTime")
                        .HasColumnName("FechaRegistro");

                    b.Property<int>("IdRolFk")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoDocumentoFk")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoPersonaFk")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("IdRolFk");

                    b.HasIndex("IdTipoDocumentoFk");

                    b.HasIndex("IdTipoPersonaFk");

                    b.ToTable("persona", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Presentacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Descripcion");

                    b.HasKey("Id");

                    b.ToTable("Presentacion", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasMaxLength(3)
                        .HasColumnType("int")
                        .HasColumnName("Cantidad");

                    b.Property<DateTime>("FechaCaducidad")
                        .HasColumnType("DateTime")
                        .HasColumnName("fechaCaducidad");

                    b.Property<int>("IdInventarioFk")
                        .HasColumnType("int");

                    b.Property<int>("IdMarcaFk")
                        .HasColumnType("int");

                    b.Property<int?>("MovimientoInventarioId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("NombreProducto");

                    b.Property<double>("Precio")
                        .HasColumnType("double")
                        .HasColumnName("Precio");

                    b.HasKey("Id");

                    b.HasIndex("IdInventarioFk");

                    b.HasIndex("IdMarcaFk");

                    b.HasIndex("MovimientoInventarioId");

                    b.ToTable("Producto", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.ProductoProveedor", b =>
                {
                    b.Property<int>("IdProductoFk")
                        .HasColumnType("int");

                    b.Property<int>("IdProveedorFk")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("IdProductoFk", "IdProveedorFk");

                    b.HasIndex("IdProveedorFk");

                    b.ToTable("productoProveedor", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.RecetaMedica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar")
                        .HasColumnName("detalle");

                    b.Property<DateTime>("FechaCaducidad")
                        .HasColumnType("DateTime")
                        .HasColumnName("FechaCaducidad");

                    b.Property<DateTime>("FechaEmicion")
                        .HasColumnType("DateTime")
                        .HasColumnName("FechaEmicion");

                    b.Property<int>("IdDoctorFk")
                        .HasColumnType("int");

                    b.Property<int>("IdInventarioFk")
                        .HasColumnType("int");

                    b.Property<int>("IdPacienteFk")
                        .HasColumnType("int");

                    b.Property<int?>("InventarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDoctorFk");

                    b.HasIndex("IdInventarioFk");

                    b.HasIndex("IdPacienteFk");

                    b.HasIndex("InventarioId");

                    b.ToTable("RecetaMedica", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Token")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("refreshToken", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("nombreRol");

                    b.HasKey("Id");

                    b.ToTable("Rol", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.TipoContacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.ToTable("TipoContacto", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.TipoDocumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("tipoDocumento", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.TipoMovInventario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("tipoMovimientoInventario", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.TipoPersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar")
                        .HasColumnName("descripcion");

                    b.HasKey("Id");

                    b.ToTable("tipoPersona", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("email");

                    b.Property<int>("IdPersonaFk")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombreuser");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar")
                        .HasColumnName("Password");

                    b.HasKey("Id");

                    b.HasIndex("IdPersonaFk")
                        .IsUnique();

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.UserRol", b =>
                {
                    b.Property<int>("IdRolFk")
                        .HasColumnType("int");

                    b.Property<int>("IdUserFk")
                        .HasColumnType("int");

                    b.HasKey("IdRolFk", "IdUserFk");

                    b.HasIndex("IdUserFk");

                    b.ToTable("userRol", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Ciudad", b =>
                {
                    b.HasOne("Dominio.Entities.Departamento", "Departamento")
                        .WithMany("Ciudades")
                        .HasForeignKey("IdDepartamentoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("Dominio.Entities.ContactoPersona", b =>
                {
                    b.HasOne("Dominio.Entities.Persona", "Persona")
                        .WithMany("ContactoPersonas")
                        .HasForeignKey("IdPersonaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.TipoContacto", "TipoContacto")
                        .WithMany("ContactoPersonas")
                        .HasForeignKey("IdTipoContactoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");

                    b.Navigation("TipoContacto");
                });

            modelBuilder.Entity("Dominio.Entities.Departamento", b =>
                {
                    b.HasOne("Dominio.Entities.Pais", "Pais")
                        .WithMany("Departamentos")
                        .HasForeignKey("IdPaisFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("Dominio.Entities.DetalleMovInventario", b =>
                {
                    b.HasOne("Dominio.Entities.Inventario", "Invintario")
                        .WithMany("DetalleMovInventarios")
                        .HasForeignKey("IdInventarioFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.MovimientoInventario", "MovimientoInventario")
                        .WithMany("DetalleMovInventarios")
                        .HasForeignKey("IdMovimientoInvFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invintario");

                    b.Navigation("MovimientoInventario");
                });

            modelBuilder.Entity("Dominio.Entities.Direccion", b =>
                {
                    b.HasOne("Dominio.Entities.Ciudad", "Ciudad")
                        .WithMany("Direcciones")
                        .HasForeignKey("IdCiudadFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Persona", "Persona")
                        .WithMany("Direcciones")
                        .HasForeignKey("IdPersonaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudad");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Dominio.Entities.Inventario", b =>
                {
                    b.HasOne("Dominio.Entities.Presentacion", "Presentacion")
                        .WithMany("Inventarios")
                        .HasForeignKey("IdPresentacionFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Presentacion");
                });

            modelBuilder.Entity("Dominio.Entities.MedicamentoRecetado", b =>
                {
                    b.HasOne("Dominio.Entities.Inventario", "Inventario")
                        .WithMany("MedicamentoRecetados")
                        .HasForeignKey("IdInventarioFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.RecetaMedica", "RecetaMedica")
                        .WithMany("MedicamentoRecetados")
                        .HasForeignKey("IdRecetaMedicaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventario");

                    b.Navigation("RecetaMedica");
                });

            modelBuilder.Entity("Dominio.Entities.MovimientoInventario", b =>
                {
                    b.HasOne("Dominio.Entities.FormaPago", "FormaPago")
                        .WithMany("MovimientoInventarios")
                        .HasForeignKey("IdFormaPagoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Persona", "ReceptorFk")
                        .WithMany("ReceptorCollection")
                        .HasForeignKey("IdReceptorFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.RecetaMedica", "RecetaMedica")
                        .WithOne("MovimientoInventario")
                        .HasForeignKey("Dominio.Entities.MovimientoInventario", "IdRecetaMedicaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Persona", "ResponsableFk")
                        .WithMany("ResponsableCollection")
                        .HasForeignKey("IdResponsableFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.TipoMovInventario", "TipoMovInventario")
                        .WithMany("MovimientoInventarios")
                        .HasForeignKey("IdTipoMovInventarioFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FormaPago");

                    b.Navigation("ReceptorFk");

                    b.Navigation("RecetaMedica");

                    b.Navigation("ResponsableFk");

                    b.Navigation("TipoMovInventario");
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.HasOne("Dominio.Entities.Rol", "Rol")
                        .WithMany("Personas")
                        .HasForeignKey("IdRolFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.TipoDocumento", "TipoDocumento")
                        .WithMany("Personas")
                        .HasForeignKey("IdTipoDocumentoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.TipoPersona", "TipoPersona")
                        .WithMany("Personas")
                        .HasForeignKey("IdTipoPersonaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("TipoDocumento");

                    b.Navigation("TipoPersona");
                });

            modelBuilder.Entity("Dominio.Entities.Producto", b =>
                {
                    b.HasOne("Dominio.Entities.Inventario", "Inventario")
                        .WithMany("Productos")
                        .HasForeignKey("IdInventarioFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Marca", "Marca")
                        .WithMany("Productos")
                        .HasForeignKey("IdMarcaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.MovimientoInventario", null)
                        .WithMany("Productos")
                        .HasForeignKey("MovimientoInventarioId");

                    b.Navigation("Inventario");

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("Dominio.Entities.ProductoProveedor", b =>
                {
                    b.HasOne("Dominio.Entities.Producto", "Producto")
                        .WithMany("ProductoProveedores")
                        .HasForeignKey("IdProductoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Persona", "Proveedor")
                        .WithMany("ProductoProveedores")
                        .HasForeignKey("IdProveedorFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Dominio.Entities.RecetaMedica", b =>
                {
                    b.HasOne("Dominio.Entities.Persona", "DoctorFk")
                        .WithMany("DoctorCollection")
                        .HasForeignKey("IdDoctorFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Inventario", "InventarioFk")
                        .WithMany("RecetaMedicas")
                        .HasForeignKey("IdInventarioFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Persona", "PacienteFk")
                        .WithMany("PacienteCollection")
                        .HasForeignKey("IdPacienteFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Inventario", null)
                        .WithMany("RecetaMedica")
                        .HasForeignKey("InventarioId");

                    b.Navigation("DoctorFk");

                    b.Navigation("InventarioFk");

                    b.Navigation("PacienteFk");
                });

            modelBuilder.Entity("Dominio.Entities.RefreshToken", b =>
                {
                    b.HasOne("Dominio.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dominio.Entities.User", b =>
                {
                    b.HasOne("Dominio.Entities.Persona", "Persona")
                        .WithOne("User")
                        .HasForeignKey("Dominio.Entities.User", "IdPersonaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Dominio.Entities.UserRol", b =>
                {
                    b.HasOne("Dominio.Entities.Rol", "Rol")
                        .WithMany("UserRols")
                        .HasForeignKey("IdRolFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.User", "User")
                        .WithMany("UserRols")
                        .HasForeignKey("IdUserFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dominio.Entities.Ciudad", b =>
                {
                    b.Navigation("Direcciones");
                });

            modelBuilder.Entity("Dominio.Entities.Departamento", b =>
                {
                    b.Navigation("Ciudades");
                });

            modelBuilder.Entity("Dominio.Entities.FormaPago", b =>
                {
                    b.Navigation("MovimientoInventarios");
                });

            modelBuilder.Entity("Dominio.Entities.Inventario", b =>
                {
                    b.Navigation("DetalleMovInventarios");

                    b.Navigation("MedicamentoRecetados");

                    b.Navigation("Productos");

                    b.Navigation("RecetaMedica");

                    b.Navigation("RecetaMedicas");
                });

            modelBuilder.Entity("Dominio.Entities.Marca", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Dominio.Entities.MovimientoInventario", b =>
                {
                    b.Navigation("DetalleMovInventarios");

                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Dominio.Entities.Pais", b =>
                {
                    b.Navigation("Departamentos");
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.Navigation("ContactoPersonas");

                    b.Navigation("Direcciones");

                    b.Navigation("DoctorCollection");

                    b.Navigation("PacienteCollection");

                    b.Navigation("ProductoProveedores");

                    b.Navigation("ReceptorCollection");

                    b.Navigation("ResponsableCollection");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dominio.Entities.Presentacion", b =>
                {
                    b.Navigation("Inventarios");
                });

            modelBuilder.Entity("Dominio.Entities.Producto", b =>
                {
                    b.Navigation("ProductoProveedores");
                });

            modelBuilder.Entity("Dominio.Entities.RecetaMedica", b =>
                {
                    b.Navigation("MedicamentoRecetados");

                    b.Navigation("MovimientoInventario");
                });

            modelBuilder.Entity("Dominio.Entities.Rol", b =>
                {
                    b.Navigation("Personas");

                    b.Navigation("UserRols");
                });

            modelBuilder.Entity("Dominio.Entities.TipoContacto", b =>
                {
                    b.Navigation("ContactoPersonas");
                });

            modelBuilder.Entity("Dominio.Entities.TipoDocumento", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Dominio.Entities.TipoMovInventario", b =>
                {
                    b.Navigation("MovimientoInventarios");
                });

            modelBuilder.Entity("Dominio.Entities.TipoPersona", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Dominio.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UserRols");
                });
#pragma warning restore 612, 618
        }
    }
}
