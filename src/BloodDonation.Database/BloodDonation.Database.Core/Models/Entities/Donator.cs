using BloodDonation.Database.Core.Models.Entities.Base;
using BloodDonation.Database.Core.Models.Enums;

namespace BloodDonation.Database.Core.Models.Entities
{
    public class Donator : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderType Gender { get; set; }
        public double Weight { get; set; }
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public List<Donation>? Donations { get; set; }
        public List<Address>? Addresses { get; set; }

        public Donator(string name, string email, DateTime birthDate, GenderType gender, double weight, BloodType bloodType, RhFactor rhFactor) : base()
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
        }

        private int Age()
        {
            var age = DateTime.Now.Year - BirthDate.Year;

            if (DateTime.Now.DayOfYear < BirthDate.DayOfYear)
                age -= 1;

            return age;
        }

        public bool IsWeightOutsideMinimumFromDonation()
        {
            return Weight < 50;
        }

        public bool AgeOutsideMinimunFromDonation()
        {
            return Age() <= 18;
        }
    }
}
