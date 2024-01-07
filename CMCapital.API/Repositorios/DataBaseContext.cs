using CMCapital.API.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CMCapital.API.Repositorios;

public class DataBaseContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DataBaseContext(DbContextOptions<DataBaseContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Produto> Produto { get; set; }
    public DbSet<CompraCliente> CompraCliente { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Principal"),
        provider => provider.EnableRetryOnFailure(3, TimeSpan.FromSeconds(5), null));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>().Property(c => c.Nome).HasMaxLength(100);
        modelBuilder.Entity<Cliente>().Property(c => c.Telefone).HasMaxLength(15);
        modelBuilder.Entity<Cliente>().Property(c => c.CapacidadeComprar).HasPrecision(29, 20);

        modelBuilder.Entity<Produto>().Property(p => p.Descricao).HasMaxLength(100);
        modelBuilder.Entity<Produto>().Property(c => c.ValorUnitario).HasPrecision(29, 20);

        modelBuilder.Entity<CompraCliente>().Property(cc => cc.ValorTotalCompra).HasPrecision(29, 20);
    }
}
