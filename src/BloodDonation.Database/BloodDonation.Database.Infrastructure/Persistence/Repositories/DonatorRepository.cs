using BloodDonation.Database.Core.Entities;
using BloodDonation.Database.Core.Repositories;
using BloodDonation.Database.Core.Repositories.Base;
using BloodDonation.Database.Infrastructure.Persistence.Configuration.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Database.Infrastructure.Persistence.Repositories
{
    public class DonatorRepository(IAddRepository<Donator> addRepository, IAddRepository<Address> addAddressRepository, SqlServerDbContext context) : IDonatorRepository
    {
        private readonly IAddRepository<Donator> _addRepository = addRepository;
        private readonly IAddRepository<Address> _addAddressRepository = addAddressRepository;
        private readonly SqlServerDbContext _context = context;

        public Task<Address> AddAddressAsync(Address address)
        {
            return _addAddressRepository.AddAsync(address);
        }

        public Task<Donator> AddAsync(Donator entity)
        {
            return _addRepository.AddAsync(entity);
        }

        public Task<bool> EmailIsExist(string email)
        {
            return _context.Donator.AnyAsync(d => d.Email == email);
        }
    }
}
