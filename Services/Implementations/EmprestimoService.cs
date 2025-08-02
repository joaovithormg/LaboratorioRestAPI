using AutoMapper;
using LaboratoriosRestAPI.DTOs;
using LaboratoriosRestAPI.Models;
using LaboratoriosRestAPI.Repository;
using LaboratoriosRestAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LaboratoriosRestAPI.Services;

public class EmprestimoService : IEmprestimoService
{
    private readonly IEmprestimoRepository _repository;
    private readonly IMapper _mapper;

    public EmprestimoService(IEmprestimoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmprestimoDTO.ReadEmprestimoDto>> GetAllAsync()
    {
        var emprestimos = await _repository.GetAllAsync();
        return _mapper.Map<List<EmprestimoDTO.ReadEmprestimoDto>>(emprestimos);
    }

    public async Task<EmprestimoDTO.ReadEmprestimoDto?> GetByIdAsync(int id)
    {
        var emprestimo = await _repository.GetByIdAsync(id);
        return emprestimo == null ? null : _mapper.Map<EmprestimoDTO.ReadEmprestimoDto>(emprestimo);
    }

    public async Task<EmprestimoDTO.ReadEmprestimoDto> AddAsync(EmprestimoDTO.CreateEmprestimoDto dto)
    {
        var emprestimo = _mapper.Map<Emprestimo>(dto);
        _repository.AddAsync(emprestimo, dto.LivroId);
        
        return _mapper.Map<EmprestimoDTO.ReadEmprestimoDto>(emprestimo);
    }

    public async Task UpdateAsync(int id, EmprestimoDTO.UpdateEmprestimoDto dto)
    {
        var emprestimo = await _repository.GetByIdAsync(id);
        if (emprestimo == null)
            throw new Exception("Empréstimo não encontrado.");

        _mapper.Map(dto, emprestimo);
        await _repository.UpdateAsync(emprestimo);
    }

    public async Task DeleteAsync(int id)
    {
        var emprestimo = await _repository.GetByIdAsync(id);
        if (emprestimo == null)
            throw new Exception("Empréstimo não encontrado.");

        await _repository.DeleteAsync(id);
    }
}