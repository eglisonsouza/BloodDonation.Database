using BloodDonation.Database.Core.Models.Entities;
using BloodDonation.Database.Core.Repositories;
using BloodDonation.Database.Core.Repositories.Base;
using BloodDonation.Database.Infrastructure.Persistence.Configuration.SqlServer;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BloodDonation.Database.Infrastructure.Persistence.Repositories
{
    [ExcludeFromCodeCoverage]
    public class DonationRepository(IAddRepository<Donation> addRepository, SqlServerDbContext context) : IDonationRepository
    {
        private readonly IAddRepository<Donation> _addRepository = addRepository;
        private readonly SqlServerDbContext _context = context;

        public Task<Donation> AddAsync(Donation entity)
        {
            return _addRepository.AddAsync(entity);
        }

        public Task<Donation?> GetLasDonationByIdDonator(Guid idDonator)
        {
            return _context.Donations.Where(d => d.DonatorId.Equals(idDonator)).OrderBy(d => d.DonationDate).LastAsync()!;
        }

        public Task<List<Donation?>> GetHistory(DateTime startDate, DateTime endDate)
        {
            return _context.Donations
                .Where(d => d.DonationDate>=startDate && d.DonationDate <= endDate)
                .Include(d => d.Donator)
                .OrderBy(d => d.DonationDate)
                .ToListAsync()!;
        }
    }
}
