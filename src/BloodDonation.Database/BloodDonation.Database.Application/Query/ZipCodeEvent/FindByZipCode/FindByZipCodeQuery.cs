using System.ComponentModel.DataAnnotations;

namespace BloodDonation.Database.Application.Query.ZipCodeEvent.FindByZipCode
{
    public class FindByZipCodeQuery
    {
        [Required(ErrorMessage = "ZipCode is required")]
        [RegularExpression(@"^\d{5}\d{3}$", ErrorMessage = "ZipCode must be in the format 00000000")]
        public string? ZipCode { get; set; }
    }
}