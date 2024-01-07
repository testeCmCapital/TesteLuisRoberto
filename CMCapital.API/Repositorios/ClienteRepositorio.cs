using CMCapital.API.Entidades;
using CMCapital.API.Helpers;
using CMCapital.API.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net;

namespace CMCapital.API.Repositorios;

public class ClienteRepositorio : IClienteRepositorio
{
    private readonly DataBaseContext _contexto;

    public ClienteRepositorio(DataBaseContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<IEnumerable<Cliente>> ObterPorNome(string nome)
    {
        var resultado = await _contexto.Cliente.Where(c => c.Nome.Contains(nome)).ToListAsync();
        return resultado;
    }

    public async Task<Cliente?> ObterPorCodigo(int codigo)
    {
        var resultado = await _contexto.Cliente.FirstOrDefaultAsync(c => c.Codigo == codigo);
        return resultado;
    }

    public async Task<Cliente?> ObterPorQuery(Expression<Func<Cliente, bool>> expression)
    {
        var resultado = await _contexto.Cliente.FirstOrDefaultAsync(expression);
        return resultado;
    }

    public async Task<Cliente?> Atualizar(int codigo, Cliente cliente)
    {
        var resultado = await ObterPorCodigo(codigo);
        if (resultado == null) return null;

        cliente.Codigo = codigo;
        _contexto.Entry(resultado).CurrentValues.SetValues(cliente);
        _contexto.Entry(resultado).State = EntityState.Modified;

        var atualizados = await _contexto.SaveChangesAsync();
        if (atualizados < 1) throw new Excecao(MensagensConstantes.ERRO_AO_ATUALIZAR_CLIENTE, HttpStatusCode.InternalServerError); ;

        return await ObterPorCodigo(codigo);
    }

    public async Task<Cliente?> Criar(Cliente cliente)
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

        _contexto.Cliente.Remove(resultado);
        _contexto.Entry(resultado).State = EntityState.Deleted;

        await _contexto.SaveChangesAsync();
        return;
    }

}
