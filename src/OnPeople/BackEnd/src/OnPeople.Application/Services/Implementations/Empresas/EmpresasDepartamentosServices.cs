using OnPeople.Application.Services.Contracts.Empresas;
using OnPeople.Domain.Models.Empresas;
using OnPeople.Persistence.Interfaces.Contracts.Empresas;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Application.Services.Implementations.Empresas
{
    public class EmpresasDepartamentosServices : IEmpresasDepartamentosServices
    {
        private readonly ISharedPersistence _sharedPersistence;
        private readonly IEmpresasDepartamentosPersistence _empresasDepartamentosPersistence;
        public EmpresasDepartamentosServices(
            ISharedPersistence sharedPersistence,
            IEmpresasDepartamentosPersistence empresasDepartamentosPersistence)
        {
            _empresasDepartamentosPersistence = empresasDepartamentosPersistence;
            _sharedPersistence = sharedPersistence;

        }
        public async Task<IEnumerable<EmpresaDepartamento>> GetAllDepartamentosByEmpresaIdAsync(int id)
        {
            try
            {
                var empresasDepartamentos = await _empresasDepartamentosPersistence.GetAllDepartamentosByEmpresaIdAsync(id);

                if (empresasDepartamentos == null) return null;

                    return empresasDepartamentos;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<EmpresaDepartamento>> GetAllEmpresasByDepartamentoIdAsync(int id)
        {
            try
            {
                var empresasDepartamentos = await _empresasDepartamentosPersistence.GetAllEmpresasByDepartamentoIdAsync(id);

                if (empresasDepartamentos == null) return null;

                    return empresasDepartamentos;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}