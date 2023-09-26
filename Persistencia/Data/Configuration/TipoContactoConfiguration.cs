using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class TipoContactoConfiguration : IEntityTypeConfiguration<TipoContacto>
    {
        public void Configure(EntityTypeBuilder<TipoContacto> builder)
        {
            builder.ToTable("TipoContacto");

            builder.Property(n => n.Nombre)
            .HasColumnName("Nombre")
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(100);
        }
    }
}