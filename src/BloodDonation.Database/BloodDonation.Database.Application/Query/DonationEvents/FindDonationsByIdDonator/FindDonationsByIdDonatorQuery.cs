using System.ComponentModel.DataAnnotations;

namespace BloodDonation.Database.Application.Query.DonationEvents.FindDonationsByIdDonator
{
    public class FindDonationsByIdDonatorQuery
    {
        [Required(ErrorMessage = "IdDonator is required")]
        public Guid IdDonator { get; set; }
    }
}
