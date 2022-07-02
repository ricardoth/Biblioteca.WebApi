using Biblioteca.Domain.CustomEntities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain.QueryFilters;
using Microsoft.Extensions.Options;

namespace Biblioteca.Domain.Services
{
    public class AutorService : IAutorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public AutorService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> paginationOptions)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = paginationOptions.Value;
        }

        public PagedList<Autor> GetAutores(AutorQueryFilter filtros)
        {
            filtros.PageNumber = filtros.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filtros.PageNumber;
            filtros.PageSize = filtros.PageSize == 0 ? _paginationOptions.DefaultPageSize : filtros.PageSize;

            var autores = _unitOfWork.AutorRepository.GetAll();

            if (filtros.IdAutor != null)
            {
                autores = autores.Where(x => x.Id == filtros.IdAutor);
            }

            if (filtros.NombreAutor != null)
            {
                autores = autores.Where(x => x.NombreAutor.ToLower().Contains(filtros.NombreAutor.ToLower()));
            }

            if (filtros.EsVigente != null)
            {
                autores = autores.Where(x => x.Vigencia == filtros.EsVigente);
            }

            var pagedAutores = PagedList<Autor>.Create(autores, filtros.PageNumber, filtros.PageSize);
            return pagedAutores;
        }

        public async Task<Autor> GetAutor(int id)
        {
            return await _unitOfWork.AutorRepository.GetById(id);
        }

        public async Task<bool> Actualizar(Autor autor)
        {
            _unitOfWork.AutorRepository.Update(autor);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task Agregar(Autor autor)
        {
            await _unitOfWork.AutorRepository.Add(autor);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Eliminar(int id)
        {
            await _unitOfWork.AutorRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        
    }
}
