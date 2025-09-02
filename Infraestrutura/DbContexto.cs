using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Infraestrutura.Db;

public class DbContexto : DbContext
{
    private readonly IConfiguration _configuracaoAppSettings;
    public DbContexto(IConfiguration configuracaoAppSettings)
    {
        _configuracaoAppSettings = configuracaoAppSettings;
    }
    public DbSet<Administrador> Administradores { get; set; } = null!;

    public DbSet<Veiculo> Veiculos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuider)
    {
        modelBuider.Entity<Administrador>().HasData(
            new Administrador
            {
                Id = 1,
                Email = "administrador@teste.com",
                Senha = "123456",
                Perfil = "Adm"
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var stringConexao = _configuracaoAppSettings.GetConnectionString("DefaultConnection");
        if (!string.IsNullOrEmpty(stringConexao))
        {
            optionsBuilder.UseSqlServer(stringConexao);
        }

    }
}