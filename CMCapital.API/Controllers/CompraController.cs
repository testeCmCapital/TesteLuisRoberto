using CMCapital.API.DTOs;
using CMCapital.API.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMCapital.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CompraController : ControllerBase
{
    private readonly ICompraServico _compraServico;
    public CompraController(ICompraServico compraServico)
    {
        _compraServico = compraServico;
    }

    [HttpGet]
    public async Task<IActionResult> Obter([FromQuery] int? codigoCliente, [FromQuery] int? codigoProduto)
    {

        if (codigoCliente != null)
        {
            var resultado = await _compraServico.ObterTodasAsComprasCliente((int)codigoCliente);
            return Ok(resultado);
        }

        if (codigoProduto != null)
        {
            var resultado = await _compraServico.ObterTodasAsComprasProduto((int)codigoProduto);
            return Ok(resultado);
        }

        return Ok(await _compraServico.ObterTodasAsCompras());
    }

    [HttpPost]
    public async Task<IActionResult> Comprar([FromBody] CompraDTO cliente)
    {
        var resultado = await _compraServico.Comprar(cliente);
        return Ok(resultado);
    }

    [HttpDelete]
    public async Task<IActionResult> Deletar([FromQuery] int codigo)
    {
        var resultado = await _compraServico.Deletar(codigo);
        return Ok(resultado);
    }

}
