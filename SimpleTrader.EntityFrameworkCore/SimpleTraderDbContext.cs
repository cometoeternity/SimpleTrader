using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using System.Diagnostics.CodeAnalysis;

namespace SimpleTrader.EntityFrameworkCore
{
    public class SimpleTraderDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AssetTransaction> AssetTransactions { get; set; }

        public SimpleTraderDbContext([NotNullAttribute] DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetTransaction>().OwnsOne(a => a.Stock);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SimpleTraderDB;Trusted_Connection=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
