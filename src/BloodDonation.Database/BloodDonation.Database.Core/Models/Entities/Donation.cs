using BloodDonation.Database.Core.Models.Entities.Base;
using BloodDonation.Database.Core.Models.Enums;

namespace BloodDonation.Database.Core.Models.Entities
{
    public class Donation : BaseEntity
    {
        private const int IntervalMinimunMasculine = 90;
        private const int IntervalMinimunFeminine = 60;

        public Guid DonatorId { get; set; }
        public DateTime DonationDate { get; set; }
        public int QuantityMl { get; set; }
        public Donator? Donator { get; set; }

        private int LastDonation(DateTime nextDate) => nextDate.Subtract(DonationDate).Days;

        private bool LastDonationOutDate(DateTime donationDate) => LastDonation(donationDate) < GetDonationInterval();

        private int GetDonationInterval()
        {
            return Donator!.Gender.Equals(GenderType.Feminine) ? IntervalMinimunMasculine : IntervalMinimunFeminine;
        }

        public void ValidateInterval(DateTime donationDate)
        {
            if (LastDonationOutDate(donationDate))
                throw new Exception("Donator outside the minimum date range for donation");
        }
    }
}