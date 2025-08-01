using LaboratoriosRestAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LaboratoriosRestAPI
{
    public class BookLendingContext : DbContext
    {
        public BookLendingContext(DbContextOptions<BookLendingContext> options)
            : base(options) { }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
    }
}