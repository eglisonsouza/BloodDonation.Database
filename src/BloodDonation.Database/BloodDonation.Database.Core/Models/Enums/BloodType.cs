using System.ComponentModel;

namespace BloodDonation.Database.Core.Models.Enums
{
    public enum BloodType
    {
        [Description("A")]
        A,
        [Description("B")]
        B,
        [Description("AB")]
        AB,
        [Description("O")]
        O
    }
}
