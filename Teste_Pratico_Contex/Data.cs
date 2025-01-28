using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Teste_Pratico_Entity;

namespace Teste_Pratico_Contex
{
    public class Data : DbContext
    {
        public Data(DbContextOptions<Data> options) : base(options) { }

        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
