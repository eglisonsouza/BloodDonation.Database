using BloodDonation.Database.Core.Services;
using Microsoft.Extensions.Caching.Memory;

namespace BloodDonation.Database.Infrastructure.Services.Cache
{
    public class Cache(IMemoryCache memoryCache) : ICache
    {
        private readonly IMemoryCache _memoryCache = memoryCache;

        public T Get<T>(string key, out T output)
        {
            _memoryCache.TryGetValue(key, out output!);
            return output!;
        }

        public void Set<T>(string key, T value, TimeSpan? timeToLive = null)
        {
            _memoryCache.Set(key, value, timeToLive ?? TimeSpan.FromMinutes(30));
        }
    }
}
