using Teste_Pratico_Entity.Models;
using Teste_Pratico_API.Repositories;

namespace Teste_Pratico_API.Services
{
    public class AnuncioService
    {
        private readonly IAnuncioRepository _repository;

        public AnuncioService(IAnuncioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Anuncio>> GetAllAnunciosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAnuncioAsync(Anuncio anuncio)
        {
            // Validação extra (opcional)
            if (anuncio.DataPublicacao < DateTime.Today)
            {
                throw new Exception("A data de publicação não pode ser anterior a hoje.");
            }

            await _repository.AddAsync(anuncio);
        }
    }

}
