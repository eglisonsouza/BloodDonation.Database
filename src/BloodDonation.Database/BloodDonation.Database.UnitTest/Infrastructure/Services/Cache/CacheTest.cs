using Microsoft.Extensions.Caching.Memory;
using NSubstitute;

namespace BloodDonation.Database.UnitTest.Infrastructure.Services.Cache
{
    public class CacheTest
    {
        [Fact]
        public void Get_WithExistingKey_ShouldReturnCachedValue()
        {
            // Arrange
            var key = "testKey";
            var expectedValue = "testValue";

            var memoryCache = Substitute.For<IMemoryCache>();
            memoryCache.TryGetValue(key, out Arg.Any<string?>()).Returns(x =>
            {
                x[1] = expectedValue;
                return true;
            });

            var cache = new Database.Infrastructure.Services.Cache.Cache(memoryCache);

            // Act
            var result = cache.Get<string>(key, out var output);

            // Assert
            Assert.Equal(expectedValue, result);
            Assert.Equal(expectedValue, output);
        }

        [Fact]
        public void Get_WithNonExistingKey_ShouldReturnFalseValue()
        {
            // Arrange
            var key = "nonExistentKey";

            var memoryCache = Substitute.For<IMemoryCache>();
            memoryCache.TryGetValue(key, out Arg.Any<string?>()).Returns(false);

            var cache = new Database.Infrastructure.Services.Cache.Cache(memoryCache);

            // Act
            var result = cache.Get<string>(key, out _);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Set_ShouldCallMemoryCacheSetWithCorrectParameters()
        {
            // Arrange
            var key = "testKey";
            var value = "testValue";
            var timeToLive = TimeSpan.FromMinutes(15);

            var memoryCache = Substitute.For<IMemoryCache>();
            var cache = new Database.Infrastructure.Services.Cache.Cache(memoryCache);

            // Act
            cache.Set(key, value, timeToLive);

            // Assert
            memoryCache.Received(1).Set(key, value, timeToLive);
        }
    }
}
