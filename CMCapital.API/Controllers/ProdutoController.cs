using CMCapital.API.DTOs;
using CMCapital.API.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMCapital.API.Controllers;
[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoServico _produtoServico;
    public ProdutoController(IProdutoServico produtoServico)
    {
        _produtoServico = produtoServico;
    }

    [HttpGet]
    public async Task<IActionResult> ObterPorNome([FromQuery] string descricao)
    {
        var resultado = await _produtoServico.ObterPorDescricao(descricao);
        return Ok(resultado);
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] ProdutoDTO produto)
    {
        var resultado = await _produtoServico.Criar(produto);
        return Ok(resultado);
    }

    [HttpPut]
    public async Task<IActionResult> Atualizar([FromQuery] int codigo, [FromBody] ProdutoDTO produto)
    {
        var resultado = await _produtoServico.Atualizar(codigo, produto);
        return Ok(resultado);
    }

    [HttpDelete]
    public async Task<IActionResult> Deletar([FromQuery] int codigo)
    {
        var resultado = await _produtoServico.Deletar(codigo);
        return Ok(resultado);
    }
}
