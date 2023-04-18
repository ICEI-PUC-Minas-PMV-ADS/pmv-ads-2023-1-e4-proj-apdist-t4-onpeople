using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class MetasService : IMetasService
    {

        private readonly IGeralPersist _geralPersist;
        private readonly IMetaPersist _metasPersist;

        public MetasService(IGeralPersist geralPersist,  IMetaPersist metasPersist)
        {
            _metasPersist = metasPersist;
            _geralPersist = geralPersist;
        }


        public async Task<Meta> AddMetas(Meta model)
        {
            try
            {
                _geralPersist.Add<Meta>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _metasPersist.GetMetaByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Meta> UpdateMeta(int id, Meta model)
        {
            try
            {
                var meta = await _metasPersist.GetMetaByIdAsync(id);
                if (meta == null) return null;

                model.Id = meta.Id;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _metasPersist.GetMetaByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteMeta(int id)
        {
            try
            {
                var meta = await _metasPersist.GetMetaByIdAsync(id);
                if (meta == null) throw new Exception("Meta não encontrada!");

                _geralPersist.Delete<Meta>(meta);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Meta[]> GetAllMetasAsync()
        {
            try
            {
                var metas = await _metasPersist.GetAllMetasAsync();
                if (metas == null) return null;

                return metas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Meta[]> GetAllMetasByTipoAsync(string tipoMeta)
        {
            try
            {
                var metas = await _metasPersist.GetAllMetasByTipoAsync(tipoMeta);
                if (metas == null) return null;

                return metas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Meta> GetMetaByIdAsync(int id)
        {
            try
            {
                var metas = await _metasPersist.GetMetaByIdAsync(id);
                if (metas == null) return null;

                return metas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}