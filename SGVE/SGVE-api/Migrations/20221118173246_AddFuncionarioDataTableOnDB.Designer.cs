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
    [Migration("20221118173246_AddFuncionarioDataTableOnDB")]
    partial class AddFuncionarioDataTableOnDB
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
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_FUNCIONARIO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

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

                    b.Property<DateTime>("Data_Desligamento")
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
                });
#pragma warning restore 612, 618
        }
    }
}
