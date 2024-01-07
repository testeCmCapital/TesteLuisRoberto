using CMCapital.API.Entidades;
using CMCapital.API.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CMCapital.API.Repositorios;

public class ProdutoRepositorio : IProdutoRepositorio
{
    private readonly DataBaseContext _contexto;

    public ProdutoRepositorio(DataBaseContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<Produto?> ObterPorDescricao(string descricao)
    {
        var resultado = await _contexto.Produto.FirstOrDefaultAsync(c => c.Descricao == descricao);
        return resultado;
    }

    public async Task<Produto?> ObterPorCodigo(int codigo)
    {
        var resultado = await _contexto.Produto.FirstOrDefaultAsync(c => c.Codigo == codigo);
        return resultado;
    }

    public async Task<Produto?> ObterPorQuery(Expression<Func<Produto, bool>> expression)
    {
        var resultado = await _contexto.Produto.FirstOrDefaultAsync(expression);
        return resultado;
    }

    public async Task<Produto?> Atualizar(int codigo, Produto cliente)
    {
        var resultado = await ObterPorCodigo(codigo);
        if (resultado == null) return null;

        cliente.Codigo = codigo;
        _contexto.Entry(resultado).CurrentValues.SetValues(cliente);
        _contexto.Entry(resultado).State = EntityState.Modified;

        var atualizados = await _contexto.SaveChangesAsync();
        if (atualizados < 1) return null;

        return await ObterPorCodigo(codigo);
    }

    public async Task<Produto?> Criar(Produto cliente)
    {
        var resultado = await _contexto.AddAsync(cliente);
        var salvo = await _contexto.SaveChangesAsync();
        if (salvo < 1) return null;

        return resultado.Entity;
    }

    public async Task Deletar(int codigo)
    {
        var resultado = await ObterPorCodigo(codigo);
        if (resultado == null) return;

        _contexto.Produto.Remove(resultado);
        _contexto.Entry(resultado).State = EntityState.Deleted;

        var removidos = await _contexto.SaveChangesAsync();
        return;
    }

}
