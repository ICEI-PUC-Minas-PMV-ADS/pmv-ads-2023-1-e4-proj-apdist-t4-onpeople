using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Empresas;
using OnPeople.Persistence.Interfaces.Contexts;
using OnPeople.Persistence.Interfaces.Contracts.Empresas;
using OnPeople.Persistence.Interfaces.Implementations.Shared;

namespace OnPeople.Persistence.Interfaces.Implementations.Empresas
{
    public class EmpresasContasPersistence : SharedPersistence, IEmpresasContasPersistence
    {
        private readonly OnPeopleContext _context;
        public EmpresasContasPersistence(OnPeopleContext context) : base(context)
        {
            _context = context;

        }
        public async Task<IEnumerable<EmpresaConta>> GetAllContasByEmpresaIdAsync(int id)
        {
            IQueryable<EmpresaConta> query = _context.EmpresasContas;

            query = query
                .AsNoTracking()
                .Where(e => e.EmpresaId == id)
                .OrderBy(e => e.EmpresaId);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<EmpresaConta>> GetAllEmpresasByContaIdAsync(int id)
        {
            IQueryable<EmpresaConta> query = _context.EmpresasContas;

            query = query
                .AsNoTracking()
                .Where(e => e.ContaId == id)
                .OrderBy(e => e.ContaId);

            return await query.ToListAsync();
        }
    }
}