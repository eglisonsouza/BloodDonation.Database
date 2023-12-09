using BloodDonation.Database.Core.Models.Config;
using BloodDonation.Database.Core.Models.DTOs;
using BloodDonation.Database.Core.Services;

namespace BloodDonation.Database.Infrastructure.Services.ZipCode
{
    public class ZipCodeService : IZipCodeSerivice
    {
        private readonly IHttpGetHandler _httpHandler;
        private readonly string UrlZipCodeServiceExternal;

        public ZipCodeService(IHttpGetHandler httpHandler, AppSettings appSettings)
        {
            _httpHandler = httpHandler;
            UrlZipCodeServiceExternal = appSettings.ExternalServices?.ViaCep!;
        }

        public async Task<ZipCodeDto> GetByZipCodeAsync(string zipCode)
        {
            return ZipCodeServiceAdapter.CreateAddress(await _httpHandler.GetAsync(string.Format(UrlZipCodeServiceExternal, zipCode)));
        }
    }
}
