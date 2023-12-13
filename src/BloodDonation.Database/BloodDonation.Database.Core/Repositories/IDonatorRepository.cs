using BloodDonation.Database.Core.Models.Entities;
using BloodDonation.Database.Core.Repositories.Base;

namespace BloodDonation.Database.Core.Repositories
{
    public interface IDonatorRepository : IAddRepository<Donator>, IGetByIdRepository<Donator>
    {
        Task<bool> EmailIsExist(string email);
        Task<Donator?> GetAllDonatiosByIdAsync(Guid id);
    }
}
