using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Core.Models.Enums;

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

    public class BloodStockViewModelMock
    {
        public static BloodStockViewModel GetBloodStockViewModel()
        {
            return new BloodStockViewModel
            {
                BloodType = BloodType.A,
                QuantityMl = 450,
                RhFactor = RhFactor.Positive,
                CreatedAt = DateTime.Now
            };
        }
    }
}
