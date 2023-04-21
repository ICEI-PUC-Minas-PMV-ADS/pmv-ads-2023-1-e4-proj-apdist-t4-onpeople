using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Metas;
using OnPeople.Persistence.Interfaces.Contexts;
using OnPeople.Persistence.Interfaces.Contracts.Metas;
using OnPeople.Persistence.Interfaces.Implementations.Shared;

namespace OnPeople.Persistence.Interfaces.Implementations.Metas
{
    public class MetasPersist : IMetaPersist
    {
        private readonly OnPeopleContext _context;

        public MetasPersist(OnPeopleContext context)
        {
            _context = context;
    
        }

        public async Task<Meta[]> GetAllMetasAsync()
        {
            IQueryable<Meta> query = _context.Metas;
            

            query = query.AsNoTracking().OrderBy(m => m.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Meta[]> GetAllMetasByTipoAsync(string tipoMeta)
        {
            IQueryable<Meta> query = _context.Metas;


            query = query.AsNoTracking().OrderBy(m => m.Id)
                         .Where(m => m.TipoMeta.ToLower().Contains(tipoMeta.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Meta> GetMetaByIdAsync(int id)
        {
            IQueryable<Meta> query = _context.Metas;


            query = query.AsNoTracking().OrderBy(m => m.Id).Where(m => m.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}