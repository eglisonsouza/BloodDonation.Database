using BloodDonation.Database.Infrastructure.Services.HttpRequest;
using BloodDonation.Database.UnitTest.Mock;

namespace BloodDonation.Database.UnitTest.Infrastructure.Services.HttpRequest
{
    public class HttpHandlerTest
    {
        [Fact]
        public async Task GetAsync_ShouldReturnExpectedResult()
        {
            // Arrange
            var fakeContent = StringsMock.ZipCodeResponseViaCep;
            var httpHandler = new HttpHandler();

            // Act
            var result = await httpHandler.GetAsync("https://viacep.com.br/ws/85907439/json/");

            // Assert
            Assert.Equal(fakeContent.Trim().Replace("\r", ""), result.Trim());
        }
    }
}
