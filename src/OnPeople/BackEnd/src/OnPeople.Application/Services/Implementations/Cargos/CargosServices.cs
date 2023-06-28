using AutoMapper;
using OnPeople.Application.Dtos.Cargos;
using OnPeople.Application.Services.Contracts.Cargos;
using OnPeople.Domain.Models.Cargos;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Persistence.Interfaces.Contracts.Cargos;

namespace OnPeople.Application.Services.Implementations.Cargos
{
    public class CargosServices : ICargosServices
    {
        private readonly DashboardCargos _dashCargo = new();
        private readonly PageParameters _pageParameters = new();
        private readonly ICargosPersistence _cargosPersistence;
        private readonly IMapper _mapper;

        public CargosServices(
Persistence.Interfaces.Contracts.Shared.ISharedPersistence @object, ICargosPersistence cargosPersistence, IMapper mapper)
        {
            _cargosPersistence = cargosPersistence;
            _mapper = mapper;

        }

        public async Task<PageList<CargoDto>> GetAllCargosAsync(PageParameters pageParameters, int empresaId, int departamentoId, int cargoId)
        {
            try
            {
                var cargos = await _cargosPersistence.GetAllCargosAsync(pageParameters, empresaId, departamentoId, cargoId);

                if (cargos == null) return null;

                var cargosMapper = _mapper.Map<PageList<CargoDto>>(cargos);

                cargosMapper.CurrentPage = cargos.CurrentPage;
                cargosMapper.TotalPages = cargos.TotalPages;
                cargosMapper.PageSize = cargos.PageSize;
                cargosMapper.TotalCounter = cargos.TotalCounter;

                return cargosMapper;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<CargoDto> GetCargoByIdAsync(int cargoId)
        {
            try
            {
                var cargo = await _cargosPersistence.GetCargoByIdAsync(cargoId);

                if (cargo == null) return null;

                var cargosMapper = _mapper.Map<CargoDto>(cargo);

                return cargosMapper;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<PageList<CargoDto>> GetCargosByDepartamentoIdAsync(int departamentoId)
        {
            try
            {
                var cargos = await _cargosPersistence.GetCargosByDepartamentoIdAsync(departamentoId);

                if (cargos == null) return null;

                var cargosMapper = _mapper.Map<PageList<CargoDto>>(cargos);

                return cargosMapper;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<CargoDto> CreateCargos(CargoDto cargoDto)
        {
            try
            {
                var cargo = _mapper.Map<Cargo>(cargoDto);

                _cargosPersistence.Create<Cargo>(cargo);

                if (await _cargosPersistence.SaveChangesAsync())
                {
                    var cargoCriado = await _cargosPersistence.GetCargoByIdAsync(cargo.Id);
                    return _mapper.Map<CargoDto>(cargoCriado);
                }

                return null;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<CargoDto> UpdateCargo(int cargoId, CargoDto cargoDto)
        {
            try
            {
                var cargo = await _cargosPersistence.GetCargoByIdAsync(cargoId);

                if (cargo == null) return null;

                var cargoUpdate = _mapper.Map(cargoDto, cargo);

                _cargosPersistence.Update<Cargo>(cargoUpdate);

                if (await _cargosPersistence.SaveChangesAsync())
                {
                    var cargoAlterado = await _cargosPersistence.GetCargoByIdAsync(cargoUpdate.Id);
                    return _mapper.Map<CargoDto>(cargoAlterado);
                }

                return null;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteCargo(int cargoId)
        {
            try
            {
                var cargo = await _cargosPersistence.GetCargoByIdAsync(cargoId);

                if (cargo == null) return false;

                _cargosPersistence.Delete<Cargo>(cargo);

                return await _cargosPersistence.SaveChangesAsync();
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<DashboardCargos> GetDashboardCArgos(int empresaId, int departamentoId, int cargoId)
        {
            try
            {
                _pageParameters.PageSize = 1000;
                _pageParameters.PageNumber = 1;

                var cargos = await _cargosPersistence.GetAllCargosAsync(_pageParameters, empresaId, departamentoId, cargoId);
                
                if (cargos == null) return null;
                    
                _dashCargo.CountCargos = cargos.Count();
                _dashCargo.CountCargosAtivos  = cargos.Count(c => c.Ativo);
                _dashCargo.ListaNomeCargo = cargos.Select(e => e.NomeCargo);
                _dashCargo.ListaQtdeFuncionarios = cargos.Select(e => e.Funcionarios.Count());

                _dashCargo.PercentualCargosAtivos =  100.00 * ((double)_dashCargo.CountCargosAtivos)  / ((double)_dashCargo.CountCargos);
                
                return _dashCargo;
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            }
        }

        public async Task<List<ListaMetas>> GetDashboardCargoMetas(int empresaId, int departamentoId, int cargoId)
        {
            try
            {
                _pageParameters.PageSize = 1000;
                _pageParameters.PageNumber = 1;

                var cargos = await _cargosPersistence.GetAllCargosAsync(_pageParameters, empresaId, departamentoId, cargoId);

                if (cargos == null)
                    return new List<ListaMetas>();

                var dashCargosMetas = cargos.Select(cargo => new ListaMetas {
                    NomeEmpresa = cargo.NomeCargo,
                    QtdeMetas = cargo.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count(),
                    QtdeMetasCumpridas = cargo.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count(fm => fm.MetaCumprida),
                    QtdeMetasNaoCumpridas = cargo.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count(fm => !fm.MetaCumprida),
                    PercentualMetasCumpridas = cargo.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count(fm => fm.MetaCumprida) == 0 ? 0 : 100.00 * ((double)cargo.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count(fm => fm.MetaCumprida)) / ((double)cargo.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count()),
                    PercentualMetasNaoCumpridas = cargo.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count(fm => !fm.MetaCumprida) == 0 ? 0 : 100.00 * ((double)cargo.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count(fm => !fm.MetaCumprida)) / ((double)cargo.Funcionarios.SelectMany(fm => fm.FuncionariosMetas).Count())
                }).ToList();

                return dashCargosMetas;
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            }
        }
    }
}