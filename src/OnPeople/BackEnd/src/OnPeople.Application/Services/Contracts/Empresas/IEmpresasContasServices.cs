using OnPeople.Domain.Models.Empresas;

namespace OnPeople.Application.Services.Contracts.Empresas
{
    public interface IEmpresasContasServices
    {
         Task<IEnumerable<EmpresaConta>> GetAllContasByEmpresaIdAsync(int id);
         Task<IEnumerable<EmpresaConta>> GetAllEmpresasByContaIdAsync(int id);
    }
}