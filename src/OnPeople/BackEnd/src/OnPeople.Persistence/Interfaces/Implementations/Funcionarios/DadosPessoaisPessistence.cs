using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Persistence.Interfaces.Contexts;
using OnPeople.Persistence.Interfaces.Contracts.Funcionarios;
using OnPeople.Persistence.Interfaces.Implementations.Shared;

namespace OnPeople.Persistence.Interfaces.Implementations.Funcionarios
{
    public class DadosPessoaisPersistence : SharedPersistence, IDadosPessoaisPersistence
    {
        private readonly OnPeopleContext _context;

        public DadosPessoaisPersistence(OnPeopleContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DadoPessoal>> GetAllDadosPessoaisAsync()
        {
            // Console.WriteLine("-------------------------" + master);
            IQueryable<DadoPessoal> query = _context.DadosPessoais
                .Include(f => f.Funcionario)
                .AsNoTracking();
      
            return await query.ToListAsync();
        }

        public async Task<DadoPessoal> GetDadoPessoalByIdAsync(int dadoPessoalId)
        {
            Console.WriteLine("id" + dadoPessoalId);
            IQueryable<DadoPessoal> query = _context.DadosPessoais
            .Include(e => e.Funcionario);

            query = query
                .AsNoTracking()
                .Where(e => e.Id == dadoPessoalId);

            return await query.FirstOrDefaultAsync();
        }
        
        public async Task<IEnumerable<DadoPessoal>> GetAllDadosPessoaisByFuncionarioIdAsync(int funcionarioId)
        {
            // Console.WriteLine("-------------------------" + master);
            IQueryable<DadoPessoal> query = _context.DadosPessoais
                .Include(f => f.Funcionario)
                .AsNoTracking()
                .Where(e => e.FuncionarioId == funcionarioId)
                .OrderBy(e => e.Id);

            return await query.ToListAsync();
        }
    }
}