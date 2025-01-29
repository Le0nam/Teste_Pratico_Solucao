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

        public async Task<List<Anuncio>> Todos()
        {
            return await _repository.TodosAsync();
        }

        public async Task Adicioanr(Anuncio anuncio)
        {
            if (anuncio.DataPublicacao < DateTime.Today)
            {
                throw new Exception("A data de publicação não pode ser anterior a hoje.");
            }
            await _repository.AdicionarAsync(anuncio);
        }
        public async Task<Anuncio> BuscarPorId(int id)
        {
            return await _repository.BuscaPorIdAsync(id) ?? null;
        }
        public async Task<bool> Atualizar(int id, Anuncio anuncio)
        {
            var anuncioExistente = await _repository.BuscaPorIdAsync(id);

            if (anuncioExistente == null)
            {
                return false;
            }
            anuncioExistente.DataPublicacao = anuncio.DataPublicacao;
            anuncioExistente.Valor = anuncio.Valor;
            anuncioExistente.Cidade = anuncio.Cidade;
            anuncioExistente.Nome = anuncio.Nome;

            await _repository.AtualizarAsync(anuncioExistente);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var anuncio = await _repository.BuscaPorIdAsync(id);

            if (anuncio == null)
            {
                return false;
            }

            await _repository.RemoverAsync(anuncio);
            return true;
        }
    }
}
