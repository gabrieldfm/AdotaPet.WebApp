using Microsoft.EntityFrameworkCore.Migrations;

namespace AdotaPet.WebApp.Migrations
{
    public partial class correcaoDoEnderecoNapessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Endereco_Endereco_IdId",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_Endereco_IdId",
                table: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "Endereco_IdId",
                table: "Pessoa",
                newName: "Numero");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Pessoa",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Pessoa",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Pessoa",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Pessoa",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Pessoa",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "Pessoa",
                maxLength: 2,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "UF",
                table: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Pessoa",
                newName: "Endereco_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_Endereco_IdId",
                table: "Pessoa",
                column: "Endereco_IdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Endereco_Endereco_IdId",
                table: "Pessoa",
                column: "Endereco_IdId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
