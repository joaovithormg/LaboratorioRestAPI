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
        var livrosDto = await _livroService.GetAllAsync();
        return Ok(livrosDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var livro = await _livroService.GetByIdAsync(id);
        if (livro == null) return NotFound();
        return Ok(livro);
    }

    [HttpGet("livrosAutor/{id}")]
    public async Task<IActionResult> GetByLivroAutor(int id)
    {
        var livros = await _livroService.GetByAutor(id);
        if (livros == null) return NotFound();
        
        return Ok(livros);
    }

    [HttpPost]
    public async Task<IActionResult> Create(LivroDTO.CreateLivroDto dto)
    {
        var livroRead = await _livroService.AddAsync(dto);
        return StatusCode(201, livroRead);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, LivroDTO.UpdateLivroDto dto)
    {
        var livro = await _livroService.GetByIdAsync(id);
        if (livro == null) return NotFound();

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