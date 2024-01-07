using AutoMapper;
using CMCapital.API.DTOs;
using CMCapital.API.Entidades;
using CMCapital.API.Helpers;
using CMCapital.API.Repositorios.Interfaces;
using CMCapital.API.Servicos.Interfaces;
using System.Net;

namespace CMCapital.API.Servicos;

public class CompraServico : ICompraServico
{

    private readonly ICompraRepositorio _compraRepositorio;
    private readonly IClienteRepositorio _clienteRepositorio;
    private readonly IProdutoRepositorio _produtoRepositorio;
    private readonly IMapper _mapper;

    public CompraServico(ICompraRepositorio compraRepositorio, IClienteRepositorio clienteRepositorio, IProdutoRepositorio produtoRepositorio, IMapper mapper)
    {
        _compraRepositorio = compraRepositorio;
        _clienteRepositorio = clienteRepositorio;
        _produtoRepositorio = produtoRepositorio;
        _mapper = mapper;
    }

    public async Task<string> Comprar(CompraDTO dto)
    {
        var cliente = await _clienteRepositorio.ObterPorCodigo(dto.CodigoCliente);
        if (cliente == null) throw new Excecao(MensagensConstantes.CLIENTE_NAO_ENCONTRADO, HttpStatusCode.NotFound);

        var produto = await _produtoRepositorio.ObterPorCodigo(dto.CodigoProduto);
        if (produto == null) throw new Excecao(MensagensConstantes.PRODUTO_NAO_ENCONTRADO, HttpStatusCode.NotFound);

        var valorTotalCompra = dto.Quantidade * produto.ValorUnitario;
        if (valorTotalCompra > cliente.CapacidadeComprar) throw new Excecao(MensagensConstantes.CLIENTE_ULTRAPASSOU_LIMITE_DE_COMPRAR, HttpStatusCode.BadRequest);

        var compra = _mapper.Map<CompraDTO, CompraCliente>(dto);
        compra.ValorTotalCompra = valorTotalCompra;

        var compraRealizada = await _compraRepositorio.Criar(compra);
        if (compraRealizada != null) return MensagensConstantes.COMPRA_REALIZADA_COM_SUCESSO;

        throw new Excecao(MensagensConstantes.ERRO_AO_REALIZAR_COMPRA, HttpStatusCode.BadRequest);
    }

    public async Task<string> Deletar(int codigo)
    {
        await _compraRepositorio.Deletar(codigo);
        return MensagensConstantes.COMPRA_DELETADA_COM_SUCESSO;
    }

    public async Task<IEnumerable<CompraCliente>> ObterTodasAsCompras()
    {
        var compras = await _compraRepositorio.ObterTodasAsCompras();
        return compras;
    }

    public async Task<IEnumerable<CompraCliente>> ObterTodasAsComprasCliente(int codigoCliente)
    {
        var cliente = await _clienteRepositorio.ObterPorCodigo(codigoCliente);
        if (cliente == null) throw new Excecao(MensagensConstantes.CLIENTE_NAO_ENCONTRADO, HttpStatusCode.NotFound);

        var compras = await _compraRepositorio.ObterPorCliente(codigoCliente);
        return compras;
    }

    public async Task<IEnumerable<CompraCliente>> ObterTodasAsComprasProduto(int codigoProduto)
    {
        var produto = await _produtoRepositorio.ObterPorCodigo(codigoProduto);
        if (produto == null) throw new Excecao(MensagensConstantes.PRODUTO_NAO_ENCONTRADO, HttpStatusCode.NotFound);

        var compras = await _compraRepositorio.ObterPorProduto(codigoProduto);
        return compras;
    }
}
