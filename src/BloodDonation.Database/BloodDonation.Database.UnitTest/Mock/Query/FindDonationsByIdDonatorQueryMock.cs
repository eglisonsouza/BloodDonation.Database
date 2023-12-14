using BloodDonation.Database.Application.Query.DonationEvents.FindDonationsByIdDonator;

namespace BloodDonation.Database.UnitTest.Mock.Query
{
    public class FindDonationsByIdDonatorQueryMock
    {
        public static FindDonationsByIdDonatorQuery GetFindDonationsByIdDonatorQuery()
        {
            return new FindDonationsByIdDonatorQuery
            {
                IdDonator = Guid.NewGuid()
            };
        }
    }
}
