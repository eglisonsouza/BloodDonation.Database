using BloodDonation.Database.Core.Models.DTOs;
using BloodDonation.Database.Core.Services;
using BloodDonation.Database.Infrastructure.Services.ZipCode;
using BloodDonation.Database.UnitTest.Mock;
using NSubstitute;

namespace BloodDonation.Database.UnitTest.Infrastructure.Services.ZipCode
{
    public class ZipCodeServiceProxyTest
    {
        [Fact]
        public async Task GetByZipCodeAsync_CacheMiss_ReturnsServiceValueAndCachesIt()
        {
            var zipCodeDto = ZipCodeDtoMock.GetZipCodeDto();

            // Arrange
            var zipCode = StringsMock.ZipCode;

            var zipCodeServiceMock = Substitute.For<IZipCodeService>();
            zipCodeServiceMock.GetByZipCodeAsync(zipCode).Returns(zipCodeDto);

            var cacheMock = Substitute.For<ICache>();
            cacheMock.Get($"zipCode_${zipCode}", out ZipCodeDto _).Returns(null as ZipCodeDto);

            var proxy = new ZipCodeServiceProxy(zipCodeServiceMock, cacheMock);

            // Act
            var result = await proxy.GetByZipCodeAsync(zipCode);

            // Assert
            Assert.NotNull(result);
            Assert.Same(zipCodeDto, result); // Verifica se o objeto retornado é o mesmo do serviço
            await zipCodeServiceMock.Received(1).GetByZipCodeAsync(zipCode); // Verifica se o método foi chamado
            cacheMock.Received(1).Set($"zipCode_${zipCode}", zipCodeDto); // Verifica se o valor foi armazenado em cache
        }
    }
}
