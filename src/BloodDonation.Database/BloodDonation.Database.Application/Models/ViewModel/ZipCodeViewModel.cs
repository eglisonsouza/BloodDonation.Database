using BloodDonation.Database.Core.Models.DTOs;

namespace BloodDonation.Database.Application.Models.ViewModel
{
    public class ZipCodeViewModel
    {
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Street { get; set; }
        public string? Zone { get; set; }

        public static ZipCodeViewModel FromDto(ZipCodeDto address)
        {
            return new ZipCodeViewModel
            {
                ZipCode = address.ZipCode,
                City = address.City,
                State = address.State,
                Street = address.Street,
                Zone = address.Zone
            };
        }
    }
}
