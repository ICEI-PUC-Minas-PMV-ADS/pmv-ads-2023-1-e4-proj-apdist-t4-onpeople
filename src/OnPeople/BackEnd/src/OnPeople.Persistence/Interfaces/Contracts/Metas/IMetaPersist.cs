using OnPeople.Domain.Models.Metas;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Persistence.Interfaces.Contracts.Metas
{
    public interface IMetaPersist
    {
        Task<Meta[]> GetAllMetasAsync();
        Task<Meta> GetMetaByIdAsync(int id);
        Task<Meta[]> GetAllMetasByTipoAsync(string tipoMeta);
    }
}