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
    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> entity)
        {
            entity.HasKey(e => e.IdLibro);

            entity.ToTable("Libro");

            entity.Property(e => e.AnioLanzamiento).HasColumnType("datetime");

            entity.Property(e => e.CodigoLibro)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.NombreLibro)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.UrlArchivo)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAutorNavigation)
                .WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdAutor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Libro_Autor");

            entity.HasOne(d => d.IdCategoriaNavigation)
                .WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Libro_Categoria");
        }
    }
}
