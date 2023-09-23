using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class MovimientoInventarioConfiguration : IEntityTypeConfiguration<MovimientoInventario>
    {
        public void Configure(EntityTypeBuilder<MovimientoInventario> builder)
        {
            builder.ToTable("movimientoInventario");


            builder.Property(p => p.FechaMovimiento)
            .HasColumnName("fechaMovimiento")
            .HasColumnType("DateOnly")
            .IsRequired();
            

            builder.Property(p => p.FechaVencimiento)
            .HasColumnName("fechaVencimiento")
            .HasColumnType("DateOnly")
            .IsRequired();

            builder.HasOne(p => p.FormaPago)
            .WithMany(p => p.MovimientoInventarios)
            .HasForeignKey(p => p.IdFormaPagoFk);

            builder.HasOne(p => p.TipoMovInventario)
            .WithMany(p => p.MovimientoInventarios)
            .HasForeignKey(p => p.IdTipoMovInventarioFk);

            builder.HasOne(mi => mi.ResponsableFk)
            .WithMany(p => p.ResponsableCollection)
            .HasForeignKey(mi => mi.IdResponsableFk);

            builder.HasOne(mi => mi.ReceptorFk)
            .WithMany(p => p.ReceptorCollection)
            .HasForeignKey(mi => mi.IdReceptorFk);



        }


    }
}