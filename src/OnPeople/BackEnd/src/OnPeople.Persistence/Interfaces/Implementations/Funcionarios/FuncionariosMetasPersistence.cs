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
            // Console.WriteLine("-------------------------" + master);
            IQueryable<FuncionarioMeta> query = _context.FuncionariosMetas
                .Include(fm => fm.Funcionario)
                .Include(fm => fm.Meta)
                .AsNoTracking()
                .Where(fm => fm.MetaId == metaId);
            
            return await query.ToArrayAsync();
        }

        public async Task<IEnumerable<FuncionarioMeta>> GetAllMetasByFuncionarioIdAsync(int funcionarioId)
        {
            // Console.WriteLine("-------------------------" + master);
            IQueryable<FuncionarioMeta> query = _context.FuncionariosMetas
                .Include(fm => fm.Funcionario)
                .Include(fm => fm.Meta)
                .AsNoTracking()
                .Where(fm => fm.FuncionarioId == funcionarioId);
            
            return await query.ToArrayAsync();
        }
        
        public async Task<FuncionarioMeta> GetFuncionarioMetaByIdAsync(int funcionarioMetaId)
        {
            // Console.WriteLine("-------------------------" + master);
            IQueryable<FuncionarioMeta> query = _context.FuncionariosMetas
                .Include(fm => fm.Funcionario)
                .Include(fm => fm.Meta)
                .AsNoTracking()
                .Where(fm => fm.Id == funcionarioMetaId);
            
            return await query.FirstOrDefaultAsync();
        }

        public DashboardFuncionariosMetas GetDashboard(int funcionarioId, int metaId)
        {
            IQueryable<FuncionarioMeta> queryMetasAssociadas = _context.FuncionariosMetas
                .AsNoTracking();
              
                
            if (funcionarioId == 0 && metaId == 0) {
            } else if (funcionarioId == 0) {
                queryMetasAssociadas = queryMetasAssociadas
                    .Where(fm => fm.MetaId == metaId);
            } else if (metaId == 0) {
                queryMetasAssociadas = queryMetasAssociadas 
                    .Where(fm => fm.FuncionarioId == funcionarioId);
            } else {
                queryMetasAssociadas = queryMetasAssociadas 
                    .Where(fm => fm.FuncionarioId == funcionarioId &&  fm.MetaId == metaId) ;
            }

            _dashFuncionarioMeta.CountMetasAssociadas = queryMetasAssociadas.Count<FuncionarioMeta>();
            
            IQueryable<FuncionarioMeta> querymetasCumpridas = _context.FuncionariosMetas
                .AsNoTracking();
                
                
            if (funcionarioId == 0 && metaId == 0) {
                querymetasCumpridas = querymetasCumpridas
                    .Where(fm => fm.MetaCumprida);
            } else if (funcionarioId == 0) {
                querymetasCumpridas = querymetasCumpridas
                    .Where(fm => fm.MetaCumprida && fm.MetaId == metaId);
            } else if (metaId == 0) {
                querymetasCumpridas = querymetasCumpridas 
                    .Where(fm => fm.MetaCumprida && fm.FuncionarioId == funcionarioId);
            } else {
                querymetasCumpridas = querymetasCumpridas 
                    .Where(fm => fm.MetaCumprida && fm.FuncionarioId == funcionarioId &&  fm.MetaId == metaId) ;
            }
            return _dashFuncionarioMeta;
        }
    }
}