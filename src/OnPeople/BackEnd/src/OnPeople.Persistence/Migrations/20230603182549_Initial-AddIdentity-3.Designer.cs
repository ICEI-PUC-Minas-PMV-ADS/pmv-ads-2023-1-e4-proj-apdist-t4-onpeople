﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnPeople.Persistence.Interfaces.Contexts;

#nullable disable

namespace OnPeople.Persistence.Migrations
{
    [DbContext(typeof(OnPeopleContext))]
    [Migration("20230603182549_Initial-AddIdentity-3")]
    partial class InitialAddIdentity3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("DataCriacao")
                        .HasColumnType("longtext");

                    b.Property<string>("DataEncerramento")
                        .HasColumnType("longtext");

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

                    b.Property<string>("DataCriacao")
                        .HasColumnType("longtext");

                    b.Property<string>("DataEncerramento")
                        .HasColumnType("longtext");

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

                    b.Property<string>("AtividadePrincipal")
                        .HasColumnType("longtext");

                    b.Property<string>("Bairro")
                        .HasColumnType("longtext");

                    b.Property<string>("CEP")
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .HasColumnType("longtext");

                    b.Property<int>("CidadeIbgeId")
                        .HasColumnType("int");

                    b.Property<int>("CidadeId")
                        .HasColumnType("int");

                    b.Property<string>("CidadeSiafiId")
                        .HasColumnType("longtext");

                    b.Property<string>("Cnpj")
                        .HasColumnType("longtext");

                    b.Property<string>("Complemento")
                        .HasColumnType("longtext");

                    b.Property<string>("DDD")
                        .HasColumnType("longtext");

                    b.Property<string>("DataCadastro")
                        .HasColumnType("longtext");

                    b.Property<string>("DataDesativacao")
                        .HasColumnType("longtext");

                    b.Property<string>("EmailEmpresa")
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .HasColumnType("longtext");

                    b.Property<int>("EstadoIbgeId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<bool>("Filial")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Logotipo")
                        .HasColumnType("longtext");

                    b.Property<string>("Logradouro")
                        .HasColumnType("longtext");

                    b.Property<int>("MatrizId")
                        .HasColumnType("int");

                    b.Property<string>("NaturezaJuridica")
                        .HasColumnType("longtext");

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("longtext");

                    b.Property<string>("NomePais")
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .HasColumnType("longtext");

                    b.Property<string>("OptanteSimples")
                        .HasColumnType("longtext");

                    b.Property<string>("PadraoEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("PaisId")
                        .HasColumnType("longtext");

                    b.Property<string>("PorteEmpresa")
                        .HasColumnType("longtext");

                    b.Property<int>("PresidenteId")
                        .HasColumnType("int");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("longtext");

                    b.Property<string>("SiglaEmpresa")
                        .HasColumnType("longtext");

                    b.Property<string>("SiglaEstado")
                        .HasColumnType("longtext");

                    b.Property<string>("SiglaPaisIso2")
                        .HasColumnType("longtext");

                    b.Property<string>("SiglaPaisIso3")
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext");

                    b.Property<string>("TipoLogradouro")
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

                    b.Property<string>("DataExpedicao")
                        .HasColumnType("longtext");

                    b.Property<string>("DataExpedicaoCarteiraTrabalho")
                        .HasColumnType("longtext");

                    b.Property<string>("EstadoCivil")
                        .HasColumnType("longtext");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<string>("Identidade")
                        .HasColumnType("longtext");

                    b.Property<bool>("ImpedimentoEleitoral")
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

                    b.Property<string>("DataCriação")
                        .HasColumnType("longtext");

                    b.Property<string>("DataUltimaAtualizacao")
                        .HasColumnType("longtext");

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

                    b.Property<string>("DataAdmissao")
                        .HasColumnType("longtext");

                    b.Property<string>("DataDemissao")
                        .HasColumnType("longtext");

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<int>("Funcao")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
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

                    b.Property<string>("FimAcordado")
                        .HasColumnType("longtext");

                    b.Property<string>("FimEfetivo")
                        .HasColumnType("longtext");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("InicioAcordado")
                        .HasColumnType("longtext");

                    b.Property<string>("InicioEfetivo")
                        .HasColumnType("longtext");

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

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<int>("DiasPlanejado")
                        .HasColumnType("int");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("FimOficial")
                        .HasColumnType("longtext");

                    b.Property<string>("FumPlanejado")
                        .HasColumnType("longtext");

                    b.Property<string>("InicioOficial")
                        .HasColumnType("longtext");

                    b.Property<string>("InicioPlanejado")
                        .HasColumnType("longtext");

                    b.Property<bool>("MetaAprovada")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("MetaCumprida")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("NomeMeta")
                        .HasColumnType("longtext");

                    b.Property<string>("TipoMeta")
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

                    b.Property<int>("CodFuncionario")
                        .HasColumnType("int");

                    b.Property<int>("CodMeta")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("DataCadastro")
                        .HasColumnType("longtext");

                    b.Property<string>("DataEncerramento")
                        .HasColumnType("longtext");

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

                    b.Property<string>("NomeEmpresa")
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
                    b.HasOne("OnPeople.Domain.Models.Departamentos.Departamento", "Departamento")
                        .WithMany("Cargos")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnPeople.Domain.Models.Empresas.Empresa", "Empresa")
                        .WithMany("Cargos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Departamentos.Departamento", b =>
                {
                    b.HasOne("OnPeople.Domain.Models.Empresas.Empresa", "Empresa")
                        .WithMany("Departamentos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Funcionarios.DadoPessoal", b =>
                {
                    b.HasOne("OnPeople.Domain.Models.Funcionarios.Funcionario", "Funcionario")
                        .WithMany("DadosPessoais")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Funcionarios.Endereco", b =>
                {
                    b.HasOne("OnPeople.Domain.Models.Funcionarios.Funcionario", "Funcionario")
                        .WithMany("Enderecos")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("OnPeople.Domain.Models.Funcionarios.Funcionario", b =>
                {
                    b.HasOne("OnPeople.Domain.Models.Cargos.Cargo", "Cargo")
                        .WithMany("Funcionarios")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnPeople.Domain.Models.Departamentos.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnPeople.Domain.Models.Empresas.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnPeople.Domain.Models.Users.User", "Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("Departamento");

                    b.Navigation("Empresa");

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
                    b.Navigation("Cargos");

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
