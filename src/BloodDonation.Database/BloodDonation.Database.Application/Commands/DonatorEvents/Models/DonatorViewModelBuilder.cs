using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Core.Entities;
using BloodDonation.Database.Core.Enums;

namespace BloodDonation.Database.Application.Commands.DonatorEvents.Models
{
    public class DonatorViewModelBuilder
    {
        private DonatorViewModel? _donatorViewModel;

        public DonatorViewModelBuilder Start()
        {
            _donatorViewModel = new DonatorViewModel();
            return this;
        }

        public DonatorViewModelBuilder WithId(Guid id)
        {
            _donatorViewModel!.Id = id;
            return this;
        }

        public DonatorViewModelBuilder WithName(string name)
        {
            _donatorViewModel!.Name = name;
            return this;
        }

        public DonatorViewModelBuilder WithEmail(string email)
        {
            _donatorViewModel!.Email = email;
            return this;
        }

        public DonatorViewModelBuilder WithBirthDate(DateTime birthDate)
        {
            _donatorViewModel!.BirthDate = birthDate;
            return this;
        }

        public DonatorViewModelBuilder WithGender(string gender)
        {
            _donatorViewModel!.Gender = gender;
            return this;
        }

        public DonatorViewModelBuilder WithWeight(double weight)
        {
            _donatorViewModel!.Weight = weight;
            return this;
        }

        public DonatorViewModelBuilder WithBloodType(BloodType bloodType)
        {
            _donatorViewModel!.BloodType = bloodType;
            return this;
        }

        public DonatorViewModelBuilder WithRhFactor(RhFactor rhFactor)
        {
            _donatorViewModel!.RhFactor = rhFactor;
            return this;
        }

        public DonatorViewModelBuilder WithAddresses(List<Address> addresses)
        {
            _donatorViewModel!.Addresses = AddressViewModel.FromEntity(addresses);
            return this;
        }

        public DonatorViewModelBuilder WithCreateAt(DateTime createAt)
        {
            _donatorViewModel!.CreateAt = createAt;
            return this;
        }

        public DonatorViewModelBuilder WithUpdateAt(DateTime? updateAt)
        {
            _donatorViewModel!.UpdateAt = updateAt;
            return this;
        }

        public DonatorViewModel Build() => _donatorViewModel!;
    }
}
