using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGVEapi.Migrations
{
    /// <inheritdoc />
    public partial class AddDbProdutosDataTableDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TB_PRODUTO",
                keyColumn: "ID_PRODUTO",
                keyValue: 2L,
                columns: new[] { "DT_CADASTRO", "FK_ID_FORNECEDOR", "FK_ID_TIPO" },
                values: new object[] { new DateTime(2023, 4, 4, 19, 31, 24, 246, DateTimeKind.Local).AddTicks(9515), 2, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TB_PRODUTO",
                keyColumn: "ID_PRODUTO",
                keyValue: 2L,
                columns: new[] { "DT_CADASTRO", "FK_ID_FORNECEDOR", "FK_ID_TIPO" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 });
        }
    }
}
