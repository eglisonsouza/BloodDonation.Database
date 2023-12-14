using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Core.Models.Enums;

namespace BloodDonation.Database.UnitTest.Mock.ViewModel
{
    public class DonatorViewModelMock
    {
        public static DonatorViewModel GetDonatorViewModel()
        {
            return new DonatorViewModel
            {
                Id = Guid.NewGuid(),
                Name = "João Silva",
                Email = "joaosilva@gmail.com",
                BirthDate = DateTime.Now,
                Gender = GenderType.Masculine,
                Weight = 80,
                BloodType = BloodType.A,
                RhFactor = RhFactor.Positive,
                Addresses =
                [
                    new AddressViewModel
                    {
                        Id = Guid.NewGuid(),
                        Street = "Rua 1",
                        Number = "123",
                        Zone = "Bairro 1",
                        City = "Cidade 1",
                        State = "Estado 1",
                        ZipCode = "12345678"
                    }
                ],
                CreateAt = DateTime.Now
            };
        }
    }
}
