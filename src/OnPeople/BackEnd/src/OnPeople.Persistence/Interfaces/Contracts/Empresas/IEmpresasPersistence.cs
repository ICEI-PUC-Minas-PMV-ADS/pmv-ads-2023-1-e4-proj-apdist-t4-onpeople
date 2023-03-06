using OnPeople.Domain.Models.Empresas;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Persistence.Interfaces.Contracts.Empresas
{
    public interface IEmpresasPersistence: ISharedPersistence
    {
        Task<Empresa> GetEmpresaByIdAsync(int id);
        Task<IEnumerable<Empresa>> GetAllEmpresasAsync();
        Task<IEnumerable<Empresa>> GetAllEmpresasByArgumentoAsync(string argumento);
        Task<IEnumerable<Empresa>> GetAllEmpresasAtivasAsync();
        Task<IEnumerable<Empresa>> GetAllEmpresasFiliaisAsync();
    }
}