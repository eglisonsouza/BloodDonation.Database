using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BloodDonation.Database.Infrastructure.Persistence.Configuration.SqlServer
{
    [ExcludeFromCodeCoverage]
    public class SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerDbContext).Assembly);
        }
    }
}
