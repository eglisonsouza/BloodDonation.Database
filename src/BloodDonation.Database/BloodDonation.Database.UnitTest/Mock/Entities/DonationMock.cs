using BloodDonation.Database.Core.Models.Entities;

namespace BloodDonation.Database.UnitTest.Mock.Entities
{
    public class DonationMock
    {
        public static Donation GetDonationMock()
        {
            return new Donation
            {
                Id = Guid.NewGuid(),
                DonationDate = DateTime.Now,
                QuantityMl = 100,
                CreatedAt = DateTime.Now,
                Donator = DonatorMock.GetDonatorElegibity(),
            };
        }

        public static Donation GetDonationOtherDateMock()
        {
            return new Donation
            {
                Id = Guid.NewGuid(),
                DonationDate = new DateTime(2020, 1, 1),
                QuantityMl = 100,
                CreatedAt = DateTime.Now,
                Donator = DonatorMock.GetDonatorElegibity(),
            };
        }

        public static Donation GetDonationWithoutDonatorMock()
        {
            return new Donation
            {
                Id = Guid.NewGuid(),
                DonationDate = DateTime.Now,
                QuantityMl = 100,
                CreatedAt = DateTime.Now
            };
        }
    }
}
