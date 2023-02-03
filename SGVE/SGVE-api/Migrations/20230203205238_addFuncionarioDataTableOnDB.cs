using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SGVEapi.Migrations
{
    /// <inheritdoc />
    public partial class addFuncionarioDataTableOnDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_FUNCIONARIO",
                columns: table => new
                {
                    IDFUNCIONARIO = table.Column<long>(name: "ID_FUNCIONARIO", type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VCPF = table.Column<string>(name: "V_CPF", type: "nvarchar(11)", maxLength: 11, nullable: false),
                    VNOME = table.Column<string>(name: "V_NOME", type: "nvarchar(500)", maxLength: 500, nullable: false),
                    VRG = table.Column<string>(name: "V_RG", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DTNASCIMENTO = table.Column<DateTime>(name: "DT_NASCIMENTO", type: "datetime2", nullable: false),
                    VDDDCELULAR = table.Column<string>(name: "V_DDD_CELULAR", type: "nvarchar(3)", maxLength: 3, nullable: true),
                    VCELULAR = table.Column<string>(name: "V_CELULAR", type: "nvarchar(15)", maxLength: 15, nullable: true),
                    VDDDTELEFONE = table.Column<string>(name: "V_DDD_TELEFONE", type: "nvarchar(3)", maxLength: 3, nullable: true),
                    VTELEFONE = table.Column<string>(name: "V_TELEFONE", type: "nvarchar(15)", maxLength: 15, nullable: true),
                    FKIDENDERECO = table.Column<int>(name: "FK_ID_ENDERECO", type: "int", maxLength: 15, nullable: false),
                    INUMENDERECO = table.Column<string>(name: "I_NUM_ENDERECO", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VCOMPLEMENTO = table.Column<string>(name: "V_COMPLEMENTO", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    VEMAIL = table.Column<string>(name: "V_EMAIL", type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VSENHA = table.Column<string>(name: "V_SENHA", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DTCADASTRO = table.Column<DateTime>(name: "DT_CADASTRO", type: "datetime2", maxLength: 20, nullable: false),
                    DTDESLIGAMENTO = table.Column<DateTime>(name: "DT_DESLIGAMENTO", type: "datetime2", maxLength: 20, nullable: true),
                    FKIDCARGO = table.Column<int>(name: "FK_ID_CARGO", type: "int", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FUNCIONARIO", x => x.IDFUNCIONARIO);
                });

            migrationBuilder.InsertData(
                table: "TB_FUNCIONARIO",
                columns: new[] { "ID_FUNCIONARIO", "V_CELULAR", "V_COMPLEMENTO", "V_CPF", "V_DDD_CELULAR", "V_DDD_TELEFONE", "DT_CADASTRO", "DT_DESLIGAMENTO", "DT_NASCIMENTO", "V_EMAIL", "FK_ID_CARGO", "FK_ID_ENDERECO", "V_NOME", "I_NUM_ENDERECO", "V_RG", "V_SENHA", "V_TELEFONE" },
                values: new object[,]
                {
                    { 2L, null, null, "11122233344", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, "João", null, null, null, null },
                    { 3L, null, null, "55566677799", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, "Pedro", null, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_FUNCIONARIO");
        }
    }
}
