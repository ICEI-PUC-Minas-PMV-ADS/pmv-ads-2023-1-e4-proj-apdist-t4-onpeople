using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnPeople.Persistence.Migrations
{
    public partial class InitialAddIdentity6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FumPlanejado",
                table: "Metas",
                newName: "FimPlanejado");

            migrationBuilder.AddColumn<int>(
                name: "DiasOficial",
                table: "Metas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiasOficial",
                table: "Metas");

            migrationBuilder.RenameColumn(
                name: "FimPlanejado",
                table: "Metas",
                newName: "FumPlanejado");
        }
    }
}
