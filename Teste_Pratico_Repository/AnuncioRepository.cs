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
