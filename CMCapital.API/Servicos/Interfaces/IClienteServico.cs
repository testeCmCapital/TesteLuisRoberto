using CMCapital.API.DTOs;
using CMCapital.API.Entidades;

namespace CMCapital.API.Servicos.Interfaces;

public interface IClienteServico
{
    Task<Cliente> ObterPorNome(string nome);
    Task<Cliente> Criar(ClienteDTO cliente);
    Task<Cliente> Atualizar(int codigo, ClienteDTO cliente);
    Task<string> Deletar(int codigo);
}
