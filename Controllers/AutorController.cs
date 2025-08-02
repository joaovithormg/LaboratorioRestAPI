using AutoMapper;
using LaboratoriosRestAPI.DTOs;
using LaboratoriosRestAPI.Models;
using LaboratoriosRestAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LaboratoriosRestAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutorController : ControllerBase
{
    private readonly IAutorService _service;
    private readonly IMapper _mapper;

    public AutorController(IAutorService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var autores = await _service.GetAllAsync();
        return Ok(autores);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var autor = await _service.GetByIdAsync(id);
        if (autor == null) return NotFound();
        return Ok(_mapper.Map<AutorDTO.ReadAutorDto>(autor));
    }

    [HttpPost]
    public async Task<IActionResult> Create(AutorDTO.CreateAutorDto dto)
    {
        var autor = _mapper.Map<Autor>(dto);
        await _service.AddAsync(dto);
        var autorRead = _mapper.Map<AutorDTO.ReadAutorDto>(autor);
        return StatusCode(201, autorRead);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, AutorDTO.UpdateAutorDto dto)
    {
        if (id == 0) return BadRequest();
        var autor = await _service.GetByIdAsync(id);
        if (autor == null) return NotFound();

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