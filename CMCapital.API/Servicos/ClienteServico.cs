using AutoMapper;
using CMCapital.API.DTOs;
using CMCapital.API.Entidades;
using CMCapital.API.Helpers;
using CMCapital.API.Repositorios.Interfaces;
using CMCapital.API.Servicos.Interfaces;
using System.Linq.Expressions;
using System.Net;

namespace CMCapital.API.Servicos;

public class ClienteServico : IClienteServico
{
    private readonly IClienteRepositorio _clienteRepositorio;
    private readonly IMapper _mapper;
    public ClienteServico(IClienteRepositorio clienteRepositorio, IMapper mapper)
    {
        _clienteRepositorio = clienteRepositorio;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Cliente>> ObterPorNome(string nome)
    {
        var cliente = await _clienteRepositorio.ObterPorNome(nome);
        return cliente;
    }

    public async Task<Cliente> Atualizar(int codigo, ClienteDTO cliente)
    {
        Expression<Func<Cliente, bool>> query = q => q.Telefone == cliente.Telefone;
        var clienteSalvo = await _clienteRepositorio.ObterPorQuery(query);

        if (clienteSalvo != null && clienteSalvo.Codigo != codigo) throw new Excecao(MensagensConstantes.TELEFONE_INDICADO_JA_EM_USO, HttpStatusCode.BadRequest);

        var clienteAtualizado = await _clienteRepositorio.Atualizar(codigo, _mapper.Map<ClienteDTO, Cliente>(cliente));
        if (clienteAtualizado != null) return clienteAtualizado;

        throw new Excecao(MensagensConstantes.CLIENTE_NAO_ENCONTRADO, HttpStatusCode.NotFound);
    }

    public async Task<Cliente> Criar(ClienteDTO cliente)
    {
        Expression<Func<Cliente, bool>> query = q => q.Telefone == cliente.Telefone;

        var clienteSalvo = await _clienteRepositorio.ObterPorQuery(query);
        if (clienteSalvo != null) throw new Excecao(MensagensConstantes.TELEFONE_INDICADO_JA_EM_USO, HttpStatusCode.BadRequest);

        var clienteCriado = await _clienteRepositorio.Criar(_mapper.Map<ClienteDTO, Cliente>(cliente));
        if (clienteCriado != null) return clienteCriado;

        throw new Excecao(MensagensConstantes.ERRO_AO_CRIAR_CLIENTE, HttpStatusCode.BadRequest);

    }

    public async Task<string> Deletar(int codigo)
    {
        await _clienteRepositorio.Deletar(codigo);
        return MensagensConstantes.CLIENTE_DELETADO_COM_SUCESSO;
    }
}
