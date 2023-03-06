using OnPeople.Domain.Models.Empresas;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Persistence.Interfaces.Contracts.Empresas
{
    public interface IEmpresasDepartamentosPersistence : ISharedPersistence
    {
         Task<IEnumerable<EmpresaDepartamento>> GetAllDepartamentosByEmpresaIdAsync(int id);
         Task<IEnumerable<EmpresaDepartamento>> GetAllEmpresasByDepartamentoIdAsync(int id);
    }
}