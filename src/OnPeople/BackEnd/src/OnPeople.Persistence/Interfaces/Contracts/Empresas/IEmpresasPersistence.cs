using OnPeople.Domain.Models.Empresas;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Persistence.Interfaces.Contracts.Shared;


namespace OnPeople.Persistence.Interfaces.Contracts.Empresas
{
    public interface IEmpresasPersistence: ISharedPersistence
    {
        Task<Empresa> GetEmpresaByIdAsync(int empresaId);
        Task<PageList<Empresa>> GetAllEmpresasAsync(PageParameters pageParameters, int empresaId, Boolean Master);
        Task<PageList<Empresa>> GetAllEmpresasAtivasAsync(PageParameters pageParameters, int empresaId, Boolean Master );
        Task<PageList<Empresa>> GetAllEmpresasFiliaisAsync(PageParameters pageParameters, int empresaId, Boolean Master);
        Task<Empresa> GetEmpresaMatrizAsync();
        Task<Empresa> GetEmpresaByContaIdAsync(int empresaId, Boolean Master);
        DashboardEmpresa GetDashboard(int empresaId, Boolean master);
        Task<Empresa> GetEmpresaByCnpjAsync(string cnpj, Boolean Master);
    }
}