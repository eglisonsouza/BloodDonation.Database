using BloodDonation.Database.Core.Models.DTOs;

namespace BloodDonation.Database.Core.Services
{
    public interface IZipCodeService
    {
        Task<ZipCodeDto> GetByZipCodeAsync(string zipCode);
    }
}
