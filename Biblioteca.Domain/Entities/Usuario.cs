using System;
using System.Collections.Generic;

namespace Biblioteca.Domain
{
    public partial class Usuario
    {
        public Usuario()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdUsuario { get; set; }
        public int Rut { get; set; }
        public string Dv { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string ApellidoPat { get; set; } = null!;
        public string ApellidoMat { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; } = null!;
        public int Fono { get; set; }
        public bool Vigencia { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
