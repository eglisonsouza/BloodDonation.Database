using BloodDonation.Database.Application.Commands.DonationEvents.AddDonation;

namespace BloodDonation.Database.UnitTest.Mock
{
    public class AddDonationCommandMock
    {
        public static AddDonationCommand GetAddDonationCommand()
        {
            return new AddDonationCommand
            {
                DonatorId = Guid.NewGuid(),
                DonationDate = DateTime.Now,
                QuantityMl = 450
            };
        }
    }
}
