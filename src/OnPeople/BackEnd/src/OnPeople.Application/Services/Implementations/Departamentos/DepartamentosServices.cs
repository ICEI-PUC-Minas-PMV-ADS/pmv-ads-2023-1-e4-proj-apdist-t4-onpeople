using OnPeople.Application.Services.Contracts.Departamentos;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Persistence.Interfaces.Contracts.Departamentos;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Application.Services.Implementations.Departamentos
{
    public class DepartamentosServices : IDepartamentosServices
    {
        private readonly ISharedPersistence _sharedPersistence;
        private readonly IDepartamentosPersistence _departamentosPersistence;

         public DepartamentosServices(
            ISharedPersistence sharedPersistence,
            IDepartamentosPersistence departamentosPersistence)
        {
            _departamentosPersistence = departamentosPersistence;
            _sharedPersistence = sharedPersistence;

        }

        public async Task<Departamento> CreateDepartamentos(Departamento model)
        {
        try
            {
                _sharedPersistence.Create<Departamento>(model);

                if (await _departamentosPersistence.SaveChangesAsync())
                {
                    return await _departamentosPersistence.GetDepartamentoByIdAsync(model.Id);
                }

                return null;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<Departamento>> GetAllDepartamentosAsync()
        {
            try
            {
                var departamentos = await _departamentosPersistence.GetAllDepartamentosAsync();

                if (departamentos == null) return null;

                return departamentos;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<Departamento> GetDepartamentoByIdAsync(int id)
        {
            try
            {
                var departamentos = await _departamentosPersistence.GetDepartamentoByIdAsync(id);

                if (departamentos == null) return null;

                return departamentos;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
    }
}