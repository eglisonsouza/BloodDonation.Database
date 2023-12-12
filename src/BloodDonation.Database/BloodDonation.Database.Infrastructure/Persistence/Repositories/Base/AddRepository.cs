using BloodDonation.Database.Core.Entities.Base;
using BloodDonation.Database.Core.Repositories.Base;
using BloodDonation.Database.Infrastructure.Persistence.Configuration.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Database.Infrastructure.Persistence.Repositories.Base
{
    public class AddRepository<TEntity> : IAddRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly SqlServerDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public AddRepository(SqlServerDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await _dbSet.AddAsync(entity);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
