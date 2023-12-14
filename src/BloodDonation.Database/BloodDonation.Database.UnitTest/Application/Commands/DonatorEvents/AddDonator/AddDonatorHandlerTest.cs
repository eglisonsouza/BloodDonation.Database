using BloodDonation.Database.Application.Commands.DonatorEvents.AddDonator;
using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Core.Exceptions;
using BloodDonation.Database.Core.Models.Entities;
using BloodDonation.Database.Core.Repositories;
using BloodDonation.Database.UnitTest.Mock.Command;
using BloodDonation.Database.UnitTest.Mock.Entities;
using NSubstitute;

namespace BloodDonation.Database.UnitTest.Application.Commands.DonatorEvents.AddDonator
{
    public class AddDonatorHandlerTest
    {
        [Fact]
        public async Task Handle_WhenEmailDoesNotExist_AddsDonatorAndAddresses()
        {
            // Arrange
            var donatorRepository = Substitute.For<IDonatorRepository>();
            var addressRepository = Substitute.For<IAddressRepository>();

            var handler = new AddDonatorHandler(donatorRepository, addressRepository);

            var command = AddDonatorCommandMock.GetAddDonationCommand();

            donatorRepository.EmailIsExist(Arg.Any<string>()).Returns(Task.FromResult(false));
            donatorRepository.AddAsync(Arg.Any<Donator>()).Returns(Task.FromResult(DonatorMock.GetDonatorElegibity()));
            addressRepository.AddAsync(Arg.Any<Address>()).Returns(Task.FromResult(AddressMock.GetAddress()));

            // Act
            var result = await handler.Handle(command);
            // Assert
            Assert.IsType<DonatorViewModel>(result);
        }

        [Fact]
        public async Task Handle_WhenEmailExists_ThrowsEmailIsExistException()
        {
            // Arrange
            var donatorRepository = Substitute.For<IDonatorRepository>();
            var addressRepository = Substitute.For<IAddressRepository>();

            var handler = new AddDonatorHandler(donatorRepository, addressRepository);

            var command = AddDonatorCommandMock.GetAddDonationCommand();

            donatorRepository.EmailIsExist(Arg.Any<string>()).Returns(Task.FromResult(true));

            // Act and Assert
            await Assert.ThrowsAsync<EmailIsExistException>(() => handler.Handle(command));

            // Ensure that no repository methods were called
            await addressRepository.DidNotReceiveWithAnyArgs().AddAsync(Arg.Any<Address>());
            await donatorRepository.DidNotReceiveWithAnyArgs().AddAsync(Arg.Any<Donator>());
        }

    }
}
