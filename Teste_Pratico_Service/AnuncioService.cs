using Teste_Pratico_Entity;
using Teste_Pratico_Repository;

namespace Teste_Pratico_Service
{
    public class AnuncioService
    {
        private readonly AnuncioRepository _repository;

        public AnuncioService(AnuncioRepository repository)
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
