using OnPeople.Application.Dtos.Metas;
using OnPeople.Domain.Models.Metas;
using OnPeople.Integration.Models.Pages.Page;

namespace OnPeople.Application.Services.Contracts.Metas
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