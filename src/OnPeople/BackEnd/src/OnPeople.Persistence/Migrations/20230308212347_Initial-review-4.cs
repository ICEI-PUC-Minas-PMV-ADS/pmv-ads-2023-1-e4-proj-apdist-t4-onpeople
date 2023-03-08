using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnPeople.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initialreview4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Contas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contas_EmpresaId",
                table: "Contas",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Empresas_EmpresaId",
                table: "Contas",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Empresas_EmpresaId",
                table: "Contas");

            migrationBuilder.DropIndex(
                name: "IX_Contas_EmpresaId",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Contas");
        }
    }
}
