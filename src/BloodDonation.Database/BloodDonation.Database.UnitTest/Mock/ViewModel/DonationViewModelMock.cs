using BloodDonation.Database.Application.Models.ViewModel;

namespace BloodDonation.Database.UnitTest.Mock.ViewModel
{
    public class DonationViewModelMock
    {
        public static DonationViewModel GetDonationViewModel()
        {
            return new DonationViewModel
            {
                DonatorId = Guid.NewGuid(),
                DonationDate = DateTime.Now,
                QuantityMl = 450,
                BloodStock = BloodStockViewModelMock.GetBloodStockViewModel()
            };
        }
    }
}
