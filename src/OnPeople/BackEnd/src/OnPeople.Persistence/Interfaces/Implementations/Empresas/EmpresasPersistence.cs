using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Empresas;
using OnPeople.Persistence.Interfaces.Contexts;
using OnPeople.Persistence.Interfaces.Contracts.Empresas;
using OnPeople.Persistence.Interfaces.Implementations.Shared;

namespace OnPeople.Persistence.Interfaces.Implementations.Empresas
{
    public class EmpresasPersistence : SharedPersistence, IEmpresasPersistence
    {
        private readonly OnPeopleContext _context;
        public EmpresasPersistence(OnPeopleContext context) : base(context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Empresa>> GetAllEmpresasAsync()
        {
            IQueryable<Empresa> query = _context.Empresas
                .Include(e => e.Contas)
                .Include(e => e.Departamentos);

            query = query
                .AsNoTracking()
                .OrderBy(e => e.Id);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Empresa>> GetAllEmpresasAtivasAsync()
        {
            IQueryable<Empresa> query = _context.Empresas 
                .Include(e => e.Contas)
                .Include(e => e.Departamentos);

            query = query
                .AsNoTracking()
                .Where(e => e.Ativa == true)
                .OrderBy(e => e.Id);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Empresa>> GetAllEmpresasFiliaisAsync()
        {
            IQueryable<Empresa> query = _context.Empresas
                .Include(e => e.Contas)
                .Include(e => e.Departamentos);

            query = query
                .AsNoTracking()
                .Where(e => e.Filial == true)
                .OrderBy(e => e.Id);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Empresa>> GetAllEmpresasByArgumentoAsync(string argumento)
        {
            IQueryable<Empresa> query = _context.Empresas                
                .Include(e => e.Contas)
                .Include(e => e.Departamentos);

            query = query
                .AsNoTracking()
                .OrderBy(e => e.Id)
                .Where(e => 
                    e.NomeEmpresa.ToLower().Contains(argumento.ToLower()) ||
                    e.NomeFantasia.ToLower().Contains(argumento.ToLower()) ||
                    e.Sigla.ToLower().Contains(argumento.ToLower()) 
                );

            return await query.ToListAsync();
        }
        public async Task<Empresa> GetEmpresaByIdAsync(int id)
        {
            IQueryable<Empresa> query = _context.Empresas
                .Include(e => e.Contas)
                .Include(e => e.Departamentos);

            query = query
                .AsNoTracking()
                .Where(e => e.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}