using Biblioteca.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infraestructure.Data.Configurations
{
    internal class AutorConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("IdAutor");

            entity.ToTable("Autor");

            entity.Property(e => e.ApellidoMatAutor)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.ApellidoPatAutor)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

            entity.Property(e => e.NombreAutor)
                .HasMaxLength(200)
                .IsUnicode(false);
        }
    }
}
