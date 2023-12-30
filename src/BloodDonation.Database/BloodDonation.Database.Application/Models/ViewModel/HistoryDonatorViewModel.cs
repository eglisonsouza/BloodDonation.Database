using BloodDonation.Database.Core.Models.Entities;
using BloodDonation.Database.Core.Models.Enums;

namespace BloodDonation.Database.Application.Models.ViewModel
{
    public class HistoryDonatorViewModel
    {
        public string? Name { get; set; }
        public GenderType? Gender { get; set; }
        public double Weight { get; set; }
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }

        public static HistoryDonatorViewModel FromEntity(Donator? donator)
        {
            return new HistoryDonatorViewModel
            {
                Name = donator!.Name,
                Gender = donator.Gender,
                Weight = donator.Weight,
                BloodType = donator.BloodType,
                RhFactor = donator.RhFactor,
            };
        }
    }
}