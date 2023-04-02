using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Persistence.Interfaces.Contexts;
using OnPeople.Persistence.Interfaces.Contracts.Departamentos;
using OnPeople.Persistence.Interfaces.Implementations.Shared;

namespace OnPeople.Persistence.Interfaces.Implementations.Empresas
{
    public class DepartamentosEmpresasPersistence : SharedPersistence, IDepartamentosEmpresasPersistence
    {
        private readonly OnPeopleContext _context;
        public DepartamentosEmpresasPersistence(OnPeopleContext context) : base(context)
        {
            _context = context;

        }
        public async Task<IEnumerable<DepartamentoEmpresa>> GetAllDepartamentosByEmpresaIdAsync(int id)
        {
            IQueryable<DepartamentoEmpresa> query = _context.DepartamentosEmpresas;

            query = query
                .AsNoTracking()
                .Where(e => e.DepartamentoId == id)
                .OrderBy(e => e.EmpresaId);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<DepartamentoEmpresa>> GetAllEmpresasByDepartamentoIdAsync(int id)
        {
            IQueryable<DepartamentoEmpresa> query = _context.DepartamentosEmpresas;

            query = query
                .AsNoTracking()
                .Where(e => e.EmpresaId == id)
                .OrderBy(e => e.EmpresaId);

            return await query.ToListAsync();
        }
    }
}