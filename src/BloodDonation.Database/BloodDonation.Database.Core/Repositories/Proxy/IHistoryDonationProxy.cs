using BloodDonation.Database.Core.Models.Entities;

namespace BloodDonation.Database.Core.Repositories.Proxy
{
    public interface IHistoryDonationProxy
    {
        Task<List<Donation>> GetAsync(DateTime startDate, DateTime endDate);
    }
}
