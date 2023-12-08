using BloodDonation.Database.Core.Entities.Base;
using BloodDonation.Database.Core.Enums;

namespace BloodDonation.Database.Core.Entities
{
    public class BloodStock : BaseEntity
    {
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public int QuantityMl { get; set; }
    }
}
