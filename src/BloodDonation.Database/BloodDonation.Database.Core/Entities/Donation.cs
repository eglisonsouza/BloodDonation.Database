using BloodDonation.Database.Core.Entities.Base;

namespace BloodDonation.Database.Core.Entities
{
    public class Donation : BaseEntity
    {
        public Guid DonatorId { get; set; }
        public DateTime DonationDate { get; set; }
        public int QuantityMl { get; set; }
        public Donator Donator { get; set; }

    }
}