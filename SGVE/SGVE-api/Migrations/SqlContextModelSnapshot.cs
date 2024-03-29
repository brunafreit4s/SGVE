﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGVE_api.Context;

#nullable disable

namespace SGVEapi.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SGVE_api.Models.Funcionario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID_FUNCIONARIO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Bairro_Endereco")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("V_BAIRRO_ENDERECO");

                    b.Property<string>("Celular")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("V_CELULAR");

                    b.Property<int>("Cep_Endereco")
                        .HasMaxLength(8)
                        .HasColumnType("int")
                        .HasColumnName("I_CEP_ENDERECO");

                    b.Property<string>("Cidade_Endereco")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("V_CIDADE_ENDERECO");

                    b.Property<string>("Complemento_Endereco")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("V_COMPLEMENTO_ENDERECO");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("V_CPF");

                    b.Property<DateTime>("Data_Alteracao")
                        .HasMaxLength(20)
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_ALTERACAO");

                    b.Property<DateTime>("Data_Cadastro")
                        .HasMaxLength(20)
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_CADASTRO");

                    b.Property<DateTime>("Data_Nascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_NASCIMENTO");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("V_EMAIL");

                    b.Property<int>("Id_Cargo")
                        .HasMaxLength(1)
                        .HasColumnType("int")
                        .HasColumnName("FK_ID_CARGO");

                    b.Property<string>("Logradouro_Endereco")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("V_LOGRADOURO_ENDERECO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("V_NOME");

                    b.Property<string>("Numero_Endereco")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
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

                    b.Property<string>("UF_Endereco")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("V_UF_ENDERECO");

                    b.HasKey("Id");

                    b.ToTable("TB_FUNCIONARIO", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Celular = "11998987474",
                            Cpf = "78134252001",
                            Email = "joao.pereira@gmail.com",
                            Nome = "João Pereira",
                            Rg = "248805253",
                            Senha = "123456",
                            Telefone = "1122223333"
                        },
                        new
                        {
                            Id = 2L,
                            Celular = "11998987474",
                            Cpf = "16926121079",
                            Email = "joao.pereira@gmail.com",
                            Nome = "Adolfo Silva",
                            Rg = "154969552",
                            Senha = "123456",
                            Telefone = "1122223333"
                        });
                });

            modelBuilder.Entity("SGVE_api.Models.Produtos", b =>
                {
                    b.Property<long>("Id_Produto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID_PRODUTO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id_Produto"));

                    b.Property<decimal>("Custo")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("D_CUSTO");

                    b.Property<DateTime>("Data_Alteracao")
                        .HasMaxLength(20)
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_ALTERACAO");

                    b.Property<DateTime>("Data_Cadastro")
                        .HasMaxLength(20)
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_CADASTRO");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("V_DESCRICAO");

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

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("D_PRECO");

                    b.Property<int>("Quantidade")
                        .HasMaxLength(4)
                        .HasColumnType("int")
                        .HasColumnName("I_QUANTIDADE");

                    b.HasKey("Id_Produto");

                    b.ToTable("TB_PRODUTO", (string)null);

                    b.HasData(
                        new
                        {
                            Custo = 0.5m,
                            Descricao = "Bolacha sabor Morango",
                            Marca = "Trakinas",
                            Nome = "Bolacha",
                            Preco = 1.5m,
                            Quantidade = 15
                        },
                        new
                        {
                            Custo = 10m,
                            Descricao = "Refrigerante sabor Coca-Cola",
                            Marca = "Coca-Cola",
                            Nome = "Coca-Cola",
                            Preco = 13.5m,
                            Quantidade = 100
                        },
                        new
                        {
                            Custo = 5m,
                            Descricao = "Papel Higiênico Primavera",
                            Marca = "Primavera",
                            Nome = "Papel Higiênico",
                            Preco = 10m,
                            Quantidade = 30
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
