using Microsoft.EntityFrameworkCore;
using SGVE.Models;

namespace SGVE_api.EntityStore
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        //Funcionario é nome da tabela no banco de dados
        public DbSet<Usuario> Funcionario { get; set; }
    }
}
