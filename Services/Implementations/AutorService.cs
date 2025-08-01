using AutoMapper;
using LaboratoriosRestAPI.DTOs;
using LaboratoriosRestAPI.Models;
using LaboratoriosRestAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LaboratoriosRestAPI.Services;

public class AutorService : IAutorService
{
    private readonly BookLendingContext _context;
    private readonly IMapper _mapper;

    public AutorService(BookLendingContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AutorDTO.ReadAutorDto>> GetAllAsync()
    {
        var autores = await _context.Autores.ToListAsync();
        return _mapper.Map<List<AutorDTO.ReadAutorDto>>(autores);
    }

    public async Task<AutorDTO.ReadAutorDto?> GetByIdAsync(int id)
    {
        var autor = await _context.Autores.FindAsync(id);
        return autor == null ? null : _mapper.Map<AutorDTO.ReadAutorDto>(autor);
    }

    public async Task<AutorDTO.ReadAutorDto> AddAsync(AutorDTO.CreateAutorDto dto)
    {
        var autor = _mapper.Map<Autor>(dto);
        _context.Autores.Add(autor);
        await _context.SaveChangesAsync();
        return _mapper.Map<AutorDTO.ReadAutorDto>(autor);
    }

    public async Task UpdateAsync(int id, AutorDTO.UpdateAutorDto dto)
    {
        var autor = await _context.Autores.FindAsync(id);
        if (autor == null) throw new Exception("Autor não encontrado");

        _mapper.Map(dto, autor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var autor = await _context.Autores.FindAsync(id);
        if (autor == null) throw new Exception("Autor não encontrado");

        _context.Autores.Remove(autor);
        await _context.SaveChangesAsync();
    }
}