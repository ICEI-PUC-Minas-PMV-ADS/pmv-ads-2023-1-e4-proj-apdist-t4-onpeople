

using OnPeople.Domain.Models.Metas;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;

namespace OnPeople.Application.Services.Contracts.Metas
{
    public interface IMetasService
    {
        Task<MetaDto> CreateMetas(MetaDto model);
        Task<MetaDto> UpdateMeta(int metaId, MetaDto model);
        Task<bool> DeleteMeta(int metaId);

        Task<PageList<MetaDto>> GetAllMetasAsync(PageParameters pageParameters, int empresaId);
        Task<IEnumerable<MetaDto>> GetAllMetasByTipoAsync(string tipoMeta);
        Task<IEnumerable<MetaDto>> GetAllMetasByEmpresaIdAsync(int empresaId);
        Task<MetaDto> GetMetaByIdAsync(int metaId);
        DashboardMetas GetDashboard(int empresaId);
    }
}