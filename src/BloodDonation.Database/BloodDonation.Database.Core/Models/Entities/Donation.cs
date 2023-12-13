using BloodDonation.Database.Core.Models.Entities.Base;
using BloodDonation.Database.Core.Models.Enums;

namespace BloodDonation.Database.Core.Models.Entities
{
    public class Donation : BaseEntity
    {
        public Guid DonatorId { get; set; }
        public DateTime DonationDate { get; set; }
        public int QuantityMl { get; set; }
        public Donator? Donator { get; set; }

        public int LastDonation(DateTime nextDate)
        {
            return nextDate.Subtract(DonationDate).Days;
        }

        public int GetDonationInterval()
        {
            return Donator!.Gender.Equals(GenderType.Feminine) ? 90 : 60;
        }

        public static bool IsQuantityBloodRange(int quantityMl)
        {
            return quantityMl >= 450 && quantityMl <= 470;
        }
    }
}