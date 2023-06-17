using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Integration.Models.Dashboard;

namespace OnPeople.Application.Services.Contracts.Funcionarios
{
    public interface IFuncionariosMetasServices
    {
        Task<FuncionarioMetaDto> CreateFuncionarioMeta(FuncionarioMetaDto funcionarioMetaDto);
        Task<bool> DeleteFuncionarioMeta(int funcionarioMetaId);
        Task<FuncionarioMeta> UpdateFuncionarioMeta(int id, FuncionarioMetaDto funcionarioMetaDto);
        Task<IEnumerable<FuncionarioMetaDto>> GetAllFuncionariosByMetaIdAsync(int metaId);
        Task<IEnumerable<FuncionarioMetaDto>> GetAllMetasByFuncionarioIdAsync(int funcionarioId);
        Task<FuncionarioMetaDto> GetFuncionarioMetaByIdAsync(int funcionarioMetaId);
        Task<FuncionarioMetaDto> GetFuncionarioMetaByIdsAsync(int funcionarioId, int metaId);
        Task<bool> VerifyFuncionarioMetaExistsAsync(int funcionarioId, int metaId);
        DashboardFuncionariosMetas GetDashboard(int funcionarioId);  
    }
}