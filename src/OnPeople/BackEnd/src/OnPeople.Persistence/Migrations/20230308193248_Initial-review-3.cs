using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnPeople.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initialreview3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PadraoEmail",
                table: "Empresas",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PadraoEmail",
                table: "Empresas");
        }
    }
}
