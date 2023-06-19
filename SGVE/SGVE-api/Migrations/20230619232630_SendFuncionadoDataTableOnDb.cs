using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SGVEapi.Migrations
{
    /// <inheritdoc />
    public partial class SendFuncionadoDataTableOnDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ENDERECO");

            migrationBuilder.DeleteData(
                table: "TB_FUNCIONARIO",
                keyColumn: "ID_FUNCIONARIO",
                keyValue: 3L);

            migrationBuilder.DropColumn(
                name: "DT_DESLIGAMENTO",
                table: "TB_FUNCIONARIO");

            migrationBuilder.DropColumn(
                name: "V_DDD_CELULAR",
                table: "TB_FUNCIONARIO");

            migrationBuilder.DropColumn(
                name: "V_DDD_TELEFONE",
                table: "TB_FUNCIONARIO");

            migrationBuilder.RenameColumn(
                name: "V_COMPLEMENTO",
                table: "TB_FUNCIONARIO",
                newName: "V_COMPLEMENTO_ENDERECO");

            migrationBuilder.RenameColumn(
                name: "FK_ID_ENDERECO",
                table: "TB_FUNCIONARIO",
                newName: "I_CEP_ENDERECO");

            migrationBuilder.AlterColumn<string>(
                name: "V_EMAIL",
                table: "TB_FUNCIONARIO",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "I_NUM_ENDERECO",
                table: "TB_FUNCIONARIO",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "V_COMPLEMENTO_ENDERECO",
                table: "TB_FUNCIONARIO",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DT_ALTERACAO",
                table: "TB_FUNCIONARIO",
                type: "datetime2",
                maxLength: 20,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "V_BAIRRO_ENDERECO",
                table: "TB_FUNCIONARIO",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "V_CIDADE_ENDERECO",
                table: "TB_FUNCIONARIO",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "V_LOGRADOURO_ENDERECO",
                table: "TB_FUNCIONARIO",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "V_UF_ENDERECO",
                table: "TB_FUNCIONARIO",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TB_FUNCIONARIO",
                keyColumn: "ID_FUNCIONARIO",
                keyValue: 2L,
                columns: new[] { "V_BAIRRO_ENDERECO", "V_CELULAR", "I_CEP_ENDERECO", "V_CIDADE_ENDERECO", "V_CPF", "DT_ALTERACAO", "DT_CADASTRO", "DT_NASCIMENTO", "V_EMAIL", "FK_ID_CARGO", "V_LOGRADOURO_ENDERECO", "V_NOME", "V_RG", "V_SENHA", "V_TELEFONE", "V_UF_ENDERECO" },
                values: new object[] { "Centro", "011998987474", 15230970, "Adolfo", "16926121079", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 19, 20, 26, 30, 857, DateTimeKind.Local).AddTicks(4620), new DateTime(1987, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "joao.pereira@gmail.com", 1, "Rua Castro Alves 984", "Adolfo Silva", "154969552", "123456", "01122223333", "SP" });

            migrationBuilder.InsertData(
                table: "TB_FUNCIONARIO",
                columns: new[] { "ID_FUNCIONARIO", "V_BAIRRO_ENDERECO", "V_CELULAR", "I_CEP_ENDERECO", "V_CIDADE_ENDERECO", "V_COMPLEMENTO_ENDERECO", "V_CPF", "DT_ALTERACAO", "DT_CADASTRO", "DT_NASCIMENTO", "V_EMAIL", "FK_ID_CARGO", "V_LOGRADOURO_ENDERECO", "V_NOME", "I_NUM_ENDERECO", "V_RG", "V_SENHA", "V_TELEFONE", "V_UF_ENDERECO" },
                values: new object[] { 1L, "Centro", "011998987474", 17800970, "Adamantina", null, "78134252001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 19, 20, 26, 30, 857, DateTimeKind.Local).AddTicks(4582), new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "joao.pereira@gmail.com", 1, "Rua Deputado Salles Filho 469", "João Pereira", null, "248805253", "123456", "01122223333", "SP" });

            migrationBuilder.UpdateData(
                table: "TB_PRODUTO",
                keyColumn: "ID_PRODUTO",
                keyValue: 2L,
                columns: new[] { "DT_CADASTRO", "FK_ID_FORNECEDOR", "FK_ID_TIPO" },
                values: new object[] { new DateTime(2023, 6, 19, 20, 26, 30, 857, DateTimeKind.Local).AddTicks(4653), 2, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_FUNCIONARIO",
                keyColumn: "ID_FUNCIONARIO",
                keyValue: 1L);

            migrationBuilder.DropColumn(
                name: "DT_ALTERACAO",
                table: "TB_FUNCIONARIO");

            migrationBuilder.DropColumn(
                name: "V_BAIRRO_ENDERECO",
                table: "TB_FUNCIONARIO");

            migrationBuilder.DropColumn(
                name: "V_CIDADE_ENDERECO",
                table: "TB_FUNCIONARIO");

            migrationBuilder.DropColumn(
                name: "V_LOGRADOURO_ENDERECO",
                table: "TB_FUNCIONARIO");

            migrationBuilder.DropColumn(
                name: "V_UF_ENDERECO",
                table: "TB_FUNCIONARIO");

            migrationBuilder.RenameColumn(
                name: "V_COMPLEMENTO_ENDERECO",
                table: "TB_FUNCIONARIO",
                newName: "V_COMPLEMENTO");

            migrationBuilder.RenameColumn(
                name: "I_CEP_ENDERECO",
                table: "TB_FUNCIONARIO",
                newName: "FK_ID_ENDERECO");

            migrationBuilder.AlterColumn<string>(
                name: "V_EMAIL",
                table: "TB_FUNCIONARIO",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "I_NUM_ENDERECO",
                table: "TB_FUNCIONARIO",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "V_COMPLEMENTO",
                table: "TB_FUNCIONARIO",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DT_DESLIGAMENTO",
                table: "TB_FUNCIONARIO",
                type: "datetime2",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "V_DDD_CELULAR",
                table: "TB_FUNCIONARIO",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "V_DDD_TELEFONE",
                table: "TB_FUNCIONARIO",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TB_ENDERECO",
                columns: table => new
                {
                    IDENDERECO = table.Column<long>(name: "ID_ENDERECO", type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VBAIRRO = table.Column<string>(name: "V_BAIRRO", type: "nvarchar(max)", nullable: false),
                    ICEP = table.Column<int>(name: "I_CEP", type: "int", maxLength: 8, nullable: false),
                    VCIDADE = table.Column<string>(name: "V_CIDADE", type: "nvarchar(max)", nullable: false),
                    VCDIBGE = table.Column<string>(name: "V_CD_IBGE", type: "nvarchar(max)", nullable: false),
                    VCOMPLEMENTO = table.Column<string>(name: "V_COMPLEMENTO", type: "nvarchar(max)", nullable: true),
                    VLOGRADOURO = table.Column<string>(name: "V_LOGRADOURO", type: "nvarchar(max)", nullable: false),
                    VTIPOCEP = table.Column<string>(name: "V_TIPO_CEP", type: "nvarchar(max)", nullable: false),
                    VUF = table.Column<string>(name: "V_UF", type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ENDERECO", x => x.IDENDERECO);
                });

            migrationBuilder.InsertData(
                table: "TB_ENDERECO",
                columns: new[] { "ID_ENDERECO", "V_BAIRRO", "I_CEP", "V_CIDADE", "V_CD_IBGE", "V_COMPLEMENTO", "V_LOGRADOURO", "V_TIPO_CEP", "V_UF" },
                values: new object[,]
                {
                    { 1L, "Jardim Novo Horizonte", 13188270, "Hortolândia", "3519071", "", "Rua João de Camargo", "1", "SP" },
                    { 2L, "Piedade", 12285815, "Caçapava", "3508504", "", "Rua Capitão Mário Raymundo da Silva", "1", "SP" },
                    { 3L, "Jardim Shangrilá (Zona Norte)", 2990250, "São Paulo", "3550308", "", "Travessa João da Baiana", "1", "SP" }
                });

            migrationBuilder.UpdateData(
                table: "TB_FUNCIONARIO",
                keyColumn: "ID_FUNCIONARIO",
                keyValue: 2L,
                columns: new[] { "V_CELULAR", "V_CPF", "V_DDD_CELULAR", "V_DDD_TELEFONE", "DT_CADASTRO", "DT_DESLIGAMENTO", "DT_NASCIMENTO", "V_EMAIL", "FK_ID_CARGO", "FK_ID_ENDERECO", "V_NOME", "V_RG", "V_SENHA", "V_TELEFONE" },
                values: new object[] { null, "11122233344", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, "João", null, null, null });

            migrationBuilder.InsertData(
                table: "TB_FUNCIONARIO",
                columns: new[] { "ID_FUNCIONARIO", "V_CELULAR", "V_COMPLEMENTO", "V_CPF", "V_DDD_CELULAR", "V_DDD_TELEFONE", "DT_CADASTRO", "DT_DESLIGAMENTO", "DT_NASCIMENTO", "V_EMAIL", "FK_ID_CARGO", "FK_ID_ENDERECO", "V_NOME", "I_NUM_ENDERECO", "V_RG", "V_SENHA", "V_TELEFONE" },
                values: new object[] { 3L, null, null, "55566677799", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, "Pedro", null, null, null, null });

            migrationBuilder.UpdateData(
                table: "TB_PRODUTO",
                keyColumn: "ID_PRODUTO",
                keyValue: 2L,
                columns: new[] { "DT_CADASTRO", "FK_ID_FORNECEDOR", "FK_ID_TIPO" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 });
        }
    }
}
