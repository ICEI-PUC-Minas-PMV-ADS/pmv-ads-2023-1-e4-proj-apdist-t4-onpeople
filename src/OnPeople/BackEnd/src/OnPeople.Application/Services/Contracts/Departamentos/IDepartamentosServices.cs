using OnPeople.Application.Dtos.Departamentos;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Integration.Models.Pages.Page;

namespace OnPeople.Application.Services.Contracts.Departamentos
{
    public interface IDepartamentosServices
    {
        Task<PageList<DepartamentoDto>> GetAllDepartamentosAsync();
        Task<DepartamentoDto> GetDepartamentoByIdAsync(int departamentoId);
        Task<PageList<DepartamentoDto>> GetDepartamentosByEmpresaIdAsync(int empresaId);
        Task<DepartamentoDto> CreateDepartamentos(DepartamentoDto departamentoDto);
        Task<DepartamentoDto> UpdateDepartamento(int departamentoId, DepartamentoDto departamentoDto);
        Task<bool> DeleteDepartamento(int departamentoId);
    }
}