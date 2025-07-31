namespace LaboratoriosRestAPI.Controllers;

using LaboratoriosRestAPI.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AutorController : ControllerBase
{
    private readonly IAutorService _service;

    public AutorController(IAutorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var autor = await _service.GetByIdAsync(id);
        return autor == null ? NotFound() : Ok(autor);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Autor autor)
    {
        await _service.AddAsync(autor);
        return CreatedAtAction(nameof(GetById), new { id = autor.Id }, autor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Autor autor)
    {
        if (id != autor.Id) return BadRequest();
        await _service.UpdateAsync(autor);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
