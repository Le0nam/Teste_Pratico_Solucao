using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Pratico_Entity;
using Teste_Pratico_Repository;

namespace Teste_Pratico_Service
{
    public class ProdutoService
    {
        private readonly ProdutoRepository _repository;

        public ProdutoService(ProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Produto>> Todos()
        {
            return await _repository.TodosAsync();
        }

        public async Task Adicioanr(Produto produto)
        {
            if (produto.DataPublicacao < DateTime.Today)
            {
                throw new Exception("A data de publicação não pode ser anterior a hoje.");
            }
            await _repository.AdicionarAsync(produto);
        }
        public async Task<Produto> BuscarPorId(int id)
        {
            return await _repository.BuscaPorIdAsync(id) ?? null;
        }
        public async Task<bool> Atualizar(int id, Produto produto)
        {
            var produtoExistente = await _repository.BuscaPorIdAsync(id);

            if (produtoExistente == null)
            {
                return false;
            }
            produtoExistente.DataPublicacao = produto.DataPublicacao;
            produtoExistente.Valor = produto.Valor;
            produtoExistente.Cidade = produto.Cidade;
            produtoExistente.Nome = produto.Nome;
            produtoExistente.Categoria = produto.Categoria;
            produtoExistente.Condicao = produto.Condicao;
            produtoExistente.Quantidade = produto.Quantidade;

            await _repository.AtualizarAsync(produtoExistente);
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
