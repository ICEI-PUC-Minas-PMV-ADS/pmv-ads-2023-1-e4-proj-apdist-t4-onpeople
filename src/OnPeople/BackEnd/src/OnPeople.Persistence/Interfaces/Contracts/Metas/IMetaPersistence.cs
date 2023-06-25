using OnPeople.Domain.Models.Metas;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Persistence.Interfaces.Contracts.Metas
{
    public interface IMetaPersistence: ISharedPersistence
    {
        Task<PageList<Meta>> GetAllMetasAsync(PageParameters pageParameters, int empresaId);
        Task<Meta> GetMetaByIdAsync(int id);
        Task<IEnumerable<Meta>> GetAllMetasByTipoAsync(string tipoMeta);
        Task<IEnumerable<Meta>> GetAllMetasByEmpresaIdAsync(int empresaId);
    }
}