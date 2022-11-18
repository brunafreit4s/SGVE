using Microsoft.EntityFrameworkCore;

namespace SGVE_models.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext() { }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }
    }
}
