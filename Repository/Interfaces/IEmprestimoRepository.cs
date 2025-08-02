namespace LaboratoriosRestAPI.Repository;

using LaboratoriosRestAPI.Models;

public interface IEmprestimoRepository
{
    Task<IEnumerable<Emprestimo>> GetAllAsync();
    Task<Emprestimo?> GetByIdAsync(int id);
    Task<Emprestimo?> GetByBookIdAsync(int id);
    Task AddAsync(Emprestimo emprestimo, int id);
    Task UpdateAsync(Emprestimo emprestimo);
    Task DeleteAsync(int id);
}
