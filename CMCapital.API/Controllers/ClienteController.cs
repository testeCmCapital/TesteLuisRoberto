using CMCapital.API.DTOs;
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
        return Ok(resultado);
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] ClienteDTO cliente)
    {
        var resultado = await _clienteServico.Criar(cliente);
        return Ok(resultado);
    }

    [HttpPut]
    public async Task<IActionResult> Atualizar([FromQuery] int codigo, [FromBody] ClienteDTO cliente)
    {
        var resultado = await _clienteServico.Atualizar(codigo, cliente);
        return Ok(resultado);
    }

    [HttpDelete]
    public async Task<IActionResult> Deletar([FromQuery] int codigo)
    {
        var resultado = await _clienteServico.Deletar(codigo);
        return Ok(resultado);
    }
}
