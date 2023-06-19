using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGVEapi.Migrations
{
    /// <inheritdoc />
    public partial class SendUpdateFuncionadoDataTableOnDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TB_FUNCIONARIO",
                keyColumn: "ID_FUNCIONARIO",
                keyValue: 1L,
                columns: new[] { "V_BAIRRO_ENDERECO", "I_CEP_ENDERECO", "V_CIDADE_ENDERECO", "V_COMPLEMENTO_ENDERECO", "DT_CADASTRO", "DT_NASCIMENTO", "FK_ID_CARGO", "V_LOGRADOURO_ENDERECO", "I_NUM_ENDERECO", "V_UF_ENDERECO" },
                values: new object[] { "Centro", 17800970, "Adamantina", "Próximo a banca de jornal do seu João", new DateTime(2023, 6, 19, 20, 38, 15, 104, DateTimeKind.Local).AddTicks(1901), new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Rua Deputado Salles Filho 469", "15", "SP" });

            migrationBuilder.UpdateData(
                table: "TB_FUNCIONARIO",
                keyColumn: "ID_FUNCIONARIO",
                keyValue: 2L,
                columns: new[] { "V_BAIRRO_ENDERECO", "I_CEP_ENDERECO", "V_CIDADE_ENDERECO", "V_COMPLEMENTO_ENDERECO", "DT_CADASTRO", "DT_NASCIMENTO", "FK_ID_CARGO", "V_LOGRADOURO_ENDERECO", "I_NUM_ENDERECO", "V_UF_ENDERECO" },
                values: new object[] { "Centro", 15230970, "Adolfo", "Próximo a casa do Pedro", new DateTime(2023, 6, 19, 20, 38, 15, 104, DateTimeKind.Local).AddTicks(1945), new DateTime(1987, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Rua Castro Alves 984", "85", "SP" });

            migrationBuilder.UpdateData(
                table: "TB_PRODUTO",
                keyColumn: "ID_PRODUTO",
                keyValue: 2L,
                columns: new[] { "DT_CADASTRO", "FK_ID_FORNECEDOR", "FK_ID_TIPO" },
                values: new object[] { new DateTime(2023, 6, 19, 20, 38, 15, 104, DateTimeKind.Local).AddTicks(1957), 2, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                keyValue: 2L,
                columns: new[] { "DT_CADASTRO", "FK_ID_FORNECEDOR", "FK_ID_TIPO" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 });
        }
    }
}
