using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnPeople.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCompleto = table.Column<string>(type: "TEXT", nullable: true),
                    Visao = table.Column<string>(type: "TEXT", nullable: true),
                    Foto = table.Column<string>(type: "TEXT", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataEncerramento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Ativa = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DadosPessoais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CPF = table.Column<string>(type: "TEXT", nullable: true),
                    TituloEleitor = table.Column<string>(type: "TEXT", nullable: true),
                    ImpedimentoEleitora = table.Column<bool>(type: "INTEGER", nullable: false),
                    Identidade = table.Column<string>(type: "TEXT", nullable: true),
                    DataExpedicao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UfEmissao = table.Column<string>(type: "TEXT", nullable: true),
                    EstadoCivil = table.Column<string>(type: "TEXT", nullable: true),
                    CarteiraTrabalho = table.Column<string>(type: "TEXT", nullable: true),
                    PisPasep = table.Column<string>(type: "TEXT", nullable: true),
                    DataExpedicaoCarteiraTrabalho = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosPessoais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeEmpresa = table.Column<string>(type: "TEXT", nullable: true),
                    NomeFantasia = table.Column<string>(type: "TEXT", nullable: true),
                    Sigla = table.Column<string>(type: "TEXT", nullable: true),
                    Ativa = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataDesativacao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Filial = table.Column<bool>(type: "INTEGER", nullable: false),
                    MatrizId = table.Column<int>(type: "INTEGER", nullable: true),
                    PresidenteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeFuncao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Metas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoMeta = table.Column<string>(type: "TEXT", nullable: true),
                    NomeMeta = table.Column<string>(type: "TEXT", nullable: true),
                    descricao = table.Column<string>(type: "TEXT", nullable: true),
                    MetaCumprida = table.Column<bool>(type: "INTEGER", nullable: false),
                    MetaAprovada = table.Column<bool>(type: "INTEGER", nullable: false),
                    InicioPlanejado = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FumPlanejado = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DiasPlanejado = table.Column<int>(type: "INTEGER", nullable: false),
                    InicioOficial = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FimOficial = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeDepartamento = table.Column<string>(type: "TEXT", nullable: true),
                    Sigla = table.Column<string>(type: "TEXT", nullable: true),
                    DiretorId = table.Column<int>(type: "INTEGER", nullable: false),
                    GerenteId = table.Column<int>(type: "INTEGER", nullable: false),
                    SupervisorId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataEncerramento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    EmpresaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamentos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpresasContas",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ContaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresasContas", x => new { x.EmpresaId, x.ContaId });
                    table.ForeignKey(
                        name: "FK_EmpresasContas_Contas_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresasContas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContasFuncoes",
                columns: table => new
                {
                    ContaId = table.Column<int>(type: "INTEGER", nullable: false),
                    FuncaoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasFuncoes", x => new { x.ContaId, x.FuncaoId });
                    table.ForeignKey(
                        name: "FK_ContasFuncoes_Contas_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContasFuncoes_Funcoes_FuncaoId",
                        column: x => x.FuncaoId,
                        principalTable: "Funcoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCargo = table.Column<string>(type: "TEXT", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataEncerramento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DepartamentoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cargos_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpresasDepartamentos",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartamentoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresasDepartamentos", x => new { x.EmpresaId, x.DepartamentoId });
                    table.ForeignKey(
                        name: "FK_EmpresasDepartamentos_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresasDepartamentos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cpf = table.Column<string>(type: "TEXT", nullable: true),
                    DataAdmissao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataDemissao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    CargoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartamentoId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmpresaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ContaId = table.Column<int>(type: "INTEGER", nullable: true),
                    FuncaoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DadoPessoalId = table.Column<int>(type: "INTEGER", nullable: false),
                    MetaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Contas_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Contas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Funcionarios_DadosPessoais_DadoPessoalId",
                        column: x => x.DadoPessoalId,
                        principalTable: "DadosPessoais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Funcoes_FuncaoId",
                        column: x => x.FuncaoId,
                        principalTable: "Funcoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Metas_MetaId",
                        column: x => x.MetaId,
                        principalTable: "Metas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoEndereco = table.Column<string>(type: "TEXT", nullable: true),
                    Cep = table.Column<string>(type: "TEXT", nullable: true),
                    Logradouro = table.Column<string>(type: "TEXT", nullable: true),
                    Numero = table.Column<string>(type: "TEXT", nullable: true),
                    Complemento = table.Column<string>(type: "TEXT", nullable: true),
                    Bairro = table.Column<string>(type: "TEXT", nullable: true),
                    Cidade = table.Column<string>(type: "TEXT", nullable: true),
                    UF = table.Column<string>(type: "TEXT", nullable: true),
                    Pais = table.Column<string>(type: "TEXT", nullable: true),
                    CaixaPostal = table.Column<string>(type: "TEXT", nullable: true),
                    ComplementoEndereco = table.Column<string>(type: "TEXT", nullable: true),
                    DataCriação = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataUltimaAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FuncionariosMetas",
                columns: table => new
                {
                    MetaId = table.Column<int>(type: "INTEGER", nullable: false),
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    MetaCumprida = table.Column<bool>(type: "INTEGER", nullable: false),
                    InicioEfetivo = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FimEfetivo = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DiasEfetivo = table.Column<int>(type: "INTEGER", nullable: false),
                    InicioAcordado = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FimAcordado = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DiasAcordado = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionariosMetas", x => new { x.FuncionarioId, x.MetaId });
                    table.ForeignKey(
                        name: "FK_FuncionariosMetas_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionariosMetas_Metas_MetaId",
                        column: x => x.MetaId,
                        principalTable: "Metas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_DepartamentoId",
                table: "Cargos",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasFuncoes_FuncaoId",
                table: "ContasFuncoes",
                column: "FuncaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_EmpresaId",
                table: "Departamentos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresasContas_ContaId",
                table: "EmpresasContas",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresasDepartamentos_DepartamentoId",
                table: "EmpresasDepartamentos",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_FuncionarioId",
                table: "Enderecos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_CargoId",
                table: "Funcionarios",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_ContaId",
                table: "Funcionarios",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_DadoPessoalId",
                table: "Funcionarios",
                column: "DadoPessoalId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_DepartamentoId",
                table: "Funcionarios",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EmpresaId",
                table: "Funcionarios",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_FuncaoId",
                table: "Funcionarios",
                column: "FuncaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_MetaId",
                table: "Funcionarios",
                column: "MetaId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionariosMetas_MetaId",
                table: "FuncionariosMetas",
                column: "MetaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContasFuncoes");

            migrationBuilder.DropTable(
                name: "EmpresasContas");

            migrationBuilder.DropTable(
                name: "EmpresasDepartamentos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "FuncionariosMetas");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "DadosPessoais");

            migrationBuilder.DropTable(
                name: "Funcoes");

            migrationBuilder.DropTable(
                name: "Metas");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
