using BloodDonation.Database.Core.Models.DTOs;

namespace BloodDonation.Database.Core.Services
{
    public interface IZipCodeSerivice
    {
        Task<ZipCodeDto> GetByZipCodeAsync(string zipCode);
    }
}
