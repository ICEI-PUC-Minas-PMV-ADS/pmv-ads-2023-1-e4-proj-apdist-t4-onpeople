using System;
using System.Threading.Tasks;
using AutoMapper;
using ProEventos.Application.Contratos;
using ProEventos.Application.Dtos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class MetasService : IMetasService
    {

        private readonly IGeralPersist _geralPersist;
        private readonly IMetaPersist _metasPersist;
        private readonly IMapper _mapper;

        public MetasService(IGeralPersist geralPersist,  IMetaPersist metasPersist, IMapper mapper)
        {
            _metasPersist = metasPersist;
            _geralPersist = geralPersist;
            _mapper = mapper;
        }


        public async Task<MetaDto> AddMetas(MetaDto model)
        {
            try
            {
                var meta = _mapper.Map<Meta>(model);

                _geralPersist.Add<Meta>(meta);

                if (await _geralPersist.SaveChangesAsync())
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

                _geralPersist.Update<Meta>(meta);
                
                if (await _geralPersist.SaveChangesAsync())
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

                _geralPersist.Delete<Meta>(meta);
                return await _geralPersist.SaveChangesAsync();
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