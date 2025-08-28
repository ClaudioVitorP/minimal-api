using Microsoft.EntityFrameworkCore;
using MinimalApi.Infraestrutura.Db;
using MinimalApi.DTOs;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Dominio.Servicos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContexto>();

builder.Services.AddScoped<IAdministradorServico, AdministradorServico>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", async (LoginDTO loginDTO, IAdministradorServico administradorServico) =>
{
      var admin = await administradorServico.LoginAsync(loginDTO);

    if (admin is null)
        return Results.Unauthorized();

    return Results.Ok($"Login com sucesso! Bem-vindo {admin.Perfil}");
});

app.Run();

