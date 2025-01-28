using Teste_Pratico_Entity.Models;
using Teste_Pratico_API.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/anuncio")] // O "controller" será substituído por "anuncios" automaticamente
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
