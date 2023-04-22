using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.Integration.Models.Pages.Page;
using OnPeople.Persistence.Interfaces.Contexts;
using OnPeople.Persistence.Interfaces.Contracts.Funcionarios;
using OnPeople.Persistence.Interfaces.Implementations.Shared;

namespace OnPeople.Persistence.Interfaces.Implementations.Funcionarios
{
    public class FuncionariosPersistence : SharedPersistence, IFuncionariosPersistence
    {
        private readonly OnPeopleContext _context;

        public FuncionariosPersistence(OnPeopleContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PageList<Funcionario>> GetAllFuncionariosAsync(PageParameters pageParameters)
        {
            // Console.WriteLine("-------------------------" + master);
            IQueryable<Funcionario> query = _context.Funcionarios
                .Include(f => f.DadosPessoais)
                .Include(f => f.Enderecos)
                .Include(f => f.FuncionariosMetas)
                .AsNoTracking();

                return await PageList<Funcionario>.CreatePageAsync(query, pageParameters.PageNumber, pageParameters.PageSize);
        }

        public async Task<Funcionario> GetFuncionarioByIdAsync(int funcionarioId)
        {
            IQueryable<Funcionario> query = _context.Funcionarios
            .Include(f => f.DadosPessoais)
            .Include(f => f.Enderecos)
            .Include(f => f.FuncionariosMetas);

            query = query
                .AsNoTracking()
                .Where(f => f.Id == funcionarioId);

            return await query.FirstOrDefaultAsync();
        }
    }
}