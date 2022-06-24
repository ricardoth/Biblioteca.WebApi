using Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Biblioteca.Domain
{
    public partial class Categorium : BaseEntity
    {
        public Categorium()
        {
            Libros = new HashSet<Libro>();
        }

        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool Vigencia { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
