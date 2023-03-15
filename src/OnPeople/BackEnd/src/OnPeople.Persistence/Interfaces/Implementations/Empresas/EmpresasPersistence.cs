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
        public async Task<IEnumerable<Empresa>> GetAllEmpresasAsync(int empresaId, Boolean Master)
        {
            IQueryable<Empresa> query = _context.Empresas
                .Include(e => e.Users)
                .Include(e => e.Departamentos);

            if (Master) {
                query = query
                    .AsNoTracking()
                    .OrderBy(e => e.Id);
            } else {
                query = query
                    .AsNoTracking()
                    .OrderBy(e => e.Id)
                    .Where(e => e.Id == empresaId);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Empresa>> GetAllEmpresasAtivasAsync(int empresaId, Boolean Master)
        {
            IQueryable<Empresa> query = _context.Empresas 
                .Include(e => e.Users)
                .Include(e => e.Departamentos);

            if (Master) {
                query = query
                    .AsNoTracking()
                    .Where(e => e.Ativa == true)
                    .OrderBy(e => e.Id);
            } else {
                query = query
                    .AsNoTracking()
                    .Where(e => e.Ativa == true && e.Id == empresaId)
                    .OrderBy(e => e.Id);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Empresa>> GetAllEmpresasFiliaisAsync(int empreaId, Boolean Master)
        {
            IQueryable<Empresa> query = _context.Empresas
                .Include(e => e.Users)
                .Include(e => e.Departamentos);

            if (Master) {
                query = query
                    .AsNoTracking()
                    .Where(e => e.Filial == true)
                    .OrderBy(e => e.Id);
            } else {
                query = query
                    .AsNoTracking()
                    .Where(e => e.Filial == true && e.Id == empreaId)
                    .OrderBy(e => e.Id);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Empresa>> GetAllEmpresasMatrizesAsync(int empresaId, Boolean Master)
        {
            IQueryable<Empresa> query = _context.Empresas
                .Include(e => e.Users)
                .Include(e => e.Departamentos);

            if (Master) {
                query = query
                    .AsNoTracking()
                    .Where(e => e.Filial == true)
                    .OrderBy(e => e.Id);
            } else {
                query = query
                    .AsNoTracking()
                    .Where(e => e.Filial == true && e.Id == empresaId)
                    .OrderBy(e => e.Id);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Empresa>> GetAllEmpresasByArgumentoAsync(int empresaId, Boolean Master, string argumento)
        {
            IQueryable<Empresa> query = _context.Empresas                
                 .Include(e => e.Users)
                .Include(e => e.Departamentos);

            if (Master) {
                query = query
                    .AsNoTracking()
                    .OrderBy(e => e.Id)
                    .Where(e => 
                        e.NomeEmpresa.ToLower().Contains(argumento.ToLower()) ||
                        e.NomeFantasia.ToLower().Contains(argumento.ToLower()) ||
                        e.Sigla.ToLower().Contains(argumento.ToLower()) 
                    );
            } else {
                                query = query
                    .AsNoTracking()
                    .OrderBy(e => e.Id)
                    .Where(e => e.Id == empresaId && (
                        e.NomeEmpresa.ToLower().Contains(argumento.ToLower()) ||
                        e.NomeFantasia.ToLower().Contains(argumento.ToLower()) ||
                        e.Sigla.ToLower().Contains(argumento.ToLower())) 
                    );
            }

            return await query.ToListAsync();
        }
        
        public async Task<Empresa> GetEmpresaByIdAsync(int empresaId, Boolean Master, int id)
        {
            IQueryable<Empresa> query = _context.Empresas
                .Include(e => e.Users)
                .Include(e => e.Departamentos);

            if (Master) {
                query = query
                    .AsNoTracking()
                    .Where(e => e.Id == id);
            } else {
                query = query
                    .AsNoTracking()
                    .Where(e => e.Id == id && e.Id == empresaId);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Empresa> GetEmpresaByContaIdAsync(int empresaId, Boolean Master)
        {
            IQueryable<Empresa> query = _context.Empresas
                .Include(e => e.Users)
                .Include(e => e.Departamentos);


            query = query
                .AsNoTracking()
                .Where(e => e.Id == empresaId);

            return await query.FirstOrDefaultAsync();
        }
    }
}