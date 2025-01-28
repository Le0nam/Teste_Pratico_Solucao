using Teste_Pratico_Entity.Models;

namespace Teste_Pratico_API.Repositories
{
    public interface IAnuncioRepository
    {
        Task<List<Anuncio>> GetAllAsync();
        Task<Anuncio> GetByIdAsync(int id);
        Task AddAsync(Anuncio anuncio);
    }
}
