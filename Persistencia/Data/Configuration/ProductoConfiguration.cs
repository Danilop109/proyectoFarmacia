using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto");

            builder.Property(n => n.Nombre)
            .HasColumnName("NombreProducto")
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(n => n.Precio)
            .HasColumnName("Precio")
            .HasColumnType("double")
            .IsRequired();

            builder.Property(n => n.Cantidad)
            .HasColumnName("Cantidad")
            .HasColumnType("int")
            .IsRequired()
            .HasMaxLength(3);

            builder.Property(p => p.FechaCaducidad)
            .HasColumnName("fechaCaducidad")
            .HasColumnType("DateTime")
            .IsRequired();

            builder.HasOne(m => m.Marca)
            .WithMany(m => m.Productos)
            .HasForeignKey(m=> m.IdMarcaFk);

            builder.HasOne(m => m.Inventario)
            .WithMany(m => m.Productos)
            .HasForeignKey(m=> m.IdInventarioFk);

            builder.HasOne(p => p.Persona)
            .WithMany(p => p.Productos)
            .HasForeignKey(p => p.IdPersonaFk);

            

        }
    }
}