using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Persistence.Interfaces.Contracts.Shared;


namespace OnPeople.Persistence.Interfaces.Contracts.Funcionarios
{
    public interface IFuncionariosPersistence: ISharedPersistence
    {
        Task<PageList<Funcionario>> GetAllFuncionariosAsync(PageParameters pageParameters, int empresaId, int departamentoId, int cargoId);
        Task<Funcionario> GetFuncionarioByIdAsync(int funcionarioId);
        Task<IEnumerable<Funcionario>> GetFuncionariosChefesByDepartamentoId(int departamentoId);
        Task<IEnumerable<Funcionario>> GetAllFuncionariosByCargoIdAsync(int cargoId);    
    }
}