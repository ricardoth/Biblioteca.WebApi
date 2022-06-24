using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Autor> AutorRepository { get; }
        IRepository<Categorium> CategoriumRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
