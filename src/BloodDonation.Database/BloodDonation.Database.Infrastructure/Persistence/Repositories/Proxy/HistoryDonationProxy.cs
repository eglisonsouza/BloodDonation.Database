using BloodDonation.Database.Core.Models.Entities;
using BloodDonation.Database.Core.Repositories;
using BloodDonation.Database.Core.Repositories.Proxy;
using BloodDonation.Database.Core.Services;

namespace BloodDonation.Database.Infrastructure.Persistence.Repositories.Proxy
{
    public class HistoryDonationProxy(ICache cache, IDonationRepository donationRepository) : IHistoryDonationProxy
    {
        private readonly ICache _cache = cache;
        private readonly IDonationRepository _donationRepository = donationRepository;

        public async Task<List<Donation>> GetAsync(DateTime startDate, DateTime endDate)
        {
            var cache = _cache.Get($"historyDonation_{startDate}{endDate}", out List<Donation> donations);

            if (cache is null)
            {
                donations = (await _donationRepository.GetHistory(startDate, endDate))!;
                _cache.Set($"historyDonation_{startDate}{endDate}", donations);
            }
            return donations;
        }
    }
}
