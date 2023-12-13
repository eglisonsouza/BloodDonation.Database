using BloodDonation.Database.Core.Models.Entities;
using BloodDonation.Database.Core.Repositories.Base;

namespace BloodDonation.Database.Core.Repositories
{
    public interface IDonationRepository : IAddRepository<Donation>
    {
        Task<Donation?> GetLasDonationByIdDonator(Guid id);
    }
}
