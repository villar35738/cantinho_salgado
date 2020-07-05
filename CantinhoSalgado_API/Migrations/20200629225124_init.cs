using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CantinhoSalgado_API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comandas",
                columns: table => new
                {
                    ComandaID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCliente = table.Column<string>(nullable: true),
                    Encomenda = table.Column<bool>(nullable: false),
                    DataEncomenda = table.Column<DateTime>(nullable: false),
                    TelefoneCliente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comandas", x => x.ComandaID);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProdutoNome = table.Column<string>(nullable: true),
                    ProdutoPreco = table.Column<double>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoID);
                });

            migrationBuilder.CreateTable(
                name: "ComandaItens",
                columns: table => new
                {
                    ComandaID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProdutoID = table.Column<int>(nullable: false),
                    ProdutoNome = table.Column<int>(nullable: false),
                    ProdutoQtd = table.Column<int>(nullable: false),
                    ComandaID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandaItens", x => x.ComandaID);
                    table.ForeignKey(
                        name: "FK_ComandaItens_Comandas_ComandaID1",
                        column: x => x.ComandaID1,
                        principalTable: "Comandas",
                        principalColumn: "ComandaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    EstoqueID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProdutoNome = table.Column<string>(nullable: true),
                    QtdEstoque = table.Column<int>(nullable: false),
                    ProdutoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.EstoqueID);
                    table.ForeignKey(
                        name: "FK_Estoque_Produtos_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComandaItens_ComandaID1",
                table: "ComandaItens",
                column: "ComandaID1");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_ProdutoID",
                table: "Estoque",
                column: "ProdutoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComandaItens");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "Comandas");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
