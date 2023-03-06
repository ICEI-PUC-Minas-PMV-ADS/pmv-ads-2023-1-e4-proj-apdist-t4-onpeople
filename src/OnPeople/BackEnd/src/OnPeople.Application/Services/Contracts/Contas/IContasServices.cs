using OnPeople.Domain.Models.Contas;

namespace OnPeople.Application.Services.Contracts.Contas
{
    public interface IContasServices
    {
        Task<Conta> CreateContas(Conta model);
        Task<Conta> UpdateContas(int id, Conta model);
        Task<bool> DeleteContas(int id);
        Task<Conta> GetContaByIdAsync(int id);
        Task<IEnumerable<Conta>> GetAllContasByArgumentoAsync(string argumento);
        Task<IEnumerable<Conta>> GetAllContasAtivasAsync();
    }
}