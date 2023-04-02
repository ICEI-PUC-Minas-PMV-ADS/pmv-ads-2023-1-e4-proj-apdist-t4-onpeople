using OnPeople.Domain.Models.Departamentos;

namespace OnPeople.Application.Services.Contracts.Departamentos
{
    public interface IDepartamentosServices
    {
        Task<Departamento> CreateDepartamentos(Departamento model);
        Task<IEnumerable<Departamento>> GetAllDepartamentosAsync();
        Task<Departamento> GetDepartamentoByIdAsync(int id);
        Task<Departamento> UpdateDepartamento(int id, Departamento model);
        Task<bool> DeleteDepartamento(int id);
    }
}