using AutoMapper;
using OnPeople.Application.Dtos.Funcionarios;
using OnPeople.Application.Services.Contracts.Funcionarios;
using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Persistence.Interfaces.Contracts.Funcionarios;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Application.Services.Implementations.Funcionarios
{
    public class DadosPessoaisServices : IDadosPessoaisServices
    {
        private readonly IDadosPessoaisPersistence _dadosPessoaisPersistence;
        private readonly ISharedPersistence _sharedPersistence;
        private readonly IMapper _mapper;
        public DadosPessoaisServices(
            IDadosPessoaisPersistence dadosPessoaisPersistence,
            ISharedPersistence sharedPersistence,
            IMapper mapper)
        {
            _dadosPessoaisPersistence = dadosPessoaisPersistence;
            _sharedPersistence = sharedPersistence;
            _mapper = mapper;
        }
        public async Task<DadoPessoalDto> CreateDadoPessoal(DadoPessoalDto dadoPessoalDto)
        {
        try
            {
                var dadoPessoal = _mapper.Map<DadoPessoal>(dadoPessoalDto);

                _sharedPersistence.Create<DadoPessoal>(dadoPessoal);

                if (await _sharedPersistence.SaveChangesAsync())
                {
                    var dadoPessoalRetorno = await _dadosPessoaisPersistence.GetDadoPessoalByIdAsync(dadoPessoal.Id);

                    return _mapper.Map<DadoPessoalDto>(dadoPessoalRetorno);
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<DadoPessoalDto>> GetAllDadosPessoais()
        {
            try
            {
                var dadosPessoais = await _dadosPessoaisPersistence.GetAllDadosPessoaisAsync();

                if (dadosPessoais == null) return null;

                var dadosPessoaisMapper = _mapper.Map<IEnumerable<DadoPessoalDto>>(dadosPessoais);

                return dadosPessoaisMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<DadoPessoalDto> GetDadoPessoalById(int dadoPessoalId)
        {
            try
            {
                var dadoPessoal = await _dadosPessoaisPersistence.GetDadoPessoalByIdAsync(dadoPessoalId);

                if (dadoPessoal == null) return null;

                var dadoPessoalMapper = _mapper.Map<DadoPessoalDto>(dadoPessoal);

                return dadoPessoalMapper;
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            }
        }

        public async Task<DadoPessoal> UpdateDadoPessoal(int dadoPessoalId, DadoPessoalDto dadoPessoalDto)
        {
            try
            {
                var dadoPessoal = await _dadosPessoaisPersistence.GetDadoPessoalByIdAsync(dadoPessoalId);

                if (dadoPessoal == null) return null;

                var dadoPessoalUpdate = _mapper.Map(dadoPessoalDto, dadoPessoal);

                _dadosPessoaisPersistence.Update<DadoPessoal>(dadoPessoalUpdate);

                if (await _sharedPersistence.SaveChangesAsync())
                {
                    var dadoPessoalMapper =  await _dadosPessoaisPersistence.GetDadoPessoalByIdAsync(dadoPessoalUpdate.Id);
                    return _mapper.Map<DadoPessoal>(dadoPessoalMapper);
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteDadoPessoal(int dadoPessoalId)
        {
            try
            {
                var dadoPesoal = await _dadosPessoaisPersistence.GetDadoPessoalByIdAsync(dadoPessoalId);

                if (dadoPesoal == null) 
                    throw new Exception("Funcionário para deleção náo foi encontrado!"); 

                _dadosPessoaisPersistence.Delete<DadoPessoal>(dadoPesoal);

                return await _sharedPersistence.SaveChangesAsync();
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
    }
}