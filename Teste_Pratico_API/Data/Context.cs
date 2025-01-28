using Teste_Pratico_Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Teste_Pratico_API.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
