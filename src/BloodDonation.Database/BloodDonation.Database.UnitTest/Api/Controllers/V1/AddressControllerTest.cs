using BloodDonation.Database.Api.Controllers.V1;
using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Application.Query.ZipCodeEvent.FindByZipCode;
using BloodDonation.Database.Core.Common.Events;
using BloodDonation.Database.UnitTest.Mock;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Text.Json;

namespace BloodDonation.Database.UnitTest.Api.Controllers.V1
{
    public class AddressControllerTest
    {
        [Fact]
        public async Task GetAsync_ValidZipCode_ReturnsOkObjectResult()
        {
            var zipCodeViewModel = ZipCodeViewModelMock.GetZipCodeViewModel();
            var query = FindByZipCodeQueryMock.GetFindByZipCodeQuery();

            // Arrange
            var handler = Substitute.For<IRequestHandler<FindByZipCodeQuery, ZipCodeViewModel>>();
            handler.Handle(query).Returns(zipCodeViewModel);

            // Act
            var controller = new AddressController();
            var result = await controller.GetAsync(handler, query) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value);
            Assert.Equal(JsonSerializer.Serialize(result.Value), JsonSerializer.Serialize(zipCodeViewModel));
            JsonSerializer.Serialize(result.Value);
        }
    }
}
