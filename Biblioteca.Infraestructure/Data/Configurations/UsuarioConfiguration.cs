using Biblioteca.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infraestructure.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> entity)
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario");

            entity.Property(e => e.ApellidoMat)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.ApellidoPat)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.Dv)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

            entity.Property(e => e.Nombres)
                .HasMaxLength(200)
                .IsUnicode(false);
        }
    }
}
