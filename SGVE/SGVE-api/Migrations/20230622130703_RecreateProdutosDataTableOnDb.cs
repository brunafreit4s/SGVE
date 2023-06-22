using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SGVEapi.Migrations
{
    /// <inheritdoc />
    public partial class RecreateProdutosDataTableOnDb : Migration
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
                    VCELULAR = table.Column<string>(name: "V_CELULAR", type: "nvarchar(15)", maxLength: 15, nullable: true),
                    VTELEFONE = table.Column<string>(name: "V_TELEFONE", type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ICEPENDERECO = table.Column<int>(name: "I_CEP_ENDERECO", type: "int", maxLength: 8, nullable: false),
                    VLOGRADOUROENDERECO = table.Column<string>(name: "V_LOGRADOURO_ENDERECO", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    INUMENDERECO = table.Column<string>(name: "I_NUM_ENDERECO", type: "nvarchar(10)", maxLength: 10, nullable: true),
                    VCOMPLEMENTOENDERECO = table.Column<string>(name: "V_COMPLEMENTO_ENDERECO", type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VBAIRROENDERECO = table.Column<string>(name: "V_BAIRRO_ENDERECO", type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VCIDADEENDERECO = table.Column<string>(name: "V_CIDADE_ENDERECO", type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VUFENDERECO = table.Column<string>(name: "V_UF_ENDERECO", type: "nvarchar(2)", maxLength: 2, nullable: true),
                    VEMAIL = table.Column<string>(name: "V_EMAIL", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VSENHA = table.Column<string>(name: "V_SENHA", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DTCADASTRO = table.Column<DateTime>(name: "DT_CADASTRO", type: "datetime2", maxLength: 20, nullable: false),
                    DTALTERACAO = table.Column<DateTime>(name: "DT_ALTERACAO", type: "datetime2", maxLength: 20, nullable: false),
                    FKIDCARGO = table.Column<int>(name: "FK_ID_CARGO", type: "int", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FUNCIONARIO", x => x.IDFUNCIONARIO);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRODUTO",
                columns: table => new
                {
                    IDPRODUTO = table.Column<long>(name: "ID_PRODUTO", type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VNOME = table.Column<string>(name: "V_NOME", type: "nvarchar(500)", maxLength: 500, nullable: false),
                    VDESCRICAO = table.Column<string>(name: "V_DESCRICAO", type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IQUANTIDADE = table.Column<int>(name: "I_QUANTIDADE", type: "int", maxLength: 4, nullable: false),
                    VMARCA = table.Column<string>(name: "V_MARCA", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DCUSTO = table.Column<decimal>(name: "D_CUSTO", type: "decimal(18,2)", nullable: false),
                    DPRECO = table.Column<decimal>(name: "D_PRECO", type: "decimal(18,2)", nullable: false),
                    DTCADASTRO = table.Column<DateTime>(name: "DT_CADASTRO", type: "datetime2", maxLength: 20, nullable: false),
                    DTALTERACAO = table.Column<DateTime>(name: "DT_ALTERACAO", type: "datetime2", maxLength: 20, nullable: false),
                    FKIDTIPO = table.Column<int>(name: "FK_ID_TIPO", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUTO", x => x.IDPRODUTO);
                });

            migrationBuilder.InsertData(
                table: "TB_FUNCIONARIO",
                columns: new[] { "ID_FUNCIONARIO", "V_BAIRRO_ENDERECO", "V_CELULAR", "I_CEP_ENDERECO", "V_CIDADE_ENDERECO", "V_COMPLEMENTO_ENDERECO", "V_CPF", "DT_ALTERACAO", "DT_CADASTRO", "DT_NASCIMENTO", "V_EMAIL", "FK_ID_CARGO", "V_LOGRADOURO_ENDERECO", "V_NOME", "I_NUM_ENDERECO", "V_RG", "V_SENHA", "V_TELEFONE", "V_UF_ENDERECO" },
                values: new object[,]
                {
                    { 1L, "Centro", "11998987474", 17800970, "Adamantina", "Próximo a banca de jornal do seu João", "78134252001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 22, 10, 7, 2, 917, DateTimeKind.Local).AddTicks(3474), new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "joao.pereira@gmail.com", 1, "Rua Deputado Salles Filho 469", "João Pereira", "15", "248805253", "123456", "1122223333", "SP" },
                    { 2L, "Centro", "11998987474", 15230970, "Adolfo", "Próximo a casa do Pedro", "16926121079", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 22, 10, 7, 2, 917, DateTimeKind.Local).AddTicks(3507), new DateTime(1987, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "joao.pereira@gmail.com", 1, "Rua Castro Alves 984", "Adolfo Silva", "85", "154969552", "123456", "1122223333", "SP" }
                });

            migrationBuilder.InsertData(
                table: "TB_PRODUTO",
                columns: new[] { "ID_PRODUTO", "D_CUSTO", "DT_ALTERACAO", "DT_CADASTRO", "V_DESCRICAO", "FK_ID_TIPO", "V_MARCA", "V_NOME", "D_PRECO", "I_QUANTIDADE" },
                values: new object[,]
                {
                    { 1L, 0.5m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 22, 10, 7, 2, 917, DateTimeKind.Local).AddTicks(3518), "Bolacha sabor Morango", 1, "Trakinas", "Bolacha", 1.5m, 15 },
                    { 2L, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 22, 10, 7, 2, 917, DateTimeKind.Local).AddTicks(3527), "Refrigerante sabor Coca-Cola", 2, "Coca-Cola", "Coca-Cola", 13.5m, 100 },
                    { 3L, 5m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 22, 10, 7, 2, 917, DateTimeKind.Local).AddTicks(3533), "Papel Higiênico Primavera", 3, "Primavera", "Papel Higiênico", 10m, 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_FUNCIONARIO");

            migrationBuilder.DropTable(
                name: "TB_PRODUTO");
        }
    }
}
