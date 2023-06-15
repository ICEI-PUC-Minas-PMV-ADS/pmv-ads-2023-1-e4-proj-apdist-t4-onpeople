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
                                m.TipoMeta.ToLower().Contains(pageParameters.Term.ToLower()) );
            } else {
                query = query
                    .Where(m => m.EmpresaId == empresaId && 
                                (m.NomeMeta.ToLower().Contains(pageParameters.Term.ToLower()) ||
                                m.TipoMeta.ToLower().Contains(pageParameters.Term.ToLower()) ));
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

        public async Task<IEnumerable<Meta>> GetAllMetasByEmpresaIdAsync(int empresaId)
        {
            IQueryable<Meta> query = _context.Metas
                .Include(m => m.Empresa)
                .Include(m => m.FuncionariosMetas);

            if (empresaId == 0)
                query = query
                    .AsNoTracking()
                    .OrderBy(m => m.Id);
            else        
                query = query
                    .AsNoTracking()
                    .OrderBy(m => m.Id)
                    .Where(m => m.EmpresaId == empresaId);

            return await query.ToArrayAsync();
        }
        public DashboardMetas GetDashboard(int empresaId)
        {
            IQueryable<Meta> query1 = _context.Metas
                .Include(m => m.Empresa)
                .Include(m => m.FuncionariosMetas);

              if (empresaId == 0) {
                query1 = query1
                    .AsNoTracking();
            } else {
                query1 = query1
                    .AsNoTracking()
                    .Where(m => m.EmpresaId == empresaId);
            }

            _dashMeta.CountMetas = query1.Count<Meta>();

            IQueryable<Meta> query2 = _context.Metas
                .Include(m => m.Empresa)
                .Include(m => m.FuncionariosMetas);
            
            if (empresaId == 0) {
                query2 = query2
                    .AsNoTracking()
                    .Where(m => m.MetaCumprida);
            } else {
                query2 = query2
                    .AsNoTracking()
                    .Where(m => m.MetaCumprida && m.EmpresaId == empresaId);
            }

            _dashMeta.CountMetasCumpridas = query2.Count<Meta>();

            IQueryable<Meta> query3 = _context.Metas
                .Include(m => m.Empresa)
                .Include(m => m.FuncionariosMetas);
            
            if (empresaId == 0) {
                query3 = query3
                    .AsNoTracking()
                    .Where(m => m.MetaAprovada);
            } else {
                query3 = query3
                    .AsNoTracking()
                    .Where(m => m.MetaAprovada && m.EmpresaId == empresaId);
            }

            _dashMeta.CountMetasAprovadas = query3.Count<Meta>();

            return _dashMeta;
        }
    }
}