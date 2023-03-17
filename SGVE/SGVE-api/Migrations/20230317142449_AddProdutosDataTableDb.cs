using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGVEapi.Migrations
{
    /// <inheritdoc />
    public partial class AddProdutosDataTableDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PRODUTOS",
                columns: table => new
                {
                    IDFUNCIONARIO = table.Column<long>(name: "ID_FUNCIONARIO", type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VNOME = table.Column<string>(name: "V_NOME", type: "nvarchar(500)", maxLength: 500, nullable: false),
                    VDESCRICAO = table.Column<string>(name: "V_DESCRICAO", type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IQUANTIDADE = table.Column<int>(name: "I_QUANTIDADE", type: "int", nullable: false),
                    VMARCA = table.Column<string>(name: "V_MARCA", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DCUSTO = table.Column<float>(name: "D_CUSTO", type: "real", nullable: false),
                    DPRECO = table.Column<float>(name: "D_PRECO", type: "real", nullable: false),
                    DTCADASTRO = table.Column<DateTime>(name: "DT_CADASTRO", type: "datetime2", nullable: false),
                    FKIDTIPO = table.Column<int>(name: "FK_ID_TIPO", type: "int", nullable: false),
                    FKIDFORNECEDOR = table.Column<int>(name: "FK_ID_FORNECEDOR", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUTOS", x => x.IDFUNCIONARIO);
                });

            migrationBuilder.InsertData(
                table: "TB_PRODUTOS",
                columns: new[] { "ID_FUNCIONARIO", "D_CUSTO", "DT_CADASTRO", "V_DESCRICAO", "FK_ID_FORNECEDOR", "FK_ID_TIPO", "V_MARCA", "V_NOME", "D_PRECO", "I_QUANTIDADE" },
                values: new object[] { 2L, 1.5f, new DateTime(2023, 3, 17, 11, 24, 49, 566, DateTimeKind.Local).AddTicks(7132), "Bolacha sabor Morango", 2, 2, "Trakinas", "Bolacha Trakinas", 0.5f, 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PRODUTOS");
        }
    }
}
