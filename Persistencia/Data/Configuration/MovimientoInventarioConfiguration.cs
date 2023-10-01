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
        }


    }
}