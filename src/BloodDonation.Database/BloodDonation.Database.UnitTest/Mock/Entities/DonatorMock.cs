using BloodDonation.Database.Core.Models.Entities;
using BloodDonation.Database.Core.Models.Enums;

namespace BloodDonation.Database.UnitTest.Mock.Entities
{
    public class DonatorMock
    {
        public static Donator GetDonatorNotOldEnough()
        {
            return new Donator
            (
                name: "John Doe",
                bloodType: BloodType.A,
                rhFactor: RhFactor.Positive,
                email: "john.doe@gmail.com",
                gender: GenderType.Masculine,
                weight: 80,
                birthDate: new DateTime(2020, 1, 1)
            );
        }

        public static Donator GetDonatorNotHeavyEnough()
        {
            return new Donator
            (
                name: "John Doe",
                bloodType: BloodType.A,
                rhFactor: RhFactor.Positive,
                email: "john.doe@gmail.com",
                gender: GenderType.Masculine,
                weight: 49,
                birthDate: new DateTime(2000, 1, 1)
            );
        }

        public static Donator GetDonatorElegibity()
        {
            var donator = new Donator
            (
                name: "John Doe",
                bloodType: BloodType.A,
                rhFactor: RhFactor.Positive,
                email: "john.doe@gmail.com",
                gender: GenderType.Masculine,
                weight: 60,
                birthDate: new DateTime(2000, 1, 1)
            )
            {
                Addresses = [AddressMock.GetAddress()]
            };
            return donator;
        }

        public static Donator GetDonatorWithDonations()
        {
            var donator = new Donator
            (
                name: "John Doe",
                bloodType: BloodType.A,
                rhFactor: RhFactor.Positive,
                email: "john.doe@gmail.com",
                gender: GenderType.Masculine,
                weight: 60,
                birthDate: new DateTime(2000, 1, 1)
            );
            donator.Addresses = [AddressMock.GetAddress()];
            donator.Donations = [DonationMock.GetDonationWithoutDonatorMock()];

            return donator;
        }
    }
}
