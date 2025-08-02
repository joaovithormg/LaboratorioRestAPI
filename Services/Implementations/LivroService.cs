using AutoMapper;
using LaboratoriosRestAPI.DTOs;
using LaboratoriosRestAPI.Models;
using LaboratoriosRestAPI.Repository;
using LaboratoriosRestAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LaboratoriosRestAPI.Services;

public class LivroService : ILivroService
{
    private readonly ILivroRepository _repository;
    private readonly IMapper _mapper;

    public LivroService(ILivroRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LivroDTO.ReadLivroDto>> GetAllAsync()
    {
        var livros = await _repository.GetAllAsync();

        return _mapper.Map<List<LivroDTO.ReadLivroDto>>(livros);
    }

    public async Task<LivroDTO.ReadLivroDto?> GetByIdAsync(int id)
    {
        var livro = await _repository.GetByIdAsync(id);

        return livro == null ? null : _mapper.Map<LivroDTO.ReadLivroDto>(livro);
    }

    public async Task<IEnumerable<LivroDTO.ReadLivroDto>> GetByAutor(int id)
    {
        var livros = await  _repository.GetByAutor(id);
        return _mapper.Map<List<LivroDTO.ReadLivroDto>>(livros);
    }
    public async Task<LivroDTO.ReadLivroDto> AddAsync(LivroDTO.CreateLivroDto dto)
    {
        var livro = _mapper.Map<Livro>(dto);

        await _repository.AddAsync(livro, dto.AutoresIds);

        return _mapper.Map<LivroDTO.ReadLivroDto>(livro);
    }


    public async Task UpdateAsync(int id, LivroDTO.UpdateLivroDto dto)
    {
        var livro = await _repository.GetByIdAsync(id);

        if (livro == null)
            throw new Exception("Livro não encontrado");

        _mapper.Map(dto, livro);

        await _repository.UpdateAsync(livro, dto.AutoresIds);
    }


    public async Task DeleteAsync(int id)
    {
        var livro = await _repository.GetByIdAsync(id);
        if (livro == null)
            throw new Exception("Livro não encontrado");

        await _repository.DeleteAsync(id);
    }
}
