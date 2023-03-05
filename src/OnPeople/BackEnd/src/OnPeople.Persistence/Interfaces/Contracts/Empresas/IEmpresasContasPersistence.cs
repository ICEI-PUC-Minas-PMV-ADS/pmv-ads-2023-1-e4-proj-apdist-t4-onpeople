using OnPeople.Domain.Models.Empresas;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Persistence.Interfaces.Contracts.Empresas
{
    public interface IEmpresasContasPersistence : ISharedPersistence
    {
         Task<IEnumerable<EmpresaConta>> GetAllContasByEmpresaIdAsync(int id);
         Task<IEnumerable<EmpresaConta>> GetAllEmpresasByContaIdAsync(int id);
    }
}