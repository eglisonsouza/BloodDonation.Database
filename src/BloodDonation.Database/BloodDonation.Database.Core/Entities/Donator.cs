using BloodDonation.Database.Core.Entities.Base;
using BloodDonation.Database.Core.Enums;

namespace BloodDonation.Database.Core.Entities
{
    public class Donator : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public double Weight { get; set; }
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public List<Donation>? Donations { get; set; }
        public List<Address>? Addresses { get; set; }

        public Donator(string name, string email, DateTime birthDate, string gender, double weight, BloodType bloodType, RhFactor rhFactor) : base()
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
        }

        public Donator()
        {
        }
    }
}
