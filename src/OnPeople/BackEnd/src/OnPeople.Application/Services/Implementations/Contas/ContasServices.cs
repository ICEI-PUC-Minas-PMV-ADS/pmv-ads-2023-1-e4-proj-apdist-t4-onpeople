using OnPeople.Application.Services.Contracts.Contas;
using OnPeople.Domain.Models.Contas;
using OnPeople.Persistence.Interfaces.Contracts.Contas;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Application.Services.Implementations.Contas
{
    public class ContasServices : IContasServices
    {
        private readonly ISharedPersistence _sharedPersistence;
        private readonly IContasPersistence _contasPersistence;
        public ContasServices(
            ISharedPersistence sharedPersistence,
            IContasPersistence contasPersistence)
        {
            _contasPersistence = contasPersistence;
            _sharedPersistence = sharedPersistence;
        }        
        public async Task<Conta> CreateContas(Conta model)
        {
            try
            {
                _sharedPersistence.Create<Conta>(model);

                if (await _contasPersistence.SaveChangesAsync())
                {
                    return await _contasPersistence.GetContaByIdAsync(model.Id);
                }

                return null;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteContas(int id)
        {
            try
            {
                var conta = await _contasPersistence.GetContaByIdAsync(id);

               if (conta == null) throw new Exception("Conta para deleção náo foi encontradC!");

                  _contasPersistence.Delete<Conta>(conta);

                return await _sharedPersistence.SaveChangesAsync();
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
         public async Task<IEnumerable<Conta>> GetAllContasAtivasAsync()
        {
            try
            {
                var contas = await _contasPersistence.GetAllContasAtivasAsync();

                if (contas == null) return null;

                return contas;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<Conta>> GetAllContasByArgumentoAsync(string argumento)
        {
            try
            {
                var contas = await _contasPersistence.GetAllContasByArgumentoAsync(argumento);

                if (contas == null) return null;

                return contas;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<Conta> GetContaByIdAsync(int id)
        {
            try
            {
                var contas = await _contasPersistence.GetContaByIdAsync(id);

                if (contas == null) return null;

                return contas;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<Conta> UpdateContas(int id, Conta model)
        {
            try
            {
                var conta = await _contasPersistence.GetContaByIdAsync(id);

                if (conta == null) return null;

                model.Id = conta.Id;

                _contasPersistence.Update(model);

                if (await _sharedPersistence.SaveChangesAsync())
                {
                    return await _contasPersistence.GetContaByIdAsync(model.Id);
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