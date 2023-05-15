using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SGVEapi.Migrations
{
    /// <inheritdoc />
    public partial class AddEnderecoDataTableDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    IDPRODUTO = table.Column<long>(name: "ID_PRODUTO", type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ICEP = table.Column<int>(name: "I_CEP", type: "int", maxLength: 8, nullable: false),
                    VTIPOCEP = table.Column<string>(name: "V_TIPO_CEP", type: "nvarchar(max)", nullable: false),
                    VUF = table.Column<string>(name: "V_UF", type: "nvarchar(2)", maxLength: 2, nullable: false),
                    VCIDADE = table.Column<string>(name: "V_CIDADE", type: "nvarchar(max)", nullable: false),
                    VBAIRRO = table.Column<string>(name: "V_BAIRRO", type: "nvarchar(max)", nullable: false),
                    VLOGRADOURO = table.Column<string>(name: "V_LOGRADOURO", type: "nvarchar(max)", nullable: false),
                    VCOMPLEMENTO = table.Column<string>(name: "V_COMPLEMENTO", type: "nvarchar(max)", nullable: true),
                    VCDIBGE = table.Column<string>(name: "V_CD_IBGE", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.IDPRODUTO);
                });

            migrationBuilder.InsertData(
                table: "Endereco",
                columns: new[] { "ID_PRODUTO", "V_BAIRRO", "I_CEP", "V_CIDADE", "V_CD_IBGE", "V_COMPLEMENTO", "V_LOGRADOURO", "V_TIPO_CEP", "V_UF" },
                values: new object[,]
                {
                    { 1L, "Jardim Novo Horizonte", 13188270, "Hortolândia", "3519071", "", "Rua João de Camargo", "1", "SP" },
                    { 2L, "Piedade", 12285815, "Caçapava", "3508504", "", "Rua Capitão Mário Raymundo da Silva", "1", "SP" },
                    { 3L, "Jardim Shangrilá (Zona Norte)", 2990250, "São Paulo", "3550308", "", "Travessa João da Baiana", "1", "SP" }
                });

            migrationBuilder.UpdateData(
                table: "TB_PRODUTO",
                keyColumn: "ID_PRODUTO",
                keyValue: 2L,
                columns: new[] { "DT_CADASTRO", "FK_ID_FORNECEDOR", "FK_ID_TIPO" },
                values: new object[] { new DateTime(2023, 5, 15, 18, 50, 8, 91, DateTimeKind.Local).AddTicks(9059), 2, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.UpdateData(
                table: "TB_PRODUTO",
                keyColumn: "ID_PRODUTO",
                keyValue: 2L,
                columns: new[] { "DT_CADASTRO", "FK_ID_FORNECEDOR", "FK_ID_TIPO" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 });
        }
    }
}
