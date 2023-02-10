using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SGVE.IdentityServer.Models.Sql.Context
{
    public class SqlContext : IdentityDbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUser { get; set;}
    }
}
