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
        private readonly DashboardCargos _dashCargo = new();

        public CargosPersistence(OnPeopleContext context) : base(context)
        {
            _context = context;

        }
        public async Task<PageList<Cargo>> GetAllCargosAsync(PageParameters pageParameters, int empresaId, int departamentoId, int cargoId)
        {
            IQueryable<Cargo> query = _context.Cargos
                .Include(c => c.Empresa)
                .Include(c => c.Departamento)
                .Include(c => c.Funcionarios)
                    .ThenInclude(e => e.FuncionariosMetas)
                .AsNoTracking()
                .OrderBy(c => c.Id);

            if (empresaId != 0 && departamentoId != 0 && cargoId != 0)
                query = query
                    .Where(c => c.EmpresaId == empresaId && c.DepartamentoId == departamentoId && c.Id == cargoId &&
                        c.NomeCargo.ToLower().Contains(pageParameters.Term.ToLower()));
            else if (cargoId != 0) 
                query = query
                    .Where(c => c.Id == cargoId &&
                        c.NomeCargo.ToLower().Contains(pageParameters.Term.ToLower()));
            else if (departamentoId != 0)
                query = query
                    .Where(c => c.DepartamentoId == departamentoId &&
                        c.NomeCargo.ToLower().Contains(pageParameters.Term.ToLower()));
            else if (empresaId != 0)
                query = query
                    .Where(c => c.EmpresaId == empresaId &&
                        c.NomeCargo.ToLower().Contains(pageParameters.Term.ToLower()));
            else
                query = query
                    .Where(c => c.NomeCargo.ToLower().Contains(pageParameters.Term.ToLower()));

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

            if (departamentoId == 0 )
            {
                query = query
                    .AsNoTracking()
                    .OrderBy(c => c.Id);
            } else {
                query = query
                    .AsNoTracking()
                    .Where(c => c.DepartamentoId == departamentoId)
                    .OrderBy(c => c.Id);

            }

            return await query.ToListAsync();
        }

    }
}
