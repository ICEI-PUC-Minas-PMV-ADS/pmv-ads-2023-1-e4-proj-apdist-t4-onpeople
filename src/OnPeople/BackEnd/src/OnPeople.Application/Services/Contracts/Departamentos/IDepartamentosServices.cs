using OnPeople.Application.Dtos.Departamentos;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;

namespace OnPeople.Application.Services.Contracts.Departamentos
{
    public interface IDepartamentosServices
    {
        Task<PageList<DepartamentoDto>> GetAllDepartamentosAsync(PageParameters pageParameters, int empresaId, bool Master);
        Task<IEnumerable<DepartamentoDto>> GetAllDepartamentosByEmpresaIdAsync(int empresaId);
        Task<DepartamentoDto> GetDepartamentoByIdAsync(int departamentoId);
        Task<DepartamentoDto> CreateDepartamentos(DepartamentoDto departamentoDto);
        Task<DepartamentoDto> UpdateDepartamento(int departamentoId, DepartamentoDto departamentoDto);
        Task<bool> DeleteDepartamento(int departamentoId);
        Task<DashboardDepartamento> GetDashboardDepartamento(int empresaId, Boolean master);
        Task<List<ListaMetas>> GetDashboardDepartamentoMetas(int empresaId, bool master);
    }
}