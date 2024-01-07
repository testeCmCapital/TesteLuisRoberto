using CMCapital.API.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMCapital.API.Controllers;
[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteServico _clienteServico;
    public ClienteController(IClienteServico clienteServico)
    {
        _clienteServico = clienteServico;
    }

    [HttpGet]
    public async Task<IActionResult> ObterPorNome([FromQuery] string name)
    {
        var resultado = await _clienteServico.ObterPorNome(name);
        if (resultado == null) return NotFound();
        return Ok(resultado);
    }
}
