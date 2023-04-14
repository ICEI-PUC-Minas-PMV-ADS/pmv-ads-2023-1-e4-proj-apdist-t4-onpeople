using OnPeople.Application.Dtos.Departamentos;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Integration.Models.Pages.Page;

namespace OnPeople.Application.Services.Contracts.Departamentos
{
    public interface IDepartamentosServices
    {
        Task<DepartamentoDto> CreateDepartamentos(DepartamentoDto departamentoDto);
        Task<PageList<DepartamentoDto>> GetAllDepartamentosAsync();
        Task<DepartamentoDto> GetDepartamentoByIdAsync(int departamentoId);
        Task<DepartamentoDto> UpdateDepartamento(int departamentoId, DepartamentoDto DepartamentoDto);
        Task<bool> DeleteDepartamento(int departamentoId);
    }
}