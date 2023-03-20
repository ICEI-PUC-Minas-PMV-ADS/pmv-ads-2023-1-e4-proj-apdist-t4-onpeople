using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnPeople.Persistence.Migrations
{
    public partial class InitialAddIdentity1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeEmpresa",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeEmpresa",
                table: "AspNetUsers");
        }
    }
}
