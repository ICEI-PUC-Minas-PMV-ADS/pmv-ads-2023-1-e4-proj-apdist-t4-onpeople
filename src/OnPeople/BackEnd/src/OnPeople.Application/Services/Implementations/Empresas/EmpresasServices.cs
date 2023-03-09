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
        public async Task<EmpresaDto> CreateEmpresas(EmpresaDto empresaDto)
        {
        try
            {
                Console.WriteLine("empresa dto", empresaDto);

                var empresa = _mapper.Map<Empresa>(empresaDto);

                _sharedPersistence.Create<Empresa>(empresa);

                if (await _empresasPersistence.SaveChangesAsync())
                {
                    var empresaRetorno = await _empresasPersistence.GetEmpresaByIdAsync(empresa.Id);

                    return _mapper.Map<EmpresaDto>(empresaRetorno);
                }

                return null;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteEmpresas(int id)
        {
            try
            {
                var empresa = await _empresasPersistence.GetEmpresaByIdAsync(id);

                if (empresa == null) throw new Exception("Empresa para deleção náo foi encontrada!");

                  _empresasPersistence.Delete<Empresa>(empresa);

                return await _sharedPersistence.SaveChangesAsync();
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
        public async Task<IEnumerable<EmpresaDto>> GetAllEmpresasAsync()
        {
            try
            {
                var empresas = await _empresasPersistence.GetAllEmpresasAsync();

                if (empresas == null) return null;

                var empresasMapper = _mapper.Map<EmpresaDto[]>(empresas);

                return empresasMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
        public async Task<IEnumerable<EmpresaDto>> GetAllEmpreasByArgumentoAsync(string argumento)
        {
            try
            {
                var empresas = await _empresasPersistence.GetAllEmpresasByArgumentoAsync(argumento);

                if (empresas == null) return null;

                var empresasMapper = _mapper.Map<EmpresaDto[]>(empresas);

                return empresasMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<EmpresaDto>> GetAllEmpresasAtivasAsync()
        {
            try
            {
                var empresas = await _empresasPersistence.GetAllEmpresasAtivasAsync();

                if (empresas == null) return null;

                var empresasMapper = _mapper.Map<EmpresaDto[]>(empresas);

                return empresasMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<EmpresaDto>> GetAllEmpresasFiliaisAsync()
        {
            try
            {
                var empresas = await _empresasPersistence.GetAllEmpresasFiliaisAsync();

                if (empresas == null) return null;

                var empresasMapper = _mapper.Map<EmpresaDto[]>(empresas);

                return empresasMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<EmpresaDto> GetEmpresaByIdAsync(int id)
        {
            try
            {
                var empresa = await _empresasPersistence.GetEmpresaByIdAsync(id);

                if (empresa == null) return null;

                var empresaMapper = _mapper.Map<EmpresaDto>(empresa);

                return empresaMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<EmpresaDto> UpdateEmpresas(int id, EmpresaDto empresaDto)
        {
            try
            {
                var empresa = await _empresasPersistence.GetEmpresaByIdAsync(id);

                if (empresa == null) return null;

                var empresaUpdate = _mapper.Map<Empresa>(empresaDto);

                _sharedPersistence.Update<Empresa>(empresaUpdate);

                if (await _sharedPersistence.SaveChangesAsync())
                {
                    var empresaMapper =  await _empresasPersistence.GetEmpresaByIdAsync(empresaUpdate.Id);
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