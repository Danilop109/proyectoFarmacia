using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class PresentacionConfiguration : IEntityTypeConfiguration<Presentacion>
    {
        public void Configure(EntityTypeBuilder<Presentacion> builder)
        {
            builder.ToTable("Presentacion");

            builder.Property(p => p.Descripcion)
            .HasColumnName("Descripcion")
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(100);

        }
    }
}