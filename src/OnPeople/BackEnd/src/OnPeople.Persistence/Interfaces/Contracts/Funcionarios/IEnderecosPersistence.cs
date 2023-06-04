using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Persistence.Interfaces.Contracts.Shared;


namespace OnPeople.Persistence.Interfaces.Contracts.Funcionarios
{
    public interface IEnderecosPersistence: ISharedPersistence
    {
        Task<IEnumerable<Endereco>> GetAllEnderecosAsync();
        Task<Endereco> GetEnderecoByIdAsync(int enderecoId);
        Task<IEnumerable<Endereco>> GetAllEnderecosByFuncionarioIdAsync(int funcionarioId);

    }
}