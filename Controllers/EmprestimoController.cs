namespace LaboratoriosRestAPI.Controllers;

using LaboratoriosRestAPI.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EmprestimoController : ControllerBase
{
    private readonly IEmprestimoService _service;

    public EmprestimoController(IEmprestimoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var emp = await _service.GetByIdAsync(id);
        return emp == null ? NotFound() : Ok(emp);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Emprestimo emp)
    {
        await _service.AddAsync(emp);
        return CreatedAtAction(nameof(GetById), new { id = emp.Id }, emp);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Emprestimo emp)
    {
        if (id != emp.Id) return BadRequest();
        await _service.UpdateAsync(emp);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
