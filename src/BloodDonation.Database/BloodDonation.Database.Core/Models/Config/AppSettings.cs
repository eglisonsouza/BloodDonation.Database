using System.Diagnostics.CodeAnalysis;

namespace BloodDonation.Database.Core.Models.Config
{

    [ExcludeFromCodeCoverage]
    public class AppSettings
    {
        public const string Position = "Settings";
        public ConnectionStrings? ConnectionStrings { get; set; }
        public RabbitMqSettings? RabbitMq { get; set; }
        public ExternalServices? ExternalServices { get; set; }
        public StockSettings? Stock { get; set; }
    }
}
