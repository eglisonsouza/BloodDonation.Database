using System.Diagnostics.CodeAnalysis;

namespace BloodDonation.Database.Application.Models.ViewModel
{
    [ExcludeFromCodeCoverage]
    public class ErrorViewModel
    {
        public List<string> Errors { get; set; }

        public ErrorViewModel()
        {
            Errors = [];
        }
    }
}
