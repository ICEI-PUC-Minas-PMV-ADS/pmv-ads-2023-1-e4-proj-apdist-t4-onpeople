using OnPeople.Domain.Models.Departamentos;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Persistence.Interfaces.Contracts.Departamentos
{
    public interface IDepartamentosEmpresasPersistence : ISharedPersistence
    {
         Task<IEnumerable<DepartamentoEmpresa>> GetAllDepartamentosByEmpresaIdAsync(int id);
         Task<IEnumerable<DepartamentoEmpresa>> GetAllEmpresasByDepartamentoIdAsync(int id);
    }
}