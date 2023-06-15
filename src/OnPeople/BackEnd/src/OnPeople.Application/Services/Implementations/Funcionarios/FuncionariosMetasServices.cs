
using AutoMapper;
using OnPeople.Application.Services.Contracts.Funcionarios;
using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Persistence.Interfaces.Contracts.Funcionarios;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Application.Services.Implementations.Funcionarios
{
    public class FuncionariosMetasServices : IFuncionariosMetasServices
    {
        private readonly IFuncionariosMetasPersistence _funcionariosMetasPersistence;
        private readonly ISharedPersistence _sharedPersistence;
        private readonly IMapper _mapper;
        public FuncionariosMetasServices(
            IFuncionariosMetasPersistence funcionariosMetasPersistence,
            ISharedPersistence sharedPersistence,
            IMapper mapper)
        {
            _funcionariosMetasPersistence = funcionariosMetasPersistence;
            _sharedPersistence = sharedPersistence;
            _mapper = mapper;
        }
        public async Task<FuncionarioMetaDto> CreateFuncionarioMeta(FuncionarioMetaDto funcionarioMetaDto)
        {
        try
            {
                var funcionarioMeta = _mapper.Map<FuncionarioMeta>(funcionarioMetaDto);

                _sharedPersistence.Create<FuncionarioMeta>(funcionarioMeta);

                if (await _sharedPersistence.SaveChangesAsync())
                {
                    var funcionarioMetaRetorno = await _funcionariosMetasPersistence.GetFuncionarioMetaByIdAsync(funcionarioMeta.Id);

                    return _mapper.Map<FuncionarioMetaDto>(funcionarioMetaRetorno);
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<IEnumerable<FuncionarioMetaDto>> GetAllFuncionariosByMetaIdAsync(int metaId)
        {
            try
            {
                var funcionariosMetas = await _funcionariosMetasPersistence.GetAllFuncionariosByMetaIdAsync(metaId);

                if (funcionariosMetas == null) return null;

                var funcionariosMapper = _mapper.Map<IEnumerable<FuncionarioMetaDto>>(funcionariosMetas);

                return funcionariosMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<FuncionarioMetaDto>> GetAllMetasByFuncionarioIdAsync(int funcionarioId)
        {
            try
            {
                var funcionariosMetas = await _funcionariosMetasPersistence.GetAllMetasByFuncionarioIdAsync(funcionarioId);

                if (funcionariosMetas == null) return null;

                var funcionariosMapper = _mapper.Map<IEnumerable<FuncionarioMetaDto>>(funcionariosMetas);

                return funcionariosMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
        public async Task<FuncionarioMetaDto> GetFuncionarioMetaByIdAsync(int funcionarioMetaId)
        {
            try
            {
                var funcionarioMeta = await _funcionariosMetasPersistence.GetFuncionarioMetaByIdAsync(funcionarioMetaId);

                if (funcionarioMeta == null) return null;

                var funcionarioMapper = _mapper.Map<FuncionarioMetaDto>(funcionarioMeta);

                return funcionarioMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<FuncionarioMetaDto> GetFuncionarioMetaByIdsAsync(int funcionarioId, int metaId)
        {
            try
            {
                var funcionarioMeta = await _funcionariosMetasPersistence.GetFuncionarioMetaByIdsAsync(funcionarioId, metaId);

                if (funcionarioMeta == null) return null;

                var funcionarioMapper = _mapper.Map<FuncionarioMetaDto>(funcionarioMeta);

                return funcionarioMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> VerifyFuncionarioMetaExistsAsync(int funcionarioId, int metaId)
        {
            try
            {
                var funcionarioMeta = await _funcionariosMetasPersistence.GetFuncionarioMetaByIdsAsync(funcionarioId, metaId);

                return funcionarioMeta != null;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
        public async Task<FuncionarioMeta> UpdateFuncionarioMeta(int funcionarioMetaId, FuncionarioMetaDto funcionarioMetaDto)
        {
            try
            {
                var funcionarioMeta = await _funcionariosMetasPersistence.GetFuncionarioMetaByIdAsync(funcionarioMetaId);

                if (funcionarioMeta == null) return null;

                var funcionarioMetaUpdate = _mapper.Map(funcionarioMetaDto, funcionarioMeta);

                _funcionariosMetasPersistence.Update<FuncionarioMeta>(funcionarioMetaUpdate);

                if (await _funcionariosMetasPersistence.SaveChangesAsync())
                {
                    var funcionarioMetaMapper =  await _funcionariosMetasPersistence.GetFuncionarioMetaByIdAsync(funcionarioMetaUpdate.Id);
                    return _mapper.Map<FuncionarioMeta>(funcionarioMetaMapper);
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteFuncionarioMeta(int funcionarioMetaId)
        {
            try
            {
                var funcionarioMeta = await _funcionariosMetasPersistence.GetFuncionarioMetaByIdAsync(funcionarioMetaId);

                if (funcionarioMeta == null) 
                    throw new Exception("FuncionárioMeta para deleção náo foi encontrado!"); 

                _funcionariosMetasPersistence.Delete<FuncionarioMeta>(funcionarioMeta);

                return await _funcionariosMetasPersistence.SaveChangesAsync();
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public DashboardFuncionariosMetas GetDashboard(int funcionarioId)
        {
            try
            {
                return _funcionariosMetasPersistence.GetDashboard(funcionarioId);
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            }
        }
    }
}