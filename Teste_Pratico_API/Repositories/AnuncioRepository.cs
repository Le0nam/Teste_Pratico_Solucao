using Microsoft.EntityFrameworkCore;
using Teste_Pratico_API.Data;
using Teste_Pratico_Entity.Models;

namespace Teste_Pratico_API.Repositories
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private readonly Context _context;

        public AnuncioRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Anuncio>> GetAllAsync()
        {
            return await _context.Anuncios.ToListAsync();
        }

        public async Task<Anuncio> GetByIdAsync(int id)
        {
            return await _context.Anuncios.FindAsync(id);
        }

        public async Task AddAsync(Anuncio anuncio)
        {
            _context.Anuncios.Add(anuncio);
            await _context.SaveChangesAsync();
        }
    }

}
