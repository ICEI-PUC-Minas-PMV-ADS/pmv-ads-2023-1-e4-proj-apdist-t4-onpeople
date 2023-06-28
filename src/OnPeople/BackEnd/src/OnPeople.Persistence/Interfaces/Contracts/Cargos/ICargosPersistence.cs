using OnPeople.Domain.Models.Cargos;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Persistence.Interfaces.Contracts.Cargos
{
    public interface ICargosPersistence : ISharedPersistence
    {
        Task<PageList<Cargo>> GetAllCargosAsync(PageParameters pageParameters, int empresaId, int departamentoIc, int cargoId);
        Task<Cargo> GetCargoByIdAsync(int cargoId);
        Task<IEnumerable<Cargo>> GetCargosByDepartamentoIdAsync(int departamentoId);
    }
}