using OnPeople.Domain.Models.Empresas;

namespace OnPeople.Application.Services.Contracts.Empresas
{
    public interface IEmpresasDepartamentosServices
    {
                  
        Task<IEnumerable<EmpresaDepartamento>> GetAllDepartamentosByEmpresaIdAsync(int id);
        Task<IEnumerable<EmpresaDepartamento>> GetAllEmpresasByDepartamentoIdAsync(int id);
    }
}