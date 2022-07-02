using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.QueryFilters
{
    public class AutorQueryFilter
    {
        public int? IdAutor { get; set; }
        public string? NombreAutor { get; set; }
        public bool? EsVigente { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
