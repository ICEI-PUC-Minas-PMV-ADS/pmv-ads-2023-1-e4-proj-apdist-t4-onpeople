using AutoMapper;
using OnPeople.Application.Dtos.Empresas;
using OnPeople.Application.Services.Contracts.Empresas;
using OnPeople.Domain.Models.Empresas;
using OnPeople.Persistence.Interfaces.Contracts.Empresas;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Application.Services.Implementations.Empresas
{
    public class EmpresasServices : IEmpresasServices
    {
        private readonly ISharedPersistence _sharedPersistence;
        private readonly IEmpresasPersistence _empresasPersistence;
        private readonly IMapper _mapper;
        public EmpresasServices(
            ISharedPersistence sharedPersistence,
            IEmpresasPersistence empresasPersistence,
            IMapper mapper)
        {
            _empresasPersistence = empresasPersistence;
            _sharedPersistence = sharedPersistence;
            _mapper = mapper;
        }
        public async Task<EmpresaDto> CreateEmpresas(int empresaId, Boolean Master, EmpresaDto empresaDto)
        {
        try
            {
                var empresa = _mapper.Map<Empresa>(empresaDto);

                _sharedPersistence.Create<Empresa>(empresa);

                if (await _empresasPersistence.SaveChangesAsync())
                {
                    var empresaRetorno = await _empresasPersistence.GetEmpresaByIdAsync(empresaId, Master, empresa.Id);

                    return _mapper.Map<EmpresaDto>(empresaRetorno);
                }

                return null;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteEmpresas(int empresaId, Boolean Master, int id)
        {
            try
            {
                var empresa = await _empresasPersistence.GetEmpresaByIdAsync(empresaId, Master,id);

                if (empresa == null) throw new Exception("Empresa para deleção náo foi encontrada!");

                  _empresasPersistence.Delete<Empresa>(empresa);

                return await _sharedPersistence.SaveChangesAsync();
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
        public async Task<IEnumerable<EmpresaDto>> GetAllEmpresasAsync(int empresaId, Boolean Master)
        {
            try
            {
                var empresas = await _empresasPersistence.GetAllEmpresasAsync(empresaId, Master );

                if (empresas == null) return null;

                var empresasMapper = _mapper.Map<EmpresaDto[]>(empresas);

                return empresasMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
        public async Task<IEnumerable<EmpresaDto>> GetAllEmpreasByArgumentoAsync(int empresaId, Boolean Master, string argumento)
        {
            try
            {
                var empresas = await _empresasPersistence.GetAllEmpresasByArgumentoAsync(empresaId, Master, argumento);

                if (empresas == null) return null;

                var empresasMapper = _mapper.Map<EmpresaDto[]>(empresas);

                return empresasMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<EmpresaDto>> GetAllEmpresasAtivasAsync(int empresaId, Boolean Master)
        {
            try
            {
                var empresas = await _empresasPersistence.GetAllEmpresasAtivasAsync(empresaId, Master);

                if (empresas == null) return null;

                var empresasMapper = _mapper.Map<EmpresaDto[]>(empresas);

                return empresasMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<EmpresaDto>> GetAllEmpresasFiliaisAsync(int empresaId, Boolean Master)
        {
            try
            {
                var empresas = await _empresasPersistence.GetAllEmpresasFiliaisAsync(empresaId, Master);

                if (empresas == null) return null;

                var empresasMapper = _mapper.Map<EmpresaDto[]>(empresas);

                return empresasMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<EmpresaDto> GetEmpresaByIdAsync(int empresaId, Boolean Master, int id)
        {
            try
            {

                var empresa = await _empresasPersistence.GetEmpresaByIdAsync(empresaId, Master, id);

                if (empresa == null) return null;

                var empresaMapper = _mapper.Map<EmpresaDto>(empresa);

                return empresaMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<EmpresaDto> UpdateEmpresas(int empresaId, Boolean Master, int id, EmpresaDto empresaDto)
        {
            try
            {
                var empresa = await _empresasPersistence.GetEmpresaByIdAsync(empresaId, Master, id);

                if (empresa == null) return null;

                var empresaUpdate = _mapper.Map(empresaDto, empresa);

                _sharedPersistence.Update<Empresa>(empresaUpdate);

                if (await _sharedPersistence.SaveChangesAsync())
                {
                    var empresaMapper =  await _empresasPersistence.GetEmpresaByIdAsync(empresaId, Master, empresaUpdate.Id);
                    return _mapper.Map<EmpresaDto>(empresaMapper);
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}