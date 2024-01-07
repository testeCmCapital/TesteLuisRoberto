using CMCapital.API.Helpers;
using CMCapital.API.Repositorios;
using CMCapital.API.Repositorios.Interfaces;
using CMCapital.API.Servicos;
using CMCapital.API.Servicos.Interfaces;

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

        //Servicos    
        services.AddScoped<IClienteServico, ClienteServico>();
        services.AddScoped<IProdutoServico, ProdutoServico>();

        //Auxiliares
        services.AddScoped<MiddlewareGlobalExcecoes>();
        services.AddAutoMapper(typeof(Mapeamento).Assembly);
    }
}
