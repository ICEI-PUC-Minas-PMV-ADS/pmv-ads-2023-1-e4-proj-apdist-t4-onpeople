using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IMetaPersist
    {
        Task<Meta[]> GetAllMetasAsync();
        Task<Meta> GetMetaByIdAsync(int id);
        Task<Meta[]> GetAllMetasByTipoAsync(string tipoMeta);
    }
}