using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGVEapi.Migrations
{
    /// <inheritdoc />
    public partial class SendUpdateFuncionariosDataTableOnDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TB_FUNCIONARIO",
                keyColumn: "ID_FUNCIONARIO",
                keyValue: 1L,
                columns: new[] { "V_BAIRRO_ENDERECO", "V_CELULAR", "I_CEP_ENDERECO", "V_CIDADE_ENDERECO", "V_COMPLEMENTO_ENDERECO", "DT_CADASTRO", "DT_NASCIMENTO", "FK_ID_CARGO", "V_LOGRADOURO_ENDERECO", "I_NUM_ENDERECO", "V_TELEFONE", "V_UF_ENDERECO" },
                values: new object[] { "Centro", "11998987474", 17800970, "Adamantina", "Próximo a banca de jornal do seu João", new DateTime(2023, 6, 20, 14, 22, 29, 600, DateTimeKind.Local).AddTicks(5204), new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Rua Deputado Salles Filho 469", "15", "1122223333", "SP" });

            migrationBuilder.UpdateData(
                table: "TB_FUNCIONARIO",
                keyColumn: "ID_FUNCIONARIO",
                keyValue: 2L,
                columns: new[] { "V_BAIRRO_ENDERECO", "V_CELULAR", "I_CEP_ENDERECO", "V_CIDADE_ENDERECO", "V_COMPLEMENTO_ENDERECO", "DT_CADASTRO", "DT_NASCIMENTO", "FK_ID_CARGO", "V_LOGRADOURO_ENDERECO", "I_NUM_ENDERECO", "V_TELEFONE", "V_UF_ENDERECO" },
                values: new object[] { "Centro", "11998987474", 15230970, "Adolfo", "Próximo a casa do Pedro", new DateTime(2023, 6, 20, 14, 22, 29, 600, DateTimeKind.Local).AddTicks(5243), new DateTime(1987, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Rua Castro Alves 984", "85", "1122223333", "SP" });

            migrationBuilder.UpdateData(
                table: "TB_PRODUTO",
                keyColumn: "ID_PRODUTO",
                keyValue: 2L,
                columns: new[] { "DT_CADASTRO", "FK_ID_FORNECEDOR", "FK_ID_TIPO" },
                values: new object[] { new DateTime(2023, 6, 20, 14, 22, 29, 600, DateTimeKind.Local).AddTicks(5253), 2, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TB_FUNCIONARIO",
                keyColumn: "ID_FUNCIONARIO",
                keyValue: 1L,
                columns: new[] { "V_BAIRRO_ENDERECO", "V_CELULAR", "I_CEP_ENDERECO", "V_CIDADE_ENDERECO", "V_COMPLEMENTO_ENDERECO", "DT_CADASTRO", "DT_NASCIMENTO", "FK_ID_CARGO", "V_LOGRADOURO_ENDERECO", "I_NUM_ENDERECO", "V_TELEFONE", "V_UF_ENDERECO" },
                values: new object[] { null, "011998987474", 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, "01122223333", null });

            migrationBuilder.UpdateData(
                table: "TB_FUNCIONARIO",
                keyColumn: "ID_FUNCIONARIO",
                keyValue: 2L,
                columns: new[] { "V_BAIRRO_ENDERECO", "V_CELULAR", "I_CEP_ENDERECO", "V_CIDADE_ENDERECO", "V_COMPLEMENTO_ENDERECO", "DT_CADASTRO", "DT_NASCIMENTO", "FK_ID_CARGO", "V_LOGRADOURO_ENDERECO", "I_NUM_ENDERECO", "V_TELEFONE", "V_UF_ENDERECO" },
                values: new object[] { null, "011998987474", 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, "01122223333", null });

            migrationBuilder.UpdateData(
                table: "TB_PRODUTO",
                keyColumn: "ID_PRODUTO",
                keyValue: 2L,
                columns: new[] { "DT_CADASTRO", "FK_ID_FORNECEDOR", "FK_ID_TIPO" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 });
        }
    }
}
