using BloodDonation.Database.Api.Controllers.V1;
using BloodDonation.Database.Application.Commands.DonationEvents.AddDonation;
using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Application.Query.DonationEvents.FindDonationsByIdDonator;
using BloodDonation.Database.Application.Query.DonationEvents.Models;
using BloodDonation.Database.Core.Common.Events;
using BloodDonation.Database.UnitTest.Mock;
using BloodDonation.Database.UnitTest.Mock.Query;
using BloodDonation.Database.UnitTest.Mock.ViewModel;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Text.Json;

namespace BloodDonation.Database.UnitTest.Api.Controllers.V1
{
    public class DonationControllerTest
    {
        [Fact]
        public async Task CreateDonationAsync_ValidDonation_ReturnsOkObjectResult()
        {
            var donationViewModel = DonationViewModelMock.GetDonationViewModel();
            var command = AddDonationCommandMock.GetAddDonationQuantityMLOutsideRangeCommand();

            // Arrange
            var handler = Substitute.For<IRequestHandler<AddDonationCommand, DonationViewModel>>();
            handler.Handle(command).Returns(donationViewModel);

            // Act
            var controller = new DonationController();
            var result = await controller.CreateDonationAsync(handler, command) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value);
            Assert.Equal(JsonSerializer.Serialize(result.Value), JsonSerializer.Serialize(donationViewModel));
        }

        [Fact]
        public async Task GetDonationsByIdDonatorAsync_ValidDonator_ReturnsOkObjectResult()
        {
            var donatorWithDonationsViewModel = DonatorWithDonationsViewModelMock.GetDonatorWithDonationsViewModel();
            var query = FindDonationsByIdDonatorQueryMock.GetFindDonationsByIdDonatorQuery();

            // Arrange
            var handler = Substitute.For<IRequestHandler<FindDonationsByIdDonatorQuery, DonatorWithDonationsViewModel>>();
            handler.Handle(query).Returns(donatorWithDonationsViewModel);

            // Act
            var controller = new DonationController();
            var result = await controller.GetDonationsByIdDonatorAsync(handler, query) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value);
            Assert.Equal(JsonSerializer.Serialize(result.Value), JsonSerializer.Serialize(donatorWithDonationsViewModel));
        }
    }
}
