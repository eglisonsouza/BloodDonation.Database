using BloodDonation.Database.Core.Entities;
using BloodDonation.Database.Core.Repositories.Base;

namespace BloodDonation.Database.Core.Repositories
{
    public interface IDonatorRepository : IAddRepository<Donator>
    {
        Task<Address> AddAddressAsync(Address address);
        public Task<bool> EmailIsExist(string email);
    }
}
