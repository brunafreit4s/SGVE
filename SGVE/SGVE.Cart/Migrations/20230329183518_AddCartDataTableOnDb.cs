using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGVE.Cart.Migrations
{
    /// <inheritdoc />
    public partial class AddCartDataTableOnDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PRODUTO",
                columns: table => new
                {
                    IdProduto = table.Column<long>(name: "Id_Produto", type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_TB_PRODUTO", x => x.IdProduto);
                });

            migrationBuilder.CreateTable(
                name: "TB_VENDA",
                columns: table => new
                {
                    IdVenda = table.Column<long>(name: "Id_Venda", type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VUSERID = table.Column<string>(name: "V_USER_ID", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VENDA", x => x.IdVenda);
                });

            migrationBuilder.CreateTable(
                name: "TB_VENDA_PRODUTO",
                columns: table => new
                {
                    IDVENDAPRODUTO = table.Column<long>(name: "ID_VENDA_PRODUTO", type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVenda = table.Column<long>(name: "Id_Venda", type: "bigint", nullable: false),
                    IdProduto = table.Column<long>(name: "Id_Produto", type: "bigint", nullable: false),
                    COUNT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VENDA_PRODUTO", x => x.IDVENDAPRODUTO);
                    table.ForeignKey(
                        name: "FK_TB_VENDA_PRODUTO_TB_PRODUTO_Id_Produto",
                        column: x => x.IdProduto,
                        principalTable: "TB_PRODUTO",
                        principalColumn: "Id_Produto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_VENDA_PRODUTO_TB_VENDA_Id_Venda",
                        column: x => x.IdVenda,
                        principalTable: "TB_VENDA",
                        principalColumn: "Id_Venda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_VENDA_PRODUTO_Id_Produto",
                table: "TB_VENDA_PRODUTO",
                column: "Id_Produto");

            migrationBuilder.CreateIndex(
                name: "IX_TB_VENDA_PRODUTO_Id_Venda",
                table: "TB_VENDA_PRODUTO",
                column: "Id_Venda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_VENDA_PRODUTO");

            migrationBuilder.DropTable(
                name: "TB_PRODUTO");

            migrationBuilder.DropTable(
                name: "TB_VENDA");
        }
    }
}
