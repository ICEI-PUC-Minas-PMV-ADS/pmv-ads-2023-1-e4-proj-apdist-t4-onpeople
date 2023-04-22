using OnPeople.Domain.Models.Departamentos;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Persistence.Interfaces.Contracts.Departamentos
{
    public interface IDepartamentosPersistence : ISharedPersistence
    {
        Task<IEnumerable<Departamento>> GetAllDepartamentosAsync();
        Task<Departamento> GetDepartamentoByIdAsync(int departamentoId);
        Task<IEnumerable<Departamento>> GetDepartamentosByEmpresaIdAsync(int empresaId);
    }
}