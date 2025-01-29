using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Pratico_Contex;
using Teste_Pratico_Entity;

namespace Teste_Pratico_Repository
{
    public class ProdutoRepository
    {
        private readonly Data _context;

        public ProdutoRepository(Data context)
        {
            _context = context;
        }

        public async Task<List<Produto>> TodosAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> BuscaPorIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task AdicionarAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }
        public async Task AtualizarAsync(Produto produto)
        {
            var produtoExistente = await BuscaPorIdAsync(produto.Id);
            _context.Produtos.Entry(produtoExistente).CurrentValues.SetValues(produto);
            await _context.SaveChangesAsync();
        }
        public async Task RemoverAsync(Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}
