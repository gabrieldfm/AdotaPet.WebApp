using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdotaPet.WebApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doenca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doenca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(maxLength: 200, nullable: false),
                    Logradouro = table.Column<string>(maxLength: 200, nullable: false),
                    Cep = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Raca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Login = table.Column<string>(maxLength: 100, nullable: false),
                    Senha = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ong",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<int>(nullable: false),
                    Razao_Social = table.Column<string>(maxLength: 200, nullable: false),
                    Nome_Fantasia = table.Column<string>(maxLength: 200, nullable: false),
                    Cnpj = table.Column<string>(maxLength: 18, nullable: false),
                    Usuario_IdId = table.Column<int>(nullable: false),
                    Endereco_IdId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ong_Endereco_Endereco_IdId",
                        column: x => x.Endereco_IdId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ong_Usuario_Usuario_IdId",
                        column: x => x.Usuario_IdId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Porte = table.Column<short>(nullable: false),
                    Vacina = table.Column<string>(nullable: false),
                    Vermifugado = table.Column<string>(nullable: false),
                    Sexo = table.Column<string>(nullable: false),
                    Castrado = table.Column<string>(nullable: false),
                    Ong_IdId = table.Column<int>(nullable: false),
                    Doenca_IdId = table.Column<int>(nullable: false),
                    Raca_IdId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animal_Doenca_Doenca_IdId",
                        column: x => x.Doenca_IdId,
                        principalTable: "Doenca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal_Ong_Ong_IdId",
                        column: x => x.Ong_IdId,
                        principalTable: "Ong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal_Raca_Raca_IdId",
                        column: x => x.Raca_IdId,
                        principalTable: "Raca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Rg = table.Column<string>(maxLength: 20, nullable: false),
                    Cpf = table.Column<string>(maxLength: 14, nullable: false),
                    Telefone = table.Column<string>(maxLength: 20, nullable: false),
                    Ong_IdId = table.Column<int>(nullable: false),
                    Endereco_IdId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_Endereco_Endereco_IdId",
                        column: x => x.Endereco_IdId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Pessoa_Ong_Ong_IdId",
                        column: x => x.Ong_IdId,
                        principalTable: "Ong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adocao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<int>(nullable: false),
                    Data_Cadastro = table.Column<DateTime>(nullable: false),
                    Data_Finalizacao = table.Column<DateTime>(nullable: false),
                    Ong_IdId = table.Column<int>(nullable: false),
                    Pessoa_IdId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adocao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adocao_Ong_Ong_IdId",
                        column: x => x.Ong_IdId,
                        principalTable: "Ong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adocao_Pessoa_Pessoa_IdId",
                        column: x => x.Pessoa_IdId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Adocao_Itens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adocao_IdId = table.Column<int>(nullable: false),
                    Animal_IdId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adocao_Itens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adocao_Itens_Adocao_Adocao_IdId",
                        column: x => x.Adocao_IdId,
                        principalTable: "Adocao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Adocao_Itens_Animal_Animal_IdId",
                        column: x => x.Animal_IdId,
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adocao_Ong_IdId",
                table: "Adocao",
                column: "Ong_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Adocao_Pessoa_IdId",
                table: "Adocao",
                column: "Pessoa_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Adocao_Itens_Adocao_IdId",
                table: "Adocao_Itens",
                column: "Adocao_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Adocao_Itens_Animal_IdId",
                table: "Adocao_Itens",
                column: "Animal_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_Doenca_IdId",
                table: "Animal",
                column: "Doenca_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_Ong_IdId",
                table: "Animal",
                column: "Ong_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_Raca_IdId",
                table: "Animal",
                column: "Raca_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Ong_Endereco_IdId",
                table: "Ong",
                column: "Endereco_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Ong_Usuario_IdId",
                table: "Ong",
                column: "Usuario_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_Endereco_IdId",
                table: "Pessoa",
                column: "Endereco_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_Ong_IdId",
                table: "Pessoa",
                column: "Ong_IdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adocao_Itens");

            migrationBuilder.DropTable(
                name: "Adocao");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Doenca");

            migrationBuilder.DropTable(
                name: "Raca");

            migrationBuilder.DropTable(
                name: "Ong");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
