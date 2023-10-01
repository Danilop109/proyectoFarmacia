using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class MedicamentoRecetadoConfiguration : IEntityTypeConfiguration<MedicamentoRecetado>
    {
        public void Configure(EntityTypeBuilder<MedicamentoRecetado> builder)
        {
            builder.ToTable("medicamentoRecetado");

            builder.Property(p => p.NombreMedicamento)
            .HasColumnName("nombreMedicamentoRecetado")
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(200);

            builder.HasOne(p => p.RecetaMedica)
            .WithMany(p => p.MedicamentoRecetados)
            .HasForeignKey(p => p.IdRecetaMedicaFk);

            builder.HasOne(p => p.Inventario)
            .WithMany(p => p.MedicamentoRecetados)
            .HasForeignKey(p => p.IdInventarioFk);
        }
    }
}