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
            IQueryable<Departamento> query = _context.Departamentos
            .Include(d => d.Cargos);


            query = query
                .AsNoTracking()
                .OrderBy(d => d.Id);

            return await query.ToListAsync();
        }

        public async Task<Departamento> GetDepartamentoByIdAsync(int departamentoId)
        {
            IQueryable<Departamento> query = _context.Departamentos
            .Include(d => d.Cargos);

            query = query
                .AsNoTracking()
                .Where(d => d.Id == departamentoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Departamento>> GetDepartamentosByEmpresaIdAsync(int empresaId)
        {
            IQueryable<Departamento> query = _context.Departamentos
            .Include(d => d.Cargos);

            query = query
                .AsNoTracking()
                .Where(d => d.EmpresaId == empresaId)
                .OrderBy(d => d.Id);

            return await query.ToListAsync();
        }

    }
}
