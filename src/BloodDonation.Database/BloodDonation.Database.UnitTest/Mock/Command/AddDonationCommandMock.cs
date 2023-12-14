using BloodDonation.Database.Application.Commands.DonationEvents.AddDonation;

namespace BloodDonation.Database.UnitTest.Mock
{
    public class AddDonationCommandMock
    {
        public static AddDonationCommand GetAddDonationQuantityMLOutsideRangeCommand()
        {
            return new AddDonationCommand
            {
                DonatorId = Guid.NewGuid(),
                DonationDate = DateTime.Now,
                QuantityMl = 440
            };
        }

        public static AddDonationCommand GetAddDonationQuantityMLInsideRangeCommand()
        {
            return new AddDonationCommand
            {
                DonatorId = Guid.NewGuid(),
                DonationDate = DateTime.Now,
                QuantityMl = 460
            };
        }
    }
}
