using BloodDonation.Database.Core.Models.Entities;
using BloodDonation.Database.Core.Models.Enums;
using BloodDonation.Database.Core.Repositories;
using BloodDonation.Database.Core.Repositories.Base;
using BloodDonation.Database.Infrastructure.Persistence.Configuration.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Database.Infrastructure.Persistence.Repositories
{
    public class BloodStockRepository(SqlServerDbContext context, IUpdateRepository<BloodStock> updateRepository, IAddRepository<BloodStock> addRepository) : IBloodStockRepository
    {
        private readonly IUpdateRepository<BloodStock> _updateRepository = updateRepository;
        private readonly IAddRepository<BloodStock> _addRepository = addRepository;
        private readonly SqlServerDbContext _context = context;

        public Task<BloodStock> AddAsync(BloodStock entity)
        {
            return _addRepository.AddAsync(entity);
        }

        public Task<BloodStock> GetByBloodTypeAndRhFactorAsync(BloodType bloodType, RhFactor rhFactor)
        {
            return _context.BloodStocks.FirstOrDefaultAsync(b => b.BloodType.Equals(bloodType) && b.RhFactor.Equals(rhFactor))!;
        }

        public BloodStock Update(BloodStock entity)
        {
            return _updateRepository.Update(entity);
        }
    }
}
