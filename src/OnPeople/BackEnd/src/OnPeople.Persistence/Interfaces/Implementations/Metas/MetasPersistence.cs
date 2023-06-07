using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Metas;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Persistence.Interfaces.Contexts;
using OnPeople.Persistence.Interfaces.Contracts.Metas;
using OnPeople.Persistence.Interfaces.Implementations.Shared;

namespace OnPeople.Persistence.Interfaces.Implementations.Metas
{
    public class MetasPersistence : SharedPersistence, IMetaPersistence
    {
        private readonly OnPeopleContext _context;

        private readonly DashboardMetas _dashMeta = new();

        public MetasPersistence(OnPeopleContext context) : base(context)
        {
            _context = context;
    
        }

        public async Task<PageList<Meta>> GetAllMetasAsync(PageParameters pageParameters, int empresaId)
        {
            IQueryable<Meta> query = _context.Metas
                .Include(m => m.Empresa)
                .Include(m => m.FuncionariosMetas)
                .AsNoTracking()
                .OrderBy(c => c.Id);

             if (empresaId == 0) {
                query = query
                    .Where(m => m.NomeMeta.ToLower().Contains(pageParameters.Term.ToLower()) ||
                                m.TipoMeta.ToLower().Contains(pageParameters.Term.ToLower()) ||
                                m.Descricao.ToLower().Contains(pageParameters.Term.ToLower()));
            } else {
                query = query
                    .Where(m => m.EmpresaId == empresaId && 
                                (m.NomeMeta.ToLower().Contains(pageParameters.Term.ToLower()) ||
                                m.TipoMeta.ToLower().Contains(pageParameters.Term.ToLower()) ||
                                m.Descricao.ToLower().Contains(pageParameters.Term.ToLower())));
            }

            return await PageList<Meta>.CreatePageAsync(query, pageParameters.PageNumber, pageParameters.PageSize);
        }

        public async Task<IEnumerable<Meta>> GetAllMetasByTipoAsync(string tipoMeta)
        {
            IQueryable<Meta> query = _context.Metas
                .Include(m => m.Empresa)
                .Include(m => m.FuncionariosMetas);


            query = query.AsNoTracking().OrderBy(m => m.Id)
                         .Where(m => m.TipoMeta.ToLower().Contains(tipoMeta.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Meta> GetMetaByIdAsync(int id)
        {
            IQueryable<Meta> query = _context.Metas
                .Include(m => m.Empresa)
                .Include(m => m.FuncionariosMetas);


            query = query.AsNoTracking().OrderBy(m => m.Id).Where(m => m.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public DashboardMetas GetDashboard(int empresaId)
        {
            IQueryable<Meta> query = _context.Metas
                .Include(m => m.Empresa)
                .Include(m => m.FuncionariosMetas);
            
            if (empresaId == 0) {
                query = query
                    .AsNoTracking();
            } else {
                query = query
                    .AsNoTracking()
                    .Where(c => c.EmpresaId == empresaId);
            }

            _dashMeta.CountMetas = query.Count<Meta>();

            return _dashMeta;
        }
    }
}