using BloodDonation.Database.Application.Commands.BloodStockEvents.UpdateBloodStock;
using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Core.Common.Events;
using BloodDonation.Database.Core.Exceptions;
using BloodDonation.Database.Core.Models.Entities;
using BloodDonation.Database.Core.Repositories;

namespace BloodDonation.Database.Application.Commands.DonationEvents.AddDonation
{
    public class AddDonationHandler(
        IDonatorRepository donatorRepository,
        IDonationRepository donationRepository,
        IRequestHandler<UpdateBloodStockCommand, BloodStockViewModel> updateBloodStockHandler) : IRequestHandler<AddDonationCommand, DonationViewModel>
    {
        private readonly IDonatorRepository _donatorRepository = donatorRepository;
        private readonly IDonationRepository _donationRepository = donationRepository;
        private readonly IRequestHandler<UpdateBloodStockCommand, BloodStockViewModel> _updateBloodStockHandler = updateBloodStockHandler;

        public async Task<DonationViewModel> Handle(AddDonationCommand request)
        {
            var donator = await _donatorRepository.GetByIdAsync(request.DonatorId)!
                ?? throw new DonatorNotFoundException();

            ValidateEligibityDonator(donator);

            var lastDonation = await GetLastDonation(request.DonatorId);

            lastDonation?.ValidateInterval(request.DonationDate);

            var entity = await _donationRepository.AddAsync(request.ToEntity());

            var bloodStock = await UpdateBloodStockAsync(entity);

            return DonationViewModel.FromEntity(entity, bloodStock);
        }

        private async Task<Donation?> GetLastDonation(Guid idDonator)
        {
            try
            {
                return await _donationRepository.GetLasDonationByIdDonator(idDonator);
            }
            catch
            {
                return null;
            }
        }

        private static void ValidateEligibityDonator(Donator donator)
        {
            if (donator.AgeOutsideMinimunFromDonation())
                throw new Exception("Donator is not old enough to donate blood");

            if (donator.IsWeightOutsideMinimumFromDonation())
                throw new Exception("Donator is not heavy enough to donate blood");
        }

        private async Task<BloodStockViewModel> UpdateBloodStockAsync(Donation entity)
        {
            return await _updateBloodStockHandler.Handle(new UpdateBloodStockCommand(
                entity.Donator!.BloodType,
                entity.Donator.RhFactor,
                entity.QuantityMl
            ));
        }
    }
}
