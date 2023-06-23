using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGVE.Cart.Migrations
{
    /// <inheritdoc />
    public partial class CreateVendasDataTableOnDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_VENDAS",
                columns: table => new
                {
                    IDVENDA = table.Column<long>(name: "ID_VENDA", type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DTOTAL = table.Column<decimal>(name: "D_TOTAL", type: "decimal(18,2)", nullable: false),
                    USERID = table.Column<string>(name: "USER_ID", type: "nvarchar(max)", nullable: false),
                    DTVENDA = table.Column<DateTime>(name: "DT_VENDA", type: "datetime2", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VENDAS", x => x.IDVENDA);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_VENDAS");
        }
    }
}
