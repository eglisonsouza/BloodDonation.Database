using BloodDonation.Database.Core.Models.Entities.Base;
using BloodDonation.Database.Core.Repositories.Base;
using BloodDonation.Database.Infrastructure.Persistence.Configuration.SqlServer;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BloodDonation.Database.Infrastructure.Persistence.Repositories.Base
{
    [ExcludeFromCodeCoverage]
    public class GetByIdRepository<TEntity> : IGetByIdRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        public GetByIdRepository(SqlServerDbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public Task<TEntity?>? GetByIdAsync(Guid id)
        {
            return _dbSet.FirstOrDefaultAsync(e => e.Id == id) ?? null;
        }
    }
}
