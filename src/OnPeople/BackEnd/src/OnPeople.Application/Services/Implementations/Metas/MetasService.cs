using AutoMapper;
using OnPeople.Application.Dtos.Metas;
using OnPeople.Application.Services.Contracts.Metas;
using OnPeople.Domain.Models.Metas;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Persistence.Interfaces.Contracts.Metas;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Application.Services.Implementations.Metas
{
    public class MetasService : IMetasService
    {

        private readonly ISharedPersistence _sharedPersistence;
        private readonly IMetaPersist _metasPersist;
        private readonly IMapper _mapper;

        public MetasService(ISharedPersistence sharedPersistence,  IMetaPersist metasPersist, IMapper mapper)
        {
            _sharedPersistence = sharedPersistence;
            _metasPersist = metasPersist;
            _mapper = mapper;
        }


        public async Task<MetaDto> AddMetas(MetaDto model)
        {
            try
            {
                var meta = _mapper.Map<Meta>(model);

                _sharedPersistence.Create<Meta>(meta);

                if (await _sharedPersistence.SaveChangesAsync())
                {
                    var metaRetorno = await _metasPersist.GetMetaByIdAsync(meta.Id);

                    return _mapper.Map<MetaDto>(metaRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MetaDto> UpdateMeta(int metaId, MetaDto model)
        {
            try
            {
                var meta = await _metasPersist.GetMetaByIdAsync(metaId);
                if (meta == null) return null;

                model.Id = meta.Id;

                _mapper.Map(model, meta);

                _sharedPersistence.Update<Meta>(meta);
                
                if (await _sharedPersistence.SaveChangesAsync())
                {
                    var metaRetorno = await _metasPersist.GetMetaByIdAsync(meta.Id);

                return _mapper.Map<MetaDto>(metaRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteMeta(int metaId)
        {
            try
            {
                var meta = await _metasPersist.GetMetaByIdAsync(metaId);
                if (meta == null) throw new Exception("Meta não encontrada!");

                _sharedPersistence.Delete<Meta>(meta);
                return await _sharedPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<MetaDto[]> GetAllMetasAsync()
        {
            try
            {
                var metas = await _metasPersist.GetAllMetasAsync();
                if (metas == null) return null;

                var resultado = _mapper.Map<MetaDto[]>(metas);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MetaDto[]> GetAllMetasByTipoAsync(string tipoMeta)
        {
            try
            {
                var metas = await _metasPersist.GetAllMetasByTipoAsync(tipoMeta);
                if (metas == null) return null;

                var resultado = _mapper.Map<MetaDto[]>(metas);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MetaDto> GetMetaByIdAsync(int metaId)
        {
            try
            {
                var meta = await _metasPersist.GetMetaByIdAsync(metaId);
                if (meta == null) return null;

                var resultado = _mapper.Map<MetaDto>(meta);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}