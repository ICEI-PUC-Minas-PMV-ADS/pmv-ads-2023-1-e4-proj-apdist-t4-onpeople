using OnPeople.Domain.Models.Empresas;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Persistence.Interfaces.Contracts.Empresas
{
    public interface IEmpresasPersistence: ISharedPersistence
    {
        Task<Empresa> GetEmpresaByIdAsync(int empresaId);
        Task<IEnumerable<Empresa>> GetAllEmpresasAsync(int empresaId, Boolean Master);
        Task<IEnumerable<Empresa>> GetAllEmpresasByArgumentoAsync(int empresaId, Boolean Master, string argumento);
        Task<IEnumerable<Empresa>> GetAllEmpresasAtivasAsync(int empresaId, Boolean Master );
        Task<IEnumerable<Empresa>> GetAllEmpresasFiliaisAsync(int empresaId, Boolean Master);
        Task<IEnumerable<Empresa>> GetAllEmpresasMatrizesAsync(int empresaId, Boolean Master);
        Task<Empresa> GetEmpresaByContaIdAsync(int empresaId, Boolean Master);
    }
}