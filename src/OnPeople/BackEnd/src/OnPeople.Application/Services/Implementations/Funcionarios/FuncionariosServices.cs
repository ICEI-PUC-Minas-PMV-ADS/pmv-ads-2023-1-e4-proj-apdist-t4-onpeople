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
    public class FuncionariosServices : IFuncionariosServices
    {
        private readonly IFuncionariosPersistence _funcionariosPersistence;
        private readonly ISharedPersistence _sharedPersistence;
        private readonly IMapper _mapper;
        public FuncionariosServices(
            IFuncionariosPersistence funcionariosPersistence,
            ISharedPersistence sharedPersistence,
            IMapper mapper)
        {
            _funcionariosPersistence = funcionariosPersistence;
            _sharedPersistence = sharedPersistence;
            _mapper = mapper;
        }
        public async Task<ReadFuncionarioDto> CreateFuncionario(CreateFuncionarioDto funcionarioDto)
        {
        try
            {
                var funcionario = _mapper.Map<Funcionario>(funcionarioDto);

                _sharedPersistence.Create<Funcionario>(funcionario);

                if (await _sharedPersistence.SaveChangesAsync())
                {
                    var funcionarioRetorno = await _funcionariosPersistence.GetFuncionarioByIdAsync(funcionario.Id);

                    return _mapper.Map<ReadFuncionarioDto>(funcionarioRetorno);
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<PageList<ReadFuncionarioDto>> GetAllFuncionarios(PageParameters pageParameters, int empresaId, int departamentoId, int cargoId)
        {
            try
            {
                var funcionarios = await _funcionariosPersistence.GetAllFuncionariosAsync(pageParameters, empresaId, departamentoId, cargoId);

                if (funcionarios == null) return null;

                var funcionariosMapper = _mapper.Map<PageList<ReadFuncionarioDto>>(funcionarios);

                funcionariosMapper.CurrentPage = funcionarios.CurrentPage;
                funcionariosMapper.TotalPages = funcionarios.TotalPages;
                funcionariosMapper.PageSize = funcionarios.PageSize;
                funcionariosMapper.TotalCounter = funcionarios.TotalCounter;

                return funcionariosMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<ReadFuncionarioDto> GetFuncionarioById(int funcionarioId)
        {
            try
            {
                var funcionario = await _funcionariosPersistence.GetFuncionarioByIdAsync(funcionarioId);

                if (funcionario == null) return null;

                var funcionarioMapper = _mapper.Map<ReadFuncionarioDto>(funcionario);

                return funcionarioMapper;
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            }
        }

        public async Task<Funcionario> UpdateFuncionario(int funcionarioId, UpdateFuncionarioDto funcionarioDto)
        {
            try
            {
                var funcionario = await _funcionariosPersistence.GetFuncionarioByIdAsync(funcionarioId);

                if (funcionario == null) return null;

                var funcionarioUpdate = _mapper.Map(funcionarioDto, funcionario);

                _funcionariosPersistence.Update<Funcionario>(funcionarioUpdate);

                if (await _funcionariosPersistence.SaveChangesAsync())
                {
                Console.WriteLine("funcionarioId " + funcionarioId);
                    var funcionarioMapper =  await _funcionariosPersistence.GetFuncionarioByIdAsync(funcionarioUpdate.Id);
                    return _mapper.Map<Funcionario>(funcionarioMapper);
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteFuncionario(int funcionarioId)
        {
            try
            {
                var funcionario = await _funcionariosPersistence.GetFuncionarioByIdAsync(funcionarioId);

                if (funcionario == null) 
                    throw new Exception("Funcionário para deleção náo foi encontrado!"); 

                _funcionariosPersistence.Delete<Funcionario>(funcionario);

                return await _sharedPersistence.SaveChangesAsync();
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
    }
}