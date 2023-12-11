using BloodDonation.Database.Core.Models.DTOs;

namespace BloodDonation.Database.UnitTest.Mock
{
    public class ZipCodeDtoMock
    {
        public static ZipCodeDto GetZipCodeDto()
        {
            return new ZipCodeDto
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
