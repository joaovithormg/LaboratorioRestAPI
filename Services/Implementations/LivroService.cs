using LaboratoriosRestAPI.Models;
using LaboratoriosRestAPI.Repository;
using LaboratoriosRestAPI.Services.Interfaces;

namespace LaboratoriosRestAPI.Services.Implementations;

public class LivroService: ILivroService
{
    private readonly ILivroRepository _livroRepository;

    public LivroService(ILivroRepository _livroRepository)
    {
        _livroRepository = _livroRepository;
    }

    public async Task<IEnumerable<Livro>> GetAllAsync()
    {
        return await _livroRepository.GetAllAsync();
    }

    public async Task<Livro> GetByIdAsync(int id)
    {
        return await _livroRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(Livro livro)
    {
        await _livroRepository.AddAsync(livro);
    }

    public async Task UpdateAsync(Livro livro)
    {
        await _livroRepository.UpdateAsync(livro);
    }

    public async Task DeleteAsync(int id)
    {
        await _livroRepository.DeleteAsync(id);
    }
}