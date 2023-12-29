using System.Diagnostics.CodeAnalysis;

namespace BloodDonation.Database.Core.Models.Config
{
    [ExcludeFromCodeCoverage]
    public class RabbitMqSettings
    {
        public string? Uri { get; set; }
        public string? Host { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }
    }
}
