using OnPeople.Application.Dtos.Empresas;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;

namespace OnPeople.Application.Services.Contracts.Empresas
{
    public interface IEmpresasServices
    {
        Task<EmpresaDto> CreateEmpresas(int empresaId, Boolean Master, EmpresaDto empresaDto);
        Task<EmpresaDto> UpdateEmpresa(int empresaId, EmpresaDto empresaDto);
        Task<bool> DeleteEmpresas(int empresaId);
        Task<EmpresaDto> GetEmpresaByIdAsync(int empresaId);
        Task<PageList<EmpresaDto>> GetAllEmpresasAsync(PageParameters pageParameters, int empresaId, Boolean Master);
        Task<PageList<EmpresaDto>> GetAllEmpresasAtivasAsync(PageParameters pageParameters, int empresaId, Boolean Master);
        Task<PageList<EmpresaDto>> GetAllEmpresasFiliaisAsync(PageParameters pageParameters, int empresaId, Boolean Master);
        Task<EmpresaDto> GetEmpresaMatrizAsync();
        Task<AtualizarEmpresaAtivaDto> SetEmpresa(int empresaId, AtualizarEmpresaAtivaDto atualizarEmpresaAtivaDto);
        DashboardEmpresa GetDashboard(int empresaId, Boolean master);  
        Task<EmpresaDto> GetEmpresaByCnpjAsync(string cnpj, Boolean master);      
    }
}