using AutoMapper;
using LaboratoriosRestAPI.DTOs;
using LaboratoriosRestAPI.Models;
using LaboratoriosRestAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LaboratoriosRestAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LivroController : ControllerBase
{
    private readonly ILivroService _livroService;
    private readonly IMapper _mapper;

    public LivroController(ILivroService livroService, IMapper mapper)
    {
        _livroService = livroService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var livros = await _livroService.GetAllAsync();
        var livrosDto = _mapper.Map<List<LivroDTO.ReadLivroDto>>(livros);
        return Ok(livrosDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var livro = await _livroService.GetByIdAsync(id);
        if (livro == null) return NotFound();
        return Ok(_mapper.Map<LivroDTO.ReadLivroDto>(livro));
    }

    [HttpPost]
    public async Task<IActionResult> Create(LivroDTO.CreateLivroDto dto)
    {
        var livro = _mapper.Map<Livro>(dto);
        await _livroService.AddAsync(dto);
        var livroRead = _mapper.Map<LivroDTO.ReadLivroDto>(livro);
        return CreatedAtAction(nameof(GetById), new { id = livro.Id }, livroRead);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, LivroDTO.UpdateLivroDto dto)
    {
        var livro = await _livroService.GetByIdAsync(id);
        if (livro == null) return NotFound();

        _mapper.Map(dto, livro);
        await _livroService.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _livroService.DeleteAsync(id);
        return NoContent();
    }
}