using BloodDonation.Database.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BloodDonation.Database.Infrastructure.Persistence.Configuration.SqlServer
{
    [ExcludeFromCodeCoverage]
    public class SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : DbContext(options)
    {
        public DbSet<Donator> Donator { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<BloodStock> BloodStocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerDbContext).Assembly);
        }
    }
}
