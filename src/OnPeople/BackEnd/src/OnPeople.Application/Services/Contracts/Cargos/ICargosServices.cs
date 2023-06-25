using OnPeople.Application.Dtos.Cargos;
using OnPeople.Domain.Models.Cargos;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;

namespace OnPeople.Application.Services.Contracts.Cargos
{
    public interface ICargosServices
    {
        Task<PageList<CargoDto>> GetAllCargosAsync(PageParameters pageParameters, int empresaId, int departamentoId);
        Task<CargoDto> GetCargoByIdAsync(int cargoId);
        Task<PageList<CargoDto>> GetCargosByDepartamentoIdAsync(int departamentoId);
        Task<CargoDto> CreateCargos(CargoDto cargoDto);
        Task<CargoDto> UpdateCargo (int cargoId, CargoDto cargoDto);
        Task<bool> DeleteCargo(int cargoId);
        Task<DashboardCargos> GetDashboardCArgos(int empresaId, int departamentoId);
        Task<List<ListaMetas>> GetDashboardCargoMetas(int empresaId, int departamentoId);
    }
}