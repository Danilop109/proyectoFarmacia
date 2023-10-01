

using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class ProductoProveedorConfiguration : IEntityTypeConfiguration<ProductoProveedor>
    {
        public void Configure(EntityTypeBuilder<ProductoProveedor> builder)
        {
            builder.ToTable("productoProveedor");

            builder.HasOne(p => p.Persona)
            .WithMany(p => p.ProductoProveedores)
            .HasForeignKey(p => p.IdPersonaFk);

            builder.HasOne(p => p.Producto)
            .WithMany(p => p.ProductoProveedores)
            .HasForeignKey(p => p.IdProductoFk);
        }
    }
}