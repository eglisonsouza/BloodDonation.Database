using BloodDonation.Database.Application.Commands.DonatorEvents.Models;
using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Core.Common.Events;
using BloodDonation.Database.Core.Exceptions;
using BloodDonation.Database.Core.Repositories;

namespace BloodDonation.Database.Application.Commands.DonatorEvents.AddDonator
{
    public class AddDonatorHandler(IDonatorRepository donatorRepository, IAddressRepository addressRepository) : IRequestHandler<AddDonatorCommand, DonatorViewModel>
    {
        private readonly IDonatorRepository _donatorRepository = donatorRepository;
        private readonly IAddressRepository _addressRepository = addressRepository;

        public async Task<DonatorViewModel> Handle(AddDonatorCommand request)
        {
            if (await _donatorRepository.EmailIsExist(request.Email!))
            {
                throw new EmailIsExistException();
            }

            var donator = await _donatorRepository.AddAsync(request.ToEntity());

            request.Addresses!.ForEach(async address =>
            {
                await _addressRepository.AddAsync(address.ToEntity(donator.Id));
            });

            return new DonatorViewModelBuilder()
                .Start()
                .WithId(donator.Id)
                .WithName(donator.Name)
                .WithEmail(donator.Email)
                .WithBirthDate(donator.BirthDate)
                .WithWeight(donator.Weight)
                .WithBloodType(donator.BloodType)
                .WithRhFactor(donator.RhFactor)
                .WithAddresses(donator.Addresses!)
                .WithCreateAt(donator.CreatedAt)
                .WithUpdateAt(donator.UpdatedAt)
                .Build();
        }
    }
}
