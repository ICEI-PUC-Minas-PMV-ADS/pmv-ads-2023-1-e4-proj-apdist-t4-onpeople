using AutoMapper;
using OnPeople.Application.Dtos.Empresas;
using OnPeople.Application.Services.Contracts.Empresas;
using OnPeople.Domain.Models.Empresas;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Persistence.Interfaces.Contracts.Empresas;

namespace OnPeople.Application.Services.Implementations.Empresas
{
    public class EmpresasServices : IEmpresasServices
    {
        private readonly IEmpresasPersistence _empresasPersistence;
        private readonly DashboardEmpresa _dashEmpresa = new();
        private readonly PageParameters _pageParameters = new();
        private readonly IMapper _mapper;
        public EmpresasServices(
            IEmpresasPersistence empresasPersistence,
            IMapper mapper)
        {
            _empresasPersistence = empresasPersistence;
            _mapper = mapper;
        }
        public async Task<EmpresaDto> CreateEmpresas(int empresaId, Boolean Master, EmpresaDto empresaDto)
        {
        try
            {
                var empresa = _mapper.Map<Empresa>(empresaDto);

                _empresasPersistence.Create<Empresa>(empresa);

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

        public async Task<bool> DeleteEmpresas(int empresaId)
        {
            try
            {
                var empresa = await _empresasPersistence.GetEmpresaByIdAsync(empresaId);

                if (empresa == null) 
                    throw new Exception("Empresa para deleção náo foi encontrada!"); 

                _empresasPersistence.Delete<Empresa>(empresa);

                return await _empresasPersistence.SaveChangesAsync();
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
        public async Task<PageList<EmpresaDto>> GetAllEmpresasAsync(PageParameters pageParameters, int empresaId, Boolean Master)
        {
            try
            {
                var empresas = await _empresasPersistence.GetAllEmpresasAsync(pageParameters, empresaId, Master );

                if (empresas == null) return null;

                var empresasMapper = _mapper.Map<PageList<EmpresaDto>>(empresas);

                empresasMapper.CurrentPage = empresas.CurrentPage;
                empresasMapper.TotalPages = empresas.TotalPages;
                empresasMapper.PageSize = empresas.PageSize;
                empresasMapper.TotalCounter = empresas.TotalCounter;

                return empresasMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<PageList<EmpresaDto>> GetAllEmpresasAtivasAsync(PageParameters pageParameters, int empresaId, Boolean Master)
        {
            try
            {
                var empresas = await _empresasPersistence.GetAllEmpresasAtivasAsync(pageParameters, empresaId, Master);

                if (empresas == null) return null;

                var empresasMapper = _mapper.Map<PageList<EmpresaDto>>(empresas);

                empresasMapper.CurrentPage = empresas.CurrentPage;
                empresasMapper.TotalPages = empresas.TotalPages;
                empresasMapper.PageSize = empresas.PageSize;
                empresasMapper.TotalCounter = empresas.TotalCounter;

                return empresasMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<PageList<EmpresaDto>> GetAllEmpresasFiliaisAsync(PageParameters pageParameters, int empresaId, Boolean Master)
        {
            try
            {
                var empresas = await _empresasPersistence.GetAllEmpresasFiliaisAsync(pageParameters, empresaId, Master);

                if (empresas == null) return null;

                var empresasMapper = _mapper.Map<PageList<EmpresaDto>>(empresas);

                empresasMapper.CurrentPage = empresas.CurrentPage;
                empresasMapper.TotalPages = empresas.TotalPages;
                empresasMapper.PageSize = empresas.PageSize;
                empresasMapper.TotalCounter = empresas.TotalCounter;

                return empresasMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<EmpresaDto> GetEmpresaMatrizAsync()
        {
            try
            {
                var empresa = await _empresasPersistence.GetEmpresaMatrizAsync();

                if (empresa == null) return null;

                var empresasMapper = _mapper.Map<EmpresaDto>(empresa);

                return empresasMapper;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<EmpresaDto> GetEmpresaByIdAsync(int empresaId)
        {
            try
            {
                var empresa = await _empresasPersistence.GetEmpresaByIdAsync(empresaId);

                if (empresa == null) return null;

                var empresaMapper = _mapper.Map<EmpresaDto>(empresa);

                return empresaMapper;
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            }
        }

        public async Task<EmpresaDto> UpdateEmpresa(int empresaId, EmpresaDto empresaDto)
        {
            try
            {
                var empresa = await _empresasPersistence.GetEmpresaByIdAsync(empresaId);

                if (empresa == null) return null;

                var empresaUpdate = _mapper.Map(empresaDto, empresa);

                _empresasPersistence.Update<Empresa>(empresaUpdate);

                if (await _empresasPersistence.SaveChangesAsync())
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

        public async Task<AtualizarEmpresaAtivaDto> SetEmpresa(int empresaId, AtualizarEmpresaAtivaDto atualizarEmpresaAtivaDto)
        {
            try
            {
                var empresa = await _empresasPersistence.GetEmpresaByIdAsync(empresaId);

                if (empresa == null) return null;

                var setEmpresa = _mapper.Map(atualizarEmpresaAtivaDto, empresa);

                _empresasPersistence.Update<Empresa>(setEmpresa);

                if (await _empresasPersistence.SaveChangesAsync())
                {
                    var empresaMapper =  await _empresasPersistence.GetEmpresaByIdAsync(setEmpresa.Id);
                    return _mapper.Map<AtualizarEmpresaAtivaDto>(empresaMapper);
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

  

        public async Task<EmpresaDto> GetEmpresaByCnpjAsync(string cnpj, Boolean master)
        {
            try
            {
                var empresa = await _empresasPersistence.GetEmpresaByCnpjAsync(cnpj, master);

                if (empresa == null) return null;

                var empresaMapper = _mapper.Map<EmpresaDto>(empresa);

                return empresaMapper;
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            }
        }
        
        public async Task<DashboardEmpresa> GetDashboardEmpresa(int empresaId, Boolean master)
        {
            try
            {
                _pageParameters.PageSize = 1000;
                _pageParameters.PageNumber = 1;

                var empresas = await _empresasPersistence.GetAllEmpresasAsync(_pageParameters, empresaId, master);
                
                if (empresas == null) return null;
                    
                _dashEmpresa.CountEmpresas = empresas.Count();
                _dashEmpresa.CountFiliais  = empresas.Count(e => e.Filial);
                _dashEmpresa.CountEmpresasAtivas = empresas.Count(e => e.Ativa);
                _dashEmpresa.CountFiliaisAtivas = empresas.Count(e => e.Filial && e.Ativa);
                _dashEmpresa.ListaNomeEmpresa = empresas.Select(e => e.RazaoSocial);
                _dashEmpresa.ListaQtdeDepartamentos = empresas.Select(e => e.Departamentos.Count());

                _dashEmpresa.PercentualEmpresasAtivas =  100.00 * ((double)_dashEmpresa.CountEmpresasAtivas)  / ((double)_dashEmpresa.CountEmpresas);
                _dashEmpresa.PercentualFiliais =  100.00 * ((double)_dashEmpresa.CountFiliais)  / ((double)_dashEmpresa.CountEmpresas);
                _dashEmpresa.PercentualFiliaisAtivas = 100.00 * ((double)_dashEmpresa.CountFiliaisAtivas)  / ((double)_dashEmpresa.CountEmpresas);
                _dashEmpresa.PercentualFiliaisAtivas2 = 100.00 * ((double)_dashEmpresa.CountFiliaisAtivas)  / ((double)_dashEmpresa.CountFiliais);
                
                return _dashEmpresa;
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            }
        }

        public async Task<List<ListaMetas>> GetDashboardEmpresaMetas(int empresaId, bool master)
        {
            try
            {
                _pageParameters.PageSize = 1000;
                _pageParameters.PageNumber = 1;
                var empresas = await _empresasPersistence.GetAllEmpresasAsync(_pageParameters, empresaId, master);

                if (empresas == null)
                    return new List<ListaMetas>();

                var dashEmpresasMetas = empresas.Select(empresa => new ListaMetas {
                    NomeEmpresa = empresa.RazaoSocial,
                    QtdeMetas = empresa.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count(),
                    QtdeMetasCumpridas = empresa.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count(fm => fm.MetaCumprida),
                    QtdeMetasNaoCumpridas = empresa.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count(fm => !fm.MetaCumprida),
                    PercentualMetasCumpridas = empresa.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count(fm => fm.MetaCumprida) == 0 ? 0 : 100.00 * ((double)empresa.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count(fm => fm.MetaCumprida)) / ((double)empresa.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count()),
                    PercentualMetasNaoCumpridas = empresa.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count(fm => !fm.MetaCumprida) == 0 ? 0 : 100.00 * ((double)empresa.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count(fm => !fm.MetaCumprida)) / ((double)empresa.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count())
                }).ToList();

                return dashEmpresasMetas;
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            }
        }
    }
}