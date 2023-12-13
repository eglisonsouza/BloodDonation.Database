using BloodDonation.Database.Core.Models.Entities;

namespace BloodDonation.Database.Application.Models.ViewModel
{
    public class DonationViewModel
    {
        public Guid DonatorId { get; set; }
        public DateTime DonationDate { get; set; }
        public int QuantityMl { get; set; }
        public BloodStockViewModel? BloodStock { get; set; }

        public static DonationViewModel FromEntity(Donation entity, BloodStockViewModel bloodStock)
        {
            return new DonationViewModel
            {
                DonatorId = entity.DonatorId,
                DonationDate = entity.DonationDate,
                QuantityMl = entity.QuantityMl,
                BloodStock = bloodStock
            };
        }
    }
}
