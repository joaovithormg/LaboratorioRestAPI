using AutoMapper;
using LaboratoriosRestAPI.DTOs;
using LaboratoriosRestAPI.Models;
using LaboratoriosRestAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LaboratoriosRestAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmprestimoController : ControllerBase
{
    private readonly IEmprestimoService _service;
    private readonly IMapper _mapper;

    public EmprestimoController(IEmprestimoService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var emprestimos = await _service.GetAllAsync();
        var emprestimosDto = _mapper.Map<List<EmprestimoDTO.ReadEmprestimoDto>>(emprestimos);
        return Ok(emprestimosDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var emp = await _service.GetByIdAsync(id);
        if (emp == null) return NotFound();
        return Ok(_mapper.Map<EmprestimoDTO.ReadEmprestimoDto>(emp));
    }

    [HttpGet("emprestimoLivro/{id}")]
    public async Task<IActionResult> GetEmprestimoLivro(int id)
    {
        var emp = await _service.GetByBookIdAsync(id);
        if (emp == null) return NotFound();
        return Ok(_mapper.Map<EmprestimoDTO.ReadEmprestimoDto>(emp));
    }

    [HttpPost]
    public async Task<IActionResult> Create(EmprestimoDTO.CreateEmprestimoDto dto)
    {
        var emp = _mapper.Map<Emprestimo>(dto);
        await _service.AddAsync(dto);
        var empRead = _mapper.Map<EmprestimoDTO.ReadEmprestimoDto>(emp);
        return StatusCode(201, empRead);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, EmprestimoDTO.UpdateEmprestimoDto dto)
    {
        var emp = await _service.GetByIdAsync(id);
        if (emp == null) return NotFound();

        _mapper.Map(dto, emp);
        await _service.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}