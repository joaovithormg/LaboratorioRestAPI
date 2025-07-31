using System;
using System.Linq;
using System.Threading.Tasks;
using LaboratoriosRestAPI;
using LaboratoriosRestAPI.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main(string[] args)
    {
        using var db = new BookLendingContext();

        Console.WriteLine($"Database path: {db.DbPath}.");

        // Garante que o banco está criado
        await db.Database.EnsureCreatedAsync();

        // CREATE - Inserindo um novo autor e livro
        Console.WriteLine("Inserindo novo autor e livro...");

        var autor = new Autor { PrimeiroNome = "João Vithor", UltimoNome = "Moraes"};
        var livro = new Livro { Titulo = "Aprendendo EF Core", AnoPublicacao = 2024, Autores = new List<Autor> { autor } };

        db.Autores.Add(autor);
        db.Livros.Add(livro);
        await db.SaveChangesAsync();

        // READ - Consultando livros
        Console.WriteLine("Consultando livros no banco:");

        var livros = await db.Livros
            .ToListAsync();

        foreach (var l in livros)
        {
            Console.WriteLine($"Livro: {l.Titulo}, Autor: {l.Autores}");
        }

        // UPDATE - Atualizando o título do livro
        Console.WriteLine("Atualizando título do livro...");

        var primeiroLivro = await db.Livros.FirstAsync();
        primeiroLivro.Titulo = "EF Core Avançado";
        await db.SaveChangesAsync();

        // DELETE - Removendo o livro
        Console.WriteLine("Removendo o livro...");

        db.Livros.Remove(primeiroLivro);
        await db.SaveChangesAsync();

        Console.WriteLine("Operações concluídas.");
    }
}