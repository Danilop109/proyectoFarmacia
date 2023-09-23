using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class DetalleMovInventarioConfiguration : IEntityTypeConfiguration<DetalleMovInventario>
    {
        public void Configure(EntityTypeBuilder<DetalleMovInventario> builder)
        {
            builder.ToTable("DetalleMovInventario");

            builder.Property(p => p.Cantidad)
            .HasColumnName("cantidad")
            .HasColumnType("int")
            .IsRequired()
            .HasMaxLength(100);


            builder.Property(p => p.Precio)
            .HasColumnName("precio")
            .HasColumnType("decimal")
            .IsRequired()
            .HasMaxLength(10000);

            builder.HasOne(p => p.Invintario)
            .WithMany(p => p.DetalleMovInventarios)
            .HasForeignKey(p => p.IdInventarioFk);

            builder.HasOne(p => p.MovimientoInventario)
            .WithMany(p => p.DetalleMovInventarios)
            .HasForeignKey(p => p.IdMovimientoInvFk);
        }
    }
}