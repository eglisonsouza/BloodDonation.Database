using BloodDonation.Database.Core.Models.Entities.Base;
using BloodDonation.Database.Core.Repositories.Base;
using BloodDonation.Database.Infrastructure.Persistence.Configuration.SqlServer;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BloodDonation.Database.Infrastructure.Persistence.Repositories.Base
{
    [ExcludeFromCodeCoverage]
    public class UpdateRepository<TEntity> : IUpdateRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly SqlServerDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public UpdateRepository(SqlServerDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity Update(TEntity entity)
        {
            var result = _dbSet.Update(entity);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
