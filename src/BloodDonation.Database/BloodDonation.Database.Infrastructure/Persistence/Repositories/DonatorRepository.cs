using BloodDonation.Database.Core.Models.Entities;
using BloodDonation.Database.Core.Repositories;
using BloodDonation.Database.Core.Repositories.Base;
using BloodDonation.Database.Infrastructure.Persistence.Configuration.SqlServer;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BloodDonation.Database.Infrastructure.Persistence.Repositories
{
    [ExcludeFromCodeCoverage]
    public class DonatorRepository(IAddRepository<Donator> addRepository, IGetByIdRepository<Donator> getByIdRepository, SqlServerDbContext context) : IDonatorRepository
    {
        private readonly IAddRepository<Donator> _addRepository = addRepository;
        private readonly IGetByIdRepository<Donator> _getByIdRepository = getByIdRepository;
        private readonly SqlServerDbContext _context = context;

        public Task<Donator> AddAsync(Donator entity)
        {
            return _addRepository.AddAsync(entity);
        }

        public Task<bool> EmailIsExist(string email)
        {
            return _context.Donator.AnyAsync(d => d.Email == email);
        }

        public Task<Donator?>? GetByIdAsync(Guid id)
        {
            return _getByIdRepository.GetByIdAsync(id);
        }

        public Task<Donator?> GetAllDonatiosByIdAsync(Guid id)
        {
            return _context.Donator.Include(d => d.Donations).FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
