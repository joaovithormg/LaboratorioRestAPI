namespace LaboratoriosRestAPI.Repository;

using LaboratoriosRestAPI.Models;

public interface IAutorRepository
{
    Task<IEnumerable<Autor>> GetAllAsync();
    Task<Autor?> GetByIdAsync(int id);
    Task AddAsync(Autor autor);
    Task UpdateAsync(Autor autor);
    Task DeleteAsync(int id);
}
