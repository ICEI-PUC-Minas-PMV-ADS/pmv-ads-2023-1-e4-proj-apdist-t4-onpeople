using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Persistence.Interfaces.Contracts.Shared;


namespace OnPeople.Persistence.Interfaces.Contracts.Funcionarios
{
    public interface IFuncionariosMetasPersistence: ISharedPersistence
    {
        Task<IEnumerable<FuncionarioMeta>> GetAllFuncionariosByMetaIdAsync(int metaId);

        Task<IEnumerable<FuncionarioMeta>> GetAllMetasByFuncionarioIdAsync(int funcionarioId);
        Task<FuncionarioMeta> GetFuncionarioMetaByIdAsync(int funcionarioMetaId);
        Task<FuncionarioMeta> GetFuncionarioMetaByIdsAsync(int FuncionarioId, int metaId);

    }
}