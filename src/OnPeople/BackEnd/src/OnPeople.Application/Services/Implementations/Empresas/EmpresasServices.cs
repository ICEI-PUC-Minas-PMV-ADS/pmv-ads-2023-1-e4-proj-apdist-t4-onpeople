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

        public DashboardEmpresa GetDashboard(int empresaId, Boolean master)
        {
            try
            {
                return _empresasPersistence.GetDashboard(empresaId, master);
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
        
    }
}