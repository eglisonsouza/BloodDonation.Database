using BloodDonation.Database.Application.Models.ViewModel;

namespace BloodDonation.Database.UnitTest.Mock.ViewModel
{
    public class DonatorWithDonationsViewModelMock
    {
        public static DonatorWithDonationsViewModel GetDonatorWithDonationsViewModel()
        {
            return new DonatorWithDonationsViewModel
            {
                NameDonator = "John Doe",
                Donations =
                [
                    new DonationsByDonatorViewModel
                    {
                        DonationDate = DateTime.Now,
                        QuantityMl = 450
                    }
                ],
                Email = "john.doe@gmail.com"
            };
        }
    }
}
