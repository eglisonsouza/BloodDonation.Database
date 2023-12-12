using BloodDonation.Database.Core.Entities.Base;

namespace BloodDonation.Database.Core.Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Zone { get; set; }
        public Guid DonatorId { get; set; }
        public Donator? Donator { get; set; }
    }
}