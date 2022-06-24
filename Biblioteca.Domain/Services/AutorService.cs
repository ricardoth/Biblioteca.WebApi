using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Domain.Services
{
    public class AutorService : IAutorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AutorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public async Task<Autor> GetAutor(int id)
        {
            return await _unitOfWork.AutorRepository.GetById(id);
        }

        public IEnumerable<Autor> GetAutores()
        {
            return _unitOfWork.AutorRepository.GetAll();
        }
    }
}
