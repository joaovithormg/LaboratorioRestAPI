namespace LaboratoriosRestAPI.Repository.Implementations;

using LaboratoriosRestAPI.Models;
using Microsoft.EntityFrameworkCore;

public class EmprestimoRepository : IEmprestimoRepository
{
    private readonly BookLendingContext _context;

    public EmprestimoRepository(BookLendingContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Emprestimo>> GetAllAsync()
    {
        return await _context.Emprestimos
            .Include(e => e.Livro)
            .Include(e => e.Livro.Autores)
            .ToListAsync();
    }

    public async Task<Emprestimo?> GetByIdAsync(int id)
    {
        return await _context.Emprestimos
            .Include(e => e.Livro)
            .Include(e => e.Livro.Autores)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task AddAsync(Emprestimo emprestimo, int id)
    {
        var livro = await _context.Livros.FindAsync(id);

        if (livro != null)
        {
            emprestimo.Livro = livro;
        }
        _context.Emprestimos.Add(emprestimo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Emprestimo emprestimo)
    {
        _context.Emprestimos.Update(emprestimo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var emprestimo = await _context.Emprestimos.FindAsync(id);
        if (emprestimo != null)
        {
            _context.Emprestimos.Remove(emprestimo);
            await _context.SaveChangesAsync();
        }
    }
}
