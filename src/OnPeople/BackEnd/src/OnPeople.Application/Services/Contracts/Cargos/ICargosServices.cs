using OnPeople.Application.Dtos.Cargos;
using OnPeople.Domain.Models.Cargos;
using OnPeople.Integration.Models.Pages.Page;

namespace OnPeople.Application.Services.Contracts.Cargos
{
    public interface ICargosServices
    {
        Task<PageList<CargoDto>> GetAllCargosAsync();
        Task<CargoDto> GetCargoByIdAsync(int cargoId);
        Task<PageList<CargoDto>> GetCargosByDepartamentoIdAsync(int departamentoId);
        Task<CargoDto> CreateCargos(CargoDto cargoDto);
        Task<CargoDto> UpdateCargo (int cargoId, CargoDto cargoDto);
        Task<bool> DeleteCargo(int cargoId);
    }
}