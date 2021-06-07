using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SimpleTrader.EntityFrameworkCore
{
    public class SimpleTraderDbContextFactory : IDesignTimeDbContextFactory<SimpleTraderDbContext>
    {
        public SimpleTraderDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<SimpleTraderDbContext>();
            options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SimpleTraderDB;Trusted_Connection=true");
            return new SimpleTraderDbContext(options.Options);
        }
    }
}
