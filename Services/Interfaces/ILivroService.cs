using LaboratoriosRestAPI.DTOs;

namespace LaboratoriosRestAPI.Services.Interfaces;

public interface ILivroService
{
    Task<IEnumerable<LivroDTO.ReadLivroDto>> GetAllAsync();
    Task<LivroDTO.ReadLivroDto?> GetByIdAsync(int id);
    Task<IEnumerable<LivroDTO.ReadLivroDto>> GetByAutor(int id);
    Task<LivroDTO.ReadLivroDto> AddAsync(LivroDTO.CreateLivroDto dto);
    Task UpdateAsync(int id, LivroDTO.UpdateLivroDto dto);
    Task DeleteAsync(int id);
}