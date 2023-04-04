using OnPeople.Application.Services.Contracts.Departamentos;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Persistence.Interfaces.Contracts.Departamentos;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Application.Services.Implementations.Departamentos
{
    public class DepartamentosEmpresasServices : IDepartamentosEmpresasServices
    {
        private readonly ISharedPersistence _sharedPersistence;
        private readonly IDepartamentosEmpresasPersistence _departamentosEmpresasPersistence;
        public DepartamentosEmpresasServices(
            ISharedPersistence sharedPersistence,
            IDepartamentosEmpresasPersistence departamentosEmpresasPersistence)
        {
            _departamentosEmpresasPersistence = departamentosEmpresasPersistence;
            _sharedPersistence = sharedPersistence;

        }
        public async Task<IEnumerable<DepartamentoEmpresa>> GetAllDepartamentosByEmpresaIdAsync(int id)
        {
            try
            {
                var departamentosEmpresas = await _departamentosEmpresasPersistence.GetAllDepartamentosByEmpresaIdAsync(id);

                if (departamentosEmpresas == null) return null;

                return departamentosEmpresas;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<DepartamentoEmpresa>> GetAllEmpresasByDepartamentoIdAsync(int id)
        {
            try
            {
                var departamentosEmpresas = await _departamentosEmpresasPersistence.GetAllEmpresasByDepartamentoIdAsync(id);

                if (departamentosEmpresas == null) return null;

                return departamentosEmpresas;
            }
            
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}