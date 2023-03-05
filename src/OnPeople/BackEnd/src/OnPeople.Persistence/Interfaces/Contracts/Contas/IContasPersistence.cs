using OnPeople.Domain.Models.Contas;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Persistence.Interfaces.Contracts.Contas
{
    public interface IContasPersistence : ISharedPersistence
    {
         Task<Conta> GetContaByIdAsync(int id);
         Task<IEnumerable<Conta>> GetAllContasByArgumentoAsync(string argumento);
         Task<IEnumerable<Conta>> GetAllContasAtivasAsync();
    }
}