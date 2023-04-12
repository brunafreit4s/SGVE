﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGVE_models.Context;

#nullable disable

namespace SGVEapi.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20230404224225_AddProdutosDataTableDb2")]
    partial class AddProdutosDataTableDb2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SGVE_models.Models.Funcionario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID_FUNCIONARIO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Celular")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("V_CELULAR");

                    b.Property<string>("Complemento_Endereco")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("V_COMPLEMENTO");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("V_CPF");

                    b.Property<string>("DDD_Celular")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("V_DDD_CELULAR");

                    b.Property<string>("DDD_Telefone")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("V_DDD_TELEFONE");

                    b.Property<DateTime>("Data_Cadastro")
                        .HasMaxLength(20)
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_CADASTRO");

                    b.Property<DateTime?>("Data_Desligamento")
                        .HasMaxLength(20)
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_DESLIGAMENTO");

                    b.Property<DateTime>("Data_Nascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_NASCIMENTO");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("V_EMAIL");

                    b.Property<int>("Id_Cargo")
                        .HasMaxLength(15)
                        .HasColumnType("int")
                        .HasColumnName("FK_ID_CARGO");

                    b.Property<int>("Id_Endereco")
                        .HasMaxLength(15)
                        .HasColumnType("int")
                        .HasColumnName("FK_ID_ENDERECO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("V_NOME");

                    b.Property<string>("Numero_Endereco")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("I_NUM_ENDERECO");

                    b.Property<string>("Rg")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("V_RG");

                    b.Property<string>("Senha")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("V_SENHA");

                    b.Property<string>("Telefone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("V_TELEFONE");

                    b.HasKey("Id");

                    b.ToTable("TB_FUNCIONARIO");

                    b.HasData(
                        new
                        {
                            Id = 2L,
                            Cpf = "11122233344",
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataNascimento = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdCargo = 0,
                            IdEndereco = 0,
                            Nome = "João"
                        },
                        new
                        {
                            Id = 3L,
                            Cpf = "55566677799",
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataNascimento = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdCargo = 0,
                            IdEndereco = 0,
                            Nome = "Pedro"
                        });
                });

            modelBuilder.Entity("SGVE_models.Models.Produtos", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID_PRODUTO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<float?>("Custo")
                        .IsRequired()
                        .HasColumnType("real")
                        .HasColumnName("D_CUSTO");

                    b.Property<DateTime>("Data_Cadastro")
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_CADASTRO");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("V_DESCRICAO");

                    b.Property<int>("Id_Fornecedor")
                        .HasColumnType("int")
                        .HasColumnName("FK_ID_FORNECEDOR");

                    b.Property<int>("Id_Tipo")
                        .HasColumnType("int")
                        .HasColumnName("FK_ID_TIPO");

                    b.Property<string>("Marca")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("V_MARCA");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("V_NOME");

                    b.Property<float?>("Preco")
                        .IsRequired()
                        .HasColumnType("real")
                        .HasColumnName("D_PRECO");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("I_QUANTIDADE");

                    b.HasKey("Id");

                    b.ToTable("TB_PRODUTO");

                    b.HasData(
                        new
                        {
                            Id = 2L,
                            Custo = 1.5f,
                            DataCadastro = new DateTime(2023, 4, 4, 19, 42, 25, 660, DateTimeKind.Local).AddTicks(9755),
                            Descricao = "Bolacha sabor Morango",
                            IdFornecedor = 2,
                            IdTipo = 2,
                            Marca = "Trakinas",
                            Nome = "Bolacha Trakinas",
                            Preco = 0.5f,
                            Quantidade = 10
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
