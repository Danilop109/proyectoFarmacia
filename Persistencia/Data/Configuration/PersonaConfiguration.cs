using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("persona");

            builder.Property(n => n.Nombre)
            .HasColumnName("Nombre")
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(n => n.Apellido)
            .HasColumnName("Apellido")
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(n => n.Documento)
            .HasColumnName("Documento")
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(10);

            builder.Property(n => n.FechaRegistro)
            .HasColumnName("FechaRegistro")
            .HasColumnType("DateOnly")
            .IsRequired();

            builder.HasOne(t => t.TipoPersona)
            .WithMany(t => t.Personas)
            .HasForeignKey(t => t.IdTipoPersonaFk);

            builder.HasOne(t => t.TipoDocumento)
            .WithMany(t => t.Personas)
            .HasForeignKey(t => t.IdTipoDocumentoFk);

            builder.HasOne(t => t.Rol)
            .WithMany(t => t.Personas)
            .HasForeignKey(t => t.IdRolFk);

            builder
            .HasMany(p => p.Productos)
            .WithMany(t => t.Personas)
            .UsingEntity<ProductoProveedor>(

                j => j
                .HasOne(p => p.Producto)
                .WithMany(p => p.ProductoProveedores)
                .HasForeignKey(p=> p.IdProductoFk),

                j => j
                .HasOne(p => p.Persona)
                .WithMany(p => p.ProductoProveedores)
                .HasForeignKey(p=> p.IdProveedorFk),

                j =>
                {
                    j.ToTable("productoProveedor");
                    j.HasKey(t => new {t.IdProductoFk, t.IdProveedorFk});
                }
            );

            builder.HasOne(u => u.User)
            .WithOne(u => u.Persona)
            .HasForeignKey<User>(u => u.IdPersonaFk);
        }
    }
}