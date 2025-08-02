namespace LaboratoriosRestAPI.Repository;

using LaboratoriosRestAPI.Models;

public interface ILivroRepository
{
    Task<IEnumerable<Livro>> GetAllAsync();
    Task<Livro?> GetByIdAsync(int id);
    Task<IEnumerable<Livro>> GetByAutor(int id);
    Task AddAsync(Livro livro, List<int> autoresIds);
    Task UpdateAsync(Livro livro, List<int> autoresIds);
    Task DeleteAsync(int id);
}