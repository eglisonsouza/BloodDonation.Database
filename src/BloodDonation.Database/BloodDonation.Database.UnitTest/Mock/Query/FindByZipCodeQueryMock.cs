using BloodDonation.Database.Application.Query.ZipCodeEvent.FindByZipCode;

namespace BloodDonation.Database.UnitTest.Mock.Query
{
    public class FindByZipCodeQueryMock
    {
        public static FindByZipCodeQuery GetFindByZipCodeQuery()
        {
            return new FindByZipCodeQuery
            {
                ZipCode = "85907439"
            };
        }
    }
}
