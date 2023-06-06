using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Integration.Models.Dashboard;
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
        private readonly DashboardFuncionarios _dashFuncionario = new();

        public FuncionariosPersistence(OnPeopleContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PageList<Funcionario>> GetAllFuncionariosAsync(PageParameters pageParameters, int empresaId, int departamentoId, int cargoId)
        {
            // Console.WriteLine("-------------------------" + master);
            IQueryable<Funcionario> query = _context.Funcionarios
                .Include(f => f.Empresa)
                .Include(f => f.Departamento)
                .Include(f => f.Cargo)
                .Include(f => f.DadosPessoais)
                .Include(f => f.Enderecos)
                .Include(f => f.FuncionariosMetas)
                .Include(f => f.Users)
                .AsNoTracking();
            Console.WriteLine("empresa" + empresaId + " departamento "+ departamentoId);
            if (empresaId == 0) {
                query = query
                    .Where(f => f.Users.NomeCompleto.ToLower().Contains(pageParameters.Term.ToLower()));
            } else if (departamentoId == 0) {
                query = query
                    .Where(f => f.EmpresaId == empresaId &&
                       f.Users.NomeCompleto.ToLower().Contains(pageParameters.Term.ToLower()));
            } else {
                query = query
                    .Where(f => f.EmpresaId == empresaId && f.DepartamentoId == departamentoId &&
                        f.Users.NomeCompleto.ToLower().Contains(pageParameters.Term.ToLower()));
            }
            return await PageList<Funcionario>.CreatePageAsync(query, pageParameters.PageNumber, pageParameters.PageSize);
        }

        public async Task<Funcionario> GetFuncionarioByIdAsync(int funcionarioId)
        {
            IQueryable<Funcionario> query = _context.Funcionarios
                .Include(f => f.Empresa)
                .Include(f => f.Users)
                .Include(f => f.Departamento)
                .Include(f => f.Cargo)
                .Include(f => f.DadosPessoais)
                .Include(f => f.Enderecos)
                .Include(f => f.FuncionariosMetas)
                .AsNoTracking()
                .Where(f => f.Id == funcionarioId);
            Console.WriteLine("id " + funcionarioId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Funcionario>> GetFuncionariosChefesByDepartamentoId(int departamentoId)
        {
            IQueryable<Funcionario> query = _context.Funcionarios
                .Include(f => f.Cargo)
                .AsNoTracking()
                .Where(f => f.DepartamentoId == departamentoId &&
                            (f.Cargo.NomeCargo.ToLower().Contains("diretor") ||
                             f.Cargo.NomeCargo.ToLower().Contains("gerente") ||
                             f.Cargo.NomeCargo.ToLower().Contains("supervisor")));

            return await query.ToArrayAsync();
        }

        public DashboardFuncionarios GetDashboard(int empresaId, int departamentoId, int cargoId, int funcionarioId)
        {
            IQueryable<Funcionario> query = _context.Funcionarios
                .Include(c => c.Empresa)
                .Include(c => c.Departamento)
                .Include(c => c.Cargo);
            Console.WriteLine(empresaId + " " + departamentoId + " " + cargoId + " " + funcionarioId);
            if (empresaId == 0) {
                query = query
                    .AsNoTracking();
            } else if (departamentoId == 0) {
                query = query
                    .AsNoTracking()
                    .Where(c => c.EmpresaId == empresaId);
            } else if (cargoId == 0) {
                query = query 
                    .AsNoTracking()
                    .Where(c => c.EmpresaId == empresaId &&  c.DepartamentoId == departamentoId);
             } else if (funcionarioId == 0) {
                query = query 
                    .AsNoTracking()
                    .Where(c => c.EmpresaId == empresaId &&  c.DepartamentoId == departamentoId && c.Id == cargoId);
            } else {
                                query = query 
                    .AsNoTracking()
                    .Where(c => c.EmpresaId == empresaId &&  c.DepartamentoId == departamentoId && c.CargoId == cargoId && c.Id == funcionarioId) ;
            }

            _dashFuncionario.CountFuncionarios = query.Count<Funcionario>();

            return _dashFuncionario;
        }
    }
}