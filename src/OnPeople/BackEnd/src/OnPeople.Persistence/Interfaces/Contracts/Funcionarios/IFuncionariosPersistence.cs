using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Persistence.Interfaces.Contracts.Shared;


namespace OnPeople.Persistence.Interfaces.Contracts.Funcionarios
{
    public interface IFuncionariosPersistence: ISharedPersistence
    {
        Task<PageList<Funcionario>> GetAllFuncionariosAsync(PageParameters pageParameters);
        Task<Funcionario> GetFuncionarioByIdAsync(int funcionarioId);
        
    }
}