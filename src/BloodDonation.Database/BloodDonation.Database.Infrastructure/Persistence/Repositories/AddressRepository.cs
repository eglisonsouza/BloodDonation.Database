using BloodDonation.Database.Core.Entities;
using BloodDonation.Database.Core.Repositories;
using BloodDonation.Database.Core.Repositories.Base;

namespace BloodDonation.Database.Infrastructure.Persistence.Repositories
{
    public class AddressRepository(IAddRepository<Address> addRepository) : IAddressRepository
    {
        private readonly IAddRepository<Address> _addRepository = addRepository;

        public Task<Address> AddAsync(Address entity)
        {
            return _addRepository.AddAsync(entity);
        }
    }
}
