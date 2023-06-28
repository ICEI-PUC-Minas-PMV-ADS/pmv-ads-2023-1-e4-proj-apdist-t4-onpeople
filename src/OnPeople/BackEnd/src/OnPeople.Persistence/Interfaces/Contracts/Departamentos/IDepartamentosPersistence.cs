using OnPeople.Domain.Models.Departamentos;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Persistence.Interfaces.Contracts.Departamentos
{
    public interface IDepartamentosPersistence : ISharedPersistence
    {
        Task<Departamento> GetDepartamentoByIdAsync(int departamentoId);
        Task<PageList<Departamento>> GetAllDepartamentosAsync(PageParameters pageParameters, int empresaId, int departamentoId, bool Master);
        Task<IEnumerable<Departamento>> GetAllDepartamentosByEmpresaIdAsync(int empresaId);
    }
}