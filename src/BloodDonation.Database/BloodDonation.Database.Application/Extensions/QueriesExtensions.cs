using BloodDonation.Database.Application.Query.ZipCodeEvent.FindByZipCode;
using BloodDonation.Database.Application.Query.ZipCodeEvent.Models;
using BloodDonation.Database.Core.Common.Events;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace BloodDonation.Database.Application.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class QueriesExtensions
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<FindByZipCodeQuery, ZipCodeViewModel>, FindByZipCodeHandler>();
            return services;
        }
    }
}
