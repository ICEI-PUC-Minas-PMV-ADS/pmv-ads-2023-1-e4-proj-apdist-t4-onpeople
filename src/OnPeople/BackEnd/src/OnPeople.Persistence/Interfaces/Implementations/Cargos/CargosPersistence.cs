using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Cargos;
using OnPeople.Persistence.Interfaces.Contexts;
using OnPeople.Persistence.Interfaces.Contracts.Cargos;
using OnPeople.Persistence.Interfaces.Implementations.Shared;

namespace OnPeople.Persistence.Interfaces.Implementations.Cargos
{
    public class CargosPersistence : SharedPersistence, ICargosPersistence
    {
        private readonly OnPeopleContext _context;

        public CargosPersistence(OnPeopleContext context) : base(context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Cargo>> GetAllCargosAsync()
        {
            IQueryable<Cargo> query = _context.Cargos;
            

            query = query
                .AsNoTracking()
                .OrderBy(c => c.Id);

            return await query.ToListAsync();
        }

        public async Task<Cargo> GetCargoByIdAsync(int cargoId)
        {
            IQueryable<Cargo> query = _context.Cargos;

            query = query
                .AsNoTracking()
                .Where(c => c.Id == cargoId);

            return await query.FirstOrDefaultAsync();
        }

           public async Task<IEnumerable<Cargo>> GetCargosByDepartamentoIdAsync(int departamentoId)
        {
            IQueryable<Cargo> query = _context.Cargos;

            query = query
                .AsNoTracking()
                .Where(c => c.DepartamentoId == departamentoId)
                .OrderBy(c => c.Id);

            return await query.ToListAsync();
        }

    }
}
