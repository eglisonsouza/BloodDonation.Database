using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Core.Common.Events;
using BloodDonation.Database.Core.Entities;
using BloodDonation.Database.Core.Exceptions;
using BloodDonation.Database.Core.Repositories;

namespace BloodDonation.Database.Application.Commands.DonationEvents.AddDonation
{
    public class AddDonationHandler(IDonationRepository donationRepository) : IRequestHandler<AddDonationCommand, DonationViewModel>
    {
        private readonly IDonationRepository _donationRepository = donationRepository;

        public async Task<DonationViewModel> Handle(AddDonationCommand request)
        {
            var donation = await _donationRepository.GetByDonatorIdAsync(request.DonatorId)!
                ?? throw new DonatorNotFoundException();

            ValidateEligibity(donation, request);

            var entity = await _donationRepository.AddAsync(request.ToEntity());

            return DonationViewModel.FromEntity(entity);
        }

        private static void ValidateEligibity(Donation donation, AddDonationCommand request)
        {
            if (!Donation.IsQuantityBloodRange(request.QuantityMl))
                throw new Exception("Quantity is not in range");

            if (donation.Donator!.AgeOutsideMinimunFromDonation())
                throw new Exception("Donator is not old enough to donate blood");

            if (donation.Donator.IsWeightOutsideMinimumFromDonation())
                throw new Exception("Donator is not heavy enough to donate blood");

            if (donation.LastDonation(request.DonationDate) < donation.GetDonationInterval())
                throw new Exception("Donator outside the minimum date range for donation");
        }
    }
}
