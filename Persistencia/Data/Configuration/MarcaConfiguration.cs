using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class MarcaConfiguration : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.ToTable("marca");

            builder.Property(p => p.Nombre)
            .HasColumnName("nombre")
            .HasColumnType("string")
            .IsRequired()
            .HasMaxLength(100);

            
        }
    }
}