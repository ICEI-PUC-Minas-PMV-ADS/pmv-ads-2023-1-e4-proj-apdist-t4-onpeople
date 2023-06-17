using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Persistence.Interfaces.Contexts;
using OnPeople.Persistence.Interfaces.Contracts.Funcionarios;
using OnPeople.Persistence.Interfaces.Implementations.Shared;

namespace OnPeople.Persistence.Interfaces.Implementations.Funcionarios
{
    public class FuncionariosMetasPersistence : SharedPersistence, IFuncionariosMetasPersistence
    {
        private readonly OnPeopleContext _context;
        private readonly DashboardFuncionariosMetas _dashFuncionarioMeta = new();

        public FuncionariosMetasPersistence(OnPeopleContext context) : base(context)
        {
            _context = context;

        }

        public async Task<IEnumerable<FuncionarioMeta>> GetAllFuncionariosByMetaIdAsync(int metaId)
        {
            IQueryable<FuncionarioMeta> query = _context.FuncionariosMetas
                .Include(fm => fm.Funcionario)
                .Include(fm => fm.Meta)
                .AsNoTracking()
                .Where(fm => fm.MetaId == metaId);
            
            return await query.ToArrayAsync();
        }

        public async Task<IEnumerable<FuncionarioMeta>> GetAllMetasByFuncionarioIdAsync(int funcionarioId)
        {
            IQueryable<FuncionarioMeta> query = _context.FuncionariosMetas
                .Include(fm => fm.Funcionario)
                .Include(fm => fm.Meta)
                .AsNoTracking()
                .Where(fm => fm.FuncionarioId == funcionarioId);
            
            return await query.ToArrayAsync();
        }
        
        public async Task<FuncionarioMeta> GetFuncionarioMetaByIdAsync(int funcionarioMetaId)
        {
            IQueryable<FuncionarioMeta> query = _context.FuncionariosMetas
                .Include(fm => fm.Funcionario)
                .Include(fm => fm.Meta)
                .AsNoTracking()
                .Where(fm => fm.Id == funcionarioMetaId);
            
            return await query.FirstOrDefaultAsync();
        }

        public async Task<FuncionarioMeta> GetFuncionarioMetaByIdsAsync(int funcionarioId, int metaId)
        {
            IQueryable<FuncionarioMeta> query = _context.FuncionariosMetas
                .Include(fm => fm.Funcionario)
                .Include(fm => fm.Meta)
                .AsNoTracking()
                .Where(fm => fm.FuncionarioId == funcionarioId && fm.MetaId == metaId);
            
            return await query.FirstOrDefaultAsync();
        }
        

        public DashboardFuncionariosMetas GetDashboard(int funcionarioId)
        {
            IQueryable<FuncionarioMeta> queryMetasAssociadas = _context.FuncionariosMetas
                .AsNoTracking();
              
                
            if (funcionarioId != 0 ) {
                queryMetasAssociadas = queryMetasAssociadas
                    .Where(fm => fm.FuncionarioId == funcionarioId);
            }

            _dashFuncionarioMeta.CountMetasAssociadas = queryMetasAssociadas.Count<FuncionarioMeta>();
            
            IQueryable<FuncionarioMeta> querymetasCumpridas = _context.FuncionariosMetas
                .AsNoTracking();
                
                
            if (funcionarioId == 0) {
                querymetasCumpridas = querymetasCumpridas
                    .Where(fm => fm.MetaCumprida);
            } else {
                querymetasCumpridas = querymetasCumpridas
                    .Where(fm => fm.MetaCumprida && fm.FuncionarioId == funcionarioId);
            }

            _dashFuncionarioMeta.CountMetasCumpridas = querymetasCumpridas.Count<FuncionarioMeta>();
            
            return _dashFuncionarioMeta;
        }
    }
}