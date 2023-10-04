using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.Property(n => n.Username)
            .HasColumnName("Username")
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(n => n.Email)
            .HasColumnName("email")
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(n => n.Password)
            .HasColumnName("Password")
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(200);

            builder
            .HasMany(n => n.Rols)
            .WithMany(n => n.Users)
            .UsingEntity<UserRol>(
                j => j
                .HasOne(n => n.Rol)
                .WithMany(n => n.UserRols)
                .HasForeignKey(n => n.IdRolFk),

                j=> j
                .HasOne(n => n.User)
                .WithMany(n => n.UserRols)
                .HasForeignKey(n => n.IdUserFk),

                j =>
               {
                   j.ToTable("userRol");
                   j.HasKey(t => new { t.IdRolFk, t.IdUserFk });

               }
            );
            builder.HasMany(p => p.RefreshTokens)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);

        }
    }
}