using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class DireccionConfiguration : IEntityTypeConfiguration<Direccion>
    {
        public void Configure(EntityTypeBuilder<Direccion> builder)
        {
            builder.ToTable("direccion");

            builder.Property(p => p.Descripcion)
            .HasColumnName("Descripcion")
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(100);

            builder.HasOne(p => p.Ciudad)
            .WithMany(p => p.Direcciones)
            .HasForeignKey(p => p.IdCiudadFk);

            builder.HasOne(p => p.Persona)
            .WithMany(p => p.Direcciones)
            .HasForeignKey(p => p.IdPersonaFk);


        }
    }
}