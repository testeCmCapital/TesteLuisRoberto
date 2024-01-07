using CMCapital.API.Entidades;
using CMCapital.API.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CMCapital.API.Repositorios;

public class CompraRepositorio : ICompraRepositorio
{
    private readonly DataBaseContext _contexto;

    public CompraRepositorio(DataBaseContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<CompraCliente?> Criar(CompraCliente compra)
    {
        var resultado = await _contexto.AddAsync(compra);
        var salvo = await _contexto.SaveChangesAsync();
        if (salvo < 1) return null;

        return resultado.Entity;
    }

    public async Task Deletar(int codigo)
    {
        var resultado = await ObterPorCodigo(codigo);
        if (resultado == null) return;

        _contexto.CompraCliente.Remove(resultado);
        _contexto.Entry(resultado).State = EntityState.Deleted;

        await _contexto.SaveChangesAsync();
        return;
    }

    public async Task<CompraCliente?> ObterPorCodigo(int codigo)
    {
        var resultado = await _contexto.CompraCliente.FirstOrDefaultAsync(c => c.Codigo == codigo);
        return resultado;
    }

    public async Task<IEnumerable<CompraCliente>> ObterPorCliente(int codigoCliente)
    {
        var resultado = await _contexto.CompraCliente.Where(c => c.CodigoCliente == codigoCliente).ToListAsync();
        return resultado;
    }

    public async Task<IEnumerable<CompraCliente>> ObterPorProduto(int codigoProduto)
    {
        var resultado = await _contexto.CompraCliente.Where(c => c.CodigoProduto == codigoProduto).ToListAsync();
        return resultado;
    }

    public async Task<CompraCliente?> ObterPorQuery(Expression<Func<CompraCliente, bool>> query)
    {
        var resultado = await _contexto.CompraCliente.FirstOrDefaultAsync(query);
        return resultado;
    }

    public async Task<IEnumerable<CompraCliente>> ObterTodasAsCompras()
    {
        var resultado = await _contexto.CompraCliente.ToListAsync();
        return resultado;
    }
}
