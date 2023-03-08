using AutoMapper;
using OnPeople.Application.Dtos.Contas;
using OnPeople.Application.Services.Contracts.Contas;
using OnPeople.Domain.Models.Contas;
using OnPeople.Persistence.Interfaces.Contracts.Contas;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Application.Services.Implementations.Contas
{
    public class ContasServices : IContasServices
    {
        private readonly ISharedPersistence _sharedPersistence;
        private readonly IContasPersistence _contasPersistence;
        private readonly IMapper _mapper;
        public ContasServices(
            ISharedPersistence sharedPersistence,
            IContasPersistence contasPersistence
,            IMapper mapper)
        {
            _contasPersistence = contasPersistence;
            _sharedPersistence = sharedPersistence;
            _mapper = mapper;
        }        
        public async Task<ContaDto> CreateContas(ContaDto contaDto)
        {
            try
            {
                var contaMapper = _mapper.Map<Conta>(contaDto);

                _sharedPersistence.Create<Conta>(contaMapper);

                if (await _contasPersistence.SaveChangesAsync())
                {
                    var contaRetorno = await _contasPersistence.GetContaByIdAsync(contaMapper.Id);
                    
                    return _mapper.Map<ContaDto>(contaRetorno);
                }

                return null;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteContas(int id)
        {
            try
            {
                var conta = await _contasPersistence.GetContaByIdAsync(id);

               if (conta == null) throw new Exception("Conta para deleção náo foi encontradC!");

                  _contasPersistence.Delete<Conta>(conta);

                return await _sharedPersistence.SaveChangesAsync();
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
         public async Task<IEnumerable<ContaDto>> GetAllContasAtivasAsync()
        {
            try
            {
                var contas = await _contasPersistence.GetAllContasAtivasAsync();

                if (contas == null) return null;

                return _mapper.Map<ContaDto[]>(contas);
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<ContaDto>> GetAllContasByArgumentoAsync(string argumento)
        {
            try
            {
                var contas = await _contasPersistence.GetAllContasByArgumentoAsync(argumento);

                if (contas == null) return null;

                return _mapper.Map<ContaDto[]>(contas);
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<ContaDto> GetContaByIdAsync(int id)
        {
            try
            {
                var conta = await _contasPersistence.GetContaByIdAsync(id);

                if (conta == null) return null;

                return _mapper.Map<ContaDto>(conta);
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<ContaDto> UpdateContas(int id, ContaDto contaDto)
        {
            try
            {
                var conta = await _contasPersistence.GetContaByIdAsync(id);

                if (conta == null) return null;

                var contaUpdate = _mapper.Map<Conta>(contaDto);

                _contasPersistence.Update(contaUpdate);

                if (await _sharedPersistence.SaveChangesAsync())
                {
                    var contaRetorno = await _contasPersistence.GetContaByIdAsync(contaUpdate.Id);

                    return _mapper.Map<ContaDto>(contaRetorno);
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