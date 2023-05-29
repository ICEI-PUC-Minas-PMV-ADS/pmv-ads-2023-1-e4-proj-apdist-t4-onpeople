using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Cargos;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Persistence.Interfaces.Contexts;
using OnPeople.Persistence.Interfaces.Contracts.Cargos;
using OnPeople.Persistence.Interfaces.Implementations.Shared;

namespace OnPeople.Persistence.Interfaces.Implementations.Cargos
{
    public class CargosPersistence : SharedPersistence, ICargosPersistence
    {
        private readonly OnPeopleContext _context;
        private readonly DashboardCargos _dashCargo = new DashboardCargos();

        public CargosPersistence(OnPeopleContext context) : base(context)
        {
            _context = context;

        }
        public async Task<PageList<Cargo>> GetAllCargosAsync(PageParameters pageParameters, int empresaId, int departamentoId)
        {
            IQueryable<Cargo> query = _context.Cargos
                .Include(c => c.Empresa)
                .Include(c => c.Departamento)
                .Include(c => c.Funcionarios);

            if (empresaId == 0) {
                query = query
                    .AsNoTracking()
                    .OrderBy(c => c.Id)
                    .Where(c => c.NomeCargo.ToLower().Contains(pageParameters.Term.ToLower()));
            } else if (departamentoId == 0) {
                query = query
                    .AsNoTracking()
                    .OrderBy(c => c.Id)
                    .Where(c => c.EmpresaId == empresaId &&
                        c.NomeCargo.ToLower().Contains(pageParameters.Term.ToLower()));
            } else {
                query = query
                    .AsNoTracking()
                    .OrderBy(c => c.Id)
                    .Where(c => c.EmpresaId == empresaId && c.DepartamentoId == departamentoId &&
                        c.NomeCargo.ToLower().Contains(pageParameters.Term.ToLower()));
            }
            

            return await PageList<Cargo>.CreatePageAsync(query, pageParameters.PageNumber, pageParameters.PageSize);
        }

        public async Task<Cargo> GetCargoByIdAsync(int cargoId)
        {
            IQueryable<Cargo> query = _context.Cargos
                .Include(c => c.Empresa)
                .Include(c => c.Departamento)
                .Include(c => c.Funcionarios);

            query = query
                .AsNoTracking()
                .Where(c => c.Id == cargoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cargo>> GetCargosByDepartamentoIdAsync(int departamentoId)
        {
            IQueryable<Cargo> query = _context.Cargos
                .Include(c => c.Empresa)
                .Include(c => c.Departamento)
                .Include(c => c.Funcionarios);
            query = query
                .AsNoTracking()
                .Where(c => c.DepartamentoId == departamentoId)
                .OrderBy(c => c.Id);

            return await query.ToListAsync();
        }

        public DashboardCargos GetDashboard(int empresaId, int departamentoId, int cargoId)
        {
            IQueryable<Cargo> query = _context.Cargos
                .Include(c => c.Empresa)
                .Include(c => c.Departamento)
                .Include(c => c.Funcionarios);
            
            if (empresaId == 0) {
                query = query
                    .AsNoTracking();
            } else if (departamentoId == 0) {
                query = query
                    .AsNoTracking()
                    .Where(c => c.EmpresaId == empresaId);
            } else if (cargoId == 0) {
                query = query 
                    .AsNoTracking()
                    .Where(c => c.EmpresaId == empresaId &&  c.DepartamentoId == departamentoId);
             } else {
                query = query 
                    .AsNoTracking()
                    .Where(c => c.EmpresaId == empresaId &&  c.DepartamentoId == departamentoId && c.Id == cargoId);
            }

            _dashCargo.CountCargos = query.Count<Cargo>();

            return _dashCargo;
        }
    }
}
