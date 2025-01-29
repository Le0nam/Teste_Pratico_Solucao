using Microsoft.EntityFrameworkCore;
using Teste_Pratico_Contex;
using Teste_Pratico_Entity;

namespace Teste_Pratico_Repository
{


    public class AnuncioRepository
    {
        private readonly Data _context;

        public AnuncioRepository(Data context)
        {
            _context = context;
        }

        public async Task<List<Anuncio>> TodosAsync()
        {
            return await _context.Anuncios.ToListAsync();
        }

        public async Task<Anuncio> BuscaPorIdAsync(int id)
        {
            return await _context.Anuncios.FindAsync(id);
        }

        public async Task AdicionarAsync(Anuncio anuncio)
        {
            _context.Anuncios.Add(anuncio);
            await _context.SaveChangesAsync();
        }
        public async Task AtualizarAsync(Anuncio anuncio)
        {
            var anuncioExistente = await BuscaPorIdAsync(anuncio.Id);
            _context.Anuncios.Entry(anuncioExistente).CurrentValues.SetValues(anuncio);
            await _context.SaveChangesAsync();
        }
        public async Task RemoverAsync(Anuncio anuncio)
        {
            _context.Anuncios.Remove(anuncio);
            await _context.SaveChangesAsync();
        }
    }
}
