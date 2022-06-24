using System;
using System.Collections.Generic;

namespace Biblioteca.Domain
{
    public partial class PedidoDetalle
    {
        public int IdPedidoDetalle { get; set; }
        public int IdPedido { get; set; }
        public int IdLibro { get; set; }
        public bool Vigencia { get; set; }
        public int? UsuarioCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual Libro IdLibroNavigation { get; set; } = null!;
        public virtual Pedido IdPedidoNavigation { get; set; } = null!;
    }
}
