using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnPeople.Persistence.Migrations
{
    public partial class InitialAddIdentity1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuncionariosMetas_Empresas_EmpresaId",
                table: "FuncionariosMetas");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "FuncionariosMetas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FuncionariosMetas_Empresas_EmpresaId",
                table: "FuncionariosMetas",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuncionariosMetas_Empresas_EmpresaId",
                table: "FuncionariosMetas");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "FuncionariosMetas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FuncionariosMetas_Empresas_EmpresaId",
                table: "FuncionariosMetas",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id");
        }
    }
}
