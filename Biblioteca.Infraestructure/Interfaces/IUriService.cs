using Biblioteca.Domain.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infraestructure.Interfaces
{
    public interface IUriService
    {
        Uri GetAutorPaginationUri(AutorQueryFilter filter, string? actionUrl);
    }
}
