using Microsoft.EntityFrameworkCore.Migrations;

namespace AdotaPet.WebApp.Migrations
{
    public partial class atualizandoDoenca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Grupo",
                table: "Doenca",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grupo",
                table: "Doenca");

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Doenca",
                maxLength: 250,
                nullable: true);
        }
    }
}
