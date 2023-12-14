using BloodDonation.Database.Application.Commands.BloodStockEvents.UpdateBloodStock;
using BloodDonation.Database.Core.Models.Entities;
using BloodDonation.Database.Core.Models.Enums;
using BloodDonation.Database.Core.Repositories;
using BloodDonation.Database.UnitTest.Mock.Entities;
using NSubstitute;

namespace BloodDonation.Database.UnitTest.Application.Commands.BloodStockEvents.UpdateBloodStock
{
    public class UpdateBloodStockHandlerTest
    {
        [Fact]
        public async Task UpdateBloodStockHandlerTest_UpdateStock_ReturnsBloodStockViewModel()
        {
            // Arrange
            var bloodStockRepositoryMock = Substitute.For<IBloodStockRepository>();
            var bloodStockMock = BloodStockMock.GetBloodStockMock();

            bloodStockRepositoryMock.GetByBloodTypeAndRhFactorAsync(BloodType.O, RhFactor.Negative).Returns(bloodStockMock);
            bloodStockRepositoryMock.AddAsync(Arg.Any<BloodStock>()).Returns(bloodStockMock);
            bloodStockRepositoryMock.Update(Arg.Any<BloodStock>()).Returns(bloodStockMock);

            var updateBloodStockCommand = new UpdateBloodStockCommand(BloodType.A, RhFactor.Positive, 1000);
            // Act
            var updateBloodStockHandler = new UpdateBloodStockHandler(bloodStockRepositoryMock);
            var result = await updateBloodStockHandler.Handle(updateBloodStockCommand);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(BloodType.A, result.BloodType);
            Assert.Equal(RhFactor.Positive, result.RhFactor);
            Assert.Equal(1000, result.QuantityMl);
        }

        [Fact]
        public async Task UpdateBloodStockHandlerTest_AddStock_ReturnsBloodStockViewModel()
        {
            // Arrange
            var bloodStockRepositoryMock = Substitute.For<IBloodStockRepository>();
            var bloodStockMock = BloodStockMock.GetBloodStockMock();

            bloodStockRepositoryMock.AddAsync(Arg.Any<BloodStock>()).Returns(bloodStockMock);
            bloodStockRepositoryMock.Update(Arg.Any<BloodStock>()).Returns(bloodStockMock);
            bloodStockRepositoryMock.GetByBloodTypeAndRhFactorAsync(BloodType.O, RhFactor.Negative).Returns(Task.FromResult(bloodStockMock));

            var updateBloodStockCommand = new UpdateBloodStockCommand(BloodType.A, RhFactor.Positive, 1000);
            // Act
            var updateBloodStockHandler = new UpdateBloodStockHandler(bloodStockRepositoryMock);
            var result = await updateBloodStockHandler.Handle(updateBloodStockCommand);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(BloodType.A, result.BloodType);
            Assert.Equal(RhFactor.Positive, result.RhFactor);
            Assert.Equal(1000, result.QuantityMl);
        }
    }
}
