using Microsoft.EntityFrameworkCore.Migrations;

namespace AdotaPet.WebApp.Migrations
{
    public partial class atualizaRaca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ong_IdId",
                table: "Raca",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Raca_Ong_IdId",
                table: "Raca",
                column: "Ong_IdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Raca_Ong_Ong_IdId",
                table: "Raca",
                column: "Ong_IdId",
                principalTable: "Ong",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Raca_Ong_Ong_IdId",
                table: "Raca");

            migrationBuilder.DropIndex(
                name: "IX_Raca_Ong_IdId",
                table: "Raca");

            migrationBuilder.DropColumn(
                name: "Ong_IdId",
                table: "Raca");
        }
    }
}
