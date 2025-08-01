using AutoMapper;
using LaboratoriosRestAPI.DTOs;
using LaboratoriosRestAPI.Models;
using LaboratoriosRestAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LaboratoriosRestAPI.Services;

public class EmprestimoService : IEmprestimoService
{
    private readonly BookLendingContext _context;
    private readonly IMapper _mapper;

    public EmprestimoService(BookLendingContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmprestimoDTO.ReadEmprestimoDto>> GetAllAsync()
    {
        var emprestimos = await _context.Emprestimos
            .Include(e => e.Livro)
            .Include(e => e.Livro.Autores)
            .ToListAsync();
        return _mapper.Map<List<EmprestimoDTO.ReadEmprestimoDto>>(emprestimos);
    }

    public async Task<EmprestimoDTO.ReadEmprestimoDto?> GetByIdAsync(int id)
    {
        var emprestimo = await _context.Emprestimos
            .Include(e => e.Livro)
            .Include(e => e.Livro.Autores)
            .FirstOrDefaultAsync(e => e.Id == id);
        return emprestimo == null ? null : _mapper.Map<EmprestimoDTO.ReadEmprestimoDto>(emprestimo);
    }

    public async Task<EmprestimoDTO.ReadEmprestimoDto> AddAsync(EmprestimoDTO.CreateEmprestimoDto dto)
    {
        var emprestimo = _mapper.Map<Emprestimo>(dto);
        emprestimo.Livro = await _context.Livros.FindAsync(dto.LivroId);

        _context.Emprestimos.Add(emprestimo);
        await _context.SaveChangesAsync();

        return _mapper.Map<EmprestimoDTO.ReadEmprestimoDto>(emprestimo);
    }

    public async Task UpdateAsync(int id, EmprestimoDTO.UpdateEmprestimoDto dto)
    {
        var emprestimo = await _context.Emprestimos.FindAsync(id);
        if (emprestimo == null)
            throw new Exception("Empréstimo não encontrado.");

        _mapper.Map(dto, emprestimo);

        emprestimo.Livro = await _context.Livros.FindAsync(id);

        _context.Emprestimos.Update(emprestimo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var emprestimo = await _context.Emprestimos.FindAsync(id);
        if (emprestimo == null)
            throw new Exception("Empréstimo não encontrado.");

        _context.Emprestimos.Remove(emprestimo);
        await _context.SaveChangesAsync();
    }
}