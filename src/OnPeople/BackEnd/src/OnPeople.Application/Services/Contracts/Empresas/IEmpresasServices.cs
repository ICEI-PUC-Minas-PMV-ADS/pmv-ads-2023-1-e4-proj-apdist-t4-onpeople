using OnPeople.Application.Dtos.Empresas;

namespace OnPeople.Application.Services.Contracts.Empresas
{
    public interface IEmpresasServices
    {
        Task<EmpresaDto> CreateEmpresas(int empresaId, Boolean Master, EmpresaDto empresaDto);
        Task<EmpresaDto> UpdateEmpresa(int empresaId, EmpresaDto empresaDto);
        Task<bool> DeleteEmpresas(int empresaId);
        Task<EmpresaDto> GetEmpresaByIdAsync(int empresaId);
        Task<IEnumerable<EmpresaDto>> GetAllEmpresasAsync(int empresaId, Boolean Master);
        Task<IEnumerable<EmpresaDto>> GetAllEmpreasByArgumentoAsync(int empresaId, Boolean Master, string argumento);
        Task<IEnumerable<EmpresaDto>> GetAllEmpresasAtivasAsync(int empresaId, Boolean Master);
        Task<IEnumerable<EmpresaDto>> GetAllEmpresasFiliaisAsync(int empresaId, Boolean Master);
        Task<EmpresaDto> GetEmpresaMatrizAsync();
    }
}