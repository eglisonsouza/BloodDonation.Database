using BloodDonation.Database.Application.Query.ZipCodeEvent.Models;

namespace BloodDonation.Database.UnitTest.Mock
{
    public class ZipCodeViewModelMock
    {
        public static ZipCodeViewModel GetZipCodeViewModel()
        {
            return new ZipCodeViewModel
            {
                ZipCode = "85907439",
                City = "Toledo",
                State = "PR",
                Street = "RuaGasparinaTomazoni",
                Zone = "Pinheirinho"
            };
        }
    }
}
