using AutoMapper;
using LaboratoriosRestAPI.DTOs;
using LaboratoriosRestAPI.Models;
using LaboratoriosRestAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LaboratoriosRestAPI.Services;

public class LivroService : ILivroService
{
    private readonly BookLendingContext _context;
    private readonly IMapper _mapper;

    public LivroService(BookLendingContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LivroDTO.ReadLivroDto>> GetAllAsync()
    {
        var livros = await _context.Livros
            .Include(l => l.Autores)
            .ToListAsync();

        return _mapper.Map<List<LivroDTO.ReadLivroDto>>(livros);
    }

    public async Task<LivroDTO.ReadLivroDto?> GetByIdAsync(int id)
    {
        var livro = await _context.Livros
            .Include(l => l.Autores)
            .FirstOrDefaultAsync(l => l.Id == id);

        return livro == null ? null : _mapper.Map<LivroDTO.ReadLivroDto>(livro);
    }

    public async Task<LivroDTO.ReadLivroDto> AddAsync(LivroDTO.CreateLivroDto dto)
    {
        var livro = _mapper.Map<Livro>(dto);

        if (dto.AutoresIds != null && dto.AutoresIds.Any())
        {
            livro.Autores = await _context.Autores
                .Where(a => dto.AutoresIds.Contains(a.Id))
                .ToListAsync();
        }

        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();

        return _mapper.Map<LivroDTO.ReadLivroDto>(livro);
    }

    public async Task UpdateAsync(int id, LivroDTO.UpdateLivroDto dto)
    {
        var livro = await _context.Livros
            .Include(l => l.Autores)
            .FirstOrDefaultAsync(l => l.Id == id);

        if (livro == null)
            throw new Exception("Livro não encontrado");

        _mapper.Map(dto, livro);

        if (dto.AutoresIds != null)
        {
            livro.Autores = await _context.Autores
                .Where(a => dto.AutoresIds.Contains(a.Id))
                .ToListAsync();
        }

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var livro = await _context.Livros.FindAsync(id);
        if (livro == null)
            throw new Exception("Livro não encontrado");

        _context.Livros.Remove(livro);
        await _context.SaveChangesAsync();
    }
}
