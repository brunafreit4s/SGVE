using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGVE.Cart.Migrations
{
    /// <inheritdoc />
    public partial class CreateCarrinhoDataTableOnDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CART_HEADER",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VUSERID = table.Column<string>(name: "V_USER_ID", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CART_HEADER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRODUTO_X_CARRINHO",
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
                    table.PrimaryKey("PK_TB_PRODUTO_X_CARRINHO", x => x.IDPRODUTO);
                });

            migrationBuilder.CreateTable(
                name: "TB_CART_DETAIL",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartHeaderId = table.Column<long>(type: "bigint", nullable: false),
                    ProdutoId = table.Column<long>(type: "bigint", nullable: false),
                    ICOUNT = table.Column<int>(name: "I_COUNT", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CART_DETAIL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_CART_DETAIL_TB_CART_HEADER_CartHeaderId",
                        column: x => x.CartHeaderId,
                        principalTable: "TB_CART_HEADER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CART_DETAIL_TB_PRODUTO_X_CARRINHO_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "TB_PRODUTO_X_CARRINHO",
                        principalColumn: "ID_PRODUTO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CART_DETAIL_CartHeaderId",
                table: "TB_CART_DETAIL",
                column: "CartHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CART_DETAIL_ProdutoId",
                table: "TB_CART_DETAIL",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CART_DETAIL");

            migrationBuilder.DropTable(
                name: "TB_CART_HEADER");

            migrationBuilder.DropTable(
                name: "TB_PRODUTO_X_CARRINHO");
        }
    }
}
