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
        private readonly DashboardFuncionarios _dashFuncionario = new();
        private readonly DashboardFuncionariosMetas _dashMetas = new();
        private readonly PageParameters _pageParameters = new();
        private readonly IMapper _mapper;
        public FuncionariosServices(
            IFuncionariosPersistence funcionariosPersistence,
            IMapper mapper)
        {
            _funcionariosPersistence = funcionariosPersistence;
            _mapper = mapper;
        }
        public async Task<ReadFuncionarioDto> CreateFuncionario(CreateFuncionarioDto funcionarioDto)
        {
        try
            {
                var funcionario = _mapper.Map<Funcionario>(funcionarioDto);

                _funcionariosPersistence.Create<Funcionario>(funcionario);

                if (await _funcionariosPersistence.SaveChangesAsync())
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

        public async Task<PageList<ReadFuncionarioDto>> GetAllFuncionarios(PageParameters pageParameters, int empresaId, int departamentoId, int cargoId, int funcionarioId)
        {
            try
            {
                var funcionarios = await _funcionariosPersistence.GetAllFuncionariosAsync(pageParameters, empresaId, departamentoId, cargoId, funcionarioId);

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

                return await _funcionariosPersistence.SaveChangesAsync();
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<ReadFuncionarioDto>> GetFuncionariosChefesByDepartamentoId(int departamentoId)
        {
            try
            {
                var funcionarios = await _funcionariosPersistence.GetFuncionariosChefesByDepartamentoId(departamentoId);

                if (funcionarios == null) return null;

                var funcionarioMapper = _mapper.Map<ReadFuncionarioDto[]>(funcionarios);

                return funcionarioMapper;
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<ReadFuncionarioDto>> GetFuncionariosByCargoId(int cargoId)
        {
            try
            {
                var funcionarios = await _funcionariosPersistence.GetAllFuncionariosByCargoIdAsync(cargoId);

                if (funcionarios == null) return null;

                var funcionarioMapper = _mapper.Map<ReadFuncionarioDto[]>(funcionarios);

                return funcionarioMapper;
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            }
        }
       public async Task<DashboardFuncionarios> GetDashboardFuncionario(int empresaId, int departamentoId, int cargoId, int funcionarioId)
        {
            try
            {
                _pageParameters.PageSize = 1000;
                _pageParameters.PageNumber = 1;

                var funcionarios = await _funcionariosPersistence.GetAllFuncionariosAsync(_pageParameters, empresaId, departamentoId, cargoId, funcionarioId);
                
                if (funcionarios == null) return null;
                    
                _dashFuncionario.CountFuncionarios = funcionarios.Count();
                _dashFuncionario.ListaNomeFuncionario = funcionarios.Select(e => e.NomeCompleto);
                _dashFuncionario.ListaQtdeMetas = funcionarios.Select(e => e.FuncionariosMetas.Count());
                
                return _dashFuncionario;
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            }
        }

        public async Task<List<ListaMetas>> GetDashboardFuncionarioMetas(int empresaId, int departamentoId, int cargoId, int funcionarioId)
        {
            try
            {
                _pageParameters.PageSize = 1000;
                _pageParameters.PageNumber = 1;

                 var funcionarios = await _funcionariosPersistence.GetAllFuncionariosAsync(_pageParameters, empresaId, departamentoId, cargoId, funcionarioId);

                if (funcionarios == null)
                    return new List<ListaMetas>();

                var dashFuncionarioMetas = funcionarios.Select(funcionario => new ListaMetas {
                    NomeEmpresa = funcionario.NomeCompleto,
                    QtdeMetas = funcionario.FuncionariosMetas.Count(),
                    QtdeMetasCumpridas = funcionario.FuncionariosMetas.Count(fm => fm.MetaCumprida),
                    QtdeMetasNaoCumpridas = funcionario.FuncionariosMetas.Count(fm => !fm.MetaCumprida),
                    PercentualMetasCumpridas = funcionario.FuncionariosMetas.Count(fm => fm.MetaCumprida) == 0 ? 0 : 100.00 * ((double)funcionario.FuncionariosMetas.Count(fm => fm.MetaCumprida)) / ((double)funcionario.FuncionariosMetas.Count()),
                    PercentualMetasNaoCumpridas = funcionario.FuncionariosMetas.Count(fm => !fm.MetaCumprida) == 0 ? 0 : 100.00 * ((double)funcionario.FuncionariosMetas.Count(fm => !fm.MetaCumprida)) / ((double)funcionario.FuncionariosMetas.Count())
                }).ToList();

                return dashFuncionarioMetas;
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            }
        }     

        public async Task<DashboardFuncionariosMetas> GetDashboardMetas(int empresaId, int departamentoId, int cargoId, int funcionarioId)
        {
            try
            {
                _pageParameters.PageSize = 1000;
                _pageParameters.PageNumber = 1;

                var funcionarios = await _funcionariosPersistence.GetAllFuncionariosAsync(_pageParameters, empresaId, departamentoId, cargoId, funcionarioId);
                
                if (funcionarios == null) return null;
                    
                _dashMetas.CountMetasAssociadas = funcionarios.Sum(f => f.FuncionariosMetas.Count());
                _dashMetas.CountMetasCumpridas = funcionarios.Sum(f => f.FuncionariosMetas.Count(f => f.MetaCumprida));
                
                _dashMetas.PercentualMetasCumpridas =  100.00 * ((double)_dashMetas.CountMetasCumpridas)  / ((double)_dashMetas.CountMetasAssociadas);
                return _dashMetas;
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            }
        } 
    }
}