using AutoMapper;
using CMCapital.API.DTOs;
using CMCapital.API.Entidades;
using CMCapital.API.Helpers;
using CMCapital.API.Repositorios.Interfaces;
using CMCapital.API.Servicos.Interfaces;
using System.Linq.Expressions;
using System.Net;

namespace CMCapital.API.Servicos;

public class ProdutoServico : IProdutoServico
{
    private readonly IProdutoRepositorio _produtoRepositorio;
    private readonly IMapper _mapper;
    public ProdutoServico(IProdutoRepositorio produtoRepositorio, IMapper mapper)
    {
        _produtoRepositorio = produtoRepositorio;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Produto>> ObterPorDescricao(string descricao)
    {
        var cliente = await _produtoRepositorio.ObterPorDescricao(descricao);
        return cliente;
    }

    public async Task<Produto> Atualizar(int codigo, ProdutoDTO produto)
    {
        Expression<Func<Produto, bool>> query = q => q.Descricao == produto.Descricao;
        var produtoExiste = await _produtoRepositorio.ObterPorQuery(query);

        if (produtoExiste != null && produtoExiste.Codigo != codigo) throw new Excecao(MensagensConstantes.PRODUTO_JA_CADASTRADO, HttpStatusCode.BadRequest);

        var produtoAtualizado = await _produtoRepositorio.Atualizar(codigo, _mapper.Map<ProdutoDTO, Produto>(produto));
        if (produtoAtualizado != null) return produtoAtualizado;

        throw new Excecao(MensagensConstantes.PRODUTO_NAO_ENCONTRADO, HttpStatusCode.NotFound);
    }

    public async Task<Produto> Criar(ProdutoDTO dto)
    {
        Expression<Func<Produto, bool>> query = q => q.Descricao == dto.Descricao;

        var produtoExiste = await _produtoRepositorio.ObterPorQuery(query);
        if (produtoExiste != null) throw new Excecao(MensagensConstantes.PRODUTO_JA_CADASTRADO, HttpStatusCode.BadRequest);

        var produto = _mapper.Map<ProdutoDTO, Produto>(dto);
        produto.DataCadastro = DateTime.Now;

        var produtoCriado = await _produtoRepositorio.Criar(produto);
        if (produtoCriado != null) return produtoCriado;

        throw new Excecao(MensagensConstantes.ERRO_AO_CRIAR_PRODUTO, HttpStatusCode.BadRequest);
    }

    public async Task<string> Deletar(int codigo)
    {
        await _produtoRepositorio.Deletar(codigo);
        return MensagensConstantes.PRODUTO_DELETADO_COM_SUCESSO;
    }
}
