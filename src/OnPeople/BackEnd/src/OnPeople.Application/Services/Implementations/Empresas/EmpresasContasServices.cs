using OnPeople.Application.Services.Contracts.Empresas;
using OnPeople.Domain.Models.Empresas;
using OnPeople.Persistence.Interfaces.Contracts.Empresas;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Application.Services.Implementations.Empresas
{
    public class EmpresasContasServices : IEmpresasContasServices
    {
        private readonly ISharedPersistence _sharedPersistence;
        private readonly IEmpresasContasPersistence _empresasContasPersistence;
        public EmpresasContasServices(
            ISharedPersistence sharedPersistence,
            IEmpresasContasPersistence empresasContasPersistence
        )
        {
            _empresasContasPersistence = empresasContasPersistence;
            _sharedPersistence = sharedPersistence;
            
        }
        public async Task<IEnumerable<EmpresaConta>> GetAllContasByEmpresaIdAsync(int id)
        {
            try
            {
                var empresasContas = await _empresasContasPersistence.GetAllContasByEmpresaIdAsync(id);

                if (empresasContas == null) return null;

                    return empresasContas;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<EmpresaConta>> GetAllEmpresasByContaIdAsync(int id)
        {
            try
            {
                var empresasContas = await _empresasContasPersistence.GetAllEmpresasByContaIdAsync(id);

                if (empresasContas == null) return null;

                return empresasContas;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
    }
}