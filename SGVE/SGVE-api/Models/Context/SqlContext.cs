using Microsoft.EntityFrameworkCore;
using SGVE_models.Models;

namespace SGVE_models.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext() { }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Funcionario> Funcionarios { get; set; }

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
                Nome = "João"
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
                Nome = "Pedro"
                /*
                 .
                 .
                 .
                    atribuir os valores desejados em todas as colunas.
                 */
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
