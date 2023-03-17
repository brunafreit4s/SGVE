using Microsoft.EntityFrameworkCore;
using SGVE_models.Models;

namespace SGVE_models.Context
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

            /* ... */
            /*
             * Após finalizar, executar no Console:
             * add-migration [nomedamigration]
             * update-database -Context SqlContext
             */

        }
    }
}
