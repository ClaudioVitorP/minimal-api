using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.DTOs;
using MinimalApi.Infraestrutura.Db;
using Microsoft.EntityFrameworkCore;


namespace MinimalApi.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _contexto;
    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto;
    }

    public Administrador? BuscaPorId(int id)
    {
        return _contexto.Administradores.Where(v => v.Id == id).FirstOrDefault();
    }

    public async Task<Administrador?> Incluir(Administrador administrador)
    {
        _contexto.Administradores.Add(administrador);
        await _contexto.SaveChangesAsync();

        return administrador;
    }

    public async Task<Administrador?> LoginAsync(LoginDTO loginDTO)
    {
        return await _contexto.Administradores
            .FirstOrDefaultAsync(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha);
    }


    public async Task<List<Administrador>> Todos(int? pagina)
    {
    var query = _contexto.Administradores.AsQueryable();

    int itensPorPagina = 10;

    if (pagina.HasValue)
    {
        query = query
            .Skip((pagina.Value - 1) * itensPorPagina)
            .Take(itensPorPagina);
    }

    return await query.ToListAsync();
    }

}