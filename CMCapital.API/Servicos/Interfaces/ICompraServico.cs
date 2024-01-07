using CMCapital.API.DTOs;
using CMCapital.API.Entidades;

namespace CMCapital.API.Servicos.Interfaces;

public interface ICompraServico
{
    Task<string> Comprar(CompraDTO compraCliente);
    Task<string> Deletar(int codigo);
    Task<IEnumerable<CompraCliente>> ObterTodasAsComprasCliente(int codigoCliente);
    Task<IEnumerable<CompraCliente>> ObterTodasAsComprasProduto(int codigoProduto);
    Task<IEnumerable<CompraCliente>> ObterTodasAsCompras();

}
