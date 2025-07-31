using LaboratoriosRestAPI.Models;
using LaboratoriosRestAPI.Services.Interfaces;

namespace LaboratoriosRestAPI.Services.Implementations;

public class AutorService: IAutorService
{
    private readonly IAutorRepository _autorRepository;

    public AutorService(IAutorRepository autorRepository)
    {
        _autorRepository = autorRepository;
    }

    public async Task<IEnumerable<Autor>> GetAllAsync()
    {
        return await _autorRepository.GetAllAsync();
    }

    public async Task<Autor> GetByIdAsync(int id)
    {
        return await _autorRepository.GetByIdAsybc(id);
    }

    public async Task AddAsync(Autor autor)
    {
        await _autorRepository.AddAsync(autor);
    }

    public async Task UpdateAsync(Autor autor)
    {
        await _autorRepository.UpdateAsync(autor);
    }

    public async Task DeleteAsync(int id)
    {
        await _autorRepository.DeleteAsync(id);
    }
}