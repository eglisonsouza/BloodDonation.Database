using System.Diagnostics.CodeAnalysis;

namespace BloodDonation.Database.Core.Models.Config
{
    [ExcludeFromCodeCoverage]
    public class ConnectionStrings
    {
        public string? SqlServerConnection { get; set; }
    }
}
