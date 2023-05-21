using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;
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
        public async Task<PageList<Departamento>> GetAllDepartamentosAsync(PageParameters pageParameters, int empresaId)
        {
            Console.WriteLine("************PageParameters  " + pageParameters.PageNumber + " " + pageParameters.PageSize);
            IQueryable<Departamento> query = _context.Departamentos
            .Include(d => d.Empresa)
            .Include(d => d.Cargos);

            if (empresaId == 0) {
                query = query
                    .AsNoTracking()
                    .OrderBy(d => d.Id)
                    .Where(d => d.NomeDepartamento.ToLower().Contains(pageParameters.Term.ToLower()) ||
                           d.Sigla.ToLower().Contains(pageParameters.Term.ToLower())
                );
            } else {
                query = query
                    .AsNoTracking()
                    .OrderBy(d => d.Id)
                    .Where(d => d.EmpresaId == empresaId && (
                        d.NomeDepartamento.ToLower().Contains(pageParameters.Term.ToLower()) ||
                        d.Sigla.ToLower().Contains(pageParameters.Term.ToLower())
                    ));
            }

            return await PageList<Departamento>.CreatePageAsync(query, pageParameters.PageNumber, pageParameters.PageSize);
        }

        public async Task<Departamento> GetDepartamentoByIdAsync(int departamentoId)
        {
            IQueryable<Departamento> query = _context.Departamentos
            .Include(d => d.Empresa)
            .Include(d => d.Cargos);

            query = query
                .AsNoTracking()
                .Where(d => d.Id == departamentoId);

            return await query.FirstOrDefaultAsync();
        }

        public DashboardDepartamento GetDashboard(int empresaId, int departamentoId)
        {
            DashboardDepartamento dashDepartamento = new DashboardDepartamento();
            
            IQueryable<Departamento> query = _context.Departamentos
                .Include(d => d.Cargos)
                .Include(d => d.Empresa);

            if (departamentoId == 0)
                query = query
                    .AsNoTracking()
                    .Where(d => d.EmpresaId == empresaId);
            else
                query = query 
                    .AsNoTracking()
                    .Where(d => d.EmpresaId == empresaId &&  d.Id == departamentoId);


            dashDepartamento.CountDepartamentos = query.Count<Departamento>();
            
            return dashDepartamento;
        }

    }
}
