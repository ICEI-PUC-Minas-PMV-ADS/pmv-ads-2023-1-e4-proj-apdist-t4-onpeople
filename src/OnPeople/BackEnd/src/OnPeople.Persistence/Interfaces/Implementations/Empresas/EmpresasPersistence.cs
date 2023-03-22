using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Empresas;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;
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
        public async Task<PageList<Empresa>> GetAllEmpresasAsync(PageParameters pageParameters, int empresaId, Boolean Master)
        {
            IQueryable<Empresa> query = _context.Empresas
                .Include(e => e.Users)
                .Include(e => e.Departamentos);

            if (Master) {
                query = query
                    .AsNoTracking()
                    .OrderBy(e => e.Id)
                    .Where(e => 
                        e.NomeEmpresa.ToLower().Contains(pageParameters.Term.ToLower()) ||
                        e.NomeFantasia.ToLower().Contains(pageParameters.Term.ToLower()) ||
                        e.Sigla.ToLower().Contains(pageParameters.Term.ToLower())); 
            } else {
                query = query
                    .AsNoTracking()
                    .OrderBy(e => e.Id)
                    .Where(e => e.Id == empresaId && (
                        e.NomeEmpresa.ToLower().Contains(pageParameters.Term.ToLower()) ||
                        e.NomeFantasia.ToLower().Contains(pageParameters.Term.ToLower()) ||
                        e.Sigla.ToLower().Contains(pageParameters.Term.ToLower()))); 
            }

            return await PageList<Empresa>.CreatePageAsync(query, pageParameters.PageNumber, pageParameters.PageSize);
        }
        public async Task<PageList<Empresa>> GetAllEmpresasAtivasAsync(PageParameters pageParameters, int empresaId, Boolean Master)
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

            return await PageList<Empresa>.CreatePageAsync(query, pageParameters.PageNumber, pageParameters.PageSize);
        }

        public async Task<PageList<Empresa>> GetAllEmpresasFiliaisAsync(PageParameters pageParameters, int empreaId, Boolean Master)
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

            return await PageList<Empresa>.CreatePageAsync(query, pageParameters.PageNumber, pageParameters.PageSize);
        }

        public async Task<Empresa> GetEmpresaMatrizAsync()
        {
            IQueryable<Empresa> query = _context.Empresas
                .Include(e => e.Users)
                .Include(e => e.Departamentos);

            query = query
                .AsNoTracking()
                .Where(e => e.Filial == false)
                .OrderBy(e => e.Id);

            return await query.FirstOrDefaultAsync();
        }

        
        public async Task<Empresa> GetEmpresaByIdAsync(int empresaId)
        {
            IQueryable<Empresa> query = _context.Empresas
                .Include(e => e.Users)
                .Include(e => e.Departamentos);

            query = query
                .AsNoTracking()
                .Where(e => e.Id == empresaId);

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