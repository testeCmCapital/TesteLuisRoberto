﻿using CMCapital.API.DTOs;
using CMCapital.API.DTOs.Validadores;
using CMCapital.API.Helpers;
using CMCapital.API.Repositorios;
using CMCapital.API.Repositorios.Interfaces;
using CMCapital.API.Servicos;
using CMCapital.API.Servicos.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace CMCapital.API.Configuracao;

public class InjecaoDependencia
{
    public static void Configurar(IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        //Base de dados
        services.AddDbContext<DataBaseContext>();

        //Repositorios
        services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
        services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
        services.AddScoped<ICompraRepositorio, CompraRepositorio>();

        //Servicos    
        services.AddScoped<IClienteServico, ClienteServico>();
        services.AddScoped<IProdutoServico, ProdutoServico>();
        services.AddScoped<ICompraServico, CompraServico>();

        //Auxiliares
        services.AddScoped<MiddlewareGlobalExcecoes>();
        services.AddAutoMapper(typeof(Mapeamento).Assembly);
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

        //validadores
        services.AddSingleton<IValidator<ClienteDTO>, ClienteDTOValidador>();
        services.AddSingleton<IValidator<ProdutoDTO>, ProdutoDTOValidador>();
    }
}
