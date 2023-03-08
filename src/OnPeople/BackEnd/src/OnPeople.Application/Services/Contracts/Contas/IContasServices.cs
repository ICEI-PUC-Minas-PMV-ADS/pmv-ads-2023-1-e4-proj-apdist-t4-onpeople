using OnPeople.Application.Dtos.Contas;
using OnPeople.Domain.Models.Contas;

namespace OnPeople.Application.Services.Contracts.Contas
{
    public interface IContasServices
    {
        Task<ContaDto> CreateContas(ContaDto contaDto);
        Task<ContaDto> UpdateContas(int id, ContaDto contaDto);
        Task<bool> DeleteContas(int id);
        Task<ContaDto> GetContaByIdAsync(int id);
        Task<IEnumerable<ContaDto>> GetAllContasByArgumentoAsync(string argumento);
        Task<IEnumerable<ContaDto>> GetAllContasAtivasAsync();
    }
}