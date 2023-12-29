using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BloodDonation.Database.Infrastructure.Extensions
{
    public static class ConsulExtensions
    {
        public static IServiceCollection AddConsulConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p =>
            new ConsulClient(consulConfig =>
            {
                var url = configuration.GetSection("Settings:Consul:Url");
                consulConfig.Address = new Uri(url.Value!);
            }));
            return services;
        }

        public static IApplicationBuilder UseConsul(this IApplicationBuilder app, IConfiguration configuration)
        {
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            var lifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();

            var registration = new AgentServiceRegistration()
            {
                ID = configuration.GetSection("Settings:ApiSettings:ID").Value,
                Name = configuration.GetSection("Settings:ApiSettings:Name").Value,
                Address = configuration.GetSection("Settings:ApiSettings:Address").Value,
                Port = int.Parse(configuration.GetSection("Settings:ApiSettings:Port").Value!),
                Tags = new[] { configuration.GetSection("Settings:ApiSettings:Tags").Value }
            };

            consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);

            lifetime.ApplicationStopping.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            });

            return app;
        }
    }
}
