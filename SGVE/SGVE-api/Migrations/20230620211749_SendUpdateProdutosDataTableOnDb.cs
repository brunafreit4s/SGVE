using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SGVEapi.Migrations
{
    /// <inheritdoc />
    public partial class SendUpdateProdutosDataTableOnDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FK_ID_FORNECEDOR",
                table: "TB_PRODUTO");

            migrationBuilder.AlterColumn<decimal>(
                name: "D_PRECO",
                table: "TB_PRODUTO",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "D_CUSTO",
                table: "TB_PRODUTO",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "TB_FUNCIONARIO",
                keyColumn: "ID_FUNCIONARIO",
                keyValue: 1L,
                columns: new[] { "V_BAIRRO_ENDERECO", "I_CEP_ENDERECO", "V_CIDADE_ENDERECO", "V_COMPLEMENTO_ENDERECO", "DT_CADASTRO", "DT_NASCIMENTO", "FK_ID_CARGO", "V_LOGRADOURO_ENDERECO", "I_NUM_ENDERECO", "V_UF_ENDERECO" },
                values: new object[] { "Centro", 17800970, "Adamantina", "Próximo a banca de jornal do seu João", new DateTime(2023, 6, 20, 18, 17, 49, 7, DateTimeKind.Local).AddTicks(7440), new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Rua Deputado Salles Filho 469", "15", "SP" });

            migrationBuilder.UpdateData(
                table: "TB_FUNCIONARIO",
                keyColumn: "ID_FUNCIONARIO",
                keyValue: 2L,
                columns: new[] { "V_BAIRRO_ENDERECO", "I_CEP_ENDERECO", "V_CIDADE_ENDERECO", "V_COMPLEMENTO_ENDERECO", "DT_CADASTRO", "DT_NASCIMENTO", "FK_ID_CARGO", "V_LOGRADOURO_ENDERECO", "I_NUM_ENDERECO", "V_UF_ENDERECO" },
                values: new object[] { "Centro", 15230970, "Adolfo", "Próximo a casa do Pedro", new DateTime(2023, 6, 20, 18, 17, 49, 7, DateTimeKind.Local).AddTicks(7476), new DateTime(1987, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Rua Castro Alves 984", "85", "SP" });

            migrationBuilder.UpdateData(
                table: "TB_PRODUTO",
                keyColumn: "ID_PRODUTO",
                keyValue: 2L,
                columns: new[] { "D_CUSTO", "DT_CADASTRO", "V_DESCRICAO", "FK_ID_TIPO", "V_MARCA", "V_NOME", "D_PRECO", "I_QUANTIDADE" },
                values: new object[] { 10m, new DateTime(2023, 6, 20, 18, 17, 49, 7, DateTimeKind.Local).AddTicks(7499), "Refrigerante sabor Coca-Cola", 2, "Coca-Cola", "Coca-Cola", 13.5m, 100 });

            migrationBuilder.InsertData(
                table: "TB_PRODUTO",
                columns: new[] { "ID_PRODUTO", "D_CUSTO", "DT_CADASTRO", "V_DESCRICAO", "FK_ID_TIPO", "V_MARCA", "V_NOME", "D_PRECO", "I_QUANTIDADE" },
                values: new object[,]
                {
                    { 1L, 0.5m, new DateTime(2023, 6, 20, 18, 17, 49, 7, DateTimeKind.Local).AddTicks(7491), "Bolacha sabor Morango", 1, "Trakinas", "Bolacha", 1.5m, 15 },
                    { 4L, 5m, new DateTime(2023, 6, 20, 18, 17, 49, 7, DateTimeKind.Local).AddTicks(7504), "Papel Higiênico Primavera", 3, "Primavera", "Papel Higiênico", 10m, 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_PRODUTO",
                keyColumn: "ID_PRODUTO",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "TB_PRODUTO",
                keyColumn: "ID_PRODUTO",
                keyValue: 4L);

            migrationBuilder.AlterColumn<float>(
                name: "D_PRECO",
                table: "TB_PRODUTO",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "D_CUSTO",
                table: "TB_PRODUTO",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "FK_ID_FORNECEDOR",
                table: "TB_PRODUTO",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "D_CUSTO", "DT_CADASTRO", "V_DESCRICAO", "FK_ID_FORNECEDOR", "FK_ID_TIPO", "V_MARCA", "V_NOME", "D_PRECO", "I_QUANTIDADE" },
                values: new object[] { 1.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bolacha sabor Morango", 0, 0, "Trakinas", "Bolacha Trakinas", 0.5f, 10 });
        }
    }
}
