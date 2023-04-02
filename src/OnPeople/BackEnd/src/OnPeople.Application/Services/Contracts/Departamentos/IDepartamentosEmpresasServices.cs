using OnPeople.Domain.Models.Departamentos;

namespace OnPeople.Application.Services.Contracts.Departamentos
{
    public interface IDepartamentosEmpresasServices
    {
        Task<IEnumerable<DepartamentoEmpresa>> GetAllDepartamentosByEmpresaIdAsync(int id);
        Task<IEnumerable<DepartamentoEmpresa>> GetAllEmpresasByDepartamentoIdAsync(int id);
    }
}