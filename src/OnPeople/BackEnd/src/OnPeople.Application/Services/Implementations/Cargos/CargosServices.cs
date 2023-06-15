using AutoMapper;
using OnPeople.Application.Dtos.Cargos;
using OnPeople.Application.Services.Contracts.Cargos;
using OnPeople.Domain.Models.Cargos;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Persistence.Interfaces.Contracts.Cargos;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Application.Services.Implementations.Cargos
{
    public class CargosServices : ICargosServices
    {
        private readonly ISharedPersistence _sharedPersistence;
        private readonly ICargosPersistence _cargosPersistence;
        private readonly IMapper _mapper;

        public CargosServices(
           ISharedPersistence sharedPersistence,
           ICargosPersistence cargosPersistence, IMapper mapper)
        {
            _cargosPersistence = cargosPersistence;
            _sharedPersistence = sharedPersistence;
            _mapper = mapper;

        }

        public async Task<PageList<CargoDto>> GetAllCargosAsync(PageParameters pageParameters, int empresaId, int departamentoId)
        {
            try
            {
                var cargos = await _cargosPersistence.GetAllCargosAsync(pageParameters, empresaId, departamentoId);

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

                _sharedPersistence.Create<Cargo>(cargo);

                if (await _sharedPersistence.SaveChangesAsync())
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

                return await _sharedPersistence.SaveChangesAsync();
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public DashboardCargos GetDashboard(int departamentoId) 
        {
            try
            {
                return _cargosPersistence.GetDashboard(departamentoId);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}