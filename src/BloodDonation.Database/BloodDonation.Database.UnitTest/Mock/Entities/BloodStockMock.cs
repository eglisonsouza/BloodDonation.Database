using BloodDonation.Database.Core.Models.Entities;
using BloodDonation.Database.Core.Models.Enums;

namespace BloodDonation.Database.UnitTest.Mock.Entities
{
    public class BloodStockMock
    {
        public static BloodStock GetBloodStockMock()
        {
            return new BloodStock(BloodType.A, RhFactor.Positive, 1000);
        }
    }
}
