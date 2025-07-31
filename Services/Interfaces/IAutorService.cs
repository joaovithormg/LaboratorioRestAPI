using LaboratoriosRestAPI.Models;

namespace LaboratoriosRestAPI.Services.Interfaces;

public interface IAutorService
{
    Task<IEnumerable<Autor>> GetAllAsync();
    Task<Autor?> GetByIdAsync(int id);
    Task AddAsync(Autor autor);
    Task UpdateAsync(Autor autor);
    Task DeleteAsync(int id);
}