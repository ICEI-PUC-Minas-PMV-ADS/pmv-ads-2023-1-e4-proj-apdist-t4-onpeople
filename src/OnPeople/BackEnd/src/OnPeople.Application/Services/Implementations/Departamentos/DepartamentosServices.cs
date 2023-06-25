using AutoMapper;
using OnPeople.Application.Dtos.Departamentos;
using OnPeople.Application.Services.Contracts.Departamentos;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Persistence.Interfaces.Contracts.Departamentos;

namespace OnPeople.Application.Services.Implementations.Departamentos
{
    public class DepartamentosServices : IDepartamentosServices
    {

        private readonly IDepartamentosPersistence _departamentosPersistence;
        private readonly DashboardDepartamento _dashDepartamento = new();
        private readonly PageParameters _pageParameters = new();
        private readonly IMapper _mapper;

        public DepartamentosServices(
           IDepartamentosPersistence departamentosPersistence, IMapper mapper)
        {
            _departamentosPersistence = departamentosPersistence;
            _mapper = mapper;

        }

        public async Task<PageList<DepartamentoDto>> GetAllDepartamentosAsync(PageParameters pageParameters, int empresaId, bool Master)
        {
            try
            {
                var departamentos = await _departamentosPersistence.GetAllDepartamentosAsync(pageParameters, empresaId, Master);

                if (departamentos == null) return null;

                var departamentosMapper = _mapper.Map<PageList<DepartamentoDto>>(departamentos);

                departamentosMapper.CurrentPage = departamentos.CurrentPage;
                departamentosMapper.TotalPages = departamentos.TotalPages;
                departamentosMapper.PageSize = departamentos.PageSize;
                departamentosMapper.TotalCounter = departamentos.TotalCounter;

                return departamentosMapper;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

       public async Task<IEnumerable<DepartamentoDto>> GetAllDepartamentosByEmpresaIdAsync(int empresaId)
        {
            try
            {
                var departamentos = await _departamentosPersistence.GetAllDepartamentosByEmpresaIdAsync(empresaId);

                if (departamentos == null) return null;

                var departamentosMapper = _mapper.Map<IEnumerable<DepartamentoDto>>(departamentos);

                return departamentosMapper;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<DepartamentoDto> GetDepartamentoByIdAsync(int departamentoId)
        {
            try
            {
                var departamento = await _departamentosPersistence.GetDepartamentoByIdAsync(departamentoId);

                if (departamento == null) return null;

                var departamentoMapper = _mapper.Map<DepartamentoDto>(departamento);

                return departamentoMapper;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

         public async Task<DepartamentoDto> CreateDepartamentos(DepartamentoDto departamentoDto)
        {
            try
            {
                var departamento = _mapper.Map<Departamento>(departamentoDto);

                _departamentosPersistence.Create<Departamento>(departamento);

                if (await _departamentosPersistence.SaveChangesAsync())
                {
                    var departamentoCriado = await _departamentosPersistence.GetDepartamentoByIdAsync(departamento.Id);
                    return _mapper.Map<DepartamentoDto>(departamentoCriado);
                }

                return null;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<DepartamentoDto> UpdateDepartamento(int departamentoId, DepartamentoDto departamentoDto)
        {
            try
            {
                var departamento = await _departamentosPersistence.GetDepartamentoByIdAsync(departamentoId);

                if (departamento == null) return null;

                var departamentoUpdate = _mapper.Map(departamentoDto, departamento);

                _departamentosPersistence.Update<Departamento>(departamentoUpdate);

                if (await _departamentosPersistence.SaveChangesAsync())
                {
                    var departamentoAlterado = await _departamentosPersistence.GetDepartamentoByIdAsync(departamentoUpdate.Id);
                    return _mapper.Map<DepartamentoDto>(departamentoAlterado);
                }

                return null;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteDepartamento(int departamentoId)
        {
            try
            {
                var departamento = await _departamentosPersistence.GetDepartamentoByIdAsync(departamentoId);

                if (departamento == null) return false;

                _departamentosPersistence.Delete<Departamento>(departamento);

                return await _departamentosPersistence.SaveChangesAsync();
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<DashboardDepartamento> GetDashboardDepartamento(int empresaId, Boolean master)
        {
            try
            {
                _pageParameters.PageSize = 1000;
                _pageParameters.PageNumber = 1;

                var departamentos = await _departamentosPersistence.GetAllDepartamentosAsync(_pageParameters, empresaId, master);
                
                if (departamentos == null) return null;
                    
                _dashDepartamento.CountDepartamentos = departamentos.Count();
                _dashDepartamento.CountDepartamentosAtivos  = departamentos.Count(e => e.Ativo);
                _dashDepartamento.ListaNomeDepartamentos = departamentos.Select(e => e.NomeDepartamento);
                _dashDepartamento.ListaQtdeCargos = departamentos.Select(e => e.Cargos.Count());

                _dashDepartamento.PercentualDepartamentosAtivos =  100.00 * ((double)_dashDepartamento.CountDepartamentosAtivos)  / ((double)_dashDepartamento.CountDepartamentos);
                
                return _dashDepartamento;
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            }
        }

        public async Task<List<ListaMetas>> GetDashboardDepartamentoMetas(int empresaId, bool master)
        {
            try
            {
                _pageParameters.PageSize = 1000;
                _pageParameters.PageNumber = 1;
                var departamentos = await _departamentosPersistence.GetAllDepartamentosAsync(_pageParameters, empresaId, master);

                if (departamentos == null)
                    return new List<ListaMetas>();

                var dashDepartamentoMetas = departamentos.Select(departamento => new ListaMetas {
                    NomeEmpresa = departamento.NomeDepartamento,
                    QtdeMetas = departamento.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count(),
                    QtdeMetasCumpridas = departamento.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count(fm => fm.MetaCumprida),
                    QtdeMetasNaoCumpridas = departamento.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count(fm => !fm.MetaCumprida),
                    PercentualMetasCumpridas = departamento.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count(fm => fm.MetaCumprida) == 0 ? 0 : 100.00 * ((double)departamento.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count(fm => fm.MetaCumprida)) / ((double)departamento.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count()),
                    PercentualMetasNaoCumpridas = departamento.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count(fm => !fm.MetaCumprida) == 0 ? 0 : 100.00 * ((double)departamento.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count(fm => !fm.MetaCumprida)) / ((double)departamento.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count())
                }).ToList();

                return dashDepartamentoMetas;
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            }
        }
    }
}