using LaboratoriosRestAPI.Models;

namespace LaboratoriosRestAPI;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class BookLendingContext : DbContext
{
    // DbSet for Books
    public DbSet<Livro> Livros { get; set; }
    // DbSet for Users (who borrow books)
    public DbSet<Autor> Autores { get; set; }
    // DbSet for Loans (the act of a user borrowing a book)
    public DbSet<Emprestimo> Emprestimos { get; set; }

    public string DbPath { get; }

    public BookLendingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        // Changed the database file name to reflect the new domain
        DbPath = System.IO.Path.Join(path, "booklending.db");
    }

    // Configures EF Core to use SQLite for the specified database file.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

