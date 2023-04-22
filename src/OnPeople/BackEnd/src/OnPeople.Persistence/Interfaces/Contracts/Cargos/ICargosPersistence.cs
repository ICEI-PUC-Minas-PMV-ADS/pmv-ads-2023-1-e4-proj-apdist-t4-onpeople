using OnPeople.Domain.Models.Cargos;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Persistence.Interfaces.Contracts.Cargos
{
    public interface ICargosPersistence : ISharedPersistence
    {
        Task<IEnumerable<Cargo>> GetAllCargosAsync();
        Task<Cargo> GetCargoByIdAsync(int cargoId);
        Task<IEnumerable<Cargo>> GetCargosByDepartamentoIdAsync(int departamentoId);
    }
}