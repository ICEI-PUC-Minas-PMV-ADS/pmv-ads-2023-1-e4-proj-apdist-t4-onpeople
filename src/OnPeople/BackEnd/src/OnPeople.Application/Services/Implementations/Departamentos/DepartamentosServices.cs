using AutoMapper;
using OnPeople.Application.Dtos.Departamentos;
using OnPeople.Application.Services.Contracts.Departamentos;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Persistence.Interfaces.Contracts.Departamentos;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Application.Services.Implementations.Departamentos
{
    public class DepartamentosServices : IDepartamentosServices
    {
        private readonly ISharedPersistence _sharedPersistence;
        private readonly IDepartamentosPersistence _departamentosPersistence;
        private readonly IMapper _mapper;

        public DepartamentosServices(
           ISharedPersistence sharedPersistence,
           IDepartamentosPersistence departamentosPersistence, IMapper mapper)
        {
            _departamentosPersistence = departamentosPersistence;
            _sharedPersistence = sharedPersistence;
            _mapper = mapper;

        }

        public async Task<PageList<DepartamentoDto>> GetAllDepartamentosAsync(PageParameters pageParameters, int empresaId)
        {
            try
            {
                var departamentos = await _departamentosPersistence.GetAllDepartamentosAsync(pageParameters, empresaId);

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

                _sharedPersistence.Create<Departamento>(departamento);

                if (await _sharedPersistence.SaveChangesAsync())
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

                return await _sharedPersistence.SaveChangesAsync();
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public DashboardDepartamento GetDashboard(int empresaId, int departamentoId)
        {
            try
            {
                return _departamentosPersistence.GetDashboard(empresaId, departamentoId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}