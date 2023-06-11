using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Empresas;
using OnPeople.Integration.Models.Dashboard;
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
        private readonly DashboardEmpresa _dashEmpresa = new();
        public EmpresasPersistence(OnPeopleContext context) : base(context)
        {
            _context = context;

        }
        public async Task<PageList<Empresa>> GetAllEmpresasAsync(PageParameters pageParameters, int empresaId, Boolean Master)
        {
            IQueryable<Empresa> query = _context.Empresas
                .Include(e => e.Users)
                .Include(e => e.Departamentos)
                .Include(e => e.Cargos)
                .Include(e => e.Funcionarios);

            query = query
                .AsNoTracking()
                .OrderBy(e => e.Id);
                
            if (empresaId == 0 && Master) {
                query = query
                    .Where(e =>  
                        e.RazaoSocial.ToLower().Contains(pageParameters.Term.ToLower()) ||
                        e.RazaoSocial.ToLower().Contains(pageParameters.Term.ToLower()) ||
                        e.SiglaEmpresa.ToLower().Contains(pageParameters.Term.ToLower()));
            } else {
                query = query
                .Where(e => e.Id == empresaId && ( 
                    e.RazaoSocial.ToLower().Contains(pageParameters.Term.ToLower()) ||
                    e.RazaoSocial.ToLower().Contains(pageParameters.Term.ToLower()) ||
                    e.SiglaEmpresa.ToLower().Contains(pageParameters.Term.ToLower())));
            }

            return await PageList<Empresa>.CreatePageAsync(query, pageParameters.PageNumber, pageParameters.PageSize);
        }
        public async Task<PageList<Empresa>> GetAllEmpresasAtivasAsync(PageParameters pageParameters, int empresaId, Boolean master)
        {
            Console.WriteLine("Ativas /////////////////////////////////////// " + empresaId);
            IQueryable<Empresa> query = _context.Empresas 
                .Include(e => e.Users)
                .Include(e => e.Departamentos);

            query = query
                .AsNoTracking()
                .Where(e => e.Ativa == true && master)
                .OrderBy(e => e.Id);

            return await PageList<Empresa>.CreatePageAsync(query, pageParameters.PageNumber, pageParameters.PageSize);
        }

        public async Task<PageList<Empresa>> GetAllEmpresasFiliaisAsync(PageParameters pageParameters, int empresaId, Boolean master)
        {
            Console.WriteLine("filiais /////////////////////////////////////// " + empresaId);
            IQueryable<Empresa> query = _context.Empresas
                .Include(e => e.Users)
                .Include(e => e.Departamentos);

            query = query
                .AsNoTracking()
                .Where(e => e.Filial == true && master)
                .OrderBy(e => e.Id);
 

            return await PageList<Empresa>.CreatePageAsync(query, pageParameters.PageNumber, pageParameters.PageSize);
        }

        public async Task<Empresa> GetEmpresaMatrizAsync()
        {
            Console.WriteLine("matriz /////////////////////////////////////// " );
            IQueryable<Empresa> query = _context.Empresas
                .Include(e => e.Users)
                .Include(e => e.Departamentos);

            query = query
                .AsNoTracking()
                .Where(e => e.Filial == false )
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

        public async Task<Empresa> GetEmpresaByCnpjAsync(string cnpj, Boolean Master)
        {
            IQueryable<Empresa> query = _context.Empresas
                .Include(e => e.Users)
                .Include(e => e.Departamentos);


            query = query
                .AsNoTracking()
                .Where(e => e.Cnpj == cnpj && Master);

            return await query.FirstOrDefaultAsync();
        }
        public DashboardEmpresa GetDashboard(int empresaId, Boolean master)
        {
            IQueryable<Empresa> queryFiliais = _context.Empresas;

            if (empresaId == 0 && master)
                queryFiliais = queryFiliais
                    .AsNoTracking()
                    .Where(e => e.Filial);
            else
                queryFiliais = queryFiliais
                    .AsNoTracking()
                    .Where(e => e.Filial && e.Id == empresaId );

            _dashEmpresa.CountFiliais = queryFiliais.Count<Empresa>();

            IQueryable<Empresa> queryEmpresaAtivas = _context.Empresas;

            if (empresaId == 0 && master)
                queryEmpresaAtivas = queryEmpresaAtivas
                    .AsNoTracking()
                    .Where(e => e.Ativa);
            else
                queryEmpresaAtivas = queryEmpresaAtivas
                    .AsNoTracking()
                    .Where(e => e.Ativa && e.Id == empresaId );

            _dashEmpresa.CountEmpresasAtivas = queryEmpresaAtivas.Count<Empresa>();

            IQueryable<Empresa> queryEmpresas = _context.Empresas;

            if (empresaId == 0 && master)
                queryEmpresas = queryEmpresas
                    .AsNoTracking();
            else
                queryEmpresas = queryEmpresas
                    .AsNoTracking()
                    .Where(e => e.Id == empresaId);

            _dashEmpresa.CountEmpresas = queryEmpresas.Count<Empresa>();   

            IQueryable<Empresa> queryFiliaisAtivas = _context.Empresas;

            if (empresaId == 0 && master)
                queryFiliaisAtivas = queryFiliaisAtivas
                    .AsNoTracking()
                    .Where(e => e.Filial && e.Ativa);
            else
                queryFiliaisAtivas = queryFiliaisAtivas
                    .AsNoTracking()
                    .Where(e => e.Filial && e.Ativa && e.Id == empresaId );
                    
           _dashEmpresa.CountFiliaisAtivas = queryFiliaisAtivas.Count<Empresa>();   

            return _dashEmpresa;
        }

    }
}