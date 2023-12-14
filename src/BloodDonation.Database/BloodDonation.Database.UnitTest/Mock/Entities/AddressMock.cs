using BloodDonation.Database.Core.Models.Entities;

namespace BloodDonation.Database.UnitTest.Mock.Entities
{
    public class AddressMock
    {
        public static Address GetAddress()
        {
            return new Address
            {
                Id = Guid.NewGuid(),
                City = "Bucharest",
                Street = "Bulevardul Unirii",
                Number = "1",
                ZipCode = "123456",
                CreatedAt = DateTime.Now,
            };
        }
    }
}
