using BloodDonation.Database.Application.Query.DonationEvents.FindDonationsByIdDonator;
using BloodDonation.Database.Core.Models.Entities;
using BloodDonation.Database.Core.Repositories;
using BloodDonation.Database.UnitTest.Mock.Entities;
using NSubstitute;

namespace BloodDonation.Database.UnitTest.Application.Query.DonationEvents.FindDonationsByIdDonator
{
    public class FindDonationsByIdDonatorHandlerTest
    {
        [Fact]
        public async Task Handle_WhenDonatorExists_ReturnsDonatorWithDonationsViewModel()
        {
            // Arrange
            var donatorRepository = Substitute.For<IDonatorRepository>();
            var handler = new FindDonationsByIdDonatorHandler(donatorRepository);

            var query = new FindDonationsByIdDonatorQuery
            {
                IdDonator = Guid.NewGuid() // Set your donator ID here
            };

            var donatorEntity = DonatorMock.GetDonatorWithDonations();

            donatorRepository.GetAllDonatiosByIdAsync(query.IdDonator)!.Returns(Task.FromResult(donatorEntity));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            // Add more specific assertions based on your implementation and expected behavior
        }

        [Fact]
        public async Task Handle_WhenDonatorDoesNotExist_ReturnsNull()
        {
            // Arrange
            var donatorRepository = Substitute.For<IDonatorRepository>();
            var handler = new FindDonationsByIdDonatorHandler(donatorRepository);

            var query = new FindDonationsByIdDonatorQuery
            {
                IdDonator = Guid.NewGuid() // Set your donator ID here
            };

            donatorRepository.GetAllDonatiosByIdAsync(query.IdDonator).Returns(Task.FromResult<Donator?>(null));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.Null(result.Donations);
            // Add more specific assertions based on your implementation and expected behavior
        }
    }
}
