using System;
using System.Collections.Generic;

namespace Biblioteca.Domain
{
    public partial class Pedido
    {
        public Pedido()
        {
            PedidoDetalles = new HashSet<PedidoDetalle>();
        }

        public int IdPedido { get; set; }
        public int IdUsuario { get; set; }
        public long NumeroSolicitud { get; set; }
        public string GlosaSolicitud { get; set; } = null!;
        public DateTime FechaRecepcion { get; set; }
        public int DiasPrestamo { get; set; }
        public decimal MontoSolicitud { get; set; }
        public string? DetalleSolicitud { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public bool Vigencia { get; set; }
        public int? UsuarioCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; }
    }
}
