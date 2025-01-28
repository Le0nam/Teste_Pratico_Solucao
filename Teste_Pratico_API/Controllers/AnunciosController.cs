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
            await _service.AddAnuncioAsync(anuncio);
            return Ok("Anúncio criado com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
