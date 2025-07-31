using LaboratoriosRestAPI.Models;

namespace LaboratoriosRestAPI.Services.Interfaces;

public interface ILivroService
{
    Task<IEnumerable<Livro>> GetAllAsync();
    Task<Livro?> GetByIdAsync(int id);
    Task AddAsync(Livro livro);
    Task UpdateAsync(Livro livro);
    Task DeleteAsync(int id);
}