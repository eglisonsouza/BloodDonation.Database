using BloodDonation.Database.Core.Models.Entities;

namespace BloodDonation.Database.Application.Query.DonationEvents.Models
{
    public class DonatorWithDonationsViewModel
    {
        public string? NameDonator { get; set; }
        public string? Email { get; set; }
        public List<DonationsByDonatorViewModel>? Donations { get; set; }
    }

    public class DonationsByDonatorViewModel
    {
        public DateTime DonationDate { get; set; }
        public int QuantityMl { get; set; }

        public static DonatorWithDonationsViewModel FromEntity(Donator? donator)
        {
            return new DonatorWithDonationsViewModel
            {
                Email = donator?.Email ?? string.Empty,
                NameDonator = donator?.Name ?? string.Empty,
                Donations = donator?.Donations?.Select(x => new DonationsByDonatorViewModel
                {
                    DonationDate = x.DonationDate,
                    QuantityMl = x.QuantityMl
                }).ToList()
            };
        }
    }
}
