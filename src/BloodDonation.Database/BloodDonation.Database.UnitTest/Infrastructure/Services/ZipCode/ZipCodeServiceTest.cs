using BloodDonation.Database.Core.Models.Config;
using BloodDonation.Database.Core.Services;
using BloodDonation.Database.Infrastructure.Services.ZipCode;
using BloodDonation.Database.UnitTest.Mock;
using NSubstitute;

namespace BloodDonation.Database.UnitTest.Infrastructure.Services.ZipCode
{
    public class ZipCodeServiceTest
    {
        [Fact]
        public async Task GetByZipCodeAsync_CallsHttpGetHandlerWithCorrectUrl()
        {
            // Arrange
            var zipCode = StringsMock.ZipCode;

            var httpHandlerMock = Substitute.For<IHttpGetHandler>();
            var appSettings = new AppSettings
            {
                ExternalServices = null
            };

            var zipCodeService = new ZipCodeService(httpHandlerMock, appSettings);


            await Assert.ThrowsAsync<ArgumentNullException>(async () => await zipCodeService.GetByZipCodeAsync(zipCode));
        }

        [Fact]
        public async Task GetByZipCodeAsync_ReturnsValidZipCodeDto()
        {
            // Arrange
            var zipCode = StringsMock.ZipCode;
            var expectedUrl = StringsMock.ZipCodeServiceUrl;

            var httpHandlerMock = Substitute.For<IHttpGetHandler>();
            var appSettings = new AppSettings
            {
                ExternalServices = new ExternalServices
                {
                    ViaCep = StringsMock.ZipCodeServiceUrl
                }
            };

            var zipCodeService = new ZipCodeService(httpHandlerMock, appSettings);

            var responseFromHttpHandler = StringsMock.ZipCodeResponseViaCep;
            httpHandlerMock.GetAsync(string.Format(expectedUrl, zipCode)).Returns(Task.FromResult(responseFromHttpHandler));

            // Act
            var result = await zipCodeService.GetByZipCodeAsync(zipCode);

            // Assert
            Assert.NotNull(result);
        }
    }
}
