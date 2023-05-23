using System.Threading.Tasks;
using ProEventos.Application.Dtos;

namespace ProEventos.Application.Contratos
{
    public interface IMetasService
    {
        Task<MetaDto> AddMetas(MetaDto model);
        Task<MetaDto> UpdateMeta(int metaId, MetaDto model);
        Task<bool> DeleteMeta(int metaId);

        Task<MetaDto[]> GetAllMetasAsync();
        Task<MetaDto[]> GetAllMetasByTipoAsync(string tipoMeta);
        Task<MetaDto> GetMetaByIdAsync(int metaId);
    }
}