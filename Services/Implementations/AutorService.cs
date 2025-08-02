using AutoMapper;
using LaboratoriosRestAPI.DTOs;
using LaboratoriosRestAPI.Models;
using LaboratoriosRestAPI.Repository;
using LaboratoriosRestAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LaboratoriosRestAPI.Services;

public class AutorService : IAutorService
{
    private readonly IMapper _mapper;
    private readonly IAutorRepository  _repository;

    public AutorService(IAutorRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IEnumerable<AutorDTO.ReadAutorDto>> GetAllAsync()
    {
        var autores = await _repository.GetAllAsync();
        return _mapper.Map<List<AutorDTO.ReadAutorDto>>(autores);
    }

    public async Task<AutorDTO.ReadAutorDto?> GetByIdAsync(int id)
    {
        var autor = await _repository.GetByIdAsync(id);
        return autor == null ? null : _mapper.Map<AutorDTO.ReadAutorDto>(autor);
    }

    public async Task<AutorDTO.ReadAutorDto> AddAsync(AutorDTO.CreateAutorDto dto)
    {
        var autor = _mapper.Map<Autor>(dto);
        await _repository.AddAsync(autor);
        return _mapper.Map<AutorDTO.ReadAutorDto>(autor);
    }

    public async Task UpdateAsync(int id, AutorDTO.UpdateAutorDto dto)
    {
        var autor = await _repository.GetByIdAsync(id);
        if (autor == null) throw new Exception("Autor não encontrado");

        _mapper.Map(dto, autor);
        await _repository.UpdateAsync(autor);
    }

    public async Task DeleteAsync(int id)
    {
        var autor = await _repository.GetByIdAsync(id);
        if (autor == null) throw new Exception("Autor não encontrado");

        await _repository.DeleteAsync(id);
    }
}