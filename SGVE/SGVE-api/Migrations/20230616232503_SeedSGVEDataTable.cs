using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGVEapi.Migrations
{
    /// <inheritdoc />
    public partial class SeedSGVEDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TB_PRODUTO",
                keyColumn: "ID_PRODUTO",
                keyValue: 2L,
                columns: new[] { "DT_CADASTRO", "FK_ID_FORNECEDOR", "FK_ID_TIPO" },
                values: new object[] { new DateTime(2023, 6, 16, 20, 25, 3, 500, DateTimeKind.Local).AddTicks(5885), 2, 2 });
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
