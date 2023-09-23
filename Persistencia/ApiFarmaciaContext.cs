using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistencia;
    public class ApiFarmaciaContext : DbContext
    {
        public ApiFarmaciaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<ContactoPersona> ContactosPersonas { get; set; }
        public DbSet<Departamento> Departamentos {get; set;}
        public DbSet<DetalleMovInventario> DetalleMovInventarios {get; set;}
        public DbSet<Direccion> Direcciones {get; set;}
        public DbSet<Factura> Facturas {get; set;}
        public DbSet<FormaPago> FormasPagos {get; set;}
        public DbSet<Inventario> Inventarios {get; set;}
        public DbSet<Marca> Marcas {get; set;}
        public DbSet<MedicamentoRecetado> MedicamentoRecetados {get; set;}
        public DbSet<MovimientoInventario> MovimientoInventarios {get; set;}
        public DbSet<Pais> Paises {get; set;}
        public DbSet<Persona> Personas {get; set;}
        public DbSet<Presentacion> Presentaciones {get; set;}
        public DbSet<Producto> Productos {get; set;}
        public DbSet<ProductoProveedor> ProductoProveedores {get; set;}
        public DbSet<RecetaMedica> RecetaMedicas {get; set;}
        public DbSet<Rol> Rols {get; set;}
        public DbSet<TipoContacto> TipoContactos {get; set;}
        public DbSet<TipoDocumento> TipoDocumentos {get; set;}
        public DbSet<TipoMovInventario> TipoMovInventarios {get; set;}
        public DbSet<TipoPersona> TipoPersonas {get; set;}
        public DbSet<User> Users {get; set;}
        public DbSet<UserRol> UserRols {get; set;}
        public DbSet<RefreshToken> RefreshTokens {get; set;}
        public DbSet<MovimientoInventario> ResponsableCollection {get; set;}
        public DbSet<MovimientoInventario> ReceptorCollection {get; set;}
        public DbSet<RecetaMedica> PacienteCollection {get; set;}
        public DbSet<RecetaMedica> DoctorCollection {get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

    