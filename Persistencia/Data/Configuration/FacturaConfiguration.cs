using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.ToTable("factura");

            builder.HasOne(p => p.MovimientoInventario)
            .WithMany(p => p.Facturas)
            .HasForeignKey(p => p.IdMovInventarioFk);

            builder.HasOne(p => p.Producto)
            .WithMany(p => p.Facturas)
            .HasForeignKey(p => p.IdProductoFk);
        }
    }
}