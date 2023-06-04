using System;
using System.Threading.Tasks;
using AutoMapper;
using OnPeople.Application.Services.Contracts.Metas;
using OnPeople.Domain.Models.Metas;
using OnPeople.Persistence.Interfaces.Contracts.Metas;

namespace OnPeople.Application.Services.Implementations.Metas
{
    public class MetasService : IMetasService
    {

        private readonly IMetaPersistence _metasPersistence;
        private readonly IMapper _mapper;

        public MetasService(
            IMetaPersistence metasPersistence, 
            IMapper mapper)
        {
            _metasPersistence = metasPersistence;
            _mapper = mapper;
        }


        public async Task<MetaDto> CreateMetas(MetaDto metaDto)
        {
            try
            {
                var meta = _mapper.Map<Meta>(metaDto);

                _metasPersistence.Create<Meta>(meta);

                if (await _metasPersistence.SaveChangesAsync())
                {
                    var metaRetorno = await _metasPersistence.GetMetaByIdAsync(meta.Id);

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
                var meta = await _metasPersistence.GetMetaByIdAsync(metaId);
                if (meta == null) return null;

                model.Id = meta.Id;

                _mapper.Map(model, meta);

                _metasPersistence.Update<Meta>(meta);
                
                if (await _metasPersistence.SaveChangesAsync())
                {
                    var metaRetorno = await _metasPersistence.GetMetaByIdAsync(meta.Id);

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
                var meta = await _metasPersistence.GetMetaByIdAsync(metaId);
                if (meta == null) throw new Exception("Meta não encontrada!");

                _metasPersistence.Delete<Meta>(meta);
                return await _metasPersistence.SaveChangesAsync();
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
                var metas = await _metasPersistence.GetAllMetasAsync();
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
                var metas = await _metasPersistence.GetAllMetasByTipoAsync(tipoMeta);
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
                var meta = await _metasPersistence.GetMetaByIdAsync(metaId);
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