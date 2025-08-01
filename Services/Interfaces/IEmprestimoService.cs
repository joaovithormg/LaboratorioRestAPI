using LaboratoriosRestAPI.DTOs;

namespace LaboratoriosRestAPI.Services.Interfaces;

public interface IEmprestimoService
{
    Task<IEnumerable<EmprestimoDTO.ReadEmprestimoDto>> GetAllAsync();
    Task<EmprestimoDTO.ReadEmprestimoDto?> GetByIdAsync(int id);
    Task<EmprestimoDTO.ReadEmprestimoDto> AddAsync(EmprestimoDTO.CreateEmprestimoDto dto);
    Task UpdateAsync(int id, EmprestimoDTO.UpdateEmprestimoDto dto);
    Task DeleteAsync(int id);
}