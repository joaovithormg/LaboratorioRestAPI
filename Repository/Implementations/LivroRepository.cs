namespace LaboratoriosRestAPI.Repository.Implementations;

using LaboratoriosRestAPI.Models;
using Microsoft.EntityFrameworkCore;

public class LivroRepository : ILivroRepository
{
    private readonly BookLendingContext _context;

    public LivroRepository(BookLendingContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Livro>> GetAllAsync()
    {
        return await _context.Livros.Include(l => l.Autores).ToListAsync();
    }

    public async Task<Livro?> GetByIdAsync(int id)
    {
        return await _context.Livros.Include(l => l.Autores).FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task AddAsync(Livro livro)
    {
        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Livro livro)
    {
        _context.Livros.Update(livro);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var livro = await _context.Livros.FindAsync(id);
        if (livro != null)
        {
            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
        }
    }
}
