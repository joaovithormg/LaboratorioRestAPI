using LaboratoriosRestAPI.Services.Interfaces;

namespace LaboratoriosRestAPI.Controllers;

using LaboratoriosRestAPI.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LivroController : ControllerBase
{
    private readonly ILivroService _livroService;

    public LivroController(ILivroService livroService)
    {
        _livroService = livroService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Livro>>> GetAll()
    {
        var livros = await _livroService.GetAllAsync();
        return Ok(livros);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Livro>> GetById(int id)
    {
        var livro = await _livroService.GetByIdAsync(id);
        if (livro == null) return NotFound();
        return Ok(livro);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Livro livro)
    {
        await _livroService.AddAsync(livro);
        return CreatedAtAction(nameof(GetById), new { id = livro.Id }, livro);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Livro livro)
    {
        if (id != livro.Id) return BadRequest();
        await _livroService.UpdateAsync(livro);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _livroService.DeleteAsync(id);
        return NoContent();
    }
}
