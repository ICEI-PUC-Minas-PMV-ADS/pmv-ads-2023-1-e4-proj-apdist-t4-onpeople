﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnPeople.Persistence.Interfaces.Contexts;

#nullable disable

namespace OnPeople.Persistence.Migrations
{
    [DbContext(typeof(OnPeopleContext))]
    partial class OnPeopleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Cargos.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataEncerramento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("NomeCargo")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Ativo");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Departamentos.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataEncerramento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DiretorId")
                        .HasColumnType("int");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<int>("GerenteId")
                        .HasColumnType("int");

                    b.Property<string>("NomeDepartamento")
                        .HasColumnType("longtext");

                    b.Property<string>("Sigla")
                        .HasColumnType("longtext");

                    b.Property<int>("SupervisorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Ativo");

                    b.HasIndex("DiretorId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("GerenteId");

                    b.HasIndex("SupervisorId");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Empresas.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Ativa")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataDesativacao")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Filial")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Logotipo")
                        .HasColumnType("longtext");

                    b.Property<int?>("MatrizId")
                        .HasColumnType("int");

                    b.Property<string>("NomeEmpresa")
                        .HasColumnType("longtext");

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("longtext");

                    b.Property<string>("PadraoEmail")
                        .HasColumnType("longtext");

                    b.Property<int?>("PresidenteId")
                        .HasColumnType("int");

                    b.Property<string>("Sigla")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Ativa");

                    b.HasIndex("Filial");

                    b.HasIndex("MatrizId");

                    b.HasIndex("PresidenteId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Funcionarios.DadoPessoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .HasColumnType("longtext");

                    b.Property<string>("CarteiraTrabalho")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataExpedicao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataExpedicaoCarteiraTrabalho")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EstadoCivil")
                        .HasColumnType("longtext");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<string>("Identidade")
                        .HasColumnType("longtext");

                    b.Property<bool>("ImpedimentoEleitora")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PisPasep")
                        .HasColumnType("longtext");

                    b.Property<string>("TituloEleitor")
                        .HasColumnType("longtext");

                    b.Property<string>("UfEmissao")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("DadosPessoais");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Funcionarios.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("longtext");

                    b.Property<string>("CaixaPostal")
                        .HasColumnType("longtext");

                    b.Property<string>("Cep")
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .HasColumnType("longtext");

                    b.Property<string>("Complemento")
                        .HasColumnType("longtext");

                    b.Property<string>("ComplementoEndereco")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataCriação")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataUltimaAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .HasColumnType("longtext");

                    b.Property<string>("Pais")
                        .HasColumnType("longtext");

                    b.Property<string>("TipoEndereco")
                        .HasColumnType("longtext");

                    b.Property<string>("UF")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Funcionarios.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataDemissao")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<int>("Funcao")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Ativo");

                    b.HasIndex("CargoId");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("UserId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Funcionarios.FuncionarioMeta", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<int>("MetaId")
                        .HasColumnType("int");

                    b.Property<int>("DiasAcordado")
                        .HasColumnType("int");

                    b.Property<int>("DiasEfetivo")
                        .HasColumnType("int");

                    b.Property<DateTime>("FimAcordado")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FimEfetivo")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("InicioAcordado")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("InicioEfetivo")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("MetaCumprida")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("FuncionarioId", "MetaId");

                    b.HasIndex("MetaId");

                    b.ToTable("FuncionariosMetas");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Metas.Meta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DiasPlanejado")
                        .HasColumnType("int");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FimOficial")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FumPlanejado")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("InicioOficial")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("InicioPlanejado")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("MetaAprovada")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("MetaCumprida")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("NomeMeta")
                        .HasColumnType("longtext");

                    b.Property<string>("TipoMeta")
                        .HasColumnType("longtext");

                    b.Property<string>("descricao")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("MetaAprovada");

                    b.HasIndex("MetaCumprida");

                    b.ToTable("Metas");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Users.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NomeFuncao")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("Ativa")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Bronze")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CodCargo")
                        .HasColumnType("int");

                    b.Property<int>("CodDepartamento")
                        .HasColumnType("int");

                    b.Property<int>("CodEmpresa")
                        .HasColumnType("int");

                    b.Property<int>("CodFunionarioId")
                        .HasColumnType("int");

                    b.Property<int>("CodMeta")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataEncerramento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Foto")
                        .HasColumnType("longtext");

                    b.Property<bool>("Gold")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Master")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Visao")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Users.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("OnPeople.Domain.Models.Users.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("OnPeople.Domain.Models.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("OnPeople.Domain.Models.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("OnPeople.Domain.Models.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Cargos.Cargo", b =>
                {
                    b.HasOne("OnPeople.Domain.Models.Departamentos.Departamento", "Departamentos")
                        .WithMany("Cargos")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnPeople.Domain.Models.Empresas.Empresa", "Empresas")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamentos");

                    b.Navigation("Empresas");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Departamentos.Departamento", b =>
                {
                    b.HasOne("OnPeople.Domain.Models.Empresas.Empresa", "Empresas")
                        .WithMany("Departamentos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresas");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Funcionarios.DadoPessoal", b =>
                {
                    b.HasOne("OnPeople.Domain.Models.Funcionarios.Funcionario", "Funcionarios")
                        .WithMany("DadosPessoais")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Funcionarios.Endereco", b =>
                {
                    b.HasOne("OnPeople.Domain.Models.Funcionarios.Funcionario", "Funcionarios")
                        .WithMany("Enderecos")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Funcionarios.Funcionario", b =>
                {
                    b.HasOne("OnPeople.Domain.Models.Cargos.Cargo", "Cargos")
                        .WithMany("Funcionarios")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnPeople.Domain.Models.Departamentos.Departamento", "Departamentos")
                        .WithMany()
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnPeople.Domain.Models.Empresas.Empresa", "Empresas")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnPeople.Domain.Models.Users.User", "Users")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Cargos");

                    b.Navigation("Departamentos");

                    b.Navigation("Empresas");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Funcionarios.FuncionarioMeta", b =>
                {
                    b.HasOne("OnPeople.Domain.Models.Funcionarios.Funcionario", "Funcionario")
                        .WithMany("FuncionariosMetas")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnPeople.Domain.Models.Metas.Meta", "Meta")
                        .WithMany("FuncionariosMetas")
                        .HasForeignKey("MetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");

                    b.Navigation("Meta");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Metas.Meta", b =>
                {
                    b.HasOne("OnPeople.Domain.Models.Empresas.Empresa", "Empresas")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresas");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Users.User", b =>
                {
                    b.HasOne("OnPeople.Domain.Models.Empresas.Empresa", null)
                        .WithMany("Users")
                        .HasForeignKey("EmpresaId");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Users.UserRole", b =>
                {
                    b.HasOne("OnPeople.Domain.Models.Users.Role", "Role")
                        .WithMany("UsersRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnPeople.Domain.Models.Users.User", "User")
                        .WithMany("UsersRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Cargos.Cargo", b =>
                {
                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Departamentos.Departamento", b =>
                {
                    b.Navigation("Cargos");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Empresas.Empresa", b =>
                {
                    b.Navigation("Departamentos");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Funcionarios.Funcionario", b =>
                {
                    b.Navigation("DadosPessoais");

                    b.Navigation("Enderecos");

                    b.Navigation("FuncionariosMetas");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Metas.Meta", b =>
                {
                    b.Navigation("FuncionariosMetas");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Users.Role", b =>
                {
                    b.Navigation("UsersRoles");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Users.User", b =>
                {
                    b.Navigation("UsersRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
