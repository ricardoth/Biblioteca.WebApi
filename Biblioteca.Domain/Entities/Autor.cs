using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain
{
    public partial class Autor : BaseEntity
    {
        public Autor()
        {
            Libros = new HashSet<Libro>();
        }

        public string NombreAutor { get; set; } = null!;
        public string ApellidoPatAutor { get; set; } = null!;
        public string? ApellidoMatAutor { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Vigencia { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
