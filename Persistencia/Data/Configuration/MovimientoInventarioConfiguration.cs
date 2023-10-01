using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class MovimientoInventarioConfiguration : IEntityTypeConfiguration<MovimientoInventario>
    {
        public void Configure(EntityTypeBuilder<MovimientoInventario> builder)
        {
            builder.ToTable("movimientoInventario");


            builder.Property(p => p.FechaMovimiento)
            .HasColumnName("fechaMovimiento")
            .HasColumnType("DateTime")
            .IsRequired();
            

            builder.Property(p => p.FechaVencimiento)
            .HasColumnName("fechaVencimiento")
            .HasColumnType("DateTime")
            .IsRequired();

            builder.HasOne(p => p.TipoMovInventario)
            .WithMany(p => p.MovimientoInventarios)
            .HasForeignKey(p => p.IdTipoMovimientoInventarioFk);

            builder.HasOne(p => p.Vendedor)
            .WithMany(p => p.Vendedores)
            .HasForeignKey(p => p.IdVendedorFk);

            builder.HasOne(p => p.Cliente)
            .WithMany(p => p.Clientes)
            .HasForeignKey(p => p.IdClienteFk);

            builder.HasOne(p => p.Inventario)
            .WithMany(p => p.MovimientoInventarios)
            .HasForeignKey(p => p.IdInventarioFk);

            builder.HasOne(p => p.FormaPago)
            .WithMany(p => p.MovimientoInventarios)
            .HasForeignKey(p => p.IdFormaPagoFk);
        }


    }
}