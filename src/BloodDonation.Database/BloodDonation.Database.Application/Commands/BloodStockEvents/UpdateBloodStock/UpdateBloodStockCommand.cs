using BloodDonation.Database.Core.Models.Entities;
using BloodDonation.Database.Core.Models.Enums;

namespace BloodDonation.Database.Application.Commands.BloodStockEvents.UpdateBloodStock
{
    public class UpdateBloodStockCommand(BloodType bloodType, RhFactor rhFactor, int quantityMl)
    {
        public BloodType BloodType { get; set; } = bloodType;
        public RhFactor RhFactor { get; set; } = rhFactor;
        public int QuantityMl { get; set; } = quantityMl;

        public BloodStock ToEntity()
        {
            return new BloodStock(BloodType, RhFactor, QuantityMl);
        }
    }
}
