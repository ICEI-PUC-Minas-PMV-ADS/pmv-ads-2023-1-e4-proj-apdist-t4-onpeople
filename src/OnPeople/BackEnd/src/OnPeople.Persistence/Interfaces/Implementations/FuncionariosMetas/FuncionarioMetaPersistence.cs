using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Domain.Models.Metas;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Persistence.Interfaces.Contexts;
using OnPeople.Persistence.Interfaces.Contracts.FuncionariosMetas;
using OnPeople.Persistence.Interfaces.Implementations.Shared;

namespace OnPeople.Persistence.Interfaces.Implementations.FuncionariosMetas
{
    public class FuncionarioMetaPersistence : SharedPersistence, IFuncionarioMetaPersistence
    {
        private readonly OnPeopleContext _context;

        public FuncionarioMetaPersistence(OnPeopleContext context) : base(context)
        {
            _context = context;

        }

        public async Task<int> AssociarMetaAFuncionario(int funcionarioId, int metaId)
        {
            Funcionario func = _context.Funcionarios
                                .Where(f => f.Id == funcionarioId)
                                .FirstOrDefault();
            Meta meta = _context.Metas
                                .Where(m => m.Id == metaId)
                                .FirstOrDefault();

            if (func == null || meta == null) 
                return 0;

            FuncionarioMeta funcMeta = new FuncionarioMeta();
            funcMeta.MetaId = metaId;
            funcMeta.FuncionarioId = funcionarioId;
            funcMeta.MetaCumprida = meta.MetaCumprida;
            funcMeta.InicioEfetivo = meta.InicioOficial;
            funcMeta.FimEfetivo = meta.FimOficial;
            //funcMeta.DiasEfetivo = meta.DiasPlanejado;
            funcMeta.InicioAcordado = meta.InicioPlanejado;
            funcMeta.FimAcordado = meta.FumPlanejado;
            funcMeta.DiasAcordado = meta.DiasPlanejado;

            _context.FuncionariosMetas.Add(funcMeta);
            return await _context.SaveChangesAsync();

            // return await _context.FuncionariosMetas
            //                 .Where(fm => fm.FuncionarioId == funcionarioId & fm.MetaId == metaId)
            //                 .FirstOrDefaultAsync();
        }

        public async Task<FuncionarioMeta> GetFuncionarioMetaById(int id)
        {
            IQueryable<FuncionarioMeta> query = _context.FuncionariosMetas;

            query = query
                .AsNoTracking()
                .Where(fm => fm.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}