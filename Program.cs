using System;
using System.Linq;
using System.Threading.Tasks;
using LaboratoriosRestAPI;
using LaboratoriosRestAPI.Models;
using LaboratoriosRestAPI.Repository;
using LaboratoriosRestAPI.Repository.Implementations;
using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

// Registrar o contexto e serviços no container de DI
        builder.Services.AddDbContext<BookLendingContext>();
        builder.Services.AddScoped<ILivroRepository, LivroRepository>();
        builder.Services.AddScoped<ILivroService, LivroService>();

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