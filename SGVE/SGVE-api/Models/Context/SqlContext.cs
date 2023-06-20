using Microsoft.EntityFrameworkCore;
using SGVE_api.Models;

namespace SGVE_api.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext() { }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Produtos> Produtos { get; set; }

        /* Atenção !!!!!!
         * A codificação abaixo é para ser utilizada apenas como exemplo,
         * o método OnModelCreating adiciona itens na tabela na base de dados,
         * para isso deve-se rodar um update da migrations no banco.
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>().HasData(new Funcionario
            {
                Id = 1,
                Cpf = "78134252001",
                Nome = "João Pereira",
                Rg = "248805253",
                Data_Nascimento = DateTime.Parse("01/01/1991"),
                Celular = "11998987474",
                Telefone = "1122223333",
                Cep_Endereco = 17800970,
                Logradouro_Endereco = "Rua Deputado Salles Filho 469",
                Numero_Endereco = "15",
                Complemento_Endereco = "Próximo a banca de jornal do seu João",
                Bairro_Endereco = "Centro",
                Cidade_Endereco = "Adamantina",
                UF_Endereco = "SP",
                Email = "joao.pereira@gmail.com",
                Senha = "123456",
                Data_Cadastro = DateTime.Now,
                Id_Cargo = 1,
            });

            modelBuilder.Entity<Funcionario>().HasData(new Funcionario
            {
                Id = 2,
                Cpf = "16926121079",
                Nome = "Adolfo Silva",
                Rg = "154969552",
                Data_Nascimento = DateTime.Parse("04/06/1987"),
                Celular = "11998987474",
                Telefone = "1122223333",
                Cep_Endereco = 15230970,
                Logradouro_Endereco = "Rua Castro Alves 984",
                Numero_Endereco = "85",
                Complemento_Endereco = "Próximo a casa do Pedro",
                Bairro_Endereco = "Centro",
                Cidade_Endereco = "Adolfo",
                UF_Endereco = "SP",
                Email = "joao.pereira@gmail.com",
                Senha = "123456",
                Data_Cadastro = DateTime.Now,
                Id_Cargo = 1,
            });

            modelBuilder.Entity<Produtos>().HasData(new Produtos
            {
                Id = 2,
                Nome = "Bolacha Trakinas",
                Custo = (float?)1.50,
                Preco = (float?)0.50,
                Data_Cadastro = DateTime.Now,
                Descricao = "Bolacha sabor Morango",
                Id_Fornecedor= 2,
                Id_Tipo= 2,
                Marca = "Trakinas",
                Quantidade = 10
            });

            /* ... */
            /*
             * Após finalizar, executar no Console:
             * add-migration [nomedamigration]
             * update-database -Context SqlContext
             */

        }
    }
}
