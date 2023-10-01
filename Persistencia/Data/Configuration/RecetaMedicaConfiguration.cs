using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class RecetaMedicaConfiguration : IEntityTypeConfiguration<RecetaMedica>
    {
        public void Configure(EntityTypeBuilder<RecetaMedica> builder)
        {
            builder.ToTable("RecetaMedica");

            builder.Property(p => p.FechaEmicion)
            .HasColumnName("FechaEmicion")
            .HasColumnType("DateTime")
            .IsRequired();

            builder.Property(p => p.FechaCaducidad)
            .HasColumnName("FechaCaducidad")
            .HasColumnType("DateTime")
            .IsRequired();

            builder.Property(p => p.Detalle)
            .HasColumnName("detalle")
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(256);

            builder.HasOne(p => p.PacienteFk)
            .WithMany(p=> p.PacienteCollection)
            .HasForeignKey(p => p.IdPacienteFk);

             builder.HasOne(p => p.DoctorFk)
            .WithMany(p=> p.DoctorCollection)
            .HasForeignKey(p => p.IdDoctorFk);

            builder.HasOne(mi => mi.MovimientoInventario)
            .WithOne(p => p.RecetaMedica)
            .HasForeignKey<MovimientoInventario>(mi => mi.IdRecetaMedicaFk);

        }
    }
}