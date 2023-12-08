namespace BloodDonation.Database.Core.Models.Config
{
    public class AppSettings
    {
        public ConnectionStrings? ConnectionStrings { get; set; }
        public RabbitMqSettings? RabbitMq { get; set; }
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
