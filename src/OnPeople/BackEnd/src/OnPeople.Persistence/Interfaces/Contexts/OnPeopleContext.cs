using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Cargos;
using OnPeople.Domain.Models.Contas;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Domain.Models.Empresas;
using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Domain.Models.Metas;

namespace OnPeople.Persistence.Interfaces.Contexts
{
    public class OnPeopleContext : DbContext
    {
        public OnPeopleContext(DbContextOptions<OnPeopleContext> options) : base(options) { }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<ContaFuncao> ContasFuncoes { get; set; }
        public DbSet<Funcao> Funcoes { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<EmpresaConta> EmpresasContas { get; set; }
        public DbSet<EmpresaDepartamento> EmpresasDepartamentos { get; set; }
        public DbSet<DadoPessoal> DadosPessoais { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<FuncionarioMeta> FuncionariosMetas { get; set; }
        public DbSet<Meta> Metas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmpresaConta>()
                .HasKey(EC => new {EC.EmpresaId, EC.ContaId});

            modelBuilder.Entity<EmpresaDepartamento>()
                .HasKey(ED => new {ED.EmpresaId, ED.DepartamentoId});

            modelBuilder.Entity<FuncionarioMeta>()
                .HasKey(FM => new { FM.FuncionarioId, FM.MetaId});
                
            modelBuilder.Entity<ContaFuncao>()
                .HasKey(CF => new {CF.ContaId, CF.FuncaoId});    
        }
    }
}