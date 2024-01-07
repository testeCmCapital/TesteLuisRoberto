using CMCapital.API.DTOs;
using CMCapital.API.Entidades;

namespace CMCapital.API.Servicos.Interfaces;

public interface IProdutoServico
{
    Task<IEnumerable<Produto>> ObterPorDescricao(string descricao);
    Task<Produto> Criar(ProdutoDTO produto);
    Task<Produto> Atualizar(int codigo, ProdutoDTO produto);
    Task<string> Deletar(int codigo);
}
