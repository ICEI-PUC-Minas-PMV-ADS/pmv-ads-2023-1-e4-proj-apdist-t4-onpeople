using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Empresas;
using OnPeople.Persistence.Interfaces.Contexts;
using OnPeople.Persistence.Interfaces.Contracts.Empresas;
using OnPeople.Persistence.Interfaces.Implementations.Shared;

namespace OnPeople.Persistence.Interfaces.Implementations.Empresas
{
    public class EmpresasDepartamentosPersistence : SharedPersistence, IEmpresasDepartamentosPersistence
    {
        private readonly OnPeopleContext _context;
        public EmpresasDepartamentosPersistence(OnPeopleContext context) : base(context)
        {
            _context = context;

        }
        public async Task<IEnumerable<EmpresaDepartamento>> GetAllDepartamentosByEmpresaIdAsync(int id)
        {
            IQueryable<EmpresaDepartamento> query = _context.EmpresasDepartamentos;

            query = query
                .AsNoTracking()
                .Where(e => e.EmpresaId == id)
                .OrderBy(e => e.DepartamentoId);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<EmpresaDepartamento>> GetAllEmpresasByDepartamentoIdAsync(int id)
        {
            IQueryable<EmpresaDepartamento> query = _context.EmpresasDepartamentos;

            query = query
                .AsNoTracking()
                .Where(e => e.DepartamentoId == id)
                .OrderBy(e => e.DepartamentoId);

            return await query.ToListAsync();
        }
    }
}