using BloodDonation.Database.Core.Models.Entities;
using BloodDonation.Database.Core.Models.Enums;

namespace BloodDonation.Database.Application.Models.ViewModel
{
    public class BloodStockViewModel
    {
        public Guid Id { get; set; }
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public int QuantityMl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public static BloodStockViewModel FromEntity(BloodStock bloodStock)
        {
            return new BloodStockViewModel
            {
                Id = bloodStock.Id,
                BloodType = bloodStock.BloodType,
                RhFactor = bloodStock.RhFactor,
                QuantityMl = bloodStock.QuantityMl,
                CreatedAt = bloodStock.CreatedAt,
                UpdatedAt = bloodStock.UpdatedAt
            };
        }

        public static List<BloodStockViewModel> FromEntity(List<BloodStock> bloodStock)
        {
            return bloodStock.Select(FromEntity).ToList();
        }
    }
}
