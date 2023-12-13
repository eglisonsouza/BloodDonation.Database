using BloodDonation.Database.Application.Query.DonationEvents.Models;
using BloodDonation.Database.Core.Common.Events;
using BloodDonation.Database.Core.Repositories;

namespace BloodDonation.Database.Application.Query.DonationEvents.FindDonationsByIdDonator
{
    public class FindDonationsByIdDonatorHandler(IDonatorRepository donatorRepository) : IRequestHandler<FindDonationsByIdDonatorQuery, DonatorWithDonationsViewModel>
    {
        private readonly IDonatorRepository _donatorRepository = donatorRepository;

        public async Task<DonatorWithDonationsViewModel> Handle(FindDonationsByIdDonatorQuery request)
        {
            var donator = await _donatorRepository.GetAllDonatiosByIdAsync(request.IdDonator);

            return DonationsByDonatorViewModel.FromEntity(donator);
        }
    }
}
