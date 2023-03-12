using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Persistence.Interfaces.Contexts;
using OnPeople.Persistence.Interfaces.Contracts.Departamentos;
using OnPeople.Persistence.Interfaces.Implementations.Shared;

namespace OnPeople.Persistence.Interfaces.Implementations.Departamentos
{
    public class DepartamentosPersistence : SharedPersistence, IDepartamentosPersistence
    {
        private readonly OnPeopleContext _context;

        public DepartamentosPersistence(OnPeopleContext context) : base(context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Departamento>> GetAllDepartamentosAsync()
        {
            IQueryable<Departamento> query = _context.Departamentos;

            query = query
                .AsNoTracking()
                .OrderBy(e => e.Id);

            return await query.ToListAsync();
        }

        public async Task<Departamento> GetDepartamentoByIdAsync(int id)
        {
            IQueryable<Departamento> query = _context.Departamentos;
               
            query = query
                .AsNoTracking()
                .Where(e => e.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}