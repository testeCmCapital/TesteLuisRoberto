using CMCapital.API.Entidades;

namespace CMCapital.API.Repositorios.Interfaces;

public interface IClienteRepositorio
{
    Task<Cliente?> ObterPorNome(string nome);
    Task<Cliente?> Criar(Cliente cliente);
    Task<Cliente?> Atualizar(int codigo, Cliente cliente);
    Task<bool> Deletar(int codigo);
}
