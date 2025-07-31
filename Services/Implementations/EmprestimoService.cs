using LaboratoriosRestAPI.Models;
using LaboratoriosRestAPI.Services.Interfaces;

namespace LaboratoriosRestAPI.Services.Implementations;

public class EmprestimoService: IEmprestimoService
{
    private readonly IEmprestimoRepository _emprestimoRepository;

    public EmprestimoService(IEmprestimoRepository emprestimoRepository)
    {
        _emprestimoRepository = emprestimoRepository;
    }

    public async Task<IEnumerable<Emprestimo>> GetAllAsync()
    {
        return await _emprestimoRepository.GetAllAsync();
    }

    public async Task<Emprestimo> GetByIdAsync(int id)
    {
        return await _emprestimoRepository.GetByIdAsybc(id);
    }

    public async Task AddAsync(Emprestimo emprestimo)
    {
        await _emprestimoRepository.AddAsync(emprestimo);
    }

    public async Task UpdateAsync(Emprestimo emprestimo)
    {
        await _emprestimoRepository.UpdateAsync(emprestimo);
    }

    public async Task DeleteAsync(int id)
    {
        await _emprestimoRepository.DeleteAsync(id);
    }
}