using BloodDonation.Database.Api.Controllers.V1;
using BloodDonation.Database.Application.Commands.DonatorEvents.AddDonator;
using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Core.Common.Events;
using BloodDonation.Database.UnitTest.Mock.Command;
using BloodDonation.Database.UnitTest.Mock.ViewModel;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Text.Json;

namespace BloodDonation.Database.UnitTest.Api.Controllers.V1
{
    public class DonatorControllerTest
    {
        [Fact]
        public async Task AddDonation_WithValidData_ReturnsOk()
        {
            // Arrange
            var donatorViewModel = DonatorViewModelMock.GetDonatorViewModel();
            var command = AddDonatorCommandMock.GetAddDonationCommand();
            var handle = Substitute.For<IRequestHandler<AddDonatorCommand, DonatorViewModel>>();
            handle.Handle(command).Returns(donatorViewModel);
            // Act
            var controller = new DonatorController();
            var result = await controller.CreateDonatorAsync(handle, command) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value);
            Assert.Equal(JsonSerializer.Serialize(result.Value), JsonSerializer.Serialize(donatorViewModel));

        }
    }
}
