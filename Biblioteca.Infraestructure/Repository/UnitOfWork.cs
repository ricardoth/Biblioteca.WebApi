using Biblioteca.Domain;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infraestructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BibliotecaBdContext _context;
        private readonly IRepository<Autor> _autorRepository;
        private readonly IRepository<Categorium> _categoryRepository;

        public UnitOfWork(BibliotecaBdContext context)
        {
            _context = context;
        }

        public IRepository<Autor> AutorRepository => _autorRepository ?? new BaseRepository<Autor>(_context);
        public IRepository<Categorium> CategoriumRepository => _categoryRepository ?? new BaseRepository<Categorium>(_context);
            
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
