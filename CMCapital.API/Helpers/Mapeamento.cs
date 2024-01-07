using AutoMapper;
using CMCapital.API.DTOs;
using CMCapital.API.Entidades;

namespace CMCapital.API.Helpers;

public class Mapeamento : Profile
{
    public Mapeamento()
    {
        CreateMap<Cliente, ClienteDTO>().ReverseMap();
        CreateMap<Produto, ProdutoDTO>().ReverseMap();
        CreateMap<CompraCliente, CompraDTO>().ReverseMap();
    }
}
