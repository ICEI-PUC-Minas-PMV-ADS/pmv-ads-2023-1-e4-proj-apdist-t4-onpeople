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
                var departamento = await _departamentosPersistence.GetDepartamentoByIdAsync(id);

                if (departamento == null) return null;

                return departamento;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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

        public async Task<Departamento> UpdateDepartamento(int id, Departamento model)
        {
            try
            {
                var departamento = await _departamentosPersistence.GetDepartamentoByIdAsync(id);

                if (departamento == null) throw new Exception("Departamento não encontrado.");

                model.Id = departamento.Id;

                _sharedPersistence.Update(model);

                if (await _sharedPersistence.SaveChangesAsync())
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

        public async Task<bool> DeleteDepartamento(int id)
        {
            try
            {
                var departamento = await _departamentosPersistence.GetDepartamentoByIdAsync(id);

                if (departamento == null) throw new Exception("Departamento não encontrado.");

                _departamentosPersistence.Delete<Departamento>(departamento);

                return await _sharedPersistence.SaveChangesAsync();
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}