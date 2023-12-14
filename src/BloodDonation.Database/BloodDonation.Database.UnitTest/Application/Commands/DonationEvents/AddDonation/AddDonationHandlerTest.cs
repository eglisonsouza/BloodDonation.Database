using BloodDonation.Database.Application.Commands.BloodStockEvents.UpdateBloodStock;
using BloodDonation.Database.Application.Commands.DonationEvents.AddDonation;
using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Core.Common.Events;
using BloodDonation.Database.Core.Exceptions;
using BloodDonation.Database.Core.Models.Entities;
using BloodDonation.Database.Core.Repositories;
using BloodDonation.Database.UnitTest.Mock;
using BloodDonation.Database.UnitTest.Mock.Entities;
using BloodDonation.Database.UnitTest.Mock.ViewModel;
using NSubstitute;

namespace BloodDonation.Database.UnitTest.Application.Commands.DonationEvents.AddDonation
{
    public class AddDonationHandlerTest
    {
        [Fact]
        public async Task Handle_InvalidDonation_ReturnsNotFoundException()
        {
            // Arrange
            var donatorRepositoryMock = Substitute.For<IDonatorRepository>();
            var donationRepositoryMock = Substitute.For<IDonationRepository>();
            var updateBloodStockHandlerMock = Substitute.For<IRequestHandler<UpdateBloodStockCommand, BloodStockViewModel>>();
            var addDonationCommand = AddDonationCommandMock.GetAddDonationQuantityMLOutsideRangeCommand();

            // Act
            var handler = new AddDonationHandler(donatorRepositoryMock, donationRepositoryMock, updateBloodStockHandlerMock);

            // Assert
            await Assert.ThrowsAsync<DonatorNotFoundException>(() => handler.Handle(addDonationCommand));
        }

        [Fact]
        public async Task Handle_InvalidDonation_ReturnsAgeOutsideMinimun()
        {
            // Arrange
            var donatorRepositoryMock = Substitute.For<IDonatorRepository>();
            var donationRepositoryMock = Substitute.For<IDonationRepository>();
            var updateBloodStockHandlerMock = Substitute.For<IRequestHandler<UpdateBloodStockCommand, BloodStockViewModel>>();
            var addDonationCommand = AddDonationCommandMock.GetAddDonationQuantityMLOutsideRangeCommand();

            donatorRepositoryMock.GetByIdAsync(addDonationCommand.DonatorId).Returns(DonatorMock.GetDonatorNotOldEnough());

            // Act
            var handler = new AddDonationHandler(donatorRepositoryMock, donationRepositoryMock, updateBloodStockHandlerMock);

            // Assert
            await Assert.ThrowsAsync<Exception>(() => handler.Handle(addDonationCommand));
        }

        [Fact]
        public async Task Handle_InvalidDonation_ReturnsWeightOutsideMinimum()
        {
            // Arrange
            var donatorRepositoryMock = Substitute.For<IDonatorRepository>();
            var donationRepositoryMock = Substitute.For<IDonationRepository>();
            var updateBloodStockHandlerMock = Substitute.For<IRequestHandler<UpdateBloodStockCommand, BloodStockViewModel>>();
            var addDonationCommand = AddDonationCommandMock.GetAddDonationQuantityMLOutsideRangeCommand();

            donatorRepositoryMock.GetByIdAsync(addDonationCommand.DonatorId).Returns(DonatorMock.GetDonatorNotHeavyEnough());

            // Act
            var handler = new AddDonationHandler(donatorRepositoryMock, donationRepositoryMock, updateBloodStockHandlerMock);

            // Assert
            await Assert.ThrowsAsync<Exception>(() => handler.Handle(addDonationCommand));
        }

        [Fact]
        public async Task Handle_InvalidDonation_ReturnsDataRangeOutsideMinimum()
        {
            // Arrange
            var donatorRepositoryMock = Substitute.For<IDonatorRepository>();
            var donationRepositoryMock = Substitute.For<IDonationRepository>();
            var updateBloodStockHandlerMock = Substitute.For<IRequestHandler<UpdateBloodStockCommand, BloodStockViewModel>>();
            var addDonationCommand = AddDonationCommandMock.GetAddDonationQuantityMLOutsideRangeCommand();

            donatorRepositoryMock.GetByIdAsync(addDonationCommand.DonatorId).Returns(DonatorMock.GetDonatorElegibity());
            donationRepositoryMock.GetLasDonationByIdDonator(addDonationCommand.DonatorId).Returns(DonationMock.GetDonationMock());

            // Act
            var handler = new AddDonationHandler(donatorRepositoryMock, donationRepositoryMock, updateBloodStockHandlerMock);

            // Assert
            await Assert.ThrowsAsync<Exception>(() => handler.Handle(addDonationCommand));
        }

        [Fact]
        public async Task Handle_InvalidDonation_ReturnsDataRangeInsideMinimum()
        {
            // Arrange
            var donatorRepositoryMock = Substitute.For<IDonatorRepository>();
            var donationRepositoryMock = Substitute.For<IDonationRepository>();
            var updateBloodStockHandlerMock = Substitute.For<IRequestHandler<UpdateBloodStockCommand, BloodStockViewModel>>();
            var addDonationCommand = AddDonationCommandMock.GetAddDonationQuantityMLOutsideRangeCommand();

            donatorRepositoryMock.GetByIdAsync(addDonationCommand.DonatorId).Returns(DonatorMock.GetDonatorElegibity());
            donationRepositoryMock.GetLasDonationByIdDonator(addDonationCommand.DonatorId).Returns(DonationMock.GetDonationOtherDateMock());

            // Act
            var handler = new AddDonationHandler(donatorRepositoryMock, donationRepositoryMock, updateBloodStockHandlerMock);

            // Assert
            await Assert.ThrowsAsync<Exception>(() => handler.Handle(addDonationCommand));
        }

        [Fact]
        public async Task Handle_InvalidDonation_ReturnsWithFirstDonation()
        {
            // Arrange
            var donatorRepositoryMock = Substitute.For<IDonatorRepository>();
            var donationRepositoryMock = Substitute.For<IDonationRepository>();
            var updateBloodStockHandlerMock = Substitute.For<IRequestHandler<UpdateBloodStockCommand, BloodStockViewModel>>();
            var addDonationCommand = AddDonationCommandMock.GetAddDonationQuantityMLInsideRangeCommand();

            donatorRepositoryMock.GetByIdAsync(addDonationCommand.DonatorId).Returns(DonatorMock.GetDonatorElegibity());
            donationRepositoryMock.AddAsync(Arg.Any<Donation>()).Returns(DonationMock.GetDonationMock());
            donationRepositoryMock.GetLasDonationByIdDonator(addDonationCommand.DonatorId).Returns(Task.FromResult((Donation?)null));

            updateBloodStockHandlerMock.Handle(Arg.Any<UpdateBloodStockCommand>()).Returns(BloodStockViewModelMock.GetBloodStockViewModel());
            // Act
            var handler = new AddDonationHandler(donatorRepositoryMock, donationRepositoryMock, updateBloodStockHandlerMock);
            var result = await handler.Handle(addDonationCommand);
            // Assert
            Assert.IsType<DonationViewModel>(result);
        }
    }
}
