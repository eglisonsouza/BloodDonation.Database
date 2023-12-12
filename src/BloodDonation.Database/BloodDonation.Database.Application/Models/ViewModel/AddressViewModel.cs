using BloodDonation.Database.Core.Entities;

namespace BloodDonation.Database.Application.Models.ViewModel
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Zone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public static List<AddressViewModel>? FromEntity(List<Address> addresses)
        {
            return addresses.Select(a => FromEntity(a)).ToList();
        }

        public static AddressViewModel FromEntity(Address address)
        {
            return new AddressViewModel
            {
                Id = address.Id,
                Street = address.Street,
                Number = address.Number,
                City = address.City,
                ZipCode = address.ZipCode,
                Zone = address.Zone,
                CreatedAt = address.CreatedAt,
                UpdatedAt = address.UpdatedAt
            };
        }
    }
}
