using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMCapital.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CapacidadeComprar = table.Column<double>(type: "float(29)", precision: 29, scale: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "CompraCliente",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoCliente = table.Column<int>(type: "int", nullable: false),
                    CodigoProduto = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorTotalCompra = table.Column<double>(type: "float(29)", precision: 29, scale: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraCliente", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorUnitario = table.Column<double>(type: "float(29)", precision: 29, scale: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Codigo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "CompraCliente");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
