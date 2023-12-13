using BloodDonation.Database.Core.Models.Entities;
using BloodDonation.Database.Core.Repositories;
using BloodDonation.Database.Core.Repositories.Base;
using BloodDonation.Database.Infrastructure.Persistence.Configuration.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Database.Infrastructure.Persistence.Repositories
{
    public class DonationRepository(IAddRepository<Donation> addRepository, SqlServerDbContext context) : IDonationRepository
    {
        private readonly IAddRepository<Donation> _addRepository = addRepository;
        private readonly SqlServerDbContext _context = context;
        public Task<Donation> AddAsync(Donation entity)
        {
            return _addRepository.AddAsync(entity);
        }

        public Task<Donation> GetByDonatorIdAsync(Guid id)
        {
            return _context.Donations.Include(d => d.Donator).Where(d => d.DonatorId == id).OrderBy(d => d.DonationDate).LastAsync();
        }
    }
}
