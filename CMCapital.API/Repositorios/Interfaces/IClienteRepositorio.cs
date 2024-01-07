using CMCapital.API.Entidades;
using System.Linq.Expressions;

namespace CMCapital.API.Repositorios.Interfaces;

public interface IClienteRepositorio
{
    Task<IEnumerable<Cliente>> ObterPorNome(string nome);
    Task<Cliente?> ObterPorCodigo(int codigo);
    Task<Cliente?> Criar(Cliente cliente);
    Task<Cliente?> Atualizar(int codigo, Cliente cliente);
    Task Deletar(int codigo);
    Task<Cliente?> ObterPorQuery(Expression<Func<Cliente, bool>> query);
}
