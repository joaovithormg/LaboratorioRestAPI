namespace LaboratoriosRestAPI.Repository.Implementations;

using LaboratoriosRestAPI.Models;
using Microsoft.EntityFrameworkCore;

public class AutorRepository : IAutorRepository
{
    private readonly BookLendingContext _context;

    public AutorRepository(BookLendingContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Autor>> GetAllAsync()
    {
        return await _context.Autores.Include(a => a.Livros).ToListAsync();
    }

    public async Task<Autor?> GetByIdAsync(int id)
    {
        return await _context.Autores.Include(a => a.Livros).FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task AddAsync(Autor autor)
    {
        _context.Autores.Add(autor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Autor autor)
    {
        _context.Autores.Update(autor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var autor = await _context.Autores.FindAsync(id);
        if (autor != null)
        {
            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();
        }
    }
}
