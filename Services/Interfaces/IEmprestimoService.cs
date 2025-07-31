using LaboratoriosRestAPI.Models;

namespace LaboratoriosRestAPI.Services.Interfaces;

public interface IEmprestimoService
{
    Task<IEnumerable<Emprestimo>> GetAllAsync();
    Task<Emprestimo?> GetByIdAsync(int id);
    Task AddAsync(Emprestimo emprestimo);
    Task UpdateAsync(Emprestimo emprestimo);
    Task DeleteAsync(int id);
}