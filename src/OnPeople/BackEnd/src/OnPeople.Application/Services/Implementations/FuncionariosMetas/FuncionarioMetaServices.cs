using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Application.Services.Contracts.FuncionariosMetas;
using OnPeople.Persistence.Interfaces.Contracts.FuncionariosMetas;
using OnPeople.Persistence.Interfaces.Contracts.Shared;
using AutoMapper;

namespace OnPeople.Application.Services.Implementations.FuncionariosMetas
{
    public class FuncionarioMetaServices : IFuncionarioMetaServices
    {
        private readonly IFuncionarioMetaPersistence _funcionarioMetaPersistence;
        private readonly ISharedPersistence _sharedPersistence;
        private readonly IMapper _mapper;
        public FuncionarioMetaServices(
            IFuncionarioMetaPersistence funcionarioMetaPersistence,
            ISharedPersistence sharedPersistence,
            IMapper mapper)
        {
            _funcionarioMetaPersistence = funcionarioMetaPersistence;
            _sharedPersistence = sharedPersistence;
            _mapper = mapper;
        }

        public async Task<int> AssociarMetaAFuncionario(int funcionarioId, int metaId)
        {
            try {
                return await _funcionarioMetaPersistence.AssociarMetaAFuncionario(funcionarioId, metaId);

            } catch (Exception e)
            {
                throw new System.Exception(e.Message);
            }
        }
    }
}