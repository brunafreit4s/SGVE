using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGVEapi.Migrations
{
    /// <inheritdoc />
    public partial class SendUpdateProdutosDataTableOnDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DT_ALTERACAO",
                table: "TB_PRODUTO",
                type: "datetime2",
                maxLength: 20,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TB_FUNCIONARIO",
                keyColumn: "ID_FUNCIONARIO",
                keyValue: 1L,
                columns: new[] { "V_BAIRRO_ENDERECO", "I_CEP_ENDERECO", "V_CIDADE_ENDERECO", "V_COMPLEMENTO_ENDERECO", "DT_CADASTRO", "DT_NASCIMENTO", "FK_ID_CARGO", "V_LOGRADOURO_ENDERECO", "I_NUM_ENDERECO", "V_UF_ENDERECO" },
                values: new object[] { "Centro", 17800970, "Adamantina", "Próximo a banca de jornal do seu João", new DateTime(2023, 6, 20, 18, 36, 26, 563, DateTimeKind.Local).AddTicks(125), new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Rua Deputado Salles Filho 469", "15", "SP" });

            migrationBuilder.UpdateData(
                table: "TB_FUNCIONARIO",
                keyColumn: "ID_FUNCIONARIO",
                keyValue: 2L,
                columns: new[] { "V_BAIRRO_ENDERECO", "I_CEP_ENDERECO", "V_CIDADE_ENDERECO", "V_COMPLEMENTO_ENDERECO", "DT_CADASTRO", "DT_NASCIMENTO", "FK_ID_CARGO", "V_LOGRADOURO_ENDERECO", "I_NUM_ENDERECO", "V_UF_ENDERECO" },
                values: new object[] { "Centro", 15230970, "Adolfo", "Próximo a casa do Pedro", new DateTime(2023, 6, 20, 18, 36, 26, 563, DateTimeKind.Local).AddTicks(158), new DateTime(1987, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Rua Castro Alves 984", "85", "SP" });

            migrationBuilder.UpdateData(
                table: "TB_PRODUTO",
                keyColumn: "ID_PRODUTO",
                keyValue: 1L,
                columns: new[] { "DT_ALTERACAO", "DT_CADASTRO", "FK_ID_TIPO" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 20, 18, 36, 26, 563, DateTimeKind.Local).AddTicks(175), 1 });

            migrationBuilder.UpdateData(
                table: "TB_PRODUTO",
                keyColumn: "ID_PRODUTO",
                keyValue: 2L,
                columns: new[] { "DT_ALTERACAO", "DT_CADASTRO", "FK_ID_TIPO" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 20, 18, 36, 26, 563, DateTimeKind.Local).AddTicks(187), 2 });

            migrationBuilder.UpdateData(
                table: "TB_PRODUTO",
                keyColumn: "ID_PRODUTO",
                keyValue: 4L,
                columns: new[] { "DT_ALTERACAO", "DT_CADASTRO", "FK_ID_TIPO" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 20, 18, 36, 26, 563, DateTimeKind.Local).AddTicks(193), 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DT_ALTERACAO",
                table: "TB_PRODUTO");

            migrationBuilder.UpdateData(
                table: "TB_FUNCIONARIO",
                keyColumn: "ID_FUNCIONARIO",
                keyValue: 1L,
                columns: new[] { "V_BAIRRO_ENDERECO", "I_CEP_ENDERECO", "V_CIDADE_ENDERECO", "V_COMPLEMENTO_ENDERECO", "DT_CADASTRO", "DT_NASCIMENTO", "FK_ID_CARGO", "V_LOGRADOURO_ENDERECO", "I_NUM_ENDERECO", "V_UF_ENDERECO" },
                values: new object[] { null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null });

            migrationBuilder.UpdateData(
                table: "TB_FUNCIONARIO",
                keyColumn: "ID_FUNCIONARIO",
                keyValue: 2L,
                columns: new[] { "V_BAIRRO_ENDERECO", "I_CEP_ENDERECO", "V_CIDADE_ENDERECO", "V_COMPLEMENTO_ENDERECO", "DT_CADASTRO", "DT_NASCIMENTO", "FK_ID_CARGO", "V_LOGRADOURO_ENDERECO", "I_NUM_ENDERECO", "V_UF_ENDERECO" },
                values: new object[] { null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null });

            migrationBuilder.UpdateData(
                table: "TB_PRODUTO",
                keyColumn: "ID_PRODUTO",
                keyValue: 1L,
                columns: new[] { "DT_CADASTRO", "FK_ID_TIPO" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.UpdateData(
                table: "TB_PRODUTO",
                keyColumn: "ID_PRODUTO",
                keyValue: 2L,
                columns: new[] { "DT_CADASTRO", "FK_ID_TIPO" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.UpdateData(
                table: "TB_PRODUTO",
                keyColumn: "ID_PRODUTO",
                keyValue: 4L,
                columns: new[] { "DT_CADASTRO", "FK_ID_TIPO" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });
        }
    }
}
