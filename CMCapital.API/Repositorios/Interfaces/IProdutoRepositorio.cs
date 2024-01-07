using CMCapital.API.Entidades;
using System.Linq.Expressions;

namespace CMCapital.API.Repositorios.Interfaces;

public interface IProdutoRepositorio
{
    Task<IEnumerable<Produto>> ObterPorDescricao(string descricao);
    Task<Produto?> ObterPorCodigo(int codigo);
    Task<Produto?> Criar(Produto produto);
    Task<Produto?> Atualizar(int codigo, Produto produto);
    Task Deletar(int codigo);
    Task<Produto?> ObterPorQuery(Expression<Func<Produto, bool>> query);
}
