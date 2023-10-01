using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class TipoMovInventarioConfiguration : IEntityTypeConfiguration<TipoMovInventario>
    {
        public void Configure(EntityTypeBuilder<TipoMovInventario> builder)
        {
            builder.ToTable("tipoMovimientoInventario");

            builder.Property(p => p.Nombre)
            .HasColumnName("nombre")
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(100);
        }
    }
}