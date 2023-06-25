using OnPeople.Application.Dtos.Funcionarios;
using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;

namespace OnPeople.Application.Services.Contracts.Funcionarios
{
    public interface IFuncionariosServices
    {
        Task<ReadFuncionarioDto> CreateFuncionario(CreateFuncionarioDto model);
        Task<PageList<ReadFuncionarioDto>> GetAllFuncionarios(PageParameters pageParameters, int empresaId, int departamentoId, int cargoId);
        Task<ReadFuncionarioDto> GetFuncionarioById(int id);
        Task<Funcionario> UpdateFuncionario(int id, UpdateFuncionarioDto model);
        Task<bool> DeleteFuncionario(int id);
        Task<IEnumerable<ReadFuncionarioDto>> GetFuncionariosChefesByDepartamentoId(int departamentoId);
        Task<IEnumerable<ReadFuncionarioDto>> GetFuncionariosByCargoId(int cargoId);
        Task<DashboardFuncionarios> GetDashboardFuncionario(int empresaId, int departamentoId, int cargoId);
        Task<List<ListaMetas>> GetDashboardFuncionarioMetas(int empresaId, int departamentoId, int cargoId);
    }
}