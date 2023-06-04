using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Persistence.Interfaces.Contracts.Shared;


namespace OnPeople.Persistence.Interfaces.Contracts.Funcionarios
{
    public interface IDadosPessoaisPersistence: ISharedPersistence
    {
        Task<IEnumerable<DadoPessoal>> GetAllDadosPessoaisAsync();
        Task<DadoPessoal> GetDadoPessoalByIdAsync(int dadoPessoalId);
        
    }
}