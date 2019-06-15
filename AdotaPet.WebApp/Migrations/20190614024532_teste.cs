using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdotaPet.WebApp.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControleAcompanhamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<int>(nullable: false),
                    Data_Cadastro = table.Column<DateTime>(nullable: false),
                    Ong_IdId = table.Column<int>(nullable: true),
                    Pessoa_IdId = table.Column<int>(nullable: true),
                    descricao = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControleAcompanhamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControleAcompanhamento_Ong_Ong_IdId",
                        column: x => x.Ong_IdId,
                        principalTable: "Ong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControleAcompanhamento_Pessoa_Pessoa_IdId",
                        column: x => x.Pessoa_IdId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ativo",
                value: "Y");

            migrationBuilder.CreateIndex(
                name: "IX_ControleAcompanhamento_Ong_IdId",
                table: "ControleAcompanhamento",
                column: "Ong_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_ControleAcompanhamento_Pessoa_IdId",
                table: "ControleAcompanhamento",
                column: "Pessoa_IdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControleAcompanhamento");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ativo",
                value: null);
        }
    }
}
