using CMCapital.API.Entidades;
using System.Linq.Expressions;

namespace CMCapital.API.Repositorios.Interfaces;

public interface ICompraRepositorio
{
    Task<CompraCliente?> ObterPorCodigo(int codigo);
    Task<IEnumerable<CompraCliente>> ObterPorCliente(int codigoCliente);
    Task<IEnumerable<CompraCliente>> ObterPorProduto(int codigoProduto);
    Task<IEnumerable<CompraCliente>> ObterTodasAsCompras();
    Task<CompraCliente?> Criar(CompraCliente compra);
    Task Deletar(int codigo);
    Task<CompraCliente?> ObterPorQuery(Expression<Func<CompraCliente, bool>> query);
}
