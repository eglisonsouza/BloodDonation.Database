using BloodDonation.Database.Core.Models.Entities;
using BloodDonation.Database.Core.Repositories;
using BloodDonation.Database.Core.Repositories.Base;
using System.Diagnostics.CodeAnalysis;

namespace BloodDonation.Database.Infrastructure.Persistence.Repositories
{
    [ExcludeFromCodeCoverage]
    public class AddressRepository(IAddRepository<Address> addRepository) : IAddressRepository
    {
        private readonly IAddRepository<Address> _addRepository = addRepository;

        public Task<Address> AddAsync(Address entity)
        {
            return _addRepository.AddAsync(entity);
        }
    }
}
