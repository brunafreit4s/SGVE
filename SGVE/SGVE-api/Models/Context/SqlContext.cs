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
        public DbSet<Endereco> Endereco { get; set; }

        /* Atenção !!!!!!
         * A codificação abaixo é para ser utilizada apenas como exemplo,
         * o método OnModelCreating adiciona itens na tabela na base de dados,
         * para isso deve-se rodar um update da migrations no banco.
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>().HasData(new Funcionario
            {
                Id = 2,
                Nome = "João",
                Cpf = "11122233344"
                /*
                 .
                 .
                 .
                    atribuir os valores desejados em todas as colunas.
                 */
            });

            modelBuilder.Entity<Funcionario>().HasData(new Funcionario
            {
                Id = 3,
                Nome = "Pedro",
                Cpf = "55566677799"
                /*
                 .
                 .
                 .
                    atribuir os valores desejados em todas as colunas.
                 */
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

            modelBuilder.Entity<Endereco>().HasData(new Endereco 
            {
                id = 1,
                cep = 13188270,
                tipoCep = "1",
                uf = "SP",
                cidade = "Hortolândia",
                bairro = "Jardim Novo Horizonte",
                logradouro = "Rua João de Camargo",
                complemento = "",
                codigoIBGE = "3519071"
            });

            modelBuilder.Entity<Endereco>().HasData(new Endereco
            {
                id = 2,
                cep = 12285815,
                tipoCep = "1",
                uf = "SP",
                cidade = "Caçapava",
                bairro = "Piedade",
                logradouro = "Rua Capitão Mário Raymundo da Silva",
                complemento = "",
                codigoIBGE = "3508504"
            });

            modelBuilder.Entity<Endereco>().HasData(new Endereco
            {
                id = 3,
                cep = 02990250,
                tipoCep = "1",
                uf = "SP",
                cidade = "São Paulo",
                bairro = "Jardim Shangrilá (Zona Norte)",
                logradouro = "Travessa João da Baiana",
                complemento = "",
                codigoIBGE = "3550308"
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
