using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 

namespace Persistencia.Data.Configuration
{
    public class ContactoPersonaConfiguration : IEntityTypeConfiguration<ContactoPersona>
    {
        public void Configure(EntityTypeBuilder<ContactoPersona> builder)
        {
            builder.ToTable("contactoPersona");

            builder.Property(p => p.Nombre)
            .HasColumnName("Nombre")
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(p => p.Numero)
            .HasColumnName("numero")
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(30);

            builder.HasOne(p => p.Persona)
            .WithMany(p => p.ContactoPersonas)
            .HasForeignKey( p => p.IdPersonaFk);

            builder.HasOne(p => p.TipoContacto)
            .WithMany(p => p.ContactosPersonas)
            .HasForeignKey(p => p.IdTipoContactoFk);
        }
    }


}