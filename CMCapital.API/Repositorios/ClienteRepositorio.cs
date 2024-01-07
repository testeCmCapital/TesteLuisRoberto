using CMCapital.API.Entidades;
using CMCapital.API.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CMCapital.API.Repositorios;

public class ClienteRepositorio : IClienteRepositorio
{
    private readonly DataBaseContext _contexto;

    public ClienteRepositorio(DataBaseContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<Cliente?> ObterPorNome(string nome)
    {
        var resultado = await _contexto.Cliente.FirstOrDefaultAsync(c => c.Nome.Contains(nome));
        return resultado;
    }

    public async Task<Cliente?> ObterPorCodigo(int codigo)
    {
        var resultado = await _contexto.Cliente.FirstOrDefaultAsync(c => c.Codigo == codigo);
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
        if (atualizados < 1) return null;

        return await ObterPorCodigo(codigo);

    }

    public async Task<Cliente?> Criar(Cliente cliente)
    {
        var resultado = await _contexto.AddAsync(cliente);
        var salvo = await _contexto.SaveChangesAsync();
        if (salvo < 1) return null;

        return resultado.Entity;
    }

    public async Task<bool> Deletar(int codigo)
    {
        var resultado = await ObterPorCodigo(codigo);
        if (resultado == null) return false;

        _contexto.Cliente.Remove(resultado);
        _contexto.Entry(resultado).State = EntityState.Deleted;

        var removidos = await _contexto.SaveChangesAsync();
        return removidos > 0;
    }

}
