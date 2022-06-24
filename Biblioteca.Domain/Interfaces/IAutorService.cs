using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Interfaces
{
    public interface IAutorService
    {
        IEnumerable<Autor> GetAutores();
        Task<Autor> GetAutor(int id);
        Task Agregar(Autor autor);
        Task<bool> Actualizar(Autor autor);
        Task<bool> Eliminar(int id);
    }
}
