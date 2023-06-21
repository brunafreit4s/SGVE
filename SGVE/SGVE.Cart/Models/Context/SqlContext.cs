using Microsoft.EntityFrameworkCore;

namespace SGVE.Cart.Models.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Venda_x_Produto> Venda_x_Produto { get; set; }

    }
}
