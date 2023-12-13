using BloodDonation.Database.Core.Models.Entities.Base;
using BloodDonation.Database.Core.Models.Enums;

namespace BloodDonation.Database.Core.Models.Entities
{
    public class BloodStock : BaseEntity
    {
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public int QuantityMl { get; set; }

        public BloodStock(BloodType bloodType, RhFactor rhFactor, int quantityMl) : base()
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            QuantityMl = quantityMl;
        }

        public void UpdateStock(int quantityMl)
        {
            base.Updated();
            QuantityMl += quantityMl;
        }
    }
}
