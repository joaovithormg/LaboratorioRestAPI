using System;
using System.Linq;
using System.Threading.Tasks;
using LaboratoriosRestAPI;
using LaboratoriosRestAPI.Models;
using LaboratoriosRestAPI.Repository;
using LaboratoriosRestAPI.Repository.Implementations;
using LaboratoriosRestAPI.Services.Implementations;
using LaboratoriosRestAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

// Registrar o contexto e serviços no container de DI
        builder.Services.AddScoped<IAutorRepository, AutorRepository>();
        builder.Services.AddScoped<IAutorService, AutorService>();

        builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
        builder.Services.AddScoped<IEmprestimoService, EmprestimoService>();
        
        builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
        builder.Services.AddScoped<IEmprestimoService, EmprestimoService>();

// Add suporte à API
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}