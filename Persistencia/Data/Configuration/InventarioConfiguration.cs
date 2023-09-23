using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
    {
        public void Configure(EntityTypeBuilder<Inventario> builder)
        {
            builder.ToTable("inventario");

            builder.Property(p => p.Nombre)
            .HasColumnName("nombre")
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(p => p.Stock)
            .HasColumnName("stock")
            .HasColumnType("int")
            .IsRequired();


            builder.Property(p => p.StockMin)
            .HasColumnName("stockMin")
            .HasColumnType("int")
            .IsRequired();


            builder.Property(p => p.StockMax)
            .HasColumnName("stockMax")
            .HasColumnType("int")
            .IsRequired();

            builder.Property(p => p.FechaExpiracion)
            .HasColumnName("fechaExpiracion")
            .HasColumnType("DateOnly")
            .IsRequired();

            builder.HasOne(p => p.Presentacion)
            .WithMany(p => p.Inventarios)
            .HasForeignKey(p => p.IdPresentacionFk);


        }
    }
}