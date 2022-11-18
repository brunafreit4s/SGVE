using Microsoft.EntityFrameworkCore;
using SGVE_models.Models;

namespace SGVE_models.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext() { }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
