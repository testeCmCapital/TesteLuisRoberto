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

    public async Task<IEnumerable<Produto>> ObterPorDescricao(string descricao)
    {
        var resultado = await _contexto.Produto.Where(c => c.Descricao.Contains(descricao)).ToListAsync();
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

    public async Task<Produto?> Atualizar(int codigo, Produto produto)
    {
        var resultado = await ObterPorCodigo(codigo);
        if (resultado == null) return null;

        produto.Codigo = codigo;
        produto.DataCadastro = resultado.DataCadastro;
        _contexto.Entry(resultado).CurrentValues.SetValues(produto);
        _contexto.Entry(resultado).State = EntityState.Modified;

        var atualizados = await _contexto.SaveChangesAsync();
        if (atualizados < 1) return null;

        return await ObterPorCodigo(codigo);
    }

    public async Task<Produto?> Criar(Produto produto)
    {
        var resultado = await _contexto.AddAsync(produto);
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
