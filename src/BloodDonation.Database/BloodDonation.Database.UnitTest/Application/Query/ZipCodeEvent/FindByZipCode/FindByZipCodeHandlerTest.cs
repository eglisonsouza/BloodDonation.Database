using BloodDonation.Database.Application.Query.ZipCodeEvent.FindByZipCode;
using BloodDonation.Database.Core.Services;
using BloodDonation.Database.UnitTest.Mock;
using BloodDonation.Database.UnitTest.Mock.Query;
using NSubstitute;
using System.Text.Json;

namespace BloodDonation.Database.UnitTest.Application.Query.ZipCodeEvent.FindByZipCode
{
    public class FindByZipCodeHandlerTest
    {
        [Fact]
        public async Task Handle_ValidZipCode_ReturnsZipCodeViewModel()
        {
            var zipCodeServiceProxy = Substitute.For<IZipCodeServiceProxy>();
            zipCodeServiceProxy.GetByZipCodeAsync(FindByZipCodeQueryMock.GetFindByZipCodeQuery().ZipCode!)
                .Returns(Task.FromResult(ZipCodeDtoMock.GetZipCodeDto()));

            var handler = new FindByZipCodeHandler(zipCodeServiceProxy);

            // Act
            var result = await handler.Handle(FindByZipCodeQueryMock.GetFindByZipCodeQuery());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ZipCodeDtoMock.GetZipCodeDto().State, result.State);
            Assert.Equal(JsonSerializer.Serialize(ZipCodeDtoMock.GetZipCodeDto()), JsonSerializer.Serialize(result));
        }

    }
}
