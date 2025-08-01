using LaboratoriosRestAPI.DTOs;

namespace LaboratoriosRestAPI.Services.Interfaces;

public interface IAutorService
{
    Task<IEnumerable<AutorDTO.ReadAutorDto>> GetAllAsync();
    Task<AutorDTO.ReadAutorDto?> GetByIdAsync(int id);
    Task<AutorDTO.ReadAutorDto> AddAsync(AutorDTO.CreateAutorDto dto);
    Task UpdateAsync(int id, AutorDTO.UpdateAutorDto dto);
    Task DeleteAsync(int id);
}