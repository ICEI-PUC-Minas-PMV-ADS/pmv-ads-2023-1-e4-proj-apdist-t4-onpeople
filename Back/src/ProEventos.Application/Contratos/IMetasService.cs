using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IMetasService
    {
        Task<Meta> AddMetas(Meta model);
        Task<Meta> UpdateMeta(int eventoId, Meta model);
        Task<bool> DeleteMeta(int id);

        Task<Meta[]> GetAllMetasAsync();
        Task<Meta> GetMetaByIdAsync(int id);
        Task<Meta[]> GetAllMetasByTipoAsync(string tipoMeta);
    }
}