using BloodDonation.Database.Application.Commands.DonatorEvents.AddDonator;
using BloodDonation.Database.Application.Models.InputModel;
using BloodDonation.Database.Core.Models.Enums;

namespace BloodDonation.Database.UnitTest.Mock.Command
{
    public class AddDonatorCommandMock
    {
        public static AddDonatorCommand GetAddDonationCommand()
        {
            return new AddDonatorCommand
            {
                Name = "Test",
                Email = "test@gmail.com",
                BirthDate = DateTime.MinValue,
                BloodType = BloodType.AB,
                Gender = GenderType.Feminine,
                RhFactor = RhFactor.Positive,
                Weight = 50,
                Addresses =
                [
                    new AddressInputModel
                    {
                        City = "Test",
                        Street = "Test",
                        Number = "273",
                        ZipCode = "Test",
                        State = "Test",
                        Zone = "Test"
                    }
                ]
            };
        }
    }
}
