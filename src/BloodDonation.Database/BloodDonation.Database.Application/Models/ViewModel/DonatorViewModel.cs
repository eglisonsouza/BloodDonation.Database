using BloodDonation.Database.Core.Enums;

namespace BloodDonation.Database.Application.Models.ViewModel
{
    public class DonatorViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Gender { get; set; }
        public double Weight { get; set; }
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public List<AddressViewModel>? Addresses { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
