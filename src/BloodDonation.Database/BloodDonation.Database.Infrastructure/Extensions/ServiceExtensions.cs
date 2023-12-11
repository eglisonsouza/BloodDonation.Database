using BloodDonation.Database.Core.Services;
using BloodDonation.Database.Infrastructure.Services.Cache;
using BloodDonation.Database.Infrastructure.Services.HttpRequest;
using BloodDonation.Database.Infrastructure.Services.ZipCode;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace BloodDonation.Database.Infrastructure.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServiceCollection(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<ICache, Cache>();
            services.AddScoped<IZipCodeServiceProxy, ZipCodeServiceProxy>();
            services.AddScoped<IZipCodeService, ZipCodeService>();
            services.AddScoped<IHttpGetHandler, HttpHandler>();
            return services;
        }
    }
}
