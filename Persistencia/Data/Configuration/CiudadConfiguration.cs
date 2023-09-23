using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
       builder.ToTable("ciudad");

       builder.Property(p => p.Nombre)
       .HasColumnName("nombre")
       .HasColumnType("varchar")
       .IsRequired()
       .HasMaxLength(100);

       builder.HasOne(p => p.Departamento)
       .WithMany(c => c.Ciudades)
       .HasForeignKey(f => f.IdDepartamentoFk);

    }
}
