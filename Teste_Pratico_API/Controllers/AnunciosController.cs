using Teste_Pratico_Service;
using Microsoft.AspNetCore.Mvc;
using Teste_Pratico_Entity;

[ApiController]
[Route("api/v1/anuncio")]
public class AnunciosController : ControllerBase
{
    private readonly AnuncioService _service;

    public AnunciosController(AnuncioService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Anuncio anuncio)
    {
        if (anuncio == null)
        {
            return BadRequest("Dados inválidos.");
        }
        if (anuncio.DataPublicacao.Date < DateTime.Now.Date)
        {
            return BadRequest("A data da publicação não pode ser anterior à data de hoje.");
        }
        try
        {
            await _service.Adicioanr(anuncio);
            return Ok("Anúncio criado com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var anuncio = await _service.BuscarPorId(id);
        if (anuncio == null)
        {
            return NotFound("Anúncio não encontrado.");
        }
        return Ok(anuncio);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var anuncios = await _service.Todos();
        return Ok(anuncios);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Anuncio anuncio)
    {
        if (anuncio == null)
        {
            return BadRequest("Dados inválidos.");
        }
        if (anuncio.DataPublicacao.Date < DateTime.Now.Date)
        {
            return BadRequest("A data da publicação não pode ser anterior à data de hoje.");
        }

        try
        {
            var updated = await _service.Atualizar(id, anuncio);
            if (!updated)
            {
                return NotFound("Anúncio não encontrado.");
            }
            return Ok("Anúncio atualizado com sucesso!");
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
            return NotFound("Anúncio não encontrado.");
        }
        return Ok("Anúncio removido com sucesso!");
    }
}
