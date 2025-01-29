using Microsoft.AspNetCore.Mvc;
using Teste_Pratico_Entity;
using Teste_Pratico_Service;

namespace Teste_Pratico_API.Controllers
{
    [ApiController]
    [Route("api/v1/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _service;

        public ProdutoController(ProdutoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest("Dados inválidos.");
            }
            if (produto.DataPublicacao.Date < DateTime.Now.Date)
            {
                return BadRequest("A data da publicação não pode ser anterior à data de hoje.");
            }
            try
            {
                await _service.Adicioanr(produto);
                return Ok("Produto criado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var produto = await _service.BuscarPorId(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }
            return Ok(produto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var produtos = await _service.Todos();
            return Ok(produtos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest("Dados inválidos.");
            }
            if (produto.DataPublicacao.Date < DateTime.Now.Date)
            {
                return BadRequest("A data da publicação não pode ser anterior à data de hoje.");
            }

            try
            {
                var updated = await _service.Atualizar(id, produto);
                if (!updated)
                {
                    return NotFound("Produto não encontrado.");
                }
                return Ok("Produto atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _service.Delete(id);
            if (!removido)
            {
                return NotFound("Produto não encontrado.");
            }
            return Ok("Produto removido com sucesso!");
        }
    }
}
