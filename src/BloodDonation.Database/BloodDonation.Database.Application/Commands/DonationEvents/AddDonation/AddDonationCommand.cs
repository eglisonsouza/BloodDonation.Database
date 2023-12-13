using BloodDonation.Database.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace BloodDonation.Database.Application.Commands.DonationEvents.AddDonation
{
    public class AddDonationCommand
    {
        [Required(ErrorMessage = "DonationId is required")]
        public Guid DonatorId { get; set; }

        [Required(ErrorMessage = "DonationDate is required")]
        public DateTime DonationDate { get; set; }

        [Required(ErrorMessage = "QuantityMl is required")]
        [Range(450, 470, ErrorMessage = "QuantityMl is not in range")]
        public int QuantityMl { get; set; }

        public Donation ToEntity()
        {
            return new Donation()
            {
                DonatorId = DonatorId,
                DonationDate = DonationDate,
                QuantityMl = QuantityMl
            };
        }
    }
}
