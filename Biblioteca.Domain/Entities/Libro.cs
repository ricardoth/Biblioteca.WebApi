using System;
using System.Collections.Generic;

namespace Biblioteca.Domain {
    public partial class Libro
    {
        public Libro()
        {
            PedidoDetalles = new HashSet<PedidoDetalle>();
        }

        public int IdLibro { get; set; }
        public int IdAutor { get; set; }
        public int IdCategoria { get; set; }
        public string CodigoLibro { get; set; } = null!;
        public string NombreLibro { get; set; } = null!;
        public int CantidadPaginas { get; set; }
        public DateTime AnioLanzamiento { get; set; }
        public string? UrlArchivo { get; set; }
        public bool Vigencia { get; set; }
        public int? UsuarioCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual Autor IdAutorNavigation { get; set; } = null!;
        public virtual Categorium IdCategoriaNavigation { get; set; } = null!;
        public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; }
    }
}
