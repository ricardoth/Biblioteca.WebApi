using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.DTOs
{
    public class AutorDto
    { 
        public int IdAutor { get; set; }
        public string NombreAutor { get; set; }
        public string ApellidoPatAutor { get; set; }
        public string? ApellidoMatAutor { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Vigencia { get; set; }
    }
}
