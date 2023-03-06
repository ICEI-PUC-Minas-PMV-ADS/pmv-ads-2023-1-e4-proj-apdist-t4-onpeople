using OnPeople.Domain.Models.Empresas;

namespace OnPeople.Application.Services.Contracts.Empresas
{
    public interface IEmpresasServices
    {
        Task<Empresa> CreateEmpresas(Empresa model);
        Task<Empresa> UpdateEmpresas(int id, Empresa model);
        Task<bool> DeleteEmpresas(int id);
        Task<Empresa> GetEmpresaByIdAsync(int id);
        Task<IEnumerable<Empresa>> GetAllEmpresasAsync();
        Task<IEnumerable<Empresa>> GetAllEmpreasByArgumentoAsync(string argumento);
        Task<IEnumerable<Empresa>> GetAllEmpresasAtivasAsync();
        Task<IEnumerable<Empresa>> GetAllEmpresasFiliaisAsync();
    }
}