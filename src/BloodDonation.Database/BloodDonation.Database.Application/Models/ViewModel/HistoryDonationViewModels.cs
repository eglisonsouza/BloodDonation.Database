using BloodDonation.Database.Core.Models.Entities;

namespace BloodDonation.Database.Application.Models.ViewModel
{
    public class HistoryDonationViewModels
    {
        public DateTime DonationDate { get; set; }
        public int QuantityMl { get; set; }
        public HistoryDonatorViewModel? Donator { get; set; }

        public static List<HistoryDonationViewModels> FromEntity(List<Donation?> history)
        {
            return history.Select(FromEntity).ToList();
        }

        public static HistoryDonationViewModels FromEntity(Donation? donation)
        {
            return new HistoryDonationViewModels
            {
                DonationDate = donation!.DonationDate,
                QuantityMl = donation.QuantityMl,
                Donator = HistoryDonatorViewModel.FromEntity(donation.Donator)
            };
        }
    }
}
