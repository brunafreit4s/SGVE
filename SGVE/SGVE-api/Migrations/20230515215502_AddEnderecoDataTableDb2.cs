using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGVEapi.Migrations
{
    /// <inheritdoc />
    public partial class AddEnderecoDataTableDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "TB_ENDERECO");

            migrationBuilder.RenameColumn(
                name: "ID_PRODUTO",
                table: "TB_ENDERECO",
                newName: "ID_ENDERECO");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_ENDERECO",
                table: "TB_ENDERECO",
                column: "ID_ENDERECO");

            migrationBuilder.UpdateData(
                table: "TB_PRODUTO",
                keyColumn: "ID_PRODUTO",
                keyValue: 2L,
                columns: new[] { "DT_CADASTRO", "FK_ID_FORNECEDOR", "FK_ID_TIPO" },
                values: new object[] { new DateTime(2023, 5, 15, 18, 55, 2, 560, DateTimeKind.Local).AddTicks(6682), 2, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_ENDERECO",
                table: "TB_ENDERECO");

            migrationBuilder.RenameTable(
                name: "TB_ENDERECO",
                newName: "Endereco");

            migrationBuilder.RenameColumn(
                name: "ID_ENDERECO",
                table: "Endereco",
                newName: "ID_PRODUTO");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "ID_PRODUTO");

            migrationBuilder.UpdateData(
                table: "TB_PRODUTO",
                keyColumn: "ID_PRODUTO",
                keyValue: 2L,
                columns: new[] { "DT_CADASTRO", "FK_ID_FORNECEDOR", "FK_ID_TIPO" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 });
        }
    }
}
