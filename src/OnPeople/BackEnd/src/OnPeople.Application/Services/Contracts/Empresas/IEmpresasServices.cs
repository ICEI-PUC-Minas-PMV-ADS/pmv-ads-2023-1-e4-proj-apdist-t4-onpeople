using OnPeople.Application.Dtos.Empresas;

namespace OnPeople.Application.Services.Contracts.Empresas
{
    public interface IEmpresasServices
    {
        Task<EmpresaDto> CreateEmpresas(EmpresaDto empresaDto);
        Task<EmpresaDto> UpdateEmpresas(int id, EmpresaDto empresaDto);
        Task<bool> DeleteEmpresas(int id);
        Task<EmpresaDto> GetEmpresaByIdAsync(int id);
        Task<IEnumerable<EmpresaDto>> GetAllEmpresasAsync();
        Task<IEnumerable<EmpresaDto>> GetAllEmpreasByArgumentoAsync(string argumento);
        Task<IEnumerable<EmpresaDto>> GetAllEmpresasAtivasAsync();
        Task<IEnumerable<EmpresaDto>> GetAllEmpresasFiliaisAsync();
    }
}