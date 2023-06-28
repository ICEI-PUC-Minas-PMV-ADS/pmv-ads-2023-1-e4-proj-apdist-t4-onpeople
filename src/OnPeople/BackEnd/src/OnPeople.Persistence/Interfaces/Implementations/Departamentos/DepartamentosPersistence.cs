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
        public async Task<PageList<Departamento>> GetAllDepartamentosAsync(PageParameters pageParameters, int empresaId, int departamentoId, bool Master)
        {
            IQueryable<Departamento> query = _context.Departamentos
            .Include(d => d.Empresa)
            .Include(d => d.Cargos)
            .Include(d => d.Funcionarios)
                .ThenInclude(d => d.FuncionariosMetas)
            .AsNoTracking()
            .OrderBy(d => d.Id);

            if (empresaId != 0 && departamentoId != 0) {
                query = query
                    .Where(d => d.Id == departamentoId && d.EmpresaId == empresaId && (
                        d.NomeDepartamento.ToLower().Contains(pageParameters.Term.ToLower()) ||
                        d.Sigla.ToLower().Contains(pageParameters.Term.ToLower())));
            } else if(departamentoId != 0) {
                query = query
                    .Where(d => d.Id == departamentoId && (
                        d.NomeDepartamento.ToLower().Contains(pageParameters.Term.ToLower()) ||
                        d.Sigla.ToLower().Contains(pageParameters.Term.ToLower())));
            } else {
                query = query
                    .Where(d => d.NomeDepartamento.ToLower().Contains(pageParameters.Term.ToLower()) ||
                           d.Sigla.ToLower().Contains(pageParameters.Term.ToLower()));
            }

            return await PageList<Departamento>.CreatePageAsync(query, pageParameters.PageNumber, pageParameters.PageSize);
        }

       public async Task<IEnumerable<Departamento>> GetAllDepartamentosByEmpresaIdAsync(int empresaId)
        {
            IQueryable<Departamento> query = _context.Departamentos
            .Include(d => d.Empresa)
            .Include(d => d.Cargos);

            if (empresaId == 0 ){
                query = query
                    .AsNoTracking()
                    .OrderBy(d => d.Id);
            } else {
                query = query
                    .AsNoTracking()
                    .OrderBy(d => d.Id)
                    .Where(d => d.EmpresaId == empresaId);

            }

            return await query.ToArrayAsync();
        }

        public async Task<Departamento> GetDepartamentoByIdAsync(int departamentoId)
        {
            IQueryable<Departamento> query = _context.Departamentos
            .Include(d => d.Empresa)
            .Include(d => d.Cargos)
            .Include(d => d.Funcionarios)
                .ThenInclude(d => d.FuncionariosMetas);
        
            query = query
                .AsNoTracking()
                .Where(d => d.Id == departamentoId);

            return await query.FirstOrDefaultAsync();
        }

    }
}
