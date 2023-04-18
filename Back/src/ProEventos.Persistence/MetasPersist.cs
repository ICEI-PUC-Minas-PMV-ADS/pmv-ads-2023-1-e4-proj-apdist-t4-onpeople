using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class MetasPersist : IMetaPersist
    {
        private readonly ProEventosContext _context;

        public MetasPersist(ProEventosContext context)
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


            query = query.AsNoTracking().OrderBy(m => m.Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}