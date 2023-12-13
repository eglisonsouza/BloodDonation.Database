using BloodDonation.Database.Application.Models.InputModel;
using BloodDonation.Database.Core.Entities;
using BloodDonation.Database.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace BloodDonation.Database.Application.Commands.DonatorEvents.AddDonator
{
    public class AddDonatorCommand
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "BirthDate is required")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public GenderType Gender { get; set; }
        [Required(ErrorMessage = "Weight is required")]
        public double Weight { get; set; }
        [Required(ErrorMessage = "BloodType is required")]
        public BloodType BloodType { get; set; }
        [Required(ErrorMessage = "RhFactor is required")]
        public RhFactor RhFactor { get; set; }
        [Required(ErrorMessage = "Addresses is required")]
        public List<AddressInputModel>? Addresses { get; set; }

        public Donator ToEntity() => new(
                name: Name!,
                email: Email!,
                birthDate: BirthDate,
                gender: Gender,
                weight: Weight,
                bloodType: BloodType,
                rhFactor: RhFactor
            );
    }
}
