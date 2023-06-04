

using OnPeople.Domain.Models.Metas;

namespace OnPeople.Application.Services.Contracts.Metas
{
    public interface IMetasService
    {
        Task<MetaDto> CreateMetas(MetaDto model);
        Task<MetaDto> UpdateMeta(int metaId, MetaDto model);
        Task<bool> DeleteMeta(int metaId);

        Task<MetaDto[]> GetAllMetasAsync();
        Task<MetaDto[]> GetAllMetasByTipoAsync(string tipoMeta);
        Task<MetaDto> GetMetaByIdAsync(int metaId);
    }
}