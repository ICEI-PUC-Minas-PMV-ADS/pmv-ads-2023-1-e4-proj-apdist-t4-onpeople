using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Cargos;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Domain.Models.Empresas;
using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Domain.Models.Metas;
using OnPeople.Domain.Models.Users;

namespace OnPeople.Persistence.Interfaces.Contexts
{
    public class OnPeopleContext : IdentityDbContext<User, 
                                                     Role, 
                                                     int, 
                                                     IdentityUserClaim<int>, 
                                                     UserRole, 
                                                     IdentityUserLogin<int>, 
                                                     IdentityRoleClaim<int>, 
                                                     IdentityUserToken<int>>
    {
        public OnPeopleContext(DbContextOptions<OnPeopleContext> options) : base(options) { }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<DadoPessoal> DadosPessoais { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<FuncionarioMeta> FuncionariosMetas { get; set; }
        public DbSet<Meta> Metas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(
                userRole =>
                {
                    userRole.HasKey(cf => new { cf.UserId, cf.RoleId });

                    userRole.HasOne(cf => cf.Role)
                        .WithMany(f => f.UsersRoles)
                        .HasForeignKey(cf => cf.RoleId)
                        .IsRequired();

                    userRole.HasOne(cf => cf.User)
                        .WithMany(f => f.UsersRoles)
                        .HasForeignKey(cf => cf.UserId)
                        .IsRequired();
                } 
            );

            modelBuilder.Entity<Empresa>(empresa =>
                {
                    empresa.HasMany(d => d.Departamentos);
                  
                    empresa.HasIndex(e => e.Ativa);

                    empresa.HasIndex(e => e.Filial);

                    empresa.HasIndex(e => e.MatrizId);

                    empresa.HasIndex(e => e.PresidenteId);
                } 
            );

            modelBuilder.Entity<Departamento>(departamento =>
                {
                    departamento.HasOne(d => d.Empresas);

                    departamento.HasMany(c => c.Cargos);

                    departamento.HasIndex(e => e.Ativo);

                    departamento.HasIndex(e => e.DiretorId);

                    departamento.HasIndex(e => e.GerenteId);

                    departamento.HasIndex(e => e.SupervisorId);
                } 

            
            );

            modelBuilder.Entity<Cargo>(cargo =>
                {
                    cargo.HasOne(c => c.Departamentos);

                    cargo.HasOne(c => c.Empresas);

                    cargo.HasMany(f => f.Funcionarios);

                    cargo.HasIndex(e => e.Ativo);
                } 
            
            );

            modelBuilder.Entity<Funcionario>(funcioario =>
                {
                    funcioario.HasOne(f => f.Cargos);

                    funcioario.HasOne(f => f.Departamentos);

                    funcioario.HasOne(f => f.Empresas);
                    
                    funcioario.HasOne(f => f.Users);

                    funcioario.HasMany(f => f.DadosPessoais);

                    funcioario.HasMany(f => f.Enderecos);

                    funcioario.HasMany(f => f.FuncionariosMetas);

                    funcioario.HasIndex(e => e.Ativo);
                } 
            );

            modelBuilder.Entity<DadoPessoal>(dadoPessoal =>
                {
                    dadoPessoal.HasOne(dp => dp.Funcionarios);
                } 
            );

            modelBuilder.Entity<Endereco>(endereco =>
                {
                    endereco.HasOne(e => e.Funcionarios);
                } 
            );

            modelBuilder.Entity<Meta>(meta =>
                {
                    meta.HasOne(m => m.Empresas);

                    meta.HasIndex(e => e.MetaCumprida);
                    
                    meta.HasIndex(e => e.MetaAprovada);
                } 
            );

            modelBuilder.Entity<FuncionarioMeta>(funcionarioMeta =>
                {
                    funcionarioMeta.HasKey(fm => new { fm.FuncionarioId, fm.MetaId });

                    funcionarioMeta.HasOne(fm => fm.Meta)
                        .WithMany(m => m.FuncionariosMetas)
                        .HasForeignKey(mf => mf.MetaId)
                        .IsRequired();

                    funcionarioMeta.HasOne(fm => fm.Funcionario)
                        .WithMany(m => m.FuncionariosMetas)
                        .HasForeignKey(mf => mf.FuncionarioId)
                        .IsRequired();
                } 
            );

        }
    }
}