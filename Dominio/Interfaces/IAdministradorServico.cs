using MinimalApi.Dominio.Entidades;
using MinimalApi.DTOs;

namespace MinimalApi.Dominio.Interfaces;

public interface IAdministradorServico
{
    Task<Administrador?> LoginAsync(LoginDTO loginDTO);
    Task<Administrador?> Incluir(Administrador administrador);
    Administrador? BuscaPorId(int id);
    Task<List<Administrador>> Todos(int? pagina);

}
