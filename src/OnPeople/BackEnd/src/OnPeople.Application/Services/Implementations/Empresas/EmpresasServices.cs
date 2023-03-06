using OnPeople.Application.Services.Contracts.Empresas;
using OnPeople.Domain.Models.Empresas;
using OnPeople.Persistence.Interfaces.Contracts.Empresas;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Application.Services.Implementations.Empresas
{
    public class EmpresasServices : IEmpresasServices
    {
        private readonly ISharedPersistence _sharedPersistence;
        private readonly IEmpresasPersistence _empresasPersistence;
        public EmpresasServices(
            ISharedPersistence sharedPersistence,
            IEmpresasPersistence empresasPersistence)
        {
            _empresasPersistence = empresasPersistence;
            _sharedPersistence = sharedPersistence;

        }
        public async Task<Empresa> CreateEmpresas(Empresa model)
        {
        try
            {
                _sharedPersistence.Create<Empresa>(model);

                if (await _empresasPersistence.SaveChangesAsync())
                {
                    return await _empresasPersistence.GetEmpresaByIdAsync(model.Id);
                }

                return null;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteEmpresas(int id)
        {
            try
            {
                var empresa = await _empresasPersistence.GetEmpresaByIdAsync(id);

                if (empresa == null) throw new Exception("Empresa para deleção náo foi encontrada!");

                  _empresasPersistence.Delete<Empresa>(empresa);

                return await _sharedPersistence.SaveChangesAsync();
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
        public async Task<IEnumerable<Empresa>> GetAllEmpresasAsync()
        {
            try
            {
                var empresas = await _empresasPersistence.GetAllEmpresasAsync();

                if (empresas == null) return null;

                return empresas;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
        public async Task<IEnumerable<Empresa>> GetAllEmpreasByArgumentoAsync(string argumento)
        {
            try
            {
                var empresas = await _empresasPersistence.GetAllEmpresasByArgumentoAsync(argumento);

                if (empresas == null) return null;

                return empresas;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<Empresa>> GetAllEmpresasAtivasAsync()
        {
            try
            {
                var empresas = await _empresasPersistence.GetAllEmpresasAtivasAsync();

                if (empresas == null) return null;

                return empresas;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<Empresa>> GetAllEmpresasFiliaisAsync()
        {
            try
            {
                var empresas = await _empresasPersistence.GetAllEmpresasFiliaisAsync();

                if (empresas == null) return null;

                return empresas;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<Empresa> GetEmpresaByIdAsync(int id)
        {
            try
            {
                var empresa = await _empresasPersistence.GetEmpresaByIdAsync(id);

                if (empresa == null) return null;

                return empresa;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<Empresa> UpdateEmpresas(int id, Empresa model)
        {
            try
            {
                var empresa = await _empresasPersistence.GetEmpresaByIdAsync(id);

                if (empresa == null) return null;

                model.Id = empresa.Id; 

                _sharedPersistence.Update(model);

                if (await _sharedPersistence.SaveChangesAsync())
                {
                    return await _empresasPersistence.GetEmpresaByIdAsync(model.Id);
                }

                return null;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
    }
}