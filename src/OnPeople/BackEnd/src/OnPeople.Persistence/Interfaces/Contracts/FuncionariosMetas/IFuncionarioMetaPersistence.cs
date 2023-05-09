using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Persistence.Interfaces.Contracts.Shared;


namespace OnPeople.Persistence.Interfaces.Contracts.FuncionariosMetas
{
    public interface IFuncionarioMetaPersistence: ISharedPersistence
    {
        Task<int> AssociarMetaAFuncionario(int funcionarioId, int metaId);

        Task<FuncionarioMeta> GetFuncionarioMetaById(int id);
    }
}