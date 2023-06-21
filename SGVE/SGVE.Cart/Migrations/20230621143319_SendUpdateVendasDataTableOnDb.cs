using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGVE.Cart.Migrations
{
    /// <inheritdoc />
    public partial class SendUpdateVendasDataTableOnDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PRODUTO_CARRINHO",
                columns: table => new
                {
                    IDPRODUTO = table.Column<long>(name: "ID_PRODUTO", type: "bigint", nullable: false),
                    VNOME = table.Column<string>(name: "V_NOME", type: "nvarchar(500)", maxLength: 500, nullable: false),
                    VDESCRICAO = table.Column<string>(name: "V_DESCRICAO", type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IQUANTIDADE = table.Column<int>(name: "I_QUANTIDADE", type: "int", maxLength: 4, nullable: false),
                    VMARCA = table.Column<string>(name: "V_MARCA", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DCUSTO = table.Column<decimal>(name: "D_CUSTO", type: "decimal(18,2)", nullable: false),
                    DPRECO = table.Column<decimal>(name: "D_PRECO", type: "decimal(18,2)", nullable: false),
                    DTCADASTRO = table.Column<DateTime>(name: "DT_CADASTRO", type: "datetime2", maxLength: 20, nullable: false),
                    DTALTERACAO = table.Column<DateTime>(name: "DT_ALTERACAO", type: "datetime2", maxLength: 20, nullable: false),
                    FKIDTIPO = table.Column<int>(name: "FK_ID_TIPO", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUTO_CARRINHO", x => x.IDPRODUTO);
                });

            migrationBuilder.CreateTable(
                name: "TB_VENDA",
                columns: table => new
                {
                    IDVENDA = table.Column<long>(name: "ID_VENDA", type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VUSERID = table.Column<string>(name: "V_USER_ID", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VENDA", x => x.IDVENDA);
                });

            migrationBuilder.CreateTable(
                name: "TB_VENDA_PRODUTO",
                columns: table => new
                {
                    IDVENDAPRODUTO = table.Column<long>(name: "ID_VENDA_PRODUTO", type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVenda = table.Column<long>(name: "Id_Venda", type: "bigint", nullable: false),
                    IdProduto = table.Column<long>(name: "Id_Produto", type: "bigint", nullable: false),
                    ICOUNT = table.Column<int>(name: "I_COUNT", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VENDA_PRODUTO", x => x.IDVENDAPRODUTO);
                    table.ForeignKey(
                        name: "FK_TB_VENDA_PRODUTO_TB_PRODUTO_CARRINHO_Id_Produto",
                        column: x => x.IdProduto,
                        principalTable: "TB_PRODUTO_CARRINHO",
                        principalColumn: "ID_PRODUTO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_VENDA_PRODUTO_TB_VENDA_Id_Venda",
                        column: x => x.IdVenda,
                        principalTable: "TB_VENDA",
                        principalColumn: "ID_VENDA",
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
                name: "TB_PRODUTO_CARRINHO");

            migrationBuilder.DropTable(
                name: "TB_VENDA");
        }
    }
}
