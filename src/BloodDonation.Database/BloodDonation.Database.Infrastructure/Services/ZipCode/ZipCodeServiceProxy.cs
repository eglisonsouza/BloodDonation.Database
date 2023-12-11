using BloodDonation.Database.Core.Models.DTOs;
using BloodDonation.Database.Core.Services;

namespace BloodDonation.Database.Infrastructure.Services.ZipCode
{
    public class ZipCodeServiceProxy(IZipCodeService zipCodeService, ICache cache) : IZipCodeServiceProxy
    {
        private readonly IZipCodeService _zipCodeService = zipCodeService;
        private readonly ICache _cache = cache;

        public async Task<ZipCodeDto> GetByZipCodeAsync(string zipCode)
        {
            var cache = _cache.Get($"zipCode_${zipCode}", out ZipCodeDto zipCodeDto);
            if (cache is null)
            {
                zipCodeDto = await _zipCodeService.GetByZipCodeAsync(zipCode);
                _cache.Set($"zipCode_${zipCode}", zipCodeDto);
            }

            return zipCodeDto!;
        }
    }
}
