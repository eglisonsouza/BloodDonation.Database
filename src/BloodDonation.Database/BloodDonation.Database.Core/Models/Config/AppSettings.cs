namespace BloodDonation.Database.Core.Models.Config
{
    public class AppSettings
    {
        public const string Position = "Settings";
        public ConnectionStrings? ConnectionStrings { get; set; }
        public RabbitMqSettings? RabbitMq { get; set; }
        public ExternalServices? ExternalServices { get; set; }
    }

    public class ExternalServices
    {
        public string? ViaCep { get; set; }
    }

    public class RabbitMqSettings
    {
        public string? Uri { get; set; }
        public string? Host { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }
    }

    public class ConnectionStrings
    {
        public string? SqlServerConnection { get; set; }
    }
}
