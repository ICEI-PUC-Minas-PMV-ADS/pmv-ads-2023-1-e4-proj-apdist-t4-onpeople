using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Persistence.Interfaces.Contexts;
using OnPeople.Persistence.Interfaces.Contracts.Funcionarios;
using OnPeople.Persistence.Interfaces.Implementations.Shared;

namespace OnPeople.Persistence.Interfaces.Implementations.Funcionarios
{
    public class EnderecosPersistence : SharedPersistence, IEnderecosPersistence
    {
        private readonly OnPeopleContext _context;

        public EnderecosPersistence(OnPeopleContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Endereco>> GetAllEnderecosAsync()
        {
            IQueryable<Endereco> query = _context.Enderecos
                .Include(f => f.Funcionario)
                .AsNoTracking();
      
            return await query.ToListAsync();
        }

        public async Task<Endereco> GetEnderecoByIdAsync(int enderecoId)
        {
            IQueryable<Endereco> query = _context.Enderecos
            .Include(e => e.Funcionario);

            query = query
                .AsNoTracking()
                .Where(e => e.Id == enderecoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Endereco>> GetAllEnderecosByFuncionarioIdAsync(int funcionarioId)
        {
            IQueryable<Endereco> query = _context.Enderecos
                .Include(f => f.Funcionario)
                .AsNoTracking()
                .Where(e => e.FuncionarioId == funcionarioId)
                .OrderBy(e => e.Id);

            return await query.ToListAsync();
        }
    }
}