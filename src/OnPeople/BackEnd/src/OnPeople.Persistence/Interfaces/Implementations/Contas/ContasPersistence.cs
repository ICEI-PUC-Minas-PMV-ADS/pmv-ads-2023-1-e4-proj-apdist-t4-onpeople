using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Contas;
using OnPeople.Persistence.Interfaces.Contexts;
using OnPeople.Persistence.Interfaces.Contracts.Contas;
using OnPeople.Persistence.Interfaces.Implementations.Shared;

namespace OnPeople.Persistence.Interfaces.Implementations.Contas
{
    public class ContasPersistence : SharedPersistence, IContasPersistence
    {
        private readonly OnPeopleContext _context;
        public ContasPersistence(OnPeopleContext context) : base(context)
        {
            _context = context;

        }        
        public async Task<IEnumerable<Conta>> GetAllContasByArgumentoAsync(string argumento)
        {
            IQueryable<Conta> query = _context.Contas;

            query = query
                .AsNoTracking()
                .OrderBy(c => c.Id)
                .Where(e => e.NomeCompleto.ToLower().Contains(argumento.ToLower()));

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Conta>> GetAllContasAtivasAsync()
        {
            IQueryable<Conta> query = _context.Contas;

            query = query
                .AsNoTracking()
                .Where(c => c.Ativa == true)
                .OrderBy(c => c.Id);

            return await query.ToListAsync();
        }

        public async Task<Conta> GetContaByIdAsync(int id)
        {
            IQueryable<Conta> query = _context.Contas;

            query = query
                .AsNoTracking()
                .Where(e => e.Id == id)
                .OrderBy(e => e.Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}